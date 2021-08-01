using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using plantMaterials.DTOs;
using plantMaterials.Models;
using plantMaterials.Repositories;

namespace plantMaterials.ExtensionMethods
{
    public static class GenericPlantSample
    {
        public static async Task<ProblemDetails> AddPlantSamples(this IGenericRepository<PlantSample> repo, PlantSample[] plantSamples)
        {
            ProblemDetails problemDetails = new ProblemDetails()
            {
                Detail = "Something went wrong while adding plant samples",
                Status = 500
            };

            try
            {
                if (plantSamples.Any())
                {
                    await repo.DbContext.AddRangeAsync(plantSamples.AsEnumerable());

                    var count = await repo.DbContext.SaveChangesAsync();

                    if (count > 0)
                    {
                        problemDetails.Detail = "Plant samples were added";
                        problemDetails.Status = 200;

                        return problemDetails;
                    }

                    throw new Exception("Something went wrong while adding plant samples");
                }

                throw new Exception("Plant sample array was empty");
            }
            catch (Exception e)
            {
                problemDetails.Detail = e.Message;
                return problemDetails;
            }
        }

        public static IEnumerable<PlantSampleDto> GetPlantSample(this IGenericRepository<PlantSample> repo,
            PlantSampleFiltersDto[] filters)
        {
            var plantSamples = repo.GetAll();

            foreach (var filter in filters)
            {
                switch (filter.Filter)
                {
                    case "population":
                        plantSamples = filter.Bool switch
                        {
                            0 => plantSamples.Where(p => p.PopulationId == filter.PopulationId),
                            1 => plantSamples.Where(p => p.PopulationId != filter.PopulationId),
                            _ => throw new ArgumentOutOfRangeException($"Not expected bool value: {filter.Bool}")
                        };
                        break;
                    case "tissue":
                        plantSamples = filter.Bool switch
                        {
                            0 => plantSamples.Where(p => p.TissueId == filter.TissueId),
                            1 => plantSamples.Where(p => p.TissueId != filter.TissueId),
                            _ => throw new ArgumentOutOfRangeException($"Not expected bool value: {filter.Bool}")
                        };
                        break;
                    case "duplication":
                        plantSamples = filter.Bool switch
                        {
                            0 => plantSamples.Where(p => p.DuplicationId == filter.DuplicationId),
                            1 => plantSamples.Where(p => p.DuplicationId != filter.DuplicationId),
                            _ => throw new ArgumentOutOfRangeException($"Not expected bool value: {filter.Bool}")
                        };
                        break;
                    case "location":
                        plantSamples = filter.Bool switch
                        {
                            0 => plantSamples.Where(p => p.LocationId == filter.LocationId),
                            1 => plantSamples.Where(p => p.LocationId != filter.LocationId),
                            _ => throw new ArgumentOutOfRangeException($"Not expected bool value: {filter.Bool}")
                        };
                        break;
                    case "shelfPosition":
                        plantSamples = filter.Bool switch
                        {
                            0 => plantSamples.Where(p => p.ShelfPositionId == filter.ShelfPositionId),
                            1 => plantSamples.Where(p => p.ShelfPositionId != filter.ShelfPositionId),
                            _ => throw new ArgumentOutOfRangeException($"Not expected bool value: {filter.Bool}")
                        };
                        break;
                    case "containerType":
                        plantSamples = filter.Bool switch
                        {
                            0 => plantSamples.Where(p => p.ContainerTypeId == filter.ContainerTypeId),
                            1 => plantSamples.Where(p => p.ContainerTypeId != filter.ContainerTypeId),
                            _ => throw new ArgumentOutOfRangeException($"Not expected bool value: {filter.Bool}")
                        };
                        break;
                    default:
                        throw new ArgumentException($"Wrong filter name: {filter.Filter}");
                }
            }

            return plantSamples.Select(p => new PlantSampleDto()
            {
                PlantSampleId = p.PlantSampleId,
                CollectionDate = p.CollectionDate,
                SampleName = p.SampleName,
                PopulationId = p.PopulationId,
                PlantSampleDescription = p.PlantSampleDescription,
                TissueId = p.TissueId,
                LocationId = p.LocationId,
                DuplicationId = p.DuplicationId,
                PhenotypeId = p.PhenotypeId,
                SampleWeight = p.SampleWeight,
                ShelfPositionId = p.ShelfPositionId,
                ContainerTypeId = p.ContainerTypeId,
                PrepsLocation = p.Preps.Select(p => new PrepLocationDto()
                {
                    PrepTypeName = p.PrepType.PrepTypeName,
                    LocationName = p.PrepLocation.LocationName,
                    ShelfPositionName = p.ShelfPosition.ShelfPositionName,
                    ContainerTypeName = p.ContainerType.ContainerTypeName,
                    LocationTypeName = p.PrepLocation.LocationType.LocationTypeName,
                    IsolationDate = p.IsolationDate
                }).AsEnumerable()
            });
        }

        public static async Task<ProblemDetails> UpdatePlantSamples(this IGenericRepository<PlantSample> repo, PlantSample[] plantSamples)
        {
            ProblemDetails problemDetails = new ProblemDetails()
            {
                Detail = "Something went wrong while updating plant samples",
                Status = 500
            };

            try
            {
                repo.DbContext.PlantSamples.UpdateRange(plantSamples);

                var count = await repo.DbContext.SaveChangesAsync();

                if (count > 0)
                {
                    problemDetails.Detail = "Plant samples updated successfully";
                    problemDetails.Status = 200;
                    return problemDetails;
                }

                throw new Exception("Something went wrong while updating plant samples");
            }
            catch (Exception e)
            {
                problemDetails.Detail = e.Message;
                return problemDetails;
            }
        }
    }
}