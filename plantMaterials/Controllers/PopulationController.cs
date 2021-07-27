using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plantMaterials.ExtensionMethods;
using plantMaterials.Models;
using plantMaterials.Repositories;

namespace plantMaterials.Controllers
{
    [ApiController]
    public class PopulationController : ControllerBase
    {
        private IUnitOfWork _uow;

        public PopulationController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        [HttpGet("populations")]
        public async Task<IActionResult> ShowAllPopulations([FromQuery]string populationId=null)
        {
            try
            {
                if (populationId is null)
                {
                    var populations = _uow.Repository<Population>().GetAllPopulations();
                    return Ok(populations);
                }

                var analysisType = await _uow.Repository<Population>().Get(populationId);
                return Ok(analysisType);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: 500);
            }
        }

        [HttpGet("population-by-species")]
        public IActionResult ShowPopulationsBySpecies([FromQuery] string speciesId)
        {
            var populations = _uow.Repository<Population>().ShowPopulationsBySpecies(speciesId);
            return Ok(populations);
        }
        
        [HttpGet("population/remove")]
        public async Task<IActionResult> RemovePopulation([FromQuery]string populationId)
        {
            var result = await _uow.Repository<Population>().Remove(populationId);

            return Ok(result);
        }
        
        [HttpPost("population/edit")]
        public async Task<IActionResult> EditPopulation([FromBody]Population population)
        {
            if (population.PopulationId != Guid.Empty)
            {
                var result = await _uow.Repository<Population>().Edit(population, population.PopulationId.ToString());

                return Ok(result);
            }

            var resultAdd = await _uow.Repository<Population>().Add(population);
            return Ok(resultAdd);
        }
    }
}