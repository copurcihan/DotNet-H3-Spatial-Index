using DotNetGeoJSON.Models;
using DotNetGeoJSON.Models.GeometryModels;
using DotNetH3.Models;
using DotNetH3.Utils;
using H3;
using H3.Extensions;

namespace DotNetH3;

public static partial class H3
{
    public static Feature? CellToParent(string h3Index, int resolution)
    {
        try
        {
            var result = new H3Index(h3Index).GetParentForResolution(resolution);
            var geoJson = new GeoJSON();
            var properties = new CellIdentity(result.ToString(), result.Resolution);
            var geometry = new Polygon(new LineStrings(properties.Index.GetBoundaryPoints()));
            geoJson.features.Add(new Feature(geometry, properties));
            if (geoJson.IsValid())
                return geoJson.GetAsFeature();
        }
        catch (Exception)
        {
            // ignored
        }

        return null;
    }

    public static Feature? CellToCenterChild(string h3Index, int resolution)
    {
        try
        {
            var result = new H3Index(h3Index).GetChildCenterForResolution(resolution);
            var geoJson = new GeoJSON();
            var properties = new CellIdentity(result.ToString(), result.Resolution);
            var geometry = new Polygon(new LineStrings(properties.Index.GetBoundaryPoints()));
            geoJson.features.Add(new Feature(geometry, properties));
            if (geoJson.IsValid())
                return geoJson.GetAsFeature();
        }
        catch (Exception)
        {
            // ignored
        }

        return null;
    }

    public static GeoJSON? CellToChildren(string h3Index, int resolution)
    {
        try
        {
            var result = new H3Index(h3Index).GetChildrenForResolution(resolution).ToList();
            var geoJson = new GeoJSON();
            for (var i = 0; i < result.Count(); i++)
            {
                var properties = new CellIdentity(result[i].ToString(), result[i].Resolution);
                var geometry = new Polygon(new LineStrings(properties.Index.GetBoundaryPoints()));
                geoJson.features.Add(new Feature(geometry, properties));
            }

            if (geoJson.IsValid())
                return geoJson;
        }
        catch (Exception)
        {
            // ignored
        }

        return null;
    }
}