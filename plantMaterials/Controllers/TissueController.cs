using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plantMaterials.Repositories;

namespace plantMaterials.Controllers
{
    [ApiController]
    public class TissueController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public TissueController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        [HttpGet("tissues")]
        public IActionResult Index()
        {
            try
            {
                var tissues = _uow.TissueRepository.GetAllTissues();
                return Ok(tissues);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: 500);
            }
        }

        [HttpPost("tissue/add/{tissueName}")]
        public async Task<IActionResult> AddTissue(string tissueName)
        {
            var result = await _uow.TissueRepository.AddTissue(tissueName);

            return Ok(result);
        }
        
        [HttpPost("tissue/remove/{tissueId}")]
        public async Task<IActionResult> RemoveTissue(string tissueId)
        {
            var result = await _uow.TissueRepository.RemoveTissue(tissueId);

            return Ok(result);
        }
    }
}