using DotNetGeoJSON.Models;
using DotNetGeoJSON.Models.GeometryModels;
using DotNetH3.Models;
using DotNetH3.Models.Gis;
using DotNetH3.Utils;
using H3.Algorithms;

namespace DotNetH3;

public static partial class H3
{
    public static GeoJSON? PolygonToCells(List<LatLong> coordinates, int resolution, int vertexMode)
    {
        try
        {
            var polygon = coordinates.GetPolygon();
            if (polygon != null)
            {
                var result = polygon.Fill(resolution, (VertexTestMode)vertexMode).ToList();
                var geoJson = new GeoJSON();

                var geometry = new Polygon(new LineStrings(polygon.GetBoundaryPoints()));
                geoJson.features.Add(new Feature(geometry, null));

                for (var i = 0; i < result.Count; i++)
                {
                    var properties = new CellIdentity(result[i].ToString(), result[i].Resolution);
                    geometry = new Polygon(new LineStrings(properties.Index.GetBoundaryPoints()));
                    geoJson.features.Add(new Feature(geometry, properties));
                }

                if (geoJson.IsValid())
                    return geoJson;
            }
        }
        catch (Exception)
        {
            // ignored
        }

        return null;
    }
}