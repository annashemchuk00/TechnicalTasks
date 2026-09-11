using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalTasks.Shared.DTO
{
    public class ConferenceRoomDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public decimal BasePricePerHour { get; set; }

        public ICollection<ServiceDTO> Services { get; set; } = new List<ServiceDTO>();
    }
}
