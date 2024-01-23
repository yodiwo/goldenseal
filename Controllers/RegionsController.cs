using GoldenSealWebApi.Database;
using GoldenSealWebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoldenSealWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly ILogger<RegionsController> _logger;
        private readonly DBContext _context;

        public RegionsController(DBContext context, ILogger<RegionsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<RegionViewDTO>> Get()
        {
            return await _context.Regions
                                 .Select(x => new RegionViewDTO
                                 {
                                     Id = x.Id,
                                     Name = x.Name,
                                     GeoJSON = x.GeoJSON,
                                     CreatedTs = x.CreatedTs,
                                     Area = x.Area
                                 })
                                 .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegionCreateDTO req)
        {
            await _context.Regions.AddAsync(new Region
            {
                Name = req.Name,
                GeoJSON = req.GeoJSON,
                Area = req.Area
            });
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var entry = await _context.Regions.SingleAsync(s => s.Id == id);

            _context.Regions.Remove(entry);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("metrics")]
        public async Task<IEnumerable<RegionMetricsViewDTO>> Get([FromQuery] DroneDetectedWasteLogsGetDTO req)
        {
            var wastes = await Libs.Drone.GetDetectedWasteAsync(_context, req);

            req.WasteType = null;
            var allWastes = await Libs.Drone.GetDetectedWasteAsync(_context, req);

            var wastesPerRegion = wastes.GroupBy(x => x.Region.Id);

            return wastesPerRegion.Select(wastes => new RegionMetricsViewDTO
            {
                Region = wastes.First().Region,
                WastesNumber = wastes.Count(),
                AllWastesNumber = allWastes.Count(),
                WastesArea = wastes.Sum(y => y.WasteArea ?? 0)
            }).ToList();
        }
    }
}