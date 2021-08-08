using System;

namespace plantMaterials.DTOs
{
    public class PrepDto
    {
        public Guid PrepId { get; set; }
        public string PrepName { get; set; }
        public Guid? PrepTypeId { get; set; }
        public Guid? PlantSampleId { get; set; }
        public Guid? PrepLocationId { get; set; }
        public string PrepDescription { get; set; }
        public int? VolumeUl { get; set; }
        public Guid? ShelfPositionId { get; set; }
        public Guid? ContainerTypeId { get; set; }
        public DateTime? IsolationDate { get; set; }
    }
}