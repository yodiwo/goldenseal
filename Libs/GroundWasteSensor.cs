using GoldenSealWebApi.Database;
using GoldenSealWebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoldenSealWebApi.Libs
{
    public class GroundWasteSensor
    {
        public static async Task PostStateAsync(DBContext context, GroundWasteSensorStateCreateDTO req)
        {
            var state = await context.GroundWasteSensorStates.FirstOrDefaultAsync(x => x.GroundWasteSensorId == req.GroundWasteSensorId);
            if (state == null)
            {
                await context.GroundWasteSensorStates.AddAsync(new GroundWasteSensorState
                {
                    GroundWasteSensorId = req.GroundWasteSensorId,
                    MassKg = req.MassKg,
                    Rank = req.Rank
                });
            }
            else
            {
                state.MassKg = req.MassKg;
                state.Rank = req.Rank;

                context.GroundWasteSensorStates.Update(state);
            }

            await context.GroundWasteSensorStateLogs.AddAsync(new GroundWasteSensorStateLog
            {
                GroundWasteSensorId = req.GroundWasteSensorId,
                MassKg = req.MassKg,
                Rank = req.Rank
            });

            await context.SaveChangesAsync();
        }
        public static async Task<List<GroundWasteSensorViewDTO>> GetAsync(DBContext context)
        {
            return await context.GroundWasteSensors
                                .Select(x => new GroundWasteSensorViewDTO
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    Region = new RegionViewDTO
                                    {
                                        Id = x.RegionId,
                                        Name = x.Region.Name
                                    },
                                    CreatedTs = x.CreatedTs
                                })
                                .ToListAsync();
        }
        public static async Task<GroundWasteSensorStateViewDTO> GetStateAsync(DBContext context, int id, string refId)
        {
            return await context.GroundWasteSensorStates
                                .Where(x => x.GroundWasteSensorId == id || x.GroundWasteSensor.RefId == refId)
                                .Select(x => new GroundWasteSensorStateViewDTO
                                {
                                    GroundWasteSensor = new GroundWasteSensorViewDTO
                                    {
                                        Id = x.GroundWasteSensorId,
                                        Name = x.GroundWasteSensor.Name,
                                        Region = new RegionViewDTO
                                        {
                                            Id = x.GroundWasteSensor.RegionId,
                                            Name = x.GroundWasteSensor.Region.Name
                                        }
                                    },
                                    MassKg = x.MassKg,
                                    Rank = x.Rank,
                                })
                                .SingleAsync();
        }
        public static async Task DeleteAsync(DBContext context, int id, string refId)
        {
            var entry = await context.GroundWasteSensors.SingleAsync(s => s.Id == id || s.RefId == refId);

            context.GroundWasteSensors.Remove(entry);
            await context.SaveChangesAsync();
        }
    }
}
