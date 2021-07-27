using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

                    problemDetails.Detail = "Plant samples were added";
                    problemDetails.Status = 200;

                    return problemDetails;
                }

                throw new Exception("Plant sample array was empty");
            }
            catch (Exception e)
            {
                problemDetails.Detail = e.Message;
                return problemDetails;
            }
        }
    }
}