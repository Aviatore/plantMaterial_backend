using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plantMaterials.ExtensionMethods;
using plantMaterials.Models;
using plantMaterials.Repositories;

namespace plantMaterials.Controllers
{
    [ApiController]
    public class PrepController : ControllerBase
    {
        private IUnitOfWork _uow;

        public PrepController(IUnitOfWork uow)
        {
            _uow = uow;
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
    }
}