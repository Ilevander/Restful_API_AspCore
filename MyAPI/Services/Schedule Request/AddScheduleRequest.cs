using Doctors.Models;

namespace MyAPI.Models
{
    public class AddScheduleRequest
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // Foreign key for the Doctor entity (Many-to-One)
        public int DoctorID { get; set; }

        // Navigation property for the Doctor entity (Many-to-One)
        public Doctor? Doctor { get; set; }
    }
}
