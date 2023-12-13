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

        [Column("region_id", TypeName = "int(11)")]
        public int? RegionId { get; set; }
        public Route? Region { get; set; }

        [Column("battery")]
        public float? Battery { get; set; }

        [Column("velocity_x")]
        public float? VelocityX { get; set; }

        [Column("velocity_y")]
        public float? VelocityY { get; set; }

        [Column("velocity_z")]
        public float? VelocityZ { get; set; }

        [Column("altitude")]
        public long? Altitude { get; set; }

        [Column("longitude")]
        public long? Longitude { get; set; }

        [Column("latitude")]
        public long? Latitude { get; set; }

        [Column("status")]
        public DroneStatus Status { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("ts", TypeName = "datetime")]
        public DateTime Ts { get; set; }
    }
}
