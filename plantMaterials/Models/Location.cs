using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class Location
    {
        public Location()
        {
            PlantSamples = new HashSet<PlantSample>();
        }

        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public Guid? ShelfPositionId { get; set; }
        public Guid? LocationTypeId { get; set; }
        public Guid? ContainerTypeId { get; set; }

        public virtual ContainerType ContainerType { get; set; }
        public virtual LocationType LocationType { get; set; }
        public virtual ShelfPosition ShelfPosition { get; set; }
        public virtual ICollection<PlantSample> PlantSamples { get; set; }
    }
}
