using System;
using System.Collections.Generic;

namespace plantMaterials.DTOs
{
    public class SpeciesDto
    {
        public Guid SpeciesId { get; set; }
        public string SpeciesName { get; set; }
        public string SpeciesDescription { get; set; }
    }

    public class SpeciesWithAliasDto : SpeciesDto
    {
        public string[] SpeciesAliases { get; set; }
    }
}