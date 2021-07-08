using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class Species
    {
        public Species()
        {
            Populations = new HashSet<Population>();
            SpeciesAliases = new HashSet<SpeciesAlias>();
        }

        public Guid SpeciesId { get; set; }
        public string SpeciesName { get; set; }
        public string SpeciesDescription { get; set; }

        public virtual ICollection<Population> Populations { get; set; }
        public virtual ICollection<SpeciesAlias> SpeciesAliases { get; set; }
    }
}
