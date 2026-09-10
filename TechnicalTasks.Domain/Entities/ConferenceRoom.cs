using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalTasks.Domain.Entities
{
    public class ConferenceRoom
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public decimal BasePricePerHour { get; set; }

        public ICollection<Service> Services { get; set; } = new List<Service>();

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }

}
