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
ℹ️ This allows for efficient spatial queries, such as finding all points within a certain radius of a given point, or all points within a specific hexagonal cell.

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

## ❓ Does GeoJSON Support Styling?
ℹ️ GeoJSON does not have any in-built styling, if you want to style the features in a GeoJSON file, you have to do it separately, most web mapping libraries have built-in methods for styling GeoJSON data, or you can use third-party libraries like turf.js to manipulate and style the data.

## ❓ Where Can I Store GeoJSON Data?
There are several options for storing GeoJSON data, depending on your specific use case and requirements. Some popular options include:<br/><br/>

ℹ️ **NoSQL Database:** You can store the GeoJSON data in a NoSQL database, such as MongoDB or Couchbase. This option provides high scalability and performance for handling large amounts of data, and it also allows for flexible schema design and easy integration with other data sources.<br/><br/>
ℹ️ **File System:** You can simply store the GeoJSON data as a file on your local file system or on a remote server. This is a simple and straightforward option, but it may not be the most efficient or scalable solution for large amounts of data.<br/><br/>
ℹ️ **Relational Database:** You can store the GeoJSON data in a relational database, such as PostgreSQL with PostGIS extension or MySQL with spatial extension. This option allows you to easily query and update the data, and it also provides support for spatial indexes, which can improve performance when working with large amounts of data.<br/><br/>
ℹ️ **Cloud-based storage and databases:** You can store the GeoJSON data in cloud-based storage services like Amazon S3 or Google Cloud Storage, and you can use cloud-based databases like Amazon RDS, Google Cloud SQL, MongoDB Atlas, AWS DynamoDB, and many more. This option provides scalability, high availability, and easy integration with other cloud-based services.<br/><br/>
ℹ️ **Spatial Data Warehouses:** You can store the GeoJSON data in Spatial Data Warehouses like Amazon Redshift, Google BigQuery, Microsoft Azure Synapse Analytics, and many more. This option allows you to store and analyze large amount of data easily, providing tools for spatial analysis, data visualization and reporting.<br/><br/>

Ultimately, the best option for storing GeoJSON data will depend on the specific requirements of your use case, including the size and complexity of the data, the required performance and scalability, and the available resources and budget.

## ❓ What Are The Geometry Types?
In GeoJSON, the "geometry" field describes the shape of a feature, and it must contain a "type" field that specifies the type of geometry. The following are the different types of geometry that can be used in GeoJSON:

