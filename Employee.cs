using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Appointments = new HashSet<Appointment>();
            Buildings = new HashSet<Building>();
            Messages = new HashSet<Message>();
        }

        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmployeeType { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
