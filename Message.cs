using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int? TenantId { get; set; }
        public string? Queries { get; set; }
        public DateTime? QueryDate { get; set; }
        public string? Status { get; set; }
        public int? EmployeeId { get; set; }
        public string? Response { get; set; }
        public DateTime? ResponseDate { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual Tenant? Tenant { get; set; }
    }
}
