using GoldenSealWebApi.Database;
using System.Text.Json;

namespace GoldenSealWebApi.DbContentMigrator
{
    public class DbContentMigrator : IDbContentMigrator
    {
		private readonly DBContext _context;

		public DbContentMigrator(DBContext context) 
        {
            _context = context;
        }

        public void Apply()
        {
            UpdateDetectedWastesArea();
        }

		private void UpdateDetectedWastesArea()
		{
            var wastes = _context.DroneDetectedWastes
                .Where(w => w.Area == null && w.BBPolygonGeoJSON != null)
                .ToList();

            if (wastes.Any()) 
            {
                foreach (var waste in wastes) 
                {
                    var bbGeoJson = JsonSerializer.Deserialize<Libs.GeoJSON.Geometry>(waste.BBPolygonGeoJSON!);
                    waste.Area = Libs.Converters.ToArea(bbGeoJson!);
			    }

                _context.UpdateRange(wastes);
                _context.SaveChanges();
            }
		}
	}
}
