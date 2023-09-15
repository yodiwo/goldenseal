using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenSealWebApi.Database
{
    [Table("GroundWasteSensorStates")]
    public class GroundWasteSensorState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }

        [Column("drone_id", TypeName = "int(11)")]
        public int DroneId { get; set; }
        public Drone Drone { get; set; }

        [Column("ground_waste_sensor_id", TypeName = "int(11)")]
        public int GroundWasteSensorId { get; set; }
        public GroundWasteSensor GroundWasteSensor { get; set; }

        [Column("mass_kg")]
        public float MassKg { get; set; }

        [Column("rank")]
        public int Rank { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("ts", TypeName = "datetime")]
        public DateTime Ts { get; set; }
    }
}
