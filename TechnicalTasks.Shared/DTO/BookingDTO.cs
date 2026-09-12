using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalTasks.Shared.DTO
{
    public class BookingDTO
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }


        private ICollection<ConferenceRoomDTO> CongerenceRooms = new List<ConferenceRoomDTO>();

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
