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
            await Libs.Drone.DeleteAsync(_context, id);

            return Ok();
        }

        [HttpGet("state")]
        public async Task<DroneStateViewDTO> State(int id)
        {
            return await Libs.Drone.GetStateAsync(_context, id);
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
            var entries = new List<DroneDetectedWasteLog>();

            foreach (var img in req.Images) 
            {
                foreach (var feat in img.Features) 
                {
                    var entry = new DroneDetectedWasteLog
                    {
                        DroneId = req.DroneId,
                        ConfidenceLevel = req.ConfidenceLevel,
                        WMSService = req.WMSServiceUrl,
                        Image = img.Url,
                        GeoreferencedImage = img.GeoreferencedUrl,
                        Size = feat.Size,
                        Type = feat.Type,
                        GeoJSON = feat.GeoJSON,
                        Amount = feat.Amount                        
                    };

                    entries.Add(entry);
                }
            }

            await _context.DroneDetectedWastes.AddRangeAsync(entries);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}