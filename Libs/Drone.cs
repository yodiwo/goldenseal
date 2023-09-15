using GoldenSealWebApi.Database;
using GoldenSealWebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
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
        public static async Task<DroneStateViewDTO> GetStateAsync(DBContext context, int id)
        {
            return await context.DroneStates
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
        public static async Task DeleteAsync(DBContext context, int id)
        {
            var entry = await context.Drones.SingleAsync(s => s.Id == id);

            context.Drones.Remove(entry);
            await context.SaveChangesAsync();
        }
    }
}