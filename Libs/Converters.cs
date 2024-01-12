using Geo.Geometries;
using Geo;

namespace GoldenSealWebApi.Libs
{
    public static class Converters
    {
        public static float? ToArea(this GeoJSON.Geometry geometry)
        {
            var isPolygon = geometry?.type == "Polygon";
            if (!isPolygon)
                return null;

            var coordinates = geometry
                                     ?.coordinates
                                     ?.FirstOrDefault()
                                     ?.Select(point => new Coordinate(point[1], point[0]))
                                     ?.ToList();
            if (coordinates == null)
                return null;

            var polygon = new Polygon(coordinates);

            return Math.Abs((float)polygon.GetArea().Value);
        }
    }
}
