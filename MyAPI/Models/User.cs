namespace Doctors.Models
{
    public class User
    {
        public string? Id { get; set; }
        public string? RoleId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime Date { get; set; }
        public string? Address { get; set; }
        public string? UserId { get; internal set; }
    }
}
