using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenSealWebApi.Database
{
    [Table("Drones")]
    public class Drone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }

        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column("dock_station_id", TypeName = "int(11)")]
        public int DockStationId { get; set; }
        public DockStation DockStation { get; set; }

        [Column("image", TypeName = "varchar(500)")]
        public string Image { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("created_ts", TypeName = "datetime")]
        public DateTime CreatedTs { get; set; }
    }
}
