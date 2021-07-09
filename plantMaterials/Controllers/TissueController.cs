using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plantMaterials.Models;
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
        public IActionResult ShowAllTissues()
        {
            try
            {
                var tissues = _uow.Repository<Tissue>().GetAll();
                // var tissues = _uow.TissueRepository.GetAllTissues();
                return Ok(tissues);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: 500);
            }
        }

        [HttpPost("tissue/add")]
        public async Task<IActionResult> AddTissue(Tissue tissue)
        {
            var result = await _uow.Repository<Tissue>().Add(tissue);
            /*var result = await _uow.TissueRepository.AddTissue(tissue);*/

            return Ok(result);
        }
        
        [HttpPost("tissue/remove/{tissueId}")]
        public async Task<IActionResult> RemoveTissue(string tissueId)
        {
            var result = await _uow.Repository<Tissue>().Remove(tissueId);
            /*var result = await _uow.TissueRepository.RemoveTissue(tissueId);*/

            return Ok(result);
        }

        [HttpPut("tissue/edit")]
        public async Task<IActionResult> EditTissue(Tissue tissue)
        {
            var result = await _uow.Repository<Tissue>().Edit(tissue, tissue.TissueId.ToString());
            /*var result = await _uow.TissueRepository.EditTissueName(tissue);*/

            return Ok(result);
        }
    }
}