namespace TechnicalTasks.Domain.Models
{
    public class CreateConferenceRoomModel
    {
        public string Name { get; set; }

        public int Capacity { get; set; }

        public decimal BasePricePerHour { get; set; }

        public List<Guid> ServicesIds { get; set; }
    }
}
