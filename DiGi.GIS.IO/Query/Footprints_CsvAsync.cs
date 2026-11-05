using DiGi.Core.IO.DelimitedData;
using DiGi.Core.IO.DelimitedData.Classes;
using DiGi.GIS.IO.Classes;
using DiGi.GIS.IO.Enums;
using DiGi.Geometry.Planar.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;
using System.Threading;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Streams building footprints from a delimited CSV attribute table (GHS-OBAT) as an asynchronous sequence, returning each footprint in EPSG:4326.
        /// <para>The file is read line by line through <see cref="DelimitedDataReader"/> so a country table is never materialised, and every cell stays exactly the text the source published - inferring numbers would corrupt identifiers such as 32-hex GERS ids that happen to contain only digits. The geometry is a point built from the longitude and latitude columns (accepting <c>lon</c>/<c>latitude</c> and <c>lat</c>/<c>longitude</c> spellings), which is what lets <paramref name="boundingBox"/> filter before provenance is derived.</para>
        /// <para>A row whose value count disagrees with the header, or whose coordinates do not parse, fails loudly with its row index rather than silently shifting every following column.</para>
        /// </summary>
        /// <param name="path">The path of the CSV file, or null or whitespace to return null.</param>
        /// <param name="buildingDataset">The dataset the file holds; GhsObat.</param>
        /// <param name="boundingBox">An optional bounding box, in EPSG:4326, that footprints must intersect.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The streaming sequence, or null when <paramref name="path"/> is null or whitespace.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="buildingDataset"/> is not GhsObat.</exception>
        /// <exception cref="InvalidDataException">Thrown when the file is empty, lacks a longitude/latitude column pair, or holds a malformed row.</exception>
        public static IAsyncEnumerable<Footprint>? Footprints_CsvAsync(string? path, BuildingDataset buildingDataset, BoundingBox2D? boundingBox = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            if (buildingDataset != BuildingDataset.GhsObat)
            {
                throw new ArgumentException($"The CSV reader reads GhsObat; got {buildingDataset}.", nameof(buildingDataset));
            }

            return Footprints_Csv_Iterator(path!, buildingDataset, boundingBox, cancellationToken);
        }

        /// <summary>
        /// Walks a CSV attribute table row by row, yielding one <see cref="Footprint"/> per row.
        /// </summary>
        /// <param name="path">The path of the CSV file.</param>
        /// <param name="buildingDataset">The dataset the file holds.</param>
        /// <param name="boundingBox">An optional bounding box, in EPSG:4326.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The streaming sequence.</returns>
        private static async IAsyncEnumerable<Footprint> Footprints_Csv_Iterator(string path, BuildingDataset buildingDataset, BoundingBox2D? boundingBox, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            using DelimitedDataReader delimitedDataReader = new(',', path);

            string? headerLine = await delimitedDataReader.ReadLineAsync();
            if (headerLine == null)
            {
                throw new InvalidDataException($"File '{path}' is empty.");
            }

            List<string>? headers = headerLine.Values(',');
            if (headers == null || headers.Count == 0)
            {
                throw new InvalidDataException($"File '{path}' declares no header columns.");
            }

            int longitudeIndex = -1;
            int latitudeIndex = -1;
            for (int i = 0; i < headers.Count; i++)
            {
                string header = headers[i];
                if (longitudeIndex < 0 && (string.Equals(header, "lon", StringComparison.OrdinalIgnoreCase) || string.Equals(header, "longitude", StringComparison.OrdinalIgnoreCase)))
                {
                    longitudeIndex = i;
                }

                if (latitudeIndex < 0 && (string.Equals(header, "lat", StringComparison.OrdinalIgnoreCase) || string.Equals(header, "latitude", StringComparison.OrdinalIgnoreCase)))
                {
                    latitudeIndex = i;
                }
            }

            if (longitudeIndex < 0 || latitudeIndex < 0)
            {
                throw new InvalidDataException($"File '{path}' has no longitude/latitude column pair; expected 'lon' and 'lat'.");
            }

            Func<string> nextLine = () => delimitedDataReader.ReadLine()!;

            long rowIndex = 0;
            string? line;
            while ((line = await delimitedDataReader.ReadLineAsync()) != null)
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                List<string>? values = line.Values(',', nextLine);
                if (values == null || values.Count != headers.Count)
                {
                    throw new InvalidDataException($"Row {rowIndex} of '{path}' has {values?.Count ?? 0} values but the header declares {headers.Count} columns.");
                }

                if (!double.TryParse(values[longitudeIndex], NumberStyles.Float, CultureInfo.InvariantCulture, out double longitude)
                    || !double.TryParse(values[latitudeIndex], NumberStyles.Float, CultureInfo.InvariantCulture, out double latitude))
                {
                    throw new InvalidDataException($"Row {rowIndex} of '{path}' has a non-numeric longitude or latitude.");
                }

                Point2D point2D = new(longitude, latitude);

                if (boundingBox != null && !boundingBox.InRange(point2D))
                {
                    rowIndex++;
                    continue;
                }

                JsonObject attributes = new();
                for (int i = 0; i < headers.Count; i++)
                {
                    attributes[headers[i]] = JsonValue.Create(values[i]);
                }

                yield return new Footprint(SourceId(attributes), 4326, point2D, attributes, Provenance(buildingDataset, attributes, null), null);

                rowIndex++;
            }
        }
    }
}
