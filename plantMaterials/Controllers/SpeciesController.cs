using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plantMaterials.ExtensionMethods;
using plantMaterials.Models;
using plantMaterials.Repositories;

namespace plantMaterials.Controllers
{
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public SpeciesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("species")]
        public IActionResult GetAllSpecies([FromQuery]bool alias=false, [FromQuery]string speciesId=null)
        {
            if (alias)
            {
                if (speciesId is null)
                {
                    var allSpeciesWithAliases = _uow.Repository<Species>().GetAllWithAliases().AsQueryable();
                    return Ok(allSpeciesWithAliases);
                }
                
                var speciesWithAliases = _uow.Repository<Species>().GetWithAliases(speciesId);
                return Ok(speciesWithAliases);
            }
            
            var species = _uow.Repository<Species>().GetAll().AsEnumerable();
            return Ok(species);
        }
        
        [HttpGet("species/{speciesId}/remove")]
        public async Task<IActionResult> RemoveSpecies(string speciesId)
        {
            var result = await _uow.Repository<Species>().Remove(speciesId);

            return Ok(result);
        }
    }
}