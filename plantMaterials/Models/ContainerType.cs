using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class ContainerType
    {
        public Guid ContainerTypeId { get; set; }
        public string ContainerTypeName { get; set; }
        public string ContainerDescription { get; set; }
    }
}
