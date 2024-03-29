﻿namespace Doctors.Models
{
    public class Permission
    {
        public Guid PermissionID { get; set; }
        public int RoleID { get; set; }
        public string? Title { get; set; }
        public string? Module { get; set; }
        public string? Description { get; set; }

        // Navigation property for the Role entity (Many-to-One)
        public Role? Role { get; set; }
    }
}
