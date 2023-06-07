using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenSealWebApi.Database
{
    [Table("DroneStateLogs")]
    public class DroneStateLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }

        [Column("drone_id", TypeName = "int(11)")]
        public int DroneId { get; set; }
        public Drone Drone { get; set; }

        [Column("pilot_id", TypeName = "int(11)")]
        public int? PilotId { get; set; }
        public User? Pilot { get; set; }

        [Column("route_id", TypeName = "int(11)")]
        public int? RouteId { get; set; }
        public Route? Route { get; set; }

        [Column("battery")]
        public float Battery { get; set; }

        [Column("velocity")]
        public float Velocity { get; set; }

        [Column("geojson", TypeName = "varchar(500)")]
        public string? GeoJSON { get; set; }

        [Column("status")]
        public DroneStatus Status { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("ts", TypeName = "datetime")]
        public DateTime Ts { get; set; }
    }
}
