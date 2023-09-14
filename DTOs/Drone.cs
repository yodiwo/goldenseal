using GoldenSealWebApi.Database;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoldenSealWebApi.DTOs
{
    public class DroneViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DockStationViewDTO DockStation { get; set; }
        public string Image { get; set; }
        public DateTime CreatedTs { get; set; }
    }

    public class DroneCreateDTO
    {
        public int DockStationId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class DroneStateCreateDTO
    {
        public int DroneId { get; set; }
        public int? PilotId { get; set; }
        public int? RouteId { get; set; }
        public float? Battery { get; set; }
        public float? VelocityX { get; set; }
        public float? VelocityY { get; set; }
        public float? VelocityZ { get; set; }
        public long? Altitude { get; set; }
        public long? Longitude { get; set; }
        public long? Latitude { get; set; }
        public DroneStatus Status { get; set; }
    }

    public class DroneStateViewDTO
    {
        public DroneViewDTO Drone { get; set; }
        public UserViewDTO Pilot { get; set; }
        public RouteViewDTO Route { get; set; }
        public float? Battery { get; set; }
        public float? VelocityX { get; set; }
        public float? VelocityY { get; set; }
        public float? VelocityZ { get; set; }
        public long? Altitude { get; set; }
        public long? Longitude { get; set; }
        public long? Latitude { get; set; }
        public DroneStatus Status { get; set; }
    }

    public class DroneDetectedWasteCreateDTO
    {
        public int DroneId { get; set; }
        public WasteSize Size { get; set; }
        public WasteType Type { get; set; }
        public string Image { get; set; }
        public string? GeoJSON { get; set; }
    }
}