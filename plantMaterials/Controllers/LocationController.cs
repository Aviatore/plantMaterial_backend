using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plantMaterials.Models;
using plantMaterials.Repositories;

namespace plantMaterials.Controllers
{
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public LocationController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        [HttpGet("containers")]
        public async Task<IActionResult> ShowAllContainers([FromQuery]string containerId=null)
        {
            try
            {
                if (containerId is null)
                {
                    var containers = _uow.Repository<ContainerType>().GetAll();
                    
                    return Ok(containers);
                }

                var container = await _uow.Repository<ContainerType>().Get(containerId);
                return Ok(container);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: 500);
            }
        }
        
        [HttpPost("container/add")]
        public async Task<IActionResult> AddContainer(ContainerType containerType)
        {
            var result = await _uow.Repository<ContainerType>().Add(containerType);

            return Ok(result);
        }
        
        [HttpGet("container/remove")]
        public async Task<IActionResult> RemoveContainer([FromQuery]string containerId)
        {
            var result = await _uow.Repository<ContainerType>().Remove(containerId);

            return Ok(result);
        }
        
        [HttpPost("container/edit")]
        public async Task<IActionResult> EditContainer([FromBody]ContainerType container)
        {
            Console.Out.WriteLine($"Container type name: {container.ContainerTypeName}");
            if (container.ContainerTypeId != Guid.Empty)
            {
                var result = await _uow.Repository<ContainerType>().Edit(container, container.ContainerTypeId.ToString());

                return Ok(result);
            }

            var resultAdd = await _uow.Repository<ContainerType>().Add(container);
            return Ok(resultAdd);
        }
    }
}