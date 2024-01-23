using System.ComponentModel.DataAnnotations;

namespace GoldenSealWebApi.DTOs
{
    public class RegionViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GeoJSON { get; set; }
        public float? Area { get; set; }
        public DateTime? CreatedTs { get; set; }
    }

    public class RegionCreateDTO
    {
        [Required] public string Name { get; set; }
        [Required] public float Area { get; set; }
        public string GeoJSON { get; set; }
    }

    public class RegionMetricsViewDTO
    {
        public RegionViewDTO Region { get; set; }
        public int? WastesNumber { get; set; }
        public float? WastesArea { get; set; }
        public int? AllWastesNumber { get; set; }
        public float? WastesAbundanceIndex => AllWastesNumber > 0 ? 100 * WastesNumber / AllWastesNumber : null;
        public float? WastesNumberPerArea => Region.Area > 0 ? WastesNumber / Region.Area : null;
        public float? WastesAreaCoveragePercentage => Region.Area > 0 ? 100 * WastesArea / Region.Area : null;
        public float? WastesNumberPer100SquareMeters => Region.Area > 0 ? 100 * WastesNumber / Region.Area : null;
    }
}