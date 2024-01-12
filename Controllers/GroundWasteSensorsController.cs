using GoldenSealWebApi.Database;
using GoldenSealWebApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSealWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroundWasteSensorsController : ControllerBase
    {
        private readonly ILogger<GroundWasteSensorsController> _logger;
        private readonly DBContext _context;

        public GroundWasteSensorsController(DBContext context, ILogger<GroundWasteSensorsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<GroundWasteSensorViewDTO>> Get()
        {
            return await Libs.GroundWasteSensor.GetAsync(_context);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GroundWasteSensorCreateDTO req)
        {
            await _context.GroundWasteSensors.AddAsync(new GroundWasteSensor
            {
                Name = req.Name,
                RegionId = req.RegionId,
                RefId = req.RefId,
                Image = req.Image
            });
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id, string refId)
        {
            await Libs.GroundWasteSensor.DeleteAsync(_context, id, refId);

            return Ok();
        }

        [HttpGet("state")]
        public async Task<GroundWasteSensorStateViewDTO> State(int id, string refId)
        {
            return await Libs.GroundWasteSensor.GetStateAsync(_context, id, refId);
        }
    }
}