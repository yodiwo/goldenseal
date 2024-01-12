using GoldenSealWebApi.Database;
using System.ComponentModel.DataAnnotations;

namespace GoldenSealWebApi.DTOs
{
    public class DroneViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DockStationViewDTO DockStation { get; set; }
        public string Image { get; set; }
        public DateTime? CreatedTs { get; set; }
    }

    public class DroneCreateDTO
    {
        [Required] public int DockStationId { get; set; }
        [Required] public string Name { get; set; }
        public string Image { get; set; }
    }

    public class DronePrefllightConfigCreateDTO
    {
        [Required] public int DroneId { get; set; }
        [Required] public int RegionId { get; set; }
        public int? PilotId { get; set; }
    }

    public class DronePreflightConfigViewDTO 
    {
        public RegionViewDTO Region { get; set; }
        public float? Altitude { get; set; }
    }

    public class DroneStateCreateDTO
    {
        [Required] public int DroneId { get; set; }
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
        public RegionViewDTO Region { get; set; }
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
        [Required] public int DroneId { get; set; }
        [Required] public int CMLOUploadId { get; set; }
        public float? UploadConfidenceLevel { get; set; }
        public string? WMSServiceUrl { get; set; }
        [Required] public List<DroneDetectedWasteImageDTO> Images { get; set; }
    }

    public class DroneDetectedWasteImageDTO 
    {
        public string? Url { get; set; }
        public string? GeoreferencedUrl { get; set; }
        public List<DroneDetectedWasteImageBoundingBoxDTO> BoundingBoxes { get; set; }
    }

    public class DroneDetectedWasteImageBoundingBoxDTO
    {
        public string? BBPointGeoJSON { get; set; } // κέντρο του bounding box
        public string? BBPolygonGeoJSON { get; set; } // bounding box
        public WasteSize WasteSize { get; set; }
        public WasteType WasteType { get; set; }
        public float? ConfidenceLevel { get; set; } // >= του "confidenceLevel" του upload
        public bool IsEligible { get; set; } // Αυτό δηλώνει αν το αντικείμενο που βρέθηκε βρίσκεται σε μη-επικαλυπτόμενο κομμάτι του μωσαϊκού
    }

    public class DroneDetectedWasteLogsGetDTO
    {
        [Required] public DateTime FromDate { get; set; }
        [Required] public DateTime ToDate { get; set; }
        public float? ConfidenceLevel { get; set; }
        public WasteSize? WasteSize { get; set; }
        public WasteType? WasteType { get; set; }
    }

    public class DroneDetectedWasteLogViewDTO
    {
        public DroneViewDTO Drone { get; set; }
        public RegionViewDTO Region { get; set; }
        public WasteSize WasteSize { get; set; }
        public WasteType WasteType { get; set; }
        public float? ConfidenceLevel { get; set; }
    }
}