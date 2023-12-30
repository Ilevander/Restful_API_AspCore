using Doctors.Models;
using System.ComponentModel.DataAnnotations;

namespace MyAPI.Services.Doctor_Request
{
    public class UpdateFeestRequest
    {
        public decimal Amount { get; set; }
        public int DoctorID { get; set; }
        // Navigation property for the Doctor entity (Many-to-One)
        public Doctor? Doctor { get; set; }
    }
}
