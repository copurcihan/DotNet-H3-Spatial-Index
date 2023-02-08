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

var distance= DotNetH3.H3.GridDistance("891ec915c1bffff","891ec915c37ffff");

cells = JsonSerializer.Serialize(DotNetH3.H3.GridPathCell("891ec915c1bffff","891ec915c37ffff"));

var parent=JsonSerializer.Serialize(DotNetH3.H3.CellToParent("891ec915c07ffff",7));

var centerChild=JsonSerializer.Serialize(DotNetH3.H3.CellToCenterChild("891ec915c07ffff",9));

var childrenCells=JsonSerializer.Serialize(DotNetH3.H3.CellToChildren("891ec915c07ffff",10));


var feature=DotNetH3.H3.CellToParent("891ec915c07ffff",7);
List<LatLong> coordinates = new List<LatLong>();
for (int i = 0; i < ((Polygon)(feature.geometry)).coordinates[0].Count; i++)
{
    coordinates.Add(new LatLong(((Polygon)(feature.geometry)).coordinates[0][i][1],
        ((Polygon)(feature.geometry)).coordinates[0][i][0]));
}
var region=JsonSerializer.Serialize(DotNetH3.H3.PolygonToCells(coordinates,9,vertexMode:0));