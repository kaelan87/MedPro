using System;
using System.Collections.Generic;

namespace MedPro.Models.EF
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
            Availabilities = new HashSet<Availability>();
            Doctorservices = new HashSet<Doctorservice>();
        }

        public int DocId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Availability> Availabilities { get; set; }
        public virtual ICollection<Doctorservice> Doctorservices { get; set; }
    }
}
