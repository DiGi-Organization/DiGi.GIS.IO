using DiGi.GIS.IO.Classes;
using DiGi.GIS.IO.Enums;
using DiGi.Geometry.Planar.Classes;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Streams building footprints from a Microsoft Global ML Building Footprints line-delimited GeoJSON file (plain or gzip) as an asynchronous sequence, returning each footprint in EPSG:4326.
        /// <para>gzip is detected from the file's magic bytes rather than its extension, so a renamed or mislabelled chunk still reads. The features carry no identifier of their own, so the source id is synthesized as <c>quadkey:index</c> over the zero-based feature index - a value that is stable for a given published chunk. The quadkey the chunk was fetched under becomes provenance together with any <c>capture</c> properties.</para>
        /// <para>Geometry is built from the JSON coordinates directly instead of through NetTopologySuite.IO.GeoJSON, keeping Newtonsoft out of every host that references this assembly.</para>
        /// </summary>
        /// <param name="path">The path of the GeoJSON sequence file, or null or whitespace to return null.</param>
        /// <param name="buildingDataset">The dataset the file holds; Microsoft.</param>
        /// <param name="quadkey">The quadkey the chunk was fetched under, required to synthesize source identifiers and provenance.</param>
        /// <param name="boundingBox">An optional bounding box, in EPSG:4326, that footprints must intersect.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The streaming sequence, or null when <paramref name="path"/> is null or whitespace.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="buildingDataset"/> is not Microsoft, or when <paramref name="quadkey"/> is null or whitespace.</exception>
        /// <exception cref="InvalidDataException">Thrown when a line is not a feature, carries an unsupported geometry type, or holds malformed coordinates.</exception>
        public static IAsyncEnumerable<Footprint>? Footprints_GeoJsonSequenceAsync(string? path, BuildingDataset buildingDataset, string quadkey, BoundingBox2D? boundingBox = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            if (buildingDataset != BuildingDataset.Microsoft)
            {
                throw new ArgumentException($"The line-delimited GeoJSON reader reads Microsoft; got {buildingDataset}.", nameof(buildingDataset));
            }

            if (string.IsNullOrWhiteSpace(quadkey))
            {
                throw new ArgumentException("A quadkey is required to identify Microsoft footprints.", nameof(quadkey));
            }

            return Footprints_GeoJsonSequence_Iterator(path!, buildingDataset, quadkey, boundingBox, cancellationToken);
        }

        /// <summary>
        /// Walks a line-delimited GeoJSON file line by line, yielding one <see cref="Footprint"/> per feature.
        /// </summary>
        /// <param name="path">The path of the GeoJSON sequence file.</param>
        /// <param name="buildingDataset">The dataset the file holds.</param>
        /// <param name="quadkey">The quadkey the chunk was fetched under.</param>
        /// <param name="boundingBox">An optional bounding box, in EPSG:4326.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The streaming sequence.</returns>
        private static async IAsyncEnumerable<Footprint> Footprints_GeoJsonSequence_Iterator(string path, BuildingDataset buildingDataset, string quadkey, BoundingBox2D? boundingBox, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            GeometryFactory geometryFactory = new();

            using FileStream fileStream = new(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] header = new byte[2];
            int headerCount = await fileStream.ReadAsync(header, 0, header.Length, cancellationToken);
            fileStream.Position = 0;
            bool gzip = headerCount == header.Length && header[0] == 0x1F && header[1] == 0x8B;

            using StreamReader streamReader = gzip
                ? new StreamReader(new GZipStream(fileStream, CompressionMode.Decompress, true), Encoding.UTF8)
                : new StreamReader(fileStream, Encoding.UTF8);

            long featureIndex = 0;
            string? line;
            while ((line = await streamReader.ReadLineAsync()) != null)
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                using JsonDocument jsonDocument = JsonDocument.Parse(line);
                JsonElement rootElement = jsonDocument.RootElement;

                JsonElement geometryElement = rootElement.TryGetProperty("geometry", out JsonElement geometryJsonElement) ? geometryJsonElement : rootElement;
                NetTopologySuite.Geometries.Geometry geometry = Geometry_Json(geometryElement, geometryFactory);

                JsonObject attributes;
                if (rootElement.TryGetProperty("properties", out JsonElement propertiesElement) && propertiesElement.ValueKind == JsonValueKind.Object)
                {
                    attributes = JsonNode.Parse(propertiesElement.GetRawText()) as JsonObject ?? new JsonObject();
                }
                else
                {
                    // Some published chunks carry the properties at the feature root rather than under "properties"; the geometry and the GeoJSON type marker are not attributes.
                    attributes = JsonNode.Parse(rootElement.GetRawText()) as JsonObject ?? new JsonObject();
                    attributes.Remove("geometry");
                    attributes.Remove("type");
                }

                if (boundingBox != null)
                {
                    Envelope envelope = geometry.EnvelopeInternal;
                    BoundingBox2D geometryBoundingBox = new(new Point2D(envelope.MinX, envelope.MinY), new Point2D(envelope.MaxX, envelope.MaxY));
                    if (!boundingBox.InRange(geometryBoundingBox))
                    {
                        featureIndex++;
                        continue;
                    }
                }

                string sourceId = string.Format(CultureInfo.InvariantCulture, "{0}:{1}", quadkey, featureIndex);

                yield return new Footprint(sourceId, 4326, DiGi.Geometry.Planar.Convert.ToDiGi(geometry), attributes, Provenance(buildingDataset, attributes, quadkey), null);

                featureIndex++;
            }
        }
    }
}
