﻿using System.ComponentModel.DataAnnotations;

namespace Doctors.Models
{
    public class Schedule
    {
        public Guid ScheduleID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // Foreign key for the Doctor entity (Many-to-One)
        public int DoctorID { get; set; }

        // Navigation property for the Doctor entity (Many-to-One)
        public Doctor? Doctor { get; set; }
    }

}
