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

        /// <summary>
        /// Retrieve the available ground waste sensors.
        /// </summary>
        /// <response code="200">Ground waste sensors retrieved</response>
        [ProducesResponseType(typeof(IEnumerable<GroundWasteSensorViewDTO>), 200)]
        [HttpGet]
        public async Task<IEnumerable<GroundWasteSensorViewDTO>> Get()
        {
            return await Libs.GroundWasteSensor.GetAsync(_context);
        }

        /// <summary>
        /// Cerate a ground waste sensor.
        /// </summary>
        /// <response code="200">Ground waste sensor created</response>
        [ProducesResponseType(200)]
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

        /// <summary>
        /// Delete a ground waste sensor.
        /// </summary>
        /// <response code="200">Ground waste sensor deleted</response>
        [ProducesResponseType(200)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id, string refId)
        {
            await Libs.GroundWasteSensor.DeleteAsync(_context, id, refId);

            return Ok();
        }

        /// <summary>
        /// Retrieves the latest state of a ground waste sensor.
        /// </summary>
        /// <response code="200">State retrieved</response>
        [ProducesResponseType(200)]
        [HttpGet("state")]
        public async Task<GroundWasteSensorStateViewDTO> State(int? id, string? refId)
        {
            return await Libs.GroundWasteSensor.GetStateAsync(_context, id, refId);
        }
    }
}