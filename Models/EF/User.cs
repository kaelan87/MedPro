using System;
using System.Collections.Generic;

namespace MedPro.Models.EF
{
    public partial class User
    {
        public User()
        {
            Doctors = new HashSet<Doctor>();
            Patients = new HashSet<Patient>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Role { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
