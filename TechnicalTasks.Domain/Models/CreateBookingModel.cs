using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTasks.Domain.Entities;
using TechnicalTasks.Shared.DTO;

namespace TechnicalTasks.Domain.Models
{
    public class CreateBookingModel
    {
        public Guid RoomId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public ICollection<ServiceDTO?> SelectedServices { get; set; }
    }
}
