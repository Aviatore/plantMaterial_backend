using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class SpeciesAlias
    {
        public Guid SpeciesAliasId { get; set; }
        public Guid? SpeciesId { get; set; }
        public string Alias { get; set; }

        public virtual Species Species { get; set; }
    }
}
