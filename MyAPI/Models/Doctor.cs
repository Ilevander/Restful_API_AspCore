namespace Doctors.Models
{
    public class Doctor
    {
        public Guid DoctorId { get; set; }
        public string? Name { get; set; }
        public string? Specialist { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
    }
}
