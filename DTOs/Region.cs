using System.ComponentModel.DataAnnotations;

namespace GoldenSealWebApi.DTOs
{
    public class RegionViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GeoJSON { get; set; }
        public DateTime? CreatedTs { get; set; }
    }

    public class RegionCreateDTO
    {
        [Required] public string Name { get; set; }
        [Required] public float Area { get; set; }
        public string GeoJSON { get; set; }
    }
}