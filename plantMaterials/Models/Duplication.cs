using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class Duplication
    {
        public Duplication()
        {
            PlantSamples = new HashSet<PlantSample>();
            Preps = new HashSet<Prep>();
        }

        public Guid DuplicationId { get; set; }
        public short? DuplicationName { get; set; }

        public virtual ICollection<PlantSample> PlantSamples { get; set; }
        public virtual ICollection<Prep> Preps { get; set; }
    }
}
