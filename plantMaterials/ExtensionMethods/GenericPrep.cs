using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}
    