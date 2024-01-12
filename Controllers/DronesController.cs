using GoldenSealWebApi.Database;
using GoldenSealWebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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

        [HttpPost("preflight-config")]
        public async Task<IActionResult> PreflightConfig(DronePrefllightConfigCreateDTO req)
        {
            await Libs.Drone.PostPreflightConfigAsync(_context, req);

            return Ok();
        }

        [HttpGet("state")]
        public async Task<DroneStateViewDTO> State(int id)
        {
            return await Libs.Drone.GetStateAsync(_context, id);
        }

        [HttpPost("detected-waste")]
        public async Task<IActionResult> DetectedWaste(DroneDetectedWasteCreateDTO req)
        {
            var regionId = await Libs.Drone.GetRegionAsync(_context, req.DroneId);            
            var entries = new List<DroneDetectedWasteLog>();

            foreach (var img in req.Images) 
            {
                foreach (var feat in img.BoundingBoxes) 
                {
                    var bbGeoJson = JsonSerializer.Deserialize<Libs.GeoJSON.Geometry>(feat.BBPolygonGeoJSON);
                    var wasteArea = Libs.Converters.ToArea(bbGeoJson);

                    var entry = new DroneDetectedWasteLog
                    {
                        CMLOUploadId = req.CMLOUploadId,
                        DroneId = req.DroneId,
                        UploadConfidenceLevel = req.UploadConfidenceLevel,
                        WMSService = req.WMSServiceUrl,
                        Image = img.Url,
                        GeoreferencedImage = img.GeoreferencedUrl,
                        Size = feat.WasteSize,
                        Area = wasteArea,
                        Type = feat.WasteType,
                        BBPointGeoJSON = feat.BBPointGeoJSON,
                        BBPolygonGeoJSON = feat.BBPolygonGeoJSON,
                        ConfidenceLevel = feat.ConfidenceLevel,
                        RegionId = regionId
                    };

                    entries.Add(entry);
                }
            }

            await _context.DroneDetectedWastes.AddRangeAsync(entries);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("detected-wastes")]
        public async Task<List<DroneDetectedWasteLogViewDTO>> DetectedWastes([FromQuery] DroneDetectedWasteLogsGetDTO req) 
        {
            return await Libs.Drone.GetDetectedWasteAsync(_context, req);
        }
    }
}