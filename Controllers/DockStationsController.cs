using GoldenSealWebApi.Database;
using GoldenSealWebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoldenSealWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DockStationsController : ControllerBase
    {
        private readonly ILogger<DockStationsController> _logger;
        private readonly DBContext _context;

        public DockStationsController(DBContext context, ILogger<DockStationsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<DockStationViewDTO>> Get()
        {
            return await _context.DockStations
                                 .Select(x => new DockStationViewDTO
                                 {
                                     Id = x.Id,
                                     Name = x.Name,
                                     GeoJSON = x.GeoJSON,
                                     CreatedTs = x.CreatedTs
                                 })
                                 .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Add(DockStationCreateDTO req)
        {
            await _context.DockStations.AddAsync(new DockStation
            {
                Name = req.Name,
                GeoJSON = req.GeoJSON
            });
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var entry = await _context.DockStations.SingleAsync(s => s.Id == id);

            _context.DockStations.Remove(entry);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}