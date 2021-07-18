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
        public async Task<IActionResult> ShowAllTissues([FromQuery]string tissueId=null)
        {
            try
            {
                if (tissueId is null)
                {
                    var tissues = _uow.Repository<Tissue>().GetAll();
                    // var tissues = _uow.TissueRepository.GetAllTissues();
                    return Ok(tissues);
                }

                var tissue = await _uow.Repository<Tissue>().Get(tissueId);
                return Ok(tissue);
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
        
        [HttpGet("tissue/remove")]
        public async Task<IActionResult> RemoveTissue([FromQuery]string tissueId)
        {
            var result = await _uow.Repository<Tissue>().Remove(tissueId);
            /*var result = await _uow.TissueRepository.RemoveTissue(tissueId);*/

            return Ok(result);
        }

        [HttpPost("tissue/edit")]
        public async Task<IActionResult> EditTissue([FromBody]Tissue tissue)
        {
            Console.Out.WriteLine($"Tissue name: {tissue.TissueName}");
            if (tissue.TissueId != Guid.Empty)
            {
                var result = await _uow.Repository<Tissue>().Edit(tissue, tissue.TissueId.ToString());
                /*var result = await _uow.TissueRepository.EditTissueName(tissue);*/

                return Ok(result);
            }

            var resultAdd = await _uow.Repository<Tissue>().Add(tissue);
            return Ok(resultAdd);
        }
    }
}