using Doctors.Models;
using System.ComponentModel.DataAnnotations;

namespace MyAPI.Models
{
    public class AddFeesRequest
    {
        public decimal Amount { get; set; }
        public int DoctorID { get; set; }

        // Navigation property for the Doctor entity (Many-to-One)
        public Doctor? Doctor { get; set; }
    }
}
