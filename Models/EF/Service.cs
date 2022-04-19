using System;
using System.Collections.Generic;

namespace MedPro.Models.EF
{
    public partial class Service
    {
        public Service()
        {
            Doctorservices = new HashSet<Doctorservice>();
        }

        public int SId { get; set; }
        public string? SName { get; set; }
        public int TimeNeeded { get; set; }

        public virtual ICollection<Doctorservice> Doctorservices { get; set; }
    }
}
