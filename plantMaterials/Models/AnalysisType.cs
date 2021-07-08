using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class AnalysisType
    {
        public AnalysisType()
        {
            Analyses = new HashSet<Analysis>();
        }

        public Guid AnalysisTypeId { get; set; }
        public string AnalysisTypeName { get; set; }
        public string AnalysisDescription { get; set; }

        public virtual ICollection<Analysis> Analyses { get; set; }
    }
}
