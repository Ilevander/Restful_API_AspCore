using Doctors.Models;

namespace MyAPI.Services.Patient_Request
{
    public class AddClinicRequest
    {
        public string? ClinicName { get; set; }
        public string? Location { get; set; }

        // Navigation property for the Doctor entity (One-to-Many)
        public ICollection<Doctor>? Doctors { get; set; }

        // Navigation property for the Booking entity (One-to-Many)
        public ICollection<Booking>? Bookings { get; set; }
    }
}
