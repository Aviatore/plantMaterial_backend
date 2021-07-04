using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using plantMaterials.Models;

namespace plantMaterials.Repositories
{
    public class TissueRepository : ITissueRepository
    {
        private PlantMaterialsContext _dbContext;

        public TissueRepository(PlantMaterialsContext plantMaterialsContext)
        {
            _dbContext = plantMaterialsContext;
        }

        public IEnumerable<Tissue> GetAllTissues()
        {
            return _dbContext.Tissues.AsNoTracking().AsEnumerable();
        }

        public async Task<ProblemDetails> AddTissue(string tissueName)
        {
            ProblemDetails problemDetails = new ProblemDetails()
            {
                Detail = "An error occured",
                Status = 500
            };

            try
            {
                if (tissueName is null)
                {
                    throw new Exception("Tissue name cannot be empty");
                }

                var newTissue = new Tissue()
                {
                    TissueName = tissueName
                };
                
                _dbContext.Tissues.Add(newTissue);

                await _dbContext.SaveChangesAsync();

                problemDetails.Detail = "New tissue added successfully";
                problemDetails.Status = 200;

                return problemDetails;
            }
            catch (Exception e)
            {
                problemDetails.Detail = e.Message;
                return problemDetails;
            }
        }
        
        public async Task<ProblemDetails> RemoveTissue(string tissueId)
        {
            ProblemDetails problemDetails = new ProblemDetails()
            {
                Detail = "An error occured",
                Status = 500
            };

            try
            {
                if (tissueId is null)
                {
                    throw new Exception("Tissue Id cannot be empty");
                }

                Guid id;
                if (!Guid.TryParse(tissueId, out id))
                {
                    throw new Exception("Tissue Id was provided in the wrong format");
                }

                var tissueToRemove = _dbContext.Tissues.SingleOrDefault(p => p.TissueId == id);

                if (tissueToRemove is null)
                {
                    throw new Exception("Tissue was not found in the database");
                }

                _dbContext.Tissues.Remove(tissueToRemove);

                if (!(await _dbContext.SaveChangesAsync() > 0))
                {
                    throw new Exception("Something went wrong during tissue removal");
                }

                problemDetails.Detail = "New tissue removed successfully";
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