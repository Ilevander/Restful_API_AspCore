namespace Doctors.Models
{
    public class Role
    {
        public string? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? RoleId { get; internal set; }
    }
}
