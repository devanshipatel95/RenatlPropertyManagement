using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Appartment
    {
        public Appartment()
        {
            Appointments = new HashSet<Appointment>();
        }
        public int AppartmentId { get; set; }
        public int? BuildingId { get; set; }
        public int? Number { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? RentalPrice { get; set; }

        public virtual Building? Building { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
