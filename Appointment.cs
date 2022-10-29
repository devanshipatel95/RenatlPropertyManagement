using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public int? TenantId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? AppointmentSchedule { get; set; }
        public int? AppartmentId { get; set; }
        public int? BuildingId { get; set; }

        public virtual Appartment? Appartment { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Tenant? Tenant { get; set; }
    }
}
