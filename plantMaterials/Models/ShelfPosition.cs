using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class ShelfPosition
    {
        public ShelfPosition()
        {
            Preps = new HashSet<Prep>();
        }

        public Guid ShelfPositionId { get; set; }
        public short? ShelfPositionName { get; set; }

        public virtual ICollection<Prep> Preps { get; set; }
    }
}
