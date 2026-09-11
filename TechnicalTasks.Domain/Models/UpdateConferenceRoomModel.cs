using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalTasks.Domain.Models
{
    public class UpdateConferenceRoomModel
    {
        public string Name { get; set; }

        public int Capacity { get; set; }

        public decimal BasePricePerHour { get; set; }

        public List<CreateServiceModel> Services { get; set; }
    }
}
