namespace MyAPI.Services.Doctor_Request
{
    public class UpdateAppointmentRequest
    {
        public string? DoctorId { get; set; }
        public int Number { get; set; }
        public string? Type { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}
