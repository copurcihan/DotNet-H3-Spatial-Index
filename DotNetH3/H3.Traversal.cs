using DotNetGeoJSON.Models;
using DotNetGeoJSON.Models.GeometryModels;
using DotNetH3.Models;
using DotNetH3.Utils;
using H3;
using H3.Algorithms;

namespace DotNetH3;

public static partial class H3
{
    public static GeoJSON? GridDiskDistances(string h3Index, int k)
    {
        try
        {
            var result = new H3Index(h3Index).GridDiskDistances(k).ToList();
            var geoJson = new GeoJSON();
            for (var i = 0; i < result.Count(); i++)
            {
                var properties = new CellIdentityDistance(result[i].Index.ToString(), result[i].Index.Resolution,
                    result[i].Distance);
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
    public static GeoJSON? GridRing(string h3Index, int k)
    {
        try
        {
            var result = new H3Index(h3Index).GridRing(k).ToList();
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
    public static int GridDistance(string h3Index, string h3OtherIndex)
    {
        try
        {
            return new H3Index(h3Index).GridDistance(new H3Index(h3OtherIndex));
        }
        catch (Exception)
        {
            // ignored
        }

        return -1;
    }
    public static GeoJSON? GridPathCell(string h3Index, string h3OtherIndex)
    {
        try
        {
            var result = new H3Index(h3Index).GridPathCells(new H3Index(h3OtherIndex)).ToList();
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