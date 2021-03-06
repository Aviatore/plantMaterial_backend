using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plantMaterials.DTOs;
using plantMaterials.ExtensionMethods;
using plantMaterials.Models;
using plantMaterials.Repositories;

namespace plantMaterials.Controllers
{
    [ApiController]
    public class PlantSampleController : ControllerBase
    {
        private IUnitOfWork _uow;

        public PlantSampleController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        [HttpGet("plant-sample/remove")]
        public async Task<IActionResult> RemovePlantSample([FromQuery]string plantSampleId)
        {
            var result = await _uow.Repository<PlantSample>().Remove(plantSampleId);

            return Ok(result);
        }
        
        [HttpPost("plant-sample/edit")]
        public async Task<IActionResult> EditPlantSample([FromBody]PlantSample plantSample)
        {
            var result = await _uow.Repository<PlantSample>()
                .Edit(plantSample, plantSample.PlantSampleId.ToString());

            return Ok(result);
        }
        
        [HttpPost("plant-sample/add")]
        public async Task<IActionResult> EditPlantSample([FromBody]PlantSample[] plantSamples)
        {
            var result = await _uow.Repository<PlantSample>().AddPlantSamples(plantSamples);

            return Ok(result);
        }

        [HttpPost("plant-sample/get")]
        public IActionResult GetPlantSample([FromBody] PlantSampleFiltersDto[] filters)
        {
            var result = _uow.Repository<PlantSample>().GetPlantSample(filters);

            return Ok(result);
        }
        
        [HttpPost("plant-sample/update")]
        public async Task<IActionResult> UpdatePlantSample([FromBody] PlantSample[] plantSamples)
        {
            var result = await _uow.Repository<PlantSample>().UpdatePlantSamples(plantSamples);

            return Ok(result);
        }
    }
}