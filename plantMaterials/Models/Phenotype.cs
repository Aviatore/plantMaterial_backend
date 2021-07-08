using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class Phenotype
    {
        public Phenotype()
        {
            PlantSamples = new HashSet<PlantSample>();
        }

        public Guid PhenotypeId { get; set; }
        public string PhenotypeName { get; set; }
        public string PhenotypeDescription { get; set; }

        public virtual ICollection<PlantSample> PlantSamples { get; set; }
    }
}
