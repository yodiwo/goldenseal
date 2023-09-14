using GoldenSealWebApi.Database;
using GoldenSealWebApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GoldenSealWebApi.Libs
{
    public class Drone
    {
        public static async Task PostStateAsync(DBContext context, DroneStateCreateDTO req)
        {
            var state = await context.DroneStates.FirstOrDefaultAsync(x => x.DroneId == req.DroneId);
            if (state == null)
            {
                await context.DroneStates.AddAsync(new DroneState
                {
                    DroneId = req.DroneId,
                    PilotId = req.PilotId,
                    RouteId = req.RouteId,
                    Battery = req.Battery,
                    VelocityX = req.VelocityX,
                    VelocityY = req.VelocityY,
                    VelocityZ = req.VelocityZ,
                    Altitude = req.Altitude,
                    Longitude = req.Longitude,
                    Latitude = req.Latitude,
                    Status = req.Status
                });
            }
            else
            {
                state.PilotId = req.PilotId;
                state.RouteId = req.RouteId;
                state.Battery = req.Battery;
                state.VelocityX = req.VelocityX;
                state.VelocityY = req.VelocityY;
                state.VelocityZ = req.VelocityZ;
                state.Altitude = req.Altitude;
                state.Longitude = req.Longitude;
                state.Latitude = req.Latitude;
                state.Status = req.Status;

                context.DroneStates.Update(state);
            }

            await context.DroneStateLogs.AddAsync(new DroneStateLog
            {
                DroneId = req.DroneId,
                PilotId = req.PilotId,
                RouteId = req.RouteId,
                VelocityX = req.VelocityX,
                VelocityY = req.VelocityY,
                VelocityZ = req.VelocityZ,
                Altitude = req.Altitude,
                Longitude = req.Longitude,
                Latitude = req.Latitude,
                Status = req.Status
            });

            await context.SaveChangesAsync();
        }
        public static async Task<List<DroneViewDTO>> GetAsync(DBContext context)
        {
            return await context.Drones
                                .Select(x => new DroneViewDTO
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    DockStation = new DockStationViewDTO
                                    {
                                        Id = x.DockStationId,
                                        Name = x.DockStation.Name
                                    },
                                    CreatedTs = x.CreatedTs
                                })
                                .ToListAsync();
        }
    }
}