### 1. Point
- A single point in space represented by a set of coordinates (longitude, latitude).
- ✔️ Supported By DotNet-GeoJSON<br/><br/>
![N|Solid](https://upload.wikimedia.org/wikipedia/commons/thumb/c/c2/SFA_Point.svg/102px-SFA_Point.svg.png)

**[You can copy & past example GeoJSONs to see outputs on the map: GeoJSON.io][geojson-io]**
- Here is an example of a simple GeoJSON file that represents a point location of the Empire State Building in New York City:
```
{
    "type": "Feature",
    "geometry": {
        "type": "Point",
        "coordinates": [-73.9857, 40.7484]
    },
    "properties": {
        "name": "Empire State Building",
        "address": "350 5th Ave, New York, NY 10118"
    }
}
```
- You can use the following code block to create the above GeoJSON output in your code;
```
var geoJson = new GeoJSON();

var properties = new { name = "Empire State Building", address = "address", };

var geometry = new Point(-73.9857, 40.7484);

geoJson.features.Add(new Feature(geometry, properties));

if (geoJson.IsValid())
  return geoJson.GetAsFeature();

return null;
```
- **A GeoJSON** object with the type **"FeatureCollection"** is a **FeatureCollection** object. A **FeatureCollection** object has a member with the name **"features"**. The value of **"features"** is a JSON array. Each element of the array is a **Feature** object as defined above. It is possible for this array to be empty.**
```
var geoJson = new GeoJSON();

var properties = new { name = "Empire State Building", address = "address", };

var geometry = new Point(-73.9857, 40.7484);

geoJson.features.Add(new Feature(geometry, properties));

if (geoJson.IsValid())
  return geoJson; //This is the only line different from the code block above.

return null;
```
#### Point GeoJSON Validation
- Each Point must have at least 2 double values in the List<double> coordinates property.
  
```
public override bool IsValid()
{
  return coordinates.Count >= 2;
}
```

### 2. MultiPoint
- An array of multiple Point objects.
- ✖️ Not Supported By DotNet-GeoJSON (Coming Soon)<br/><br/>
![N|Solid](https://upload.wikimedia.org/wikipedia/commons/thumb/d/d6/SFA_MultiPoint.svg/102px-SFA_MultiPoint.svg.png)
- Here is an example of a GeoJSON file that represents a MultiPoint feature with three points:
```
{
    "type": "Feature",
    "geometry": {
        "type": "MultiPoint",
        "coordinates": [
            [-73.9857, 40.7484],
            [-118.2437, 34.0522],
            [-87.6298, 41.8781]
        ]
    },
    "properties": {
        "name": "Three Cities",
        "city1": "New York",
        "city2": "Los Angeles",
        "city3": "Chicago"
    }
}
```
- In this example, the MultiPoint feature represents three cities, New York, Los Angeles and Chicago, each represented by a set of coordinates (longitude, latitude). The "coordinates" field of the "geometry" object contains an array of multiple sets of coordinates, one for each point. The "properties" field can contain any additional information about the feature, in this case the name of the cities.

### 3. LineString
- A line connecting two or more points represented by an array of coordinates.
- ✔️ Supported By DotNet-GeoJSON<br/><br/>
![N|Solid](https://upload.wikimedia.org/wikipedia/commons/thumb/b/b9/SFA_LineString.svg/102px-SFA_LineString.svg.png)
- Here is an example of a GeoJSON file that represents a LineString feature that connects two points:
```
{
    "type": "Feature",
    "geometry": {
        "type": "LineString",
        "coordinates": [
            [-73.9857, 40.7484],
            [-118.2437, 34.0522]
        ]
    },
    "properties": {
        "name": "Route from New York to Los Angeles",
        "distance": "3000 km"
    }
}
```
- In this example, the LineString feature represents a route from New York to Los Angeles, and it is defined by an array of coordinates (longitude, latitude). The "coordinates" field of the "geometry" object contains an array of multiple sets of coordinates, one for each point in the line. The "properties" field can contain any additional information about the feature, in this case the name of the route and the distance.
- You can use the following code block to create the above GeoJSON output in your code;
```
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
```
You can also have a more complex LineString with multiple segments:
```
{
    "type": "Feature",
    "geometry": {
        "type": "LineString",
        "coordinates": [
            [-73.9857, 40.7484],
            [-118.2437, 34.0522],
            [-87.6298, 41.8781]
        ]
    },
    "properties": {
        "name": "Route from New York to Los Angeles to Chicago",
        "distance": "4000 km"
    }
}
```
- In this example, the LineString feature represents a route from New York to Los Angeles to Chicago, and it is defined by an array of coordinates (longitude, latitude). The "coordinates" field of the "geometry" object contains an array of multiple sets of coordinates, one for each point in the line, in this case three points that represents the three cities. The "properties" field can contain any additional information about the feature, in this case the name of the route and the distance.

#### LineString GeoJSON Validation
- For type "LineString", the "coordinates" member is an array of two or more positions.
  
```
public override bool IsValid()
{
  if (coordinates.Count >= 2)
    return coordinates.All(t => t.Count >= 2);
  return false;
}
```
  
### 4. MultiLineString
- An array of multiple LineString objects.
- ✖️ Not Supported By DotNet-GeoJSON (Coming Soon)<br/><br/>
![N|Solid](https://upload.wikimedia.org/wikipedia/commons/thumb/8/86/SFA_MultiLineString.svg/102px-SFA_MultiLineString.svg.png)
- Here is an example of a GeoJSON file that represents a MultiLineString feature with two LineString objects:
```
{
    "type": "Feature",
    "geometry": {
        "type": "MultiLineString",
        "coordinates": [
            [
                [-73.9857, 40.7484],
                [-118.2437, 34.0522]
            ],
            [
                [-87.6298, 41.8781],
                [-118.2437, 34.0522]
            ]
        ]
    },
    "properties": {
        "name": "Routes from East Coast to West Coast",
        "distance": "4000 km"
    }
}
```
- In this example, the MultiLineString feature represents two routes from the East Coast to the West Coast, one from New York to Los Angeles and another one from Chicago to Los Angeles. Both routes are defined by an array of coordinates (longitude, latitude). The "coordinates" field of the "geometry" object contains an array of multiple arrays of coordinates, one for each line. The "properties" field can contain any additional information about the feature, in this case the name of the route and the distance.

- You can also have more complex MultiLineString where each linestring connects multiple points, in this case the coordinates field will be an array of arrays where each array represents a linestring with multiple coordinates.

### 5. Polygon
- A closed shape defined by an array of coordinates. The first and last coordinates must be the same to close the shape.
- ✔️ Supported By DotNet-GeoJSON<br/><br/>
![N|Solid](https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/SFA_Polygon.svg/102px-SFA_Polygon.svg.png)
![N|Solid](https://upload.wikimedia.org/wikipedia/commons/thumb/5/55/SFA_Polygon_with_hole.svg/102px-SFA_Polygon_with_hole.svg.png)
- Here is an example of a GeoJSON file that represents a Polygon feature that defines the shape of a park:
```
{
    "type": "Feature",
    "geometry": {
        "type": "Polygon",
        "coordinates": [
            [
                [-73.9726, 40.7896],
                [-73.9331, 40.7935],
                [-73.9287, 40.7696],
                [-73.9686, 40.7660],
                [-73.9726, 40.7896]
            ]
        ]
    },
    "properties": {
        "name": "Central Park",
        "area": "341 ha"
    }
}
```
- In this example, the Polygon feature represents the shape of Central Park, and it is defined by an array of coordinates (longitude, latitude). The "coordinates" field of the "geometry" object contains an array of multiple sets of coordinates, one for each point that defines the shape of the park. The order of the coordinates is important and they should be arranged in a clockwise or counterclockwise direction, in this case the last point is the same as the first one in order to close the shape. The "properties" field can contain any additional information about the feature, in this case the name of the park and its area.

- You can also have a polygon with an inner ring, called Hole, that is defined by a different set of coordinates and it will be represented as another array of coordinates within the coordinates field.

```
{
    "type": "Feature",
    "geometry": {
        "type": "Polygon",
        "coordinates": [
            [
                [-73.9726, 40.7896],
                [-73.9331, 40.7935],
                [-73.9287, 40.7696],
                [-73.9686, 40.7660],
                [-73.9726, 40.7896]
            ],
            [
                [-73.9648, 40.7740],
                [-73.9555, 40.7772],
                [-73.9535, 40.7712],
                [-73.9628, 40.7683],
                [-73.9648, 40.7740]
            ]
        ]
    },
    "properties": {
        "name": "Central Park",
        "area": "341 ha"
    }
}
```
- In this example, the Polygon feature represents the shape of Central Park, which includes an inner ring, that is a hole, that is defined by a different set of coordinates. The hole is defined by an array of coordinates within the coordinates field of the polygon.
- You can use the following code block to create the above GeoJSON output in your code;
```
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
```
#### Polygon GeoJSON Validation
- To specify a constraint specific to Polygons, it is useful to introduce the concept of a linear ring:

   o  A linear ring is a closed LineString with four or more positions.

   o  The first and last positions are equivalent, and they MUST contain
      identical values; their representation SHOULD also be identical.

   o  A linear ring is the boundary of a surface or the boundary of a
      hole in a surface.

   o  A linear ring MUST follow the right-hand rule with respect to the
      area it bounds, i.e., exterior rings are counterclockwise, and
      holes are clockwise.
  
   o  For type "Polygon", the "coordinates" member MUST be an array of
      linear ring coordinate arrays.

   o  For Polygons with more than one of these rings, the first MUST be
      the exterior ring, and any others MUST be interior rings.  The
      exterior ring bounds the surface, and the interior rings (if
      present) bound holes within the surface.
  
```
public override bool IsValid()
{
  if (coordinates.Count < 1 || !coordinates.All(t => t.Count >= 3)) return false;
  {
    if (coordinates.All(t1 => t1.All(t => t.Count == 2)))
      return coordinates.All(t => t[0][0] == t[t.Count - 1][0] && t[0][1] == t[t.Count - 1][1]);

     return true;
   }
}
```
### 6. MultiPolygon
- An array of multiple Polygon objects.
- ✔️ Supported By DotNet-GeoJSON<br/><br/>
![N|Solid](https://upload.wikimedia.org/wikipedia/commons/thumb/d/dc/SFA_MultiPolygon.svg/102px-SFA_MultiPolygon.svg.png)
![N|Solid](https://upload.wikimedia.org/wikipedia/commons/thumb/3/3b/SFA_MultiPolygon_with_hole.svg/102px-SFA_MultiPolygon_with_hole.svg.png)
- Here's an example of a GeoJSON Feature that contains a MultiPolygon geometry:
```
{
    "type": "Feature",
    "geometry": {
        "type": "MultiPolygon",
        "coordinates": 
        [
             [
                [
                    [-117.3325, 32.6354],
                    [-117.3325, 32.5354],
                    [-117.2325, 32.5354],
                    [-117.2325, 32.6354],
                    [-117.3325, 32.6354]
                ]
            ],
            [      
                [
                    [-118.3325, 33.6354],
                    [-118.3325, 33.5354],
                    [-118.2325, 33.5354],
                    [-118.2325, 33.6354],
                    [-118.3325, 33.6354]
                ]
            ]
        ]
    },
    "properties": {
        "name": "MultiPolygon Example"
    }
}
```
- In this example, the MultiPolygon geometry is made up of two polygons. The first polygon is represented by the first set of coordinates and the second polygon is represented by the second set of coordinates.
- Each set of coordinates is enclosed in a nested array, with the outermost array representing the entire MultiPolygon geometry.
- You can use the following code block to create the above GeoJSON output in your code;
```
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

//Initialize MultiPolygon With At Least One Polygon
var geometry = new MultiPolygon(polygon);

//Second Polygon
points = new List<Point>();
points.Add(new Point(-118.3325, 33.6354));
points.Add(new Point(-118.3325, 33.5354));
points.Add(new Point(-118.2325, 33.5354));
points.Add(new Point(-118.2325, 33.6354));
points.Add(new Point(-118.3325, 33.6354));

//Add second and many more polygons to your MultiPolygon
polygon = new Polygon(new LineStrings(points));

geometry.AddPolygon(polygon);

geoJson.features.Add(new Feature(geometry, properties));

if (geoJson.IsValid())
  return geoJson.GetAsFeature();

return null;
```
#### MultiPolygon GeoJSON Validation
- For type "MultiPolygon", the "coordinates" member is an array of Polygon coordinate arrays.
```
public override bool IsValid()
{
  if (coordinates.Count >= 1 && coordinates.All(t => t.Count >= 1) &&
      coordinates.All(t1 => t1.All(t => t.Count >= 3)))
      if (coordinates.All(t2 => t2.All(t1 => t1.All(t => t.Count == 2))))
      {
          foreach (var t in coordinates)
            if (t.Any(t1 => t1[0][0] != t1[t.Count - 1][0] || t1[0][1] != t1[t.Count - 1][1]))
                return false;
            return true;
       }

       return false;
}
```
### 7. GeometryCollection
- A collection of different types of geometries.
- ✖️ Not Supported By DotNet-GeoJSON (Coming Soon)<br/><br/>
![N|Solid](https://upload.wikimedia.org/wikipedia/commons/thumb/1/1d/SFA_GeometryCollection.svg/102px-SFA_GeometryCollection.svg.png)
- Here's an example of a GeoJSON Feature that contains a GeometryCollection geometry:
```
{
    "type": "GeometryCollection",
    "geometries": [
        {
            "type": "Point",
            "coordinates": [40.0, 10.0]
        },
        {
            "type": "LineString",
            "coordinates": [
                [10.0, 10.0], [20.0, 20.0], [10.0, 40.0]
            ]
        },
        {
            "type": "Polygon",
            "coordinates": [
                [[40.0, 40.0], [20.0, 45.0], [45.0, 30.0], [40.0, 40.0]]
            ]
        }
    ]
}
```
- In this example, the GeometryCollection geometry is made up of three different geometries: a Point, a LineString, and a Polygon. Each of these geometries is represented by a separate object within the "geometries" array.
- A GeometryCollection is a GeoJSON object that can contain multiple other geometry objects of different types, making it a powerful way to represent complex geometries.

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
| v1.0.0  | Jan 26, 2023 | - First version is ready.|
  

<!-- MARKDOWN LINKS & IMAGES -->
[geojson-io]: https://geojson.io/
[rfc-page]: https://www.rfc-editor.org/rfc/rfc7946  
[h3-index]: https://h3geo.org/ 




