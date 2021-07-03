using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class Analysis
    {
        public Guid AnalysisId { get; set; }
        public DateTime? AnalysisDate { get; set; }
        public Guid AnalysisTypeId { get; set; }
        public Guid PlantSampleId { get; set; }
        public string Description { get; set; }

        public virtual AnalysisType AnalysisType { get; set; }
        public virtual PlantSample PlantSample { get; set; }
    }
}
