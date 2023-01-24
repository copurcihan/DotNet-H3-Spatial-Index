using DotNetH3.Models.Gis;
using H3;
using H3.Extensions;
using NetTopologySuite.Geometries;
using Point = DotNetGeoJSON.Models.GeometryModels.Point;
using Polygon = NetTopologySuite.Geometries.Polygon;

namespace DotNetH3.Utils;

public static class Utils
{
    public static List<Point> GetBoundaryPoints(this string h3Index)
    {
        var points = new List<Point>();
        try
        {
            var index = new H3Index(h3Index);
            var polygon = index.GetCellBoundary();
            for (var i = 0; i < polygon.Coordinates.Length; i++)
                points.Add(new Point(polygon.Coordinates[i].X, polygon.Coordinates[i].Y));
        }
        catch (Exception)
        {
            // ignored
        }

        return points;
    }

    public static List<Point> GetBoundaryPoints(this Polygon polygon)
    {
        var points = new List<Point>();
        try
        {
            for (var i = 0; i < polygon.Coordinates.Length; i++)
                points.Add(new Point(polygon.Coordinates[i].X, polygon.Coordinates[i].Y));
        }
        catch (Exception)
        {
            // ignored
        }

        return points;
    }

    public static int GetResolution(this string h3Index)
    {
        try
        {
            return new H3Index(h3Index).Resolution;
        }
        catch (Exception)
        {
            // ignored
        }

        return -1;
    }

    public static Polygon? GetPolygon(this List<LatLong> coordinates)
    {
        var points = new Coordinate[coordinates.Count];
        try
        {
            for (var i = 0; i < coordinates.Count; i++)
                points[i] = new Coordinate(coordinates[i].Longtitude, coordinates[i].Latitude);
            return new Polygon(new LinearRing(points));
        }
        catch (Exception)
        {
            // ignored
        }

        return null;
    }
}