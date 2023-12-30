﻿using Doctors.Models;

namespace MyAPI.Services.Doctor_Request
{
    public class UpdateAppointmentRequest
    {
        public DateTime AppointmentDate { get; set; }
        public string? Description { get; set; }

        // Foreign key for the Doctor entity
        public int DoctorID { get; set; }
        public Doctor? Doctor { get; set; }

        // Foreign key for the Patient entity
        public int PatientID { get; set; }
        public Patient? Patient { get; set; }
    }
}
