using Doctors.Models;

namespace MyAPI.Models
{
    public class AddBookingRequest
    {
        public DateTime BookingDate { get; set; }
        // Foreign key for the Patient entity
        public int PatientID { get; set; }
        public Patient? Patient { get; set; }

        // Foreign key for the Clinic entity
        public int ClinicID { get; set; }
        public Clinic? Clinic { get; set; }
    }
}
