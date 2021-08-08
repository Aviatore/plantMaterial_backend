using AutoMapper;
using plantMaterials.DTOs;
using plantMaterials.Models;

namespace plantMaterials.Mapper
{
    public class PrepMapper : Profile
    {
        public PrepMapper()
        {
            CreateMap<Prep, PrepDto>();
        }
    }
}