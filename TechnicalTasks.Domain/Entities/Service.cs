using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalTasks.Domain.Entities
{
    public class Service
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public ICollection<ConferenceRoom> ConferenceRooms { get; set; } = new List<ConferenceRoom>();

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }

}
