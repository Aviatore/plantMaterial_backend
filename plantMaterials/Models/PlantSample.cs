using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class PlantSample
    {
        public PlantSample()
        {
            Preps = new HashSet<Prep>();
        }

        public Guid PlantSampleId { get; set; }
        public DateTime? CollectionDate { get; set; }
        public string SampleName { get; set; }
        public Guid? PopulationId { get; set; }
        public string PlantSampleDescription { get; set; }
        public Guid? TissueId { get; set; }
        public Guid? LocationId { get; set; }
        public Guid? DuplicationId { get; set; }
        public Guid? PhenotypeId { get; set; }
        public Guid? SampleWeightId { get; set; }
        public Guid? ShelfPositionId { get; set; }
        public Guid? ContainerTypeId { get; set; }

        public virtual Duplication Duplication { get; set; }
        public virtual Location Location { get; set; }
        public virtual Phenotype Phenotype { get; set; }
        public virtual Population Population { get; set; }
        public virtual SampleWeight SampleWeight { get; set; }
        public virtual Tissue Tissue { get; set; }
        public virtual ICollection<Prep> Preps { get; set; }
    }
}
