﻿namespace Doctors.Models
{
    public class User
    {
        public Guid UserID { get; set; }
        public int RoleID { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime Date { get; set; }
        public string? Address { get; set; }

        // Navigation property for the Role entity (Many-to-One)
        public Role? Role { get; set; }
    }

}
