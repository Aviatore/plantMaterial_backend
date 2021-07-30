using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class ContainerType
    {
        public ContainerType()
        {
            Preps = new HashSet<Prep>();
        }

        public Guid ContainerTypeId { get; set; }
        public string ContainerTypeName { get; set; }
        public string ContainerDescription { get; set; }

        public virtual ICollection<Prep> Preps { get; set; }
    }
}
