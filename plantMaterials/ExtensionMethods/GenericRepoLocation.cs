using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using plantMaterials.DTOs;
using plantMaterials.Models;
using plantMaterials.Repositories;

namespace plantMaterials.ExtensionMethods
{
    public static class GenericRepoLocation
    {
        public static IEnumerable<LocationDto> GetAllLocations(this IGenericRepository<Location> repo)
        {
            return repo.DbContext.Locations.Select(p => new LocationDto()
            {
                LocationId = p.LocationId,
                LocationName = p.LocationName,
                LocationTypeId = p.LocationTypeId,
                LocationTypeName = p.LocationType.LocationTypeName,
                LocationDescription = p.LocationDescription
            });
        }
    }
}