// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text.Json;
using DotNetGeoJSON.Models;
using DotNetGeoJSON.Models.GeometryModels;
using DotNetH3;
using DotNetH3.Models.Gis;
using SandBox;

var pointGeoJsonAsFeature= JsonSerializer.Serialize(GeoJsonCreator.CreateExamplePointGeoJsonAsFeature());
var pointGeoJsonAsFeatureList = JsonSerializer.Serialize(GeoJsonCreator.CreateExamplePointGeoJsonAsFeatureList());
var lineStringGeoJsonAsFeature = JsonSerializer.Serialize(GeoJsonCreator.CreateExampleLineStringGeoJsonAsFeature());
var polygonGeoJsonAsFeature = JsonSerializer.Serialize(GeoJsonCreator.CreateExamplePolygonGeoJsonAsFeature());
var multiPolygonGeoJsonAsFeature = JsonSerializer.Serialize(GeoJsonCreator.CreateExampleMultiPolygonGeoJsonAsFeature());

var h3Index = DotNetH3.H3.LatLongToCell(41.02652937773024, 29.12017270259408, 9);

var latLong = DotNetH3.H3.CellToLatLong("891ec915c07ffff");

var polygon = JsonSerializer.Serialize(DotNetH3.H3.CellToBoundaryAsGeoJson("891ec915c07ffff"));

var resolution = DotNetH3.H3.GetResolution("891ec915c07ffff");

var baseCellNumber= DotNetH3.H3.GetBaseCellNumber("891ec915c07ffff");

var h3IndexObject= DotNetH3.H3.StringToH3("891ec915c07ffff");

h3Index= DotNetH3.H3.H3ToString(h3IndexObject);

var isValid= DotNetH3.H3.IsValidCell("891ec915c07ffff");

var isPentagon= DotNetH3.H3.IsPentagon("891ec915c07ffff");

var faces= DotNetH3.H3.GetIcosahedronFaces("891ec915c07ffff");

var cells = JsonSerializer.Serialize(DotNetH3.H3.GridDiskDistances("891ec915c07ffff",2));

cells = JsonSerializer.Serialize(DotNetH3.H3.GridRing("891ec915c07ffff",2));












string a=DotNetH3.H3.LatLongToCell(37.0326897,30.6217852,6);
Console.WriteLine("H3 Index: "+a);
LatLong result = DotNetH3.H3.CellToLatLong(a);
Console.WriteLine("X: "+result.Longtitude+ " Y:"+result.Latitude);
var temp = DotNetH3.H3.CellToBoundaryAsGeoJson(a);
string jsonString = JsonSerializer.Serialize(temp);
Console.WriteLine("OKEY");
var resultt=DotNetH3.H3.GridDiskDistances(a,2);
jsonString = JsonSerializer.Serialize(resultt);
resultt=DotNetH3.H3.GridRing(a,2);
jsonString = JsonSerializer.Serialize(resultt);
var distance=DotNetH3.H3.GridDistance("863f6eaf7ffffff","863f6ead7ffffff");
var path=DotNetH3.H3.GridPathCell("863f6eaf7ffffff","863f6ea4fffffff");
jsonString = JsonSerializer.Serialize(path);
var feature=DotNetH3.H3.CellToParent("863f6eaf7ffffff",3);
jsonString = JsonSerializer.Serialize(feature);
var featuree=DotNetH3.H3.CellToCenterChild("863f6eaf7ffffff",9);
jsonString = JsonSerializer.Serialize(featuree);
var children=DotNetH3.H3.CellToChildren("863f6eaf7ffffff",7);
jsonString = JsonSerializer.Serialize(children);


List<LatLong> coordinates = new List<LatLong>();
for (int i = 0; i < ((Polygon)(feature.geometry)).coordinates[0].Count; i++)
{
    coordinates.Add(new LatLong(((Polygon)(feature.geometry)).coordinates[0][i][1],
        ((Polygon)(feature.geometry)).coordinates[0][i][0]));
}
var region=DotNetH3.H3.PolygonToCells(coordinates,6,vertexTestMode:2);
jsonString = JsonSerializer.Serialize(region);
Console.WriteLine("OKEY");