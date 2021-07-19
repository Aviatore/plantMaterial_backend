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
        
        
        [HttpGet("location-types")]
        public async Task<IActionResult> ShowAllLocationTypes([FromQuery]string locationTypeId=null)
        {
            try
            {
                if (locationTypeId is null)
                {
                    var locationTypes = _uow.Repository<LocationType>().GetAll();
                    
                    return Ok(locationTypes);
                }

                var locationType = await _uow.Repository<LocationType>().Get(locationTypeId);
                return Ok(locationType);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: 500);
            }
        }
        
        [HttpPost("location-types/add")]
        public async Task<IActionResult> AddLocationType(LocationType locationType)
        {
            var result = await _uow.Repository<LocationType>().Add(locationType);

            return Ok(result);
        }
        
        [HttpGet("location-types/remove")]
        public async Task<IActionResult> RemoveLocationType([FromQuery]string locationTypeId)
        {
            var result = await _uow.Repository<LocationType>().Remove(locationTypeId);

            return Ok(result);
        }
        
        [HttpPost("location-types/edit")]
        public async Task<IActionResult> EditLocationType([FromBody]LocationType locationType)
        {
            Console.Out.WriteLine($"Container type name: {locationType.LocationTypeName}");
            if (locationType.LocationTypeId != Guid.Empty)
            {
                var result = await _uow.Repository<LocationType>().Edit(locationType, locationType.LocationTypeId.ToString());

                return Ok(result);
            }

            var resultAdd = await _uow.Repository<LocationType>().Add(locationType);
            return Ok(resultAdd);
        }
        
        
        [HttpGet("shelf-positions")]
        public async Task<IActionResult> ShowAllShelfPositions([FromQuery]string shelfPositionId=null)
        {
            try
            {
                if (shelfPositionId is null)
                {
                    var shelfPositions = _uow.Repository<ShelfPosition>().GetAll();
                    
                    return Ok(shelfPositions);
                }

                var locationType = await _uow.Repository<ShelfPosition>().Get(shelfPositionId);
                return Ok(locationType);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: 500);
            }
        }
        
        [HttpPost("shelf-positions/add")]
        public async Task<IActionResult> AddShelfPosition(ShelfPosition shelfPosition)
        {
            var result = await _uow.Repository<ShelfPosition>().Add(shelfPosition);

            return Ok(result);
        }
        
        [HttpGet("shelf-positions/remove")]
        public async Task<IActionResult> RemoveShelfPosition([FromQuery]string shelfPositionId)
        {
            var result = await _uow.Repository<ShelfPosition>().Remove(shelfPositionId);

            return Ok(result);
        }
        
        [HttpPost("shelf-positions/edit")]
        public async Task<IActionResult> EditShelfPosition([FromBody]ShelfPosition shelfPosition)
        {
            Console.Out.WriteLine($"Shelf position name: {shelfPosition.ShelfPositionName.ToString()}");
            if (shelfPosition.ShelfPositionId != Guid.Empty)
            {
                var result = await _uow.Repository<ShelfPosition>().Edit(shelfPosition, shelfPosition.ShelfPositionId.ToString());

                return Ok(result);
            }

            var resultAdd = await _uow.Repository<ShelfPosition>().Add(shelfPosition);
            return Ok(resultAdd);
        }
    }
}