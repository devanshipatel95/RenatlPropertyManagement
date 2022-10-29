using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        public int UserRoleId { get; set; }
        public string? Role { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
