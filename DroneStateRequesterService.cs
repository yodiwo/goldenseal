using GoldenSealWebApi.DTOs;
using GoldenSealWebApi.Database;
using GoldenSealWebApi.DTOs.MavlinkAPI;

namespace GoldenSealWebApi
{
    public class DroneStateRequesterService : IHostedService, IDisposable
    {
        private readonly ILogger<DroneStateRequesterService> _logger;
        private IServiceProvider _services;
        private Timer? _timer = null;

        private const string URL = "https://3388-37-6-157-202.ngrok-free.app/mavlink";
        private TimeSpan TIME_PERIOD = TimeSpan.FromMinutes(5);

        public DroneStateRequesterService(ILogger<DroneStateRequesterService> logger, IServiceProvider services)
        {
            _logger = logger;
            _services = services;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(DroneStateRequesterService)} is running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TIME_PERIOD);

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            try
            {
                HttpClient client = new();

                HttpResponseMessage response = client.GetAsync(URL).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    Response rsp = response.Content.ReadFromJsonAsync<Response>().GetAwaiter().GetResult();

                    if (rsp != null)
                    {
                        using (var scope = _services.CreateScope())
                        {
                            var _context = scope.ServiceProvider.GetRequiredService<DBContext>();

                            // keep only the drones that are registered
                            var validDroneIds = Libs.Drone
                                                    .GetAsync(_context)
                                                    .GetAwaiter()
                                                    .GetResult()
                                                    .Select(drone => drone.Id)
                                                    .ToList();

                            var vehicles = rsp.vehicles
                                              .Where(v => validDroneIds.Contains(v.Value.id))
                                              .ToDictionary(v => v.Key, v => v.Value);

                            // build models for creation
                            var reqs = vehicles.Select(vehicle =>
                            {
                                var messages = vehicle.Value.components.Values.Select(comp => comp.messages);

                                var status = DroneStatus.MAV_STATE_UNINIT;

                                var statusTypeStr = messages.Select(msg => msg.SysStatus?.Message?.Type).FirstOrDefault(v => v != null);
                                if (statusTypeStr != null)
                                    _ = Enum.TryParse(statusTypeStr, out status);

                                return new DroneStateCreateDTO
                                {
                                    DroneId = vehicle.Value.id,
                                    Battery = messages.Select(msg => msg.BatteryStatus?.Message?.BatteryRemaining).FirstOrDefault(v => v != null),
                                    VelocityX = messages.Select(msg => msg.GlobalPositionInt?.Message?.Vx).FirstOrDefault(v => v != null),
                                    VelocityY = messages.Select(msg => msg.GlobalPositionInt?.Message?.Vy).FirstOrDefault(v => v != null),
                                    VelocityZ = messages.Select(msg => msg.GlobalPositionInt?.Message?.Vz).FirstOrDefault(v => v != null),
                                    Altitude = messages.Select(msg => msg.GlobalPositionInt?.Message?.Alt).FirstOrDefault(v => v != null),
                                    Longitude = messages.Select(msg => msg.GlobalPositionInt?.Message?.Lon).FirstOrDefault(v => v != null),
                                    Latitude = messages.Select(msg => msg.GlobalPositionInt?.Message?.Lat).FirstOrDefault(v => v != null),
                                    Status = status
                                };
                            });

                            // store
                            foreach (var req in reqs)
                            { 
                                Libs.Drone.PostStateAsync(_context, req).GetAwaiter().GetResult();
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { _logger.LogCritical("Unable to fetch Mavlink data", ex); }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(DroneStateRequesterService)} is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
