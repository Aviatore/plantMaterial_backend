using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using plantMaterials.DTOs;
using plantMaterials.ExtensionMethods;
using plantMaterials.Models;
using plantMaterials.Repositories;

namespace plantMaterials.Controllers
{
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public SpeciesController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
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

        [HttpPost("species/{speciesId}/edit")]
        public async Task<IActionResult> EditSpecies(string speciesId, [FromBody]SpeciesWithAliasDto species)
        {
            if (!Guid.TryParse(speciesId, out var id))
            {
                ProblemDetails problemDetails = new ProblemDetails()
                {
                    Detail = "Provided id is not valid",
                    Status = 500
                };
                
                return Ok(problemDetails);
            }
            
            species.SpeciesId = id;
            
            var aliasesBySpeciesId = _uow.Repository<SpeciesAlias>().GetAll().Where(p => p.SpeciesId.ToString().Equals(speciesId)).ToList();
            var result = await _uow.Repository<Species>().EditWithAliases(species, aliasesBySpeciesId);

            return Ok(result);
        }

        [HttpPost("species/new")]
        public async Task<IActionResult> AddSpecies(SpeciesWithAliasDto speciesWithAliasDto)
        {
            var result = await _uow.Repository<Species>().AddSpecies(speciesWithAliasDto);

            return Ok(result);
        }
    }
}