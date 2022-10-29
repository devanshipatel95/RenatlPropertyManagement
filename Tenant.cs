using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Tenant
    {
        public Tenant()
        {
            Appointments = new HashSet<Appointment>();
            Messages = new HashSet<Message>();
        }

        public int TenantId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
