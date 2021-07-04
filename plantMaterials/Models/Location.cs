using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class Location
    {
        public Location()
        {
            Populations = new HashSet<Population>();
        }

        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public string ShelfPosition { get; set; }

        public virtual ICollection<Population> Populations { get; set; }
    }
}
