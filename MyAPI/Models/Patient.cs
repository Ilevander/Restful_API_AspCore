namespace Doctors.Models
{
    public class Patient
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Username { get; set; }
        public string? PatientId { get; internal set; }
    }
}
