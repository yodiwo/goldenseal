using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenSealWebApi.Database
{
    [Table("DroneDetectedWasteLogs")]
    public class DroneDetectedWasteLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }

        [Column("drone_id", TypeName = "int(11)")]
        public int DroneId { get; set; }
        public Drone Drone { get; set; }

        [Column("type")]
        public WasteType Type { get; set; }

        [Column("upload_confidence_level")]
        public float? UploadConfidenceLevel { get; set; }

        [Column("size")]
        public WasteSize Size { get; set; }

        [Column("area")]
        public float? Area { get; set; }

        [Column("image", TypeName = "varchar(500)")]
        public string? Image { get; set; }

        [Column("georeferenced_image", TypeName = "varchar(500)")]
        public string? GeoreferencedImage { get; set; }

        [Column("bb_point_geojson", TypeName = "varchar(500)")]
        public string? BBPointGeoJSON { get; set; }

        [Column("bb_polygon_geojson", TypeName = "varchar(500)")]
        public string? BBPolygonGeoJSON { get; set; }

        [Column("wms_service", TypeName = "varchar(500)")]
        public string? WMSService { get; set; }

        [Column("cmlo_upload_id", TypeName = "int(11)")]
        public int CMLOUploadId { get; set; }

        [Column("confidence_level")]
        public float? ConfidenceLevel { get; set; }

        [Column("region_id", TypeName = "int(11)")]
        public int? RegionId { get; set; }
        public Region Region { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("ts", TypeName = "datetime")]
        public DateTime Ts { get; set; }
    }

    public enum WasteSize
    {
        Unknown = 0,
        ExtraSmall,
        Small,
        Medium,
        Large,
        ExtraLarge
    }

    public enum WasteType
    {
        Unknown = 0,
        Plastic = 1,
        Paper = 2,
        Metal = 3,
        Cloth = 4,
        GlassAndCeramic = 5,
        Rubber = 6,
        Wood = 7
    }
}
