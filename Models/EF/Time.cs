using System;
using System.Collections.Generic;

namespace MedPro.Models.EF
{
    public partial class Time
    {
        public Time()
        {
            Appointments = new HashSet<Appointment>();
            Availabilities = new HashSet<Availability>();
        }

        public int TimeId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Availability> Availabilities { get; set; }
    }
}
