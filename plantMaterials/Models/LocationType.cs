using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class LocationType
    {
        public LocationType()
        {
            Locations = new HashSet<Location>();
        }

        public Guid LocationTypeId { get; set; }
        public string LocationTypeName { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
