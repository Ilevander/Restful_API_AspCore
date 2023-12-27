namespace Doctors.Models
{
    public class Booking
    {
        public string? BookingId { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
        public string? AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}
