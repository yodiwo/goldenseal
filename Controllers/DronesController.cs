using GoldenSealWebApi.Database;
using GoldenSealWebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoldenSealWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DronesController : ControllerBase
    {
        private readonly ILogger<DronesController> _logger;
        private readonly DBContext _context;

        public DronesController(DBContext context, ILogger<DronesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<DroneViewDTO>> Get()
        {
            return await Libs.Drone.GetAsync(_context);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DroneCreateDTO req)
        {
            await _context.Drones.AddAsync(new Drone
            {
                DockStationId = req.DockStationId,
                Name = req.Name,
                Image = req.Image
            });
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var entry = await _context.Drones.SingleAsync(s => s.Id == id);

            _context.Drones.Remove(entry);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("state")]
        public async Task<DroneStateViewDTO> State(int id)
        {
            return await _context.DroneStates
                                 .Where(x => x.DroneId == id)
                                 .Select(x => new DroneStateViewDTO
                                 {
                                     Drone = new DroneViewDTO
                                     {
                                         Id = x.DroneId,
                                         Name = x.Drone.Name
                                     },
                                     Pilot = x.Pilot != null ? new UserViewDTO
                                     {
                                         Id = (int)x.PilotId,
                                         Name = x.Pilot.Name,
                                         Email = x.Pilot.Email
                                     } : null,
                                     Route = x.Route != null ? new RouteViewDTO
                                     {
                                         Id = (int)x.RouteId,
                                         Name = x.Route.Name
                                     } : null,
                                     Battery = x.Battery,
                                     VelocityX = x.VelocityX,
                                     VelocityY = x.VelocityY,
                                     VelocityZ = x.VelocityZ,
                                     Altitude = x.Altitude,
                                     Latitude = x.Latitude,
                                     Longitude = x.Longitude,
                                     Status = x.Status
                                 })
                                 .SingleAsync();
        }

        [HttpPost("state")]
        public async Task<IActionResult> State(DroneStateCreateDTO req)
        {
            await Libs.Drone.PostStateAsync(_context, req);

            return Ok();
        }

        [HttpPost("detected-waste")]
        public async Task<IActionResult> DetectedWaste(DroneDetectedWasteCreateDTO req)
        {
            await _context.DroneDetectedWastes.AddAsync(new DroneDetectedWasteLog
            {
                DroneId = req.DroneId,
                Size = req.Size,
                Type = req.Type,
                Image = req.Image,
                GeoJSON = req.GeoJSON
            });
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}