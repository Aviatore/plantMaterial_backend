using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class Population
    {
        public Population()
        {
            PlantSamples = new HashSet<PlantSample>();
        }

        public Guid PopulationId { get; set; }
        public string PopulationName { get; set; }
        public string PopulationDescription { get; set; }
        public Guid? SpeciesId { get; set; }

        public virtual Species Species { get; set; }
        public virtual ICollection<PlantSample> PlantSamples { get; set; }
    }
}
