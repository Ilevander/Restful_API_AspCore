using Doctors.Models;

namespace MyAPI.Services.Doctor_Request
{
    public class UpdateRoleRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

        // Navigation property for the Permission entity (One-to-Many)
        public ICollection<Permission>? Permissions { get; set; }
    }
}
