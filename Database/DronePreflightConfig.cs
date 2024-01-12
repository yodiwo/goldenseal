using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenSealWebApi.Database
{
    [Table("DronePreflightConfig")]
    public class DronePreflightConfig
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

        [Column("region_id", TypeName = "int(11)")]
        public int RegionId { get; set; }
        public Region Region { get; set; }

        [Column("altitude")]
        public long? Altitude { get; set; }        

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("ts", TypeName = "datetime")]
        public DateTime Ts { get; set; }
    }
}