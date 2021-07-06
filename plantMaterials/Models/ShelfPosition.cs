using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class ShelfPosition
    {
        public ShelfPosition()
        {
            Locations = new HashSet<Location>();
        }

        public Guid ShelfPositionId { get; set; }
        public short? ShelfPositionName { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
