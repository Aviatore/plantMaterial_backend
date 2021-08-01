using System;
using System.Collections.Generic;
using plantMaterials.Models;

namespace plantMaterials.DTOs
{
    public class PlantSampleDto
    {
        public Guid PlantSampleId { get; set; }
        public DateTime? CollectionDate { get; set; }
        public string SampleName { get; set; }
        public Guid? PopulationId { get; set; }
        public string PlantSampleDescription { get; set; }
        public Guid? TissueId { get; set; }
        public Guid? LocationId { get; set; }
        public Guid? DuplicationId { get; set; }
        public Guid? PhenotypeId { get; set; }
        public string SampleWeight { get; set; }
        public Guid? ShelfPositionId { get; set; }
        public Guid? ContainerTypeId { get; set; }
        public IEnumerable<PrepLocationDto> PrepsLocation { get; set; }
    }
}