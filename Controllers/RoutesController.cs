using GoldenSealWebApi.Database;
using GoldenSealWebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoldenSealWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly ILogger<RoutesController> _logger;
        private readonly DBContext _context;

        public RoutesController(DBContext context, ILogger<RoutesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<RouteViewDTO>> Get()
        {
            return await _context.Routes
                                 .Select(x => new RouteViewDTO
                                 {
                                     Id = x.Id,
                                     Name = x.Name,
                                     GeoJSON = x.GeoJSON,
                                     Region = x.Region != null ? new RegionViewDTO
                                     {
                                         Id = x.Region.Id,
                                         Name = x.Region.Name
                                     } : null,
                                     CreatedTs = x.CreatedTs
                                 })
                                 .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RouteCreateDTO req)
        {
            await _context.Routes.AddAsync(new Database.Route
            {
                RegionId = req.RegionId,
                Name = req.Name,
                GeoJSON = req.GeoJSON
            });
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var entry = await _context.Routes.SingleAsync(s => s.Id == id);

            _context.Routes.Remove(entry);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}