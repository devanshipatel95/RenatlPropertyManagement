using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int? RoleId { get; set; }

        public virtual UserRole? Role { get; set; }
    }
}
