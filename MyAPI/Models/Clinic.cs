namespace Doctors.Models
{
    public class Clinic
    {
        public string? ClinicId { get; set; }
        public string? DoctorId { get; set; }
        public string? Name { get; set; }
        public string? Place { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? ClinicName { get; internal set; }
        public string? ClinicPlace { get; internal set; }
        public string? ClinicType { get; internal set; }
        public string? ClinicDescription { get; internal set; }
    }
}
