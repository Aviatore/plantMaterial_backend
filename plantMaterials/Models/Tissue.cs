using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class Tissue
    {
        public Tissue()
        {
            PlantSamples = new HashSet<PlantSample>();
        }

        public Guid TissueId { get; set; }
        public string TissueName { get; set; }

        public virtual ICollection<PlantSample> PlantSamples { get; set; }
    }
}
