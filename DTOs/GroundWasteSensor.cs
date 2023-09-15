using GoldenSealWebApi.Database;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoldenSealWebApi.DTOs
{
    public class GroundWasteSensorViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RegionViewDTO Region { get; set; }
        public string Image { get; set; }
        public string RefId { get; set; }
        public DateTime CreatedTs { get; set; }
    }

    public class GroundWasteSensorCreateDTO
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string RefId { get; set; }
    }

    public class GroundWasteSensorStateCreateDTO
    {
        public int GroundWasteSensorId { get; set; }
        public float MassKg { get; set; }
        public int Rank { get; set; }
    }

    public class GroundWasteSensorStateViewDTO
    {
        public GroundWasteSensorViewDTO GroundWasteSensor { get; set; }
        public RegionViewDTO Region { get; set; }
        public float MassKg { get; set; }
        public int Rank { get; set; }
    }
}