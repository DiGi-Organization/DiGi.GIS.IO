using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Builds a NetTopologySuite geometry from a GeoJSON geometry element, so a line-delimited GeoJSON sequence can be read without pulling the Newtonsoft-based NetTopologySuite.IO.GeoJSON reader into every host that references this assembly.
        /// <para>Every geometry type the open building datasets use is supported; an unknown type or a malformed position fails loudly with the reason, because a silently dropped or silently reshaped geometry would surface much later as a wrong area.</para>
        /// </summary>
        /// <param name="geometryElement">The JSON element holding the geometry (its <c>type</c> and <c>coordinates</c>, or <c>geometries</c> for a collection).</param>
        /// <param name="geometryFactory">The factory used to create the geometry.</param>
        /// <returns>The geometry.</returns>
        /// <exception cref="InvalidDataException">Thrown when the element is not a geometry, carries an unsupported type, or holds malformed coordinates.</exception>
        private static NetTopologySuite.Geometries.Geometry Geometry_Json(JsonElement geometryElement, GeometryFactory geometryFactory)
        {
            static Coordinate? ToCoordinate(JsonElement pointElement)
            {
                if (pointElement.ValueKind != JsonValueKind.Array || pointElement.GetArrayLength() < 2)
                {
                    return null;
                }

                if (!pointElement[0].TryGetDouble(out double x) || !pointElement[1].TryGetDouble(out double y))
                {
                    return null;
                }

                if (pointElement.GetArrayLength() > 2 && pointElement[2].TryGetDouble(out double z))
                {
                    Coordinate coordinate = new(x, y);
                    coordinate.Z = z;
                    return coordinate;
                }

                return new Coordinate(x, y);
            }

            static Coordinate[] ToCoordinates(JsonElement arrayElement)
            {
                if (arrayElement.ValueKind != JsonValueKind.Array)
                {
                    throw new InvalidDataException("A GeoJSON coordinates member must be an array.");
                }

                List<Coordinate> coordinates = [];
                foreach (JsonElement element in arrayElement.EnumerateArray())
                {
                    Coordinate? coordinate = ToCoordinate(element);
                    if (coordinate == null)
                    {
                        throw new InvalidDataException("A GeoJSON position must be an array of at least two numbers.");
                    }

                    coordinates.Add(coordinate);
                }

                return [.. coordinates];
            }

            static Coordinate[] ToRing(JsonElement ringElement)
            {
                Coordinate[] coordinates = ToCoordinates(ringElement);
                if (coordinates.Length == 0)
                {
                    throw new InvalidDataException("A GeoJSON linear ring must not be empty.");
                }

                Coordinate first = coordinates[0];
                Coordinate last = coordinates[coordinates.Length - 1];
                if (first.X != last.X || first.Y != last.Y)
                {
                    // GeoJSON requires rings to be closed; a writer that left a ring open would otherwise be rejected by NetTopologySuite with no hint of which feature failed.
                    List<Coordinate> closed = [.. coordinates];
                    closed.Add(new Coordinate(first));
                    return [.. closed];
                }

                return coordinates;
            }

            static Polygon ToPolygon(GeometryFactory polygonGeometryFactory, JsonElement ringsElement)
            {
                if (ringsElement.ValueKind != JsonValueKind.Array || ringsElement.GetArrayLength() == 0)
                {
                    throw new InvalidDataException("A GeoJSON Polygon must carry at least one ring.");
                }

                LinearRing shell = polygonGeometryFactory.CreateLinearRing(ToRing(ringsElement[0]));
                LinearRing[] holes = new LinearRing[ringsElement.GetArrayLength() - 1];
                for (int i = 1; i < ringsElement.GetArrayLength(); i++)
                {
                    holes[i - 1] = polygonGeometryFactory.CreateLinearRing(ToRing(ringsElement[i]));
                }

                return polygonGeometryFactory.CreatePolygon(shell, holes);
            }

            if (geometryElement.ValueKind != JsonValueKind.Object)
            {
                throw new InvalidDataException("A GeoJSON geometry must be a JSON object.");
            }

            string? type = geometryElement.TryGetProperty("type", out JsonElement typeElement) && typeElement.ValueKind == JsonValueKind.String
                ? typeElement.GetString()
                : null;

            if (string.Equals(type, "GeometryCollection", StringComparison.Ordinal))
            {
                if (!geometryElement.TryGetProperty("geometries", out JsonElement geometriesElement) || geometriesElement.ValueKind != JsonValueKind.Array)
                {
                    throw new InvalidDataException("A GeoJSON GeometryCollection must carry a 'geometries' array.");
                }

                List<NetTopologySuite.Geometries.Geometry> geometries = [];
                foreach (JsonElement element in geometriesElement.EnumerateArray())
                {
                    geometries.Add(Geometry_Json(element, geometryFactory));
                }

                return geometryFactory.CreateGeometryCollection([.. geometries]);
            }

            if (!geometryElement.TryGetProperty("coordinates", out JsonElement coordinatesElement))
            {
                throw new InvalidDataException($"A GeoJSON geometry of type '{type ?? "<missing>"}' must carry a 'coordinates' array.");
            }

            switch (type)
            {
                case "Point":
                    {
                        Coordinate? coordinate = ToCoordinate(coordinatesElement);
                        if (coordinate == null)
                        {
                            throw new InvalidDataException("A GeoJSON Point position must be an array of at least two numbers.");
                        }

                        return geometryFactory.CreatePoint(coordinate);
                    }

                case "MultiPoint":
                    {
                        Coordinate[] coordinates = ToCoordinates(coordinatesElement);
                        return geometryFactory.CreateMultiPointFromCoords(coordinates);
                    }

                case "LineString":
                    {
                        Coordinate[] coordinates = ToCoordinates(coordinatesElement);
                        if (coordinates.Length < 2)
                        {
                            throw new InvalidDataException("A GeoJSON LineString must carry at least two positions.");
                        }

                        return geometryFactory.CreateLineString(coordinates);
                    }

                case "MultiLineString":
                    {
                        if (coordinatesElement.ValueKind != JsonValueKind.Array)
                        {
                            throw new InvalidDataException("A GeoJSON MultiLineString must carry an array of line coordinates.");
                        }

                        List<LineString> lineStrings = [];
                        foreach (JsonElement element in coordinatesElement.EnumerateArray())
                        {
                            Coordinate[] coordinates = ToCoordinates(element);
                            if (coordinates.Length < 2)
                            {
                                throw new InvalidDataException("Every GeoJSON LineString must carry at least two positions.");
                            }

                            lineStrings.Add(geometryFactory.CreateLineString(coordinates));
                        }

                        return geometryFactory.CreateMultiLineString([.. lineStrings]);
                    }

                case "Polygon":
                    return ToPolygon(geometryFactory, coordinatesElement);

                case "MultiPolygon":
                    {
                        if (coordinatesElement.ValueKind != JsonValueKind.Array)
                        {
                            throw new InvalidDataException("A GeoJSON MultiPolygon must carry an array of polygon coordinates.");
                        }

                        List<Polygon> polygons = [];
                        foreach (JsonElement element in coordinatesElement.EnumerateArray())
                        {
                            polygons.Add(ToPolygon(geometryFactory, element));
                        }

                        return geometryFactory.CreateMultiPolygon([.. polygons]);
                    }

                default:
                    throw new InvalidDataException($"Unsupported GeoJSON geometry type '{type ?? "<missing>"}'.");
            }
        }
    }
}
