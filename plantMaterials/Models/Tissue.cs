using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class Tissue
    {
        public Tissue()
        {
            Populations = new HashSet<Population>();
        }

        public Guid TissueId { get; set; }
        public string TissueName { get; set; }

        public virtual ICollection<Population> Populations { get; set; }
    }
}
