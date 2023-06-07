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
                                     CreatedTs = x.CreatedTs
                                 })
                                 .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegionCreateDTO req)
        {
            await _context.Regions.AddAsync(new Region
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
            var entry = await _context.Regions.SingleAsync(s => s.Id == id);

            _context.Regions.Remove(entry);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}