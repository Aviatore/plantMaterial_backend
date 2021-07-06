using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class ContainerType
    {
        public ContainerType()
        {
            Locations = new HashSet<Location>();
        }

        public Guid ContainerTypeId { get; set; }
        public string ContainerTypeName { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
