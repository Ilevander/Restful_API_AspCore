using Doctors.Models;

namespace MyAPI.Models
{
    public class AddPermissionRequest
    {
        public int RoleID { get; set; }
        public string? Title { get; set; }
        public string? Module { get; set; }
        public string? Description { get; set; }

        // Navigation property for the Role entity (Many-to-One)
        public Role? Role { get; set; }
    }
}
