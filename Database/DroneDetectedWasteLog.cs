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

        [Column("confidence_level")]
        public float? ConfidenceLevel { get; set; }

        [Column("amount")]
        public int? Amount { get; set; }

        [Column("size")]
        public WasteSize Size { get; set; }

        [Column("image", TypeName = "varchar(500)")]
        public string? Image { get; set; }

        [Column("geojson", TypeName = "varchar(500)")]
        public string? GeoJSON { get; set; }        

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
        Plastic,
        Paper,
        Wood,
        Aluminium,
        Metal,
        Glass,
        Organic
    }
}
