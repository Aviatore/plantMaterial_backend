using System;
using System.Reflection.Metadata;

namespace plantMaterials.DTOs
{
    public class LocationDto
    {
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public Guid? ShelfPositionId { get; set; }
        public short? ShelfPositionName { get; set; }
        public Guid? LocationTypeId { get; set; }
        public string LocationTypeName { get; set; }
        public Guid? ContainerTypeId { get; set; }
        public string ContainerTypeName { get; set; }
        public string LocationDescription { get; set; }
    }
}