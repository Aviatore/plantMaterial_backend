using System;

namespace plantMaterials.DTOs
{
    public class PopulationDto
    {
        public Guid PopulationId { get; set; }
        public string PopulationName { get; set; }
        public string PopulationDescription { get; set; }
        public string SpeciesName { get; set; }
    }
}