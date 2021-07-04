using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class PlantSample
    {
        public PlantSample()
        {
            Analyses = new HashSet<Analysis>();
        }

        public Guid PlantSampleId { get; set; }
        public DateTime? CollectionDate { get; set; }
        public string PlantName { get; set; }
        public Guid? PopulationId { get; set; }
        public string Description { get; set; }
        public Guid? TissueId { get; set; }

        public virtual Population Population { get; set; }
        public virtual Tissue Tissue { get; set; }
        public virtual ICollection<Analysis> Analyses { get; set; }
    }
}
