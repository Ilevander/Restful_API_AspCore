namespace Doctors.Models
{
    public class Permission
    {
        public string? Id { get; set; }
        public string? RoleId { get; set; }
        public string? Title { get; set; }
        public string? Module { get; set; }
        public string? Description { get; set; }
        public int PermissionId { get; internal set; }
    }
}
