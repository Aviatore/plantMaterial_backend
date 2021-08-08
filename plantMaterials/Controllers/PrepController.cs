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
    public class PrepController : ControllerBase
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;
        
        public PrepController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        
        [HttpPost("prep/add")]
        public async Task<IActionResult> AddPrep([FromBody]Prep[] preps)
        {
            var result = await _uow.Repository<Prep>().AddPrep(preps);

            return Ok(result);
        }

        [HttpGet("prep-types/get")]
        public IActionResult GetPrepTypes()
        {
            var result = _uow.Repository<PrepType>().GetAll();
            return Ok(result);
        }
        
        [HttpPost("prep/get")]
        public IActionResult GetPrepTypes([FromBody] PlantSampleFiltersDto[] filters)
        {
            var result = _uow.Repository<Prep>().GetPreps(filters, _mapper);
            return Ok(result);
        }
        
        [HttpPost("prep/update")]
        public async Task<IActionResult> UpdatePrep([FromBody] Prep[] preps)
        {
            var result = await _uow.Repository<Prep>().UpdatePreps(preps);

            return Ok(result);
        }
    }
}