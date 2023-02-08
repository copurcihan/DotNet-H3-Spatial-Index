<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://cihancopur.com/">
    <img src="https://cihancopur.com/img/logo.svg" alt="Logo" width="80" height="80">
  </a>
  <h3 align="center">DotNet-H3-Spatial-Index</h3>
  <p align="center">
    A class library developed with DotNet 7 that provides lightweight H3 Spatial Index functions and generally renders them as usable GeoJSON objects.
  </p>
</div>

## :sassy_man: To Request Feature or Contribute [cihancopur.com](https://cihancopur.com/en/) [info@cihancopur.com](https://emailto:info@cihancopur.com/)

## ❓[What Is H3 Geospatial H3 Index][h3-index]
ℹ️ H3 is a hierarchical spatial indexing system that can be used to efficiently index and query points in space.<br/><br/>
ℹ️ It uses a hexagonal grid to divide the Earth's surface into a series of nested cells, each with a unique index.<br/><br/>
ℹ️ This allows for efficient spatial queries, such as finding all points within a certain radius of a given point, or all points within a specific hexagonal cell.<br/><br/>
ℹ️ [You should analyze Tables of Cell Statistics to understand easily H3 Spatial Index Concept][cell-stats]

## ❓ Where To Use H3 Spatial Index?
ℹ️ Geospatial analysis and mapping<br/><br/>
ℹ️ Location-based services and searches<br/><br/>
ℹ️ Route planning and optimization<br/><br/>
ℹ️ Real-time tracking and monitoring<br/><br/>
ℹ️ Resource allocation and management<br/><br/>
ℹ️ Customer segmentation and targeting

One of the most common use cases of H3 spatial indexing is in location-based services, where it can be used to quickly identify the nearest points of interest (e.g. restaurants, shops, etc.) to a user's current location. In addition, it can be used in transportation planning and logistics to optimize routes for delivery trucks and other vehicles.


## ❓ Why Using the H3 Spatial Index is Important?
ℹ️ **Efficient spatial queries:** Because H3 divides the Earth's surface into a hierarchical grid, it can quickly identify which cells of the grid a point falls within, making spatial queries much faster than with other indexing systems.<br/><br/>
ℹ️ **Flexible spatial resolution:** The resolution of the grid can be adjusted to match the requirements of the application. For example, a higher resolution can be used for small areas while a lower resolution can be used for larger areas.<br/><br/>
ℹ️ **Compact storage:** The index of a cell takes up just a few bytes, making it well-suited for applications that need to store large amounts of data.

## ❓ How Can We Use H3 Spatial Index For The Micro Mobility Industry?
ℹ️ H3 could be used to index and query data on the location of scooters, bicycles, or other forms of micro mobility.<br/><br/>
ℹ️ This could be used to help optimize routing and dispatching of vehicles, as well as to better understand patterns of usage and demand. <br/><br/>
ℹ️ Additionally, H3 could be used to generate heatmaps of usage, or to perform spatial analytics on micro mobility data. <br/><br/>
ℹ️ H3 is a powerful and flexible spatial indexing library that can be useful in a wide range of applications, including the micromobility industry.<br/><br/>
ℹ️ It can help companies optimize their operations, better understand usage patterns, and make data-driven decisions. <br/><br/>
ℹ️ It's an open-source library, which means it can be easily integrated into existing systems and can be customized to meet specific needs.<br/><br/>
ℹ️ It's worth noting that, its use is not limited to micromobility industry and it can be used in other industry as well such as logistics, urban planning, and real-estate. <br/><br/>
![N|Solid][aggregation]
- This property allows for simpler analysis of movement. Hexagons have the property of expanding rings of neighbors approximating circles:
![N|Solid][hexagon]
- Hexagons are also optimally space-filling. On average, a polygon may be filled with hexagon tiles with a smaller margin of error than would be present with square tiles.
# 📑 API Reference

## 🔖 Indexing
These functions are used for finding the H3 cell index containing coordinates, and for finding the center and boundary of H3 indexes.

### ⚓ LatLongToCell
- Indexes the location at the specified resolution, returning the index of the cell containing the location. This buckets the geographic point into the H3 grid.
- **int resolution:** 0 to 15, H3 supports sixteen resolutions. Each finer resolution has cells with one seventh the area of the coarser resolution. Hexagons cannot be perfectly subdivided into seven hexagons, so the finer cells are only approximately contained within a parent cell.
```
string LatLongToCell(double latitude, double longtitude, int resolution)
```
**Sample Usage**
```
var h3Index = DotNetH3.H3.LatLongToCell(41.02652937773024, 29.12017270259408, 9);

//Returned value: h3Index="891ec915c07ffff";
```
**Output**
![N|Solid][binbin-hq]

### ⚓ CellToLatLong
- Finds the center of the cell in grid space.

```
LatLong CellToLatLong(string h3Index)
```
**Sample Usage**
```
var latLong = DotNetH3.H3.CellToLatLong("891ec915c07ffff");
```
### ⚓ CellToBoundaryAsGeoJson
- Finds the boundary of the cell and return as GeoJSON Polygon.

```
GeoJSON? CellToBoundaryAsGeoJson(string h3Index)
```
**Sample Usage**
```
var polygon = DotNetH3.H3.CellToBoundaryAsGeoJson("891ec915c07ffff");
```
**Output**
![N|Solid][binbin-hq-geojson]

## 🔖 Inspection
These functions provide metadata about an H3 index, such as its resolution or base cell, and provide utilities for converting into and out of the 64-bit representation of an H3 index.

### ⚓ GetResolution
- Returns the resolution of the index.
```
int GetResolution(string h3Index)
```
**Sample Usage**
```
var resolution = DotNetH3.H3.GetResolution("891ec915c07ffff");

//Returned value: resolution=9;
```
### ⚓ GetBaseCellNumber
- Returns the base cell number of the index.
- One of the 122 H3 cells (110 hexagons and 12 pentagons) of resolution 0.
- Every other cell in H3 is a child of a base cell.
- Each base cell has a "base cell number" (0--121), which is encoded into the H3Index representation of every H3 cell.
```
int GetBaseCellNumber(string h3Index)
```
**Sample Usage**
```
var baseCellNumber= DotNetH3.H3.GetBaseCellNumber("891ec915c07ffff");

//Returned value: baseCellNumber=15;
```
### ⚓ StringToH3
- Converts the string representation to H3Index.
```
H3Index? StringToH3(string h3Index)
```
**Sample Usage**
```
var h3IndexObject= DotNetH3.H3.StringToH3("891ec915c07ffff");
```
### ⚓ H3ToString
- Converts the H3Index representation of the index to the string representation.
```
string H3ToString(H3Index h3Index)
```
**Sample Usage**
```
var h3Index= DotNetH3.H3.H3ToString(h3IndexObject);

//Returned value: h3Index="891ec915c07ffff";
```
### ⚓ IsValidCell
- Validates cell.
```
bool IsValidCell(string h3Index)
```
**Sample Usage**
```
var isValid= DotNetH3.H3.IsValidCell("891ec915c07ffff");

//Returned value: isValid=true;
```
### ⚓ IsPentagon
- Checks the cell whether pentagon or hexagon.
```
bool IsPentagon(string h3Index)
```
**Sample Usage**
```
var isPentagon= DotNetH3.H3.IsPentagon("891ec915c07ffff");

//Returned value: isValid=false;
```
### ⚓ GetIcosahedronFaces
- Find all icosahedron faces intersected by a given H3 index and places them in the array out.

- Faces are represented as integers from 0-19, inclusive. The array is sparse, and empty (no intersection) array values are represented by -1.
```
int[] GetIcosahedronFaces(string h3Index)
```
**Sample Usage**
```
var faces= DotNetH3.H3.GetIcosahedronFaces("891ec915c07ffff");
```
## 🔖 Traversal
Grid traversal allows finding cells in the vicinity of an origin cell, and determining how to traverse the grid from one cell to another.

### ⚓ GridDiskDistances
- gridDisk produces indices within k distance of the origin index.

- gridDisk was previously named k-ring after the concept of a ring with distance **k**. **k-ring** 0 is defined as the origin index, **k-ring 1** is defined as k-ring 0 and all neighboring indices, and so on.

- Output is placed in the provided array in no particular order. Elements of the output array may be left as zero, which can happen when crossing a pentagon.

```
GeoJSON? GridDiskDistances(string h3Index, int k)
```
**Sample Usage**
```
var geoJSON = DotNetH3.H3.GridDiskDistances("891ec915c07ffff",2);
```
**Output**
![N|Solid][grid-disk-distances]

### ⚓ GridRing
- Produces the hollow hexagonal ring centered at origin with sides of length k.
```
GeoJSON? GridRing(string h3Index, int k)
```
**Sample Usage**
```
var geoJSON = DotNetH3.H3.GridRing("891ec915c07ffff",2);
```
**Output**
![N|Solid][grid-ring]

### ⚓ GridDistance
- Provides the distance in grid cells between the two indexes.
```
int GridDistance(string h3Index, string h3OtherIndex)
```
**Sample Usage**
```
var distance= DotNetH3.H3.GridDistance("891ec915c1bffff","891ec915c37ffff");

//Returned value: distance=4;
```
### ⚓ GridPathCell
- Given two H3 indexes, return the line of indexes between them (inclusive).
- This function may fail to find the line between two indexes, for example if they are very far apart. It may also fail when finding distances for indexes on opposite sides of a pentagon.
```
GeoJSON? GridPathCell(string h3Index, string h3OtherIndex)
```
**Sample Usage**
```
var geoJSON = DotNetH3.H3.GridPathCell("891ec915c1bffff","891ec915c37ffff")
```
**Output**
![N|Solid][grid-path-cell]

## 🔖 Hierarchical
These functions permit moving between resolutions in the H3 grid system. The functions produce parent cells (coarser), or child cells (finer).

### ⚓ CellToParent
- Provides the parent (coarser) index containing cell.
```
Feature? CellToParent(string h3Index, int resolution)
```
**Sample Usage**
```
var parent = DotNetH3.H3.CellToParent("891ec915c07ffff",7);
```
**Output**
![N|Solid][parent]

### ⚓ CellToCenterChild
- Provides the center child (finer) index contained by cell at resolution.
```
Feature? CellToCenterChild(string h3Index, int resolution)
```
**Sample Usage**
```
var centerChild = DotNetH3.H3.CellToCenterChild("891ec915c07ffff",9)
```
**Output**
![N|Solid][center-child]

### ⚓ CellToChildren
- Populates children with the indexes contained by cell at resolution. 
```
GeoJSON? CellToChildren(string h3Index, int resolution)
```
**Sample Usage**
```
var childrenCells=DotNetH3.H3.CellToChildren("891ec915c07ffff",10);
```
**Output**
![N|Solid][children]

## 🔖 Region
Convert H3 indexes to and from polygonal areas.

### ⚓ PolygonToCells
- Takes a given coordinate list of polygon preallocated, zeroed memory, and fills it with the hexagons that are contained by the polygon.
```
GeoJSON? PolygonToCells(List<LatLong> coordinates, int resolution, int vertexMode)
```
**Sample Usage**
```
var feature=DotNetH3.H3.CellToParent("891ec915c07ffff",7);
List<LatLong> coordinates = new List<LatLong>();
for (int i = 0; i < ((Polygon)(feature.geometry)).coordinates[0].Count; i++)
{
    coordinates.Add(new LatLong(((Polygon)(feature.geometry)).coordinates[0][i][1],
        ((Polygon)(feature.geometry)).coordinates[0][i][0]));
}
//The code above was written to create a sample polygon coordinate list.

var region=JsonSerializer.Serialize(DotNetH3.H3.PolygonToCells(coordinates,9,vertexMode:0));
```
**Output: vertexMode:0**
![N|Solid][polygon-to-hexagon-0]
**Output: vertexMode:1**
![N|Solid][polygon-to-hexagon-1]
**Output: vertexMode:2**
![N|Solid][polygon-to-hexagon-2]

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

## Useful Links
You can find the useful links regarding GeoJSON
* [H3 Spatial Index Official Web Site][h3-index]
* [The GeoJSON Format][rfc-page]
* [geojson.io Free GeoJSON Viewer][geojson-io]

## Changelog

| Version | Date | Changes |
| ------- | ---- | ------ |
| v1.0.0  | Feb 8, 2023 | - First version is ready.|
  

<!-- MARKDOWN LINKS & IMAGES -->
[geojson-io]: https://geojson.io/
[rfc-page]: https://www.rfc-editor.org/rfc/rfc7946  
[h3-index]: https://h3geo.org/ 
[aggregation]: https://raw.githubusercontent.com/copurcihan/DotNet-H3-Spatial-Index/main/Files/Img/Aggregation.png 
[hexagon]: https://h3geo.org/images/neighbors.png
[cell-stats]: https://h3geo.org/docs/core-library/restable
[h3-viewer]: https://wolf-h3-viewer.glitch.me/
[binbin-hq]: https://github.com/copurcihan/DotNet-H3-Spatial-Index/blob/main/Files/Img/BinBinHeadquarter.png?raw=true
[binbin-hq-geojson]: https://github.com/copurcihan/DotNet-H3-Spatial-Index/blob/main/Files/Img/PolygonH3.png?raw=true
[grid-disk-distances]: https://github.com/copurcihan/DotNet-H3-Spatial-Index/blob/main/Files/Img/GridDiskDistances.png?raw=true
[grid-ring]: https://github.com/copurcihan/DotNet-H3-Spatial-Index/blob/main/Files/Img/GridRing.png?raw=true
[grid-path-cell]: https://github.com/copurcihan/DotNet-H3-Spatial-Index/blob/main/Files/Img/GridPathCell.png?raw=true
[parent]: https://github.com/copurcihan/DotNet-H3-Spatial-Index/blob/main/Files/Img/Parent.png?raw=true
[center-child]: https://github.com/copurcihan/DotNet-H3-Spatial-Index/blob/main/Files/Img/CenterChild.png?raw=true
[children]: https://github.com/copurcihan/DotNet-H3-Spatial-Index/blob/main/Files/Img/Children.png?raw=true
[polygon-to-hexagon-0]: https://github.com/copurcihan/DotNet-H3-Spatial-Index/blob/main/Files/Img/polygonToHexagon_0.png?raw=true
[polygon-to-hexagon-1]: https://github.com/copurcihan/DotNet-H3-Spatial-Index/blob/main/Files/Img/polygonToHexagon_1.png?raw=true
[polygon-to-hexagon-2]: https://github.com/copurcihan/DotNet-H3-Spatial-Index/blob/main/Files/Img/polygonToHexagon_2.png?raw=true
