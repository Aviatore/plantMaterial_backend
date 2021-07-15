using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using plantMaterials.DTOs;
using plantMaterials.Models;
using plantMaterials.Repositories;

namespace plantMaterials.ExtensionMethods
{
    public static class GenericRepoSpecies
    {
        public static IEnumerable<SpeciesWithAliasDto> GetAllWithAliases(this IGenericRepository<Species> repo)
        {
            return repo.DbContext.Species.Include(p => p.SpeciesAliases).Select(p => repo.Mapper.Map<Species, SpeciesWithAliasDto>(p)).AsEnumerable();
        }
        
        public static SpeciesWithAliasDto GetWithAliases(this IGenericRepository<Species> repo, string speciesId)
        {
            var species = repo.DbContext.Species.Include(p => p.SpeciesAliases)
                .SingleOrDefault(p => p.SpeciesId == Guid.Parse(speciesId));

            return repo.Mapper.Map<Species, SpeciesWithAliasDto>(species);
        }
    }
}