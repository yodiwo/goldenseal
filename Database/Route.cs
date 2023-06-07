using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenSealWebApi.Database
{
    [Table("Routes")]
    public class Route
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }

        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column("region_id", TypeName = "int(11)")]
        public int? RegionId { get; set; }
        public Region? Region { get; set; }

        [Column("geojson", TypeName = "varchar(500)")]
        public string GeoJSON { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("created_ts", TypeName = "datetime")]
        public DateTime CreatedTs { get; set; }
    }
}
