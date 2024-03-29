﻿namespace Doctors.Models
{
    public class Role
    {
        public Guid RoleID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        // Navigation property for the Permission entity (One-to-Many)
        public ICollection<Permission>? Permissions { get; set; }
    }
}
