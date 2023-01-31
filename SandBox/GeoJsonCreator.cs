using System;
using DotNetGeoJSON.Models;
using DotNetGeoJSON.Models.GeometryModels;
using DotNetH3.Models;

namespace SandBox
{
	public static class GeoJsonCreator
	{
		public static Feature? CreateExamplePointGeoJsonAsFeature()
		{
            var geoJson = new GeoJSON();

            var properties = new { name = "Empire State Building", address = "address" };

            var geometry = new Point(-73.9857, 40.7484);

            geoJson.features.Add(new Feature(geometry, properties));

            if (geoJson.IsValid())
                return geoJson.GetAsFeature();

            return null;
        }
        public static GeoJSON? CreateExamplePointGeoJsonAsFeatureList()
        {
            var geoJson = new GeoJSON();

            var properties = new { name = "Empire State Building", address = "address" };

            var geometry = new Point(-73.9857, 40.7484);

            geoJson.features.Add(new Feature(geometry, properties));

            if (geoJson.IsValid())
                return geoJson;

            return null;
        }
        public static Feature? CreateExampleLineStringGeoJsonAsFeature()
        {
            var geoJson = new GeoJSON();

            var properties = new { name = "Route from New York to Los Angeles", distance = "3000 km" };

            var points = new List<Point>();
            points.Add(new Point(-73.9857, 40.7484));
            points.Add(new Point(-118.243, 34.0522));

            var geometry = new LineStrings(points);

            geoJson.features.Add(new Feature(geometry, properties));

            if (geoJson.IsValid())
                return geoJson.GetAsFeature();

            return null;
        }
        public static Feature? CreateExamplePolygonGeoJsonAsFeature()
        {
            var geoJson = new GeoJSON();

            var properties = new { name = "Central Park", area = "341 ha" };

            //Outer Ring
            var points = new List<Point>();
            points.Add(new Point(-73.9726, 40.7896));
            points.Add(new Point(-73.9331, 40.7935));
            points.Add(new Point(-73.9287, 40.7696));
            points.Add(new Point(-73.9686, 40.7660));
            points.Add(new Point(-73.9726, 40.7896));

            var lineString = new LineStrings(points);

            var geometry = new Polygon(lineString);

            //Inner Ring
            points = new List<Point>();
            points.Add(new Point(-73.9648, 40.7740));
            points.Add(new Point(-73.9555, 40.7772));
            points.Add(new Point(-73.9535, 40.7712));
            points.Add(new Point(-73.9628, 40.7683));
            points.Add(new Point(-73.9648, 40.7740));

            lineString = new LineStrings(points);

            geometry.AddLinearRing(lineString);

            geoJson.features.Add(new Feature(geometry, properties));

            if (geoJson.IsValid())
                return geoJson.GetAsFeature();

            return null;
        }
        public static Feature? CreateExampleMultiPolygonGeoJsonAsFeature()
        {
            var geoJson = new GeoJSON();

            var properties = new { name = "MultiPolygon Example"};

            //First Polygon
            var points = new List<Point>();
            points.Add(new Point(-117.3325, 32.6354));
            points.Add(new Point(-117.3325, 32.5354));
            points.Add(new Point(-117.2325, 32.5354));
            points.Add(new Point(-117.2325, 32.6354));
            points.Add(new Point(-117.3325, 32.6354));

            var polygon = new Polygon(new LineStrings(points));

            var geometry = new MultiPolygon(polygon);

            //Second Polygon
            points = new List<Point>();
            points.Add(new Point(-118.3325, 33.6354));
            points.Add(new Point(-118.3325, 33.5354));
            points.Add(new Point(-118.2325, 33.5354));
            points.Add(new Point(-118.2325, 33.6354));
            points.Add(new Point(-118.3325, 33.6354));

            polygon = new Polygon(new LineStrings(points));

            geometry.AddPolygon(polygon);

            geoJson.features.Add(new Feature(geometry, properties));

            if (geoJson.IsValid())
                return geoJson.GetAsFeature();

            return null;
        }
    }
}

