using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTasks.Domain.Entities;

namespace TechnicalTasks.Domain.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> CreateBooking(Booking booking);

        Task<bool> IsRoomOccupiedAsync(Guid roomId, DateTime start, DateTime end);
    }
}
