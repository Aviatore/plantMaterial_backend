using System.Linq;
using AutoMapper;
using plantMaterials.DTOs;
using plantMaterials.Models;

namespace plantMaterials.Mapper
{
    public class SpeciesMapper : Profile
    {
        public SpeciesMapper()
        {
            CreateMap<Species, Species>().ForMember(p => p.SpeciesId, opt => opt.Ignore());
            CreateMap<SpeciesAlias, SpeciesAlias>();
            CreateMap<Species, SpeciesWithAliasDto>().ConvertUsing(p => new SpeciesWithAliasDto()
            {
                SpeciesId = p.SpeciesId,
                SpeciesName = p.SpeciesName,
                SpeciesDescription = p.SpeciesDescription,
                SpeciesAliases = p.SpeciesAliases.Select(a => a.Alias).ToArray()
            });
            CreateMap<SpeciesWithAliasDto, Species>().ConvertUsing(p => new Species()
            {
                SpeciesName = p.SpeciesName,
                SpeciesDescription = p.SpeciesDescription
            });
        }
    }
}