using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class Location
    {
        public Location()
        {
            PlantSamples = new HashSet<PlantSample>();
            Preps = new HashSet<Prep>();
        }

        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public Guid? LocationTypeId { get; set; }
        public string LocationDescription { get; set; }

        public virtual LocationType LocationType { get; set; }
        public virtual ICollection<PlantSample> PlantSamples { get; set; }
        public virtual ICollection<Prep> Preps { get; set; }
    }
}
