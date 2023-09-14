using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenSealWebApi.Database
{
    [Table("DroneStates")]
    public class DroneState
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

    public enum DroneStatus
    {
        MAV_STATE_UNINIT, //Uninitialized system, state is unknown.
        MAV_STATE_BOOT,  //System is booting up.
        MAV_STATE_CALIBRATING, //System is calibrating and not flight-ready.
        MAV_STATE_STANDBY, //System is grounded and on standby. It can be launched any time.
        MAV_STATE_ACTIVE, //System is active and might be already airborne. Motors are engaged.
        MAV_STATE_CRITICAL, //System is in a non-normal flight mode (failsafe). It can however still navigate.
        MAV_STATE_EMERGENCY, //System is in a non-normal flight mode (failsafe). It lost control over parts or over the whole airframe. It is in mayday and going down.
        MAV_STATE_POWEROFF, //System just initialized its power-down sequence, will shut down now.
        MAV_STATE_FLIGHT_TERMINATION, //System is terminating itself (failsafe or commanded).
    }
}
