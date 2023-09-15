using Microsoft.EntityFrameworkCore;

namespace GoldenSealWebApi.Database
{
    public class DBContext : DbContext
    {
        public DBContext() { }
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        #region TABLES
        public DbSet<User> Users { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<DockStation> DockStations { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Drone> Drones { get; set; }
        public DbSet<DroneState> DroneStates { get; set; }
        public DbSet<DroneStateLog> DroneStateLogs { get; set; }
        public DbSet<DroneDetectedWasteLog> DroneDetectedWastes { get; set; }
        public DbSet<GroundWasteSensor> GroundWasteSensors { get; set; }
        public DbSet<GroundWasteSensorState> GroundWasteSensorStates { get; set; }
        public DbSet<GroundWasteSensorStateLog> GroundWasteSensorStateLogs { get; set; }
        #endregion

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.EnableDetailedErrors();

                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password='root';database=goldenseal_db", ServerVersion.Parse("5.7.40-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DroneState>()
                   .HasIndex(u => u.DroneId)
                   .IsUnique();
            builder.Entity<DockStation>()
                   .HasIndex(u => u.Name)
                   .IsUnique();
            builder.Entity<Region>()
                   .HasIndex(u => u.Name)
                   .IsUnique();
            builder.Entity<User>()
                   .HasIndex(u => u.Name)
                   .IsUnique();
            builder.Entity<User>()
                   .HasIndex(u => u.Email)
                   .IsUnique();
            builder.Entity<Route>()
                   .HasIndex(u => u.Name)
                   .IsUnique();
            builder.Entity<GroundWasteSensor>()
                   .HasIndex(u => u.RefId)
                   .IsUnique();
        }
    }
}
