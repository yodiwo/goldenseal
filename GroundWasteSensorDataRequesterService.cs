using GoldenSealWebApi.DTOs;
using GoldenSealWebApi.Database;
using GoldenSealWebApi.DTOs.SchoolTournamentAPI;

namespace GoldenSealWebApi
{
    public class GroundWasteSensorDataRequesterService : IHostedService, IDisposable
    {
        private readonly ILogger<GroundWasteSensorDataRequesterService> _logger;
        private IServiceProvider _services;
        private Timer? _timer = null;

        private const string URL = "https://app.justgozero.com/api/schooltournament-data?email=dimos@peiraias.gr";
        private TimeSpan TIME_PERIOD = TimeSpan.FromHours(2);

        public GroundWasteSensorDataRequesterService(ILogger<GroundWasteSensorDataRequesterService> logger, IServiceProvider services)
        {
            _logger = logger;
            _services = services;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(GroundWasteSensorDataRequesterService)} is running.");

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

                    if (rsp?.status == true)
                    {
                        using (var scope = _services.CreateScope())
                        {
                            var _context = scope.ServiceProvider.GetRequiredService<DBContext>();

                            // keep only the drones that are registered
                            var validSensorRefIds = Libs.GroundWasteSensor
                                                        .GetAsync(_context)
                                                        .GetAwaiter()
                                                        .GetResult()
                                                        .Where(sensor => sensor.RefId != null)
                                                        .ToDictionary(sensor => sensor.RefId, sensor => sensor.Id);
                            var sensorsData = rsp.data
                                                 .all_fm_with_generated
                                                 .Where(v => validSensorRefIds.Keys.Contains(v.id.ToString()))
                                                 .ToList();

                            // build models for creation
                            var reqs = sensorsData.Select(datum =>
                            {
                                var massString = datum.total_generated;
                                if (massString.Contains(" kg"))
                                {
                                    massString = massString
                                                    .Replace(" kg", "") // remove units
                                                    .Replace(".", "") // transform to valid format
                                                    .Replace(",", ".");

                                    if (float.TryParse(massString, out var mass))
                                    {
                                        return new GroundWasteSensorStateCreateDTO
                                        {
                                            GroundWasteSensorId = validSensorRefIds[datum.id.ToString()],
                                            MassKg = mass,
                                        };
                                    }
                                }

                                return null;
                            });

                            // store
                            foreach (var req in reqs.Where(r => r != null))
                            {
                                Libs.GroundWasteSensor.PostStateAsync(_context, req).GetAwaiter().GetResult();
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { _logger.LogCritical("Unable to fetch ground sensors data", ex); }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(GroundWasteSensorDataRequesterService)} is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
