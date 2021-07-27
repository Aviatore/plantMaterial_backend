using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plantMaterials.Models;
using plantMaterials.Repositories;

namespace plantMaterials.Controllers
{
    [ApiController]
    public class DuplicationController : ControllerBase
    {
        private IUnitOfWork _uow;

        public DuplicationController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        [HttpGet("duplications")]
        public IActionResult GetAllDuplications()
        {
            var analysisType = _uow.Repository<Duplication>().GetAll();
            return Ok(analysisType);
        }
    }
}