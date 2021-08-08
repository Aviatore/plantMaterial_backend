using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using plantMaterials.DTOs;
using plantMaterials.Models;
using plantMaterials.Repositories;

namespace plantMaterials.ExtensionMethods
{
    public static class GenericPrep
    {
        public static async Task<ProblemDetails> AddPrep(this IGenericRepository<Prep> repo, Prep[] preps)
        {
            ProblemDetails problemDetails = new ProblemDetails()
            {
                Detail = "Something went wrong while saving preps",
                Status = 500
            };

            try
            {
                repo.DbContext.Preps.AddRange(preps);
                var count = await repo.DbContext.SaveChangesAsync();

                if (count == 0)
                {
                    throw new Exception("Something went wrong while saving preps");
                }

                problemDetails.Detail = "Preps were saved successfully";
                problemDetails.Status = 200;
                return problemDetails;
            }
            catch (Exception e)
            {
                problemDetails.Detail = e.Message;
                return problemDetails;
            }
        }
        
        public static IEnumerable<PrepDto> GetPreps(this IGenericRepository<Prep> repo,
            PlantSampleFiltersDto[] filters, IMapper mapper)
        {
            var preps = repo.GetAll();

            foreach (var filter in filters)
            {
                switch (filter.Filter)
                {
                    case "Population":
                        preps = filter.Bool switch
                        {
                            0 => preps.Where(p => p.PlantSample.PopulationId == filter.PopulationId),
                            1 => preps.Where(p => p.PlantSample.PopulationId != filter.PopulationId),
                            _ => throw new ArgumentOutOfRangeException($"Not expected bool value: {filter.Bool}")
                        };
                        break;
                    case "Tissue":
                        preps = filter.Bool switch
                        {
                            0 => preps.Where(p => p.PlantSample.TissueId == filter.TissueId),
                            1 => preps.Where(p => p.PlantSample.TissueId != filter.TissueId),
                            _ => throw new ArgumentOutOfRangeException($"Not expected bool value: {filter.Bool}")
                        };
                        break;
                    case "Duplication":
                        preps = filter.Bool switch
                        {
                            0 => preps.Where(p => p.DuplicationId == filter.DuplicationId),
                            1 => preps.Where(p => p.DuplicationId != filter.DuplicationId),
                            _ => throw new ArgumentOutOfRangeException($"Not expected bool value: {filter.Bool}")
                        };
                        break;
                    case "Location type":
                        preps = filter.Bool switch
                        {
                            0 => preps.Where(p => p.PrepLocationId == filter.LocationId),
                            1 => preps.Where(p => p.PrepLocationId != filter.LocationId),
                            _ => throw new ArgumentOutOfRangeException($"Not expected bool value: {filter.Bool}")
                        };
                        break;
                    case "Shelf position":
                        preps = filter.Bool switch
                        {
                            0 => preps.Where(p => p.ShelfPositionId == filter.ShelfPositionId),
                            1 => preps.Where(p => p.ShelfPositionId != filter.ShelfPositionId),
                            _ => throw new ArgumentOutOfRangeException($"Not expected bool value: {filter.Bool}")
                        };
                        break;
                    case "Container type":
                        preps = filter.Bool switch
                        {
                            0 => preps.Where(p => p.ContainerTypeId == filter.ContainerTypeId),
                            1 => preps.Where(p => p.ContainerTypeId != filter.ContainerTypeId),
                            _ => throw new ArgumentOutOfRangeException($"Not expected bool value: {filter.Bool}")
                        };
                        break;
                    default:
                        throw new ArgumentException($"Wrong filter name: {filter.Filter}");
                }
            }

            return preps.Select(p => mapper.Map<Prep, PrepDto>(p));
        }
        
        public static async Task<ProblemDetails> UpdatePreps(this IGenericRepository<Prep> repo, Prep[] preps)
        {
            ProblemDetails problemDetails = new ProblemDetails()
            {
                Detail = "Something went wrong while updating preps",
                Status = 500
            };

            try
            {
                repo.DbContext.Preps.UpdateRange(preps);

                var count = await repo.DbContext.SaveChangesAsync();

                if (count > 0)
                {
                    problemDetails.Detail = "Preps updated successfully";
                    problemDetails.Status = 200;
                    return problemDetails;
                }

                throw new Exception("Something went wrong while updating preps");
            }
            catch (Exception e)
            {
                problemDetails.Detail = e.Message;
                return problemDetails;
            }
        }
    }
}
    