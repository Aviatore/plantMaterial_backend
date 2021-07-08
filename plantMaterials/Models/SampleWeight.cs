using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class SampleWeight
    {
        public SampleWeight()
        {
            PlantSamples = new HashSet<PlantSample>();
        }

        public Guid WeightId { get; set; }
        public string WeightName { get; set; }
        public string WeightDescription { get; set; }

        public virtual ICollection<PlantSample> PlantSamples { get; set; }
    }
}
