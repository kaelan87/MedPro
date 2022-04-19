﻿using System;
using System.Collections.Generic;

namespace MedPro.Models.EF
{
    public partial class Appointment
    {
        public int ApptId { get; set; }
        public int PId { get; set; }
        public int DocId { get; set; }
        public int TimeId { get; set; }

        public virtual Doctor Doc { get; set; } = null!;
        public virtual Patient PIdNavigation { get; set; } = null!;
        public virtual Time Time { get; set; } = null!;
    }
}
