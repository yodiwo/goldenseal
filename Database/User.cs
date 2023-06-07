using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenSealWebApi.Database
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }

        [Column("email", TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column("username", TypeName = "varchar(50)")]
        public string UserName { get; set; }

        [Column("x_api_key", TypeName = "varchar(50)")]
        public string XApiKey { get; set; }

        [Column("role", TypeName = "int(3)")]
        public UserRole Role { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("created_ts", TypeName = "datetime")]
        public DateTime CreatedTs { get; set; }
    }

    public enum UserRole
    {
        NoAccess = 0, // NoAccess
        Visitor = 1 << 1,
        SuperUser = 1 << 2,

        Admin = 1 << 15
    }
}
