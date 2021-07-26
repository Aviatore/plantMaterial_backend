using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plantMaterials.Models;
using plantMaterials.Repositories;

namespace plantMaterials.Controllers
{
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private IUnitOfWork _uow;

        public AnalysisController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        [HttpGet("analysis-types")]
        public async Task<IActionResult> ShowAllAnalysisTypes([FromQuery]string analysisTypeId=null)
        {
            try
            {
                if (analysisTypeId is null)
                {
                    var analysisTypes = _uow.Repository<AnalysisType>().GetAll();
                    return Ok(analysisTypes);
                }

                var analysisType = await _uow.Repository<AnalysisType>().Get(analysisTypeId);
                return Ok(analysisType);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: 500);
            }
        }
        
        [HttpPost("analysis-type/add")]
        public async Task<IActionResult> AddAnalysisType(AnalysisType analysisType)
        {
            var result = await _uow.Repository<AnalysisType>().Add(analysisType);

            return Ok(result);
        }
        
        [HttpGet("analysis-type/remove")]
        public async Task<IActionResult> RemoveAnalysisType([FromQuery]string analysisTypeId)
        {
            var result = await _uow.Repository<AnalysisType>().Remove(analysisTypeId);

            return Ok(result);
        }
        
        [HttpPost("analysis-type/edit")]
        public async Task<IActionResult> EditAnalysisType([FromBody]AnalysisType analysisType)
        {
            if (analysisType.AnalysisTypeId != Guid.Empty)
            {
                var result = await _uow.Repository<AnalysisType>().Edit(analysisType, analysisType.AnalysisTypeId.ToString());

                return Ok(result);
            }

            var resultAdd = await _uow.Repository<AnalysisType>().Add(analysisType);
            return Ok(resultAdd);
        }
    }
}