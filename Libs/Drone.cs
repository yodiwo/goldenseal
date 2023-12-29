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
                    RegionId = req.RegionId,
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
                state.RegionId = req.RegionId;
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
                RegionId = req.RegionId,
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
                                             Id = (int)x.PilotId!,
                                             Name = x.Pilot.Name,
                                             Email = x.Pilot.Email
                                         } : null!,
                                         Route = x.Route != null ? new RouteViewDTO
                                         {
                                             Id = (int)x.RouteId!,
                                             Name = x.Route.Name
                                         } : null!,
                                         Region = x.Region != null ? new RegionViewDTO
                                         {
                                             Id = (int)x.RegionId!,
                                             Name = x.Region.Name
                                         } : null!,
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

        public static async Task<List<DroneDetectedWasteLogViewDTO>> GetDetectedWasteAsync(DBContext context, DroneDetectedWasteLogsGetDTO req)
        {
            var query = context.DroneDetectedWastes
                               .Where(x => req.FromDate <= x.Ts && req.ToDate >= x.Ts);

            if (req.ConfidenceLevel is not null)
                query = query.Where(x => x.ConfidenceLevel >= req.ConfidenceLevel);

            if (req.WasteType is not null)
                query = query.Where(x => x.Type == req.WasteType);

            if (req.WasteSize is not null)
                query = query.Where(x => x.Size == req.WasteSize);

            return await query.Select(x => new DroneDetectedWasteLogViewDTO
            {
                Drone = new DroneViewDTO 
                { 
                    Id = x.Id,
                    Name = x.Drone.Name,
                },
                Region = x.RegionId != null ? 
                new RegionViewDTO
                {
                    Id = (int)x.RegionId,
                    Name = x.Region.Name
                } : null!,
                WasteSize = x.Size,
                WasteType = x.Type,
                ConfidenceLevel = x.ConfidenceLevel
            }).ToListAsync();
        }
    }
}