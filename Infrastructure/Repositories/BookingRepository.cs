using Microsoft.EntityFrameworkCore;
using TechnicalTask.Infrastructure.DbContexts;
using TechnicalTasks.Domain.Entities;
using TechnicalTasks.Domain.Interfaces;

namespace TechnicalTasks.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private DataContext _context;

        public BookingRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Booking> CreateBooking(Booking booking)
        {
            var newEntity = await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            return newEntity.Entity;
        }

        //перевірка вільного часу без завантажування зайвих даних
        public async Task<bool> IsRoomOccupiedAsync(Guid roomId, DateTime start, DateTime end)
        {
            return await _context.Bookings.AnyAsync(b =>
                b.RoomId == roomId &&
                b.StartDateTime < end &&
                b.EndDateTime > start);
        }
    }
}
