namespace GoldenSealWebApi.DTOs
{
    public class RouteViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RegionViewDTO Region { get; set; }
        public string GeoJSON { get; set; }
        public DateTime? CreatedTs { get; set; }
    }

    public class RouteCreateDTO
    {
        public int? RegionId { get; set; }
        public string Name { get; set; }
        public string GeoJSON { get; set; }
    }
}