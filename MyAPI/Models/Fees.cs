﻿using System.ComponentModel.DataAnnotations;

namespace Doctors.Models
{
    public class Fees
    {
        public Guid FeeID { get; set; }
        public decimal Amount { get; set; }
        public int DoctorID { get; set; }

        // Navigation property for the Doctor entity (Many-to-One)
        public Doctor? Doctor { get; set; }
    }
}
