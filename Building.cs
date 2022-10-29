using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Building
    {
        public Building()
        {
            Appartments = new HashSet<Appartment>();
        }

        public int BuildingId { get; set; }
        public int? Number { get; set; }
        public string? StreetName { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual ICollection<Appartment> Appartments { get; set; }
    }
}
