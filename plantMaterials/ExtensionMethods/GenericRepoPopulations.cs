using System.Collections.Generic;
using System.Linq;
using plantMaterials.DTOs;
using plantMaterials.Models;
using plantMaterials.Repositories;

namespace plantMaterials.ExtensionMethods
{
    public static class GenericRepoPopulations
    {
        public static IEnumerable<PopulationDto> GetAllPopulations(this IGenericRepository<Population> repo)
        {
            return repo.DbContext.Populations.Select(p => new PopulationDto()
            {
                PopulationId = p.PopulationId,
                PopulationName = p.PopulationName,
                PopulationDescription = p.PopulationDescription,
                SpeciesName = p.Species.SpeciesName
            });
        }
    }
}