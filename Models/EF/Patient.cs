using System;
using System.Collections.Generic;

namespace MedPro.Models.EF
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int PId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
