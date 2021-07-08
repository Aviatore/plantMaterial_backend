using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class Prep
    {
        public Prep()
        {
            Analyses = new HashSet<Analysis>();
        }

        public Guid PrepId { get; set; }
        public string PrepName { get; set; }
        public Guid? PrepTypeId { get; set; }
        public Guid? PlantSampleId { get; set; }
        public Guid? PrepLocationId { get; set; }
        public string PrepDescription { get; set; }
        public int? VolumeUl { get; set; }

        public virtual PlantSample PlantSample { get; set; }
        public virtual Location PrepLocation { get; set; }
        public virtual PrepType PrepType { get; set; }
        public virtual ICollection<Analysis> Analyses { get; set; }
    }
}
