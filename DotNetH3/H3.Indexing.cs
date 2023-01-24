using DotNetGeoJSON.Models;
using DotNetGeoJSON.Models.GeometryModels;
using DotNetH3.Models;
using DotNetH3.Models.Gis;
using DotNetH3.Utils;
using H3;
using H3.Extensions;
using NetTopologySuite.Geometries;
using Polygon = DotNetGeoJSON.Models.GeometryModels.Polygon;

namespace DotNetH3;

public static partial class H3
{
    public static string LatLongToCell(double latitude, double longtitude, int resolution)
    {
        if (resolution < 0 || resolution > 15)
            return "Wrong Parameter: resolution should be min=0 max=15";

        var coordinate = new Coordinate(longtitude, latitude);
        var index = coordinate.ToH3Index(resolution);
        return index.ToString();
    }

    public static LatLong CellToLatLong(string h3Index)
    {
        if (string.IsNullOrEmpty(h3Index))
            return new LatLong(0, 0);
        try
        {
            var index = new H3Index(h3Index);
            var latLng = index.ToLatLng();
            return new LatLong(latLng.LatitudeDegrees, latLng.LongitudeDegrees);
        }
        catch
        {
            return new LatLong(0, 0);
        }
    }

    public static GeoJSON? CellToBoundaryAsGeoJson(string h3Index)
    {
        if (string.IsNullOrEmpty(h3Index))
            return null;
        try
        {
            var geoJson = new GeoJSON();
            var properties = new CellIdentity(h3Index, h3Index.GetResolution());
            var geometry = new Polygon(new LineStrings(h3Index.GetBoundaryPoints()));
            geoJson.features.Add(new Feature(geometry, properties));
            if (geoJson.IsValid())
                return geoJson;
            return null;
        }
        catch
        {
            return null;
        }
    }
}