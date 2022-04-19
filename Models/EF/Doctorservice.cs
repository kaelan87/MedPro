using System;
using System.Collections.Generic;

namespace MedPro.Models.EF
{
    public partial class Doctorservice
    {
        public int DsId { get; set; }
        public int DocId { get; set; }
        public int SId { get; set; }

        public virtual Doctor Doc { get; set; } = null!;
        public virtual Service SIdNavigation { get; set; } = null!;
    }
}
