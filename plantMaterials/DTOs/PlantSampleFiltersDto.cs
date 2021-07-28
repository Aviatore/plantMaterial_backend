using System;

namespace plantMaterials.DTOs
{
    public class PlantSampleFiltersDto
    {
        public int Bool { get; set; }
        public string Filter { get; set; }
        public Guid PopulationId { get; set; }
        public Guid TissueId { get; set; }
        public Guid DuplicationId { get; set; }
        public Guid LocationId { get; set; }
        public Guid ShelfPositionId { get; set; }
        public Guid ContainerTypeId { get; set; }
    }
}