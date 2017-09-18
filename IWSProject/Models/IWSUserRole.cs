
namespace IWSProject.Models
{
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
    public class IWSUsers
    {
        [Key]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Display(Name = "Lockout End Date Utc")]
        public DateTime? LockoutEndTimeUTC { get; set; }
        public int AccessFailedCount { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<IWSRole> Roles { get; set; }
    }
    public class IWSRole
    {
        [Key]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
    public class IWSUserRoleModel
    {
        [Key]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
    public class IWSUserRole
    {
        public string UserId { get; set; }
        [Key]
        public string RoleId { get; set; }
    }
    public class IWSRoles
    {
        [Key]
        public string Id { get; set; }
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
    public class IWSUserModel
    {
        [Key]
        public string Id { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
    public class IWSUserRoles
    {
        [Key]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public List<IWSUserRoleModel> UserRole { get; set; }
    }
    public class IWSUseRolesModel
    {
        [Key]
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
    public class IWSRoleUsersModel
    {
        public string UserId { get; set; }
        [Key]
        public string RoleId { get; set; }
    }
}