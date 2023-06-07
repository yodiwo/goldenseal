namespace GoldenSealWebApi.DTOs
{
    public class DockStationViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? GeoJSON { get; set; }
        public DateTime? CreatedTs { get; set; }
    }

    public class DockStationCreateDTO
    {
        public string Name { get; set; }
        public string GeoJSON { get; set; }
    }
}