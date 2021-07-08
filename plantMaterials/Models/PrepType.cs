using System;
using System.Collections.Generic;

#nullable disable

namespace plantMaterials.Models
{
    public partial class PrepType
    {
        public PrepType()
        {
            Preps = new HashSet<Prep>();
        }

        public Guid PrepTypeId { get; set; }
        public string PrepTypeName { get; set; }
        public string PrepDescription { get; set; }

        public virtual ICollection<Prep> Preps { get; set; }
    }
}
