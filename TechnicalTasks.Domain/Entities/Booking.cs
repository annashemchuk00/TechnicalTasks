using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalTasks.Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }

        public ConferenceRoom ConferenceRoom { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public decimal TotalPrice { get; set; }

        public ICollection<Service> SelectedServices { get; set; } = new List<Service>();
    }

}
