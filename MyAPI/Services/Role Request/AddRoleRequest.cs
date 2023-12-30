using Doctors.Models;

namespace MyAPI.Models
{
    public class AddRoleRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

        // Navigation property for the Permission entity (One-to-Many)
        public ICollection<Permission>? Permissions { get; set; }
    }
}
