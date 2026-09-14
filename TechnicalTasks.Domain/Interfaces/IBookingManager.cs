using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTasks.Domain.Entities;
using TechnicalTasks.Domain.Models;
using TechnicalTasks.Shared.DTO;

namespace TechnicalTasks.Domain.Interfaces
{
    public interface IBookingManager
    {
        Task<BookingDTO> CreateBooking(CreateBookingModel booking);
    }
}
