using System;

namespace plantMaterials.DTOs
{
    public class PrepLocationDto
    {
        public string LocationName { get; set; }
        public short? ShelfPositionName { get; set; }
        public string ContainerTypeName { get; set; }
        public string PrepTypeName { get; set; }
        public string LocationTypeName { get; set; }
        public DateTime? IsolationDate { get; set; }
    }
}