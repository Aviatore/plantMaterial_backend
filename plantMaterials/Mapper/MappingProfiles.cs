using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using plantMaterials.Models;

namespace plantMaterials.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Analysis, Analysis>();
            CreateMap<AnalysisType, AnalysisType>();
            CreateMap<ContainerType, ContainerType>();
            CreateMap<Duplication, Duplication>();
            CreateMap<Location, Location>();
            CreateMap<LocationType, LocationType>();
            CreateMap<Phenotype, Phenotype>();
            CreateMap<PlantSample, PlantSample>();
            CreateMap<Population, Population>();
            CreateMap<Prep, Prep>();
            CreateMap<PrepType, PrepType>();
            CreateMap<SampleWeight, SampleWeight>();
            CreateMap<ShelfPosition, ShelfPosition>();
            CreateMap<Species, Species>();
            CreateMap<SpeciesAlias, SpeciesAlias>();
            CreateMap<Tissue, Tissue>();
        }
    }
}