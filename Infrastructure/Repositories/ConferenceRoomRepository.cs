using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TechnicalTask.Infrastructure.DbContexts;
using TechnicalTasks.Domain.Entities;
using TechnicalTasks.Domain.Interfaces;

namespace TechnicalTasks.Infrastructure.Repositories
{
    public class ConferenceRoomRepository : IConferenceRoomRepository
    {
        private DataContext _context;

        public ConferenceRoomRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ConferenceRoom> CreateConferenceRoom(ConferenceRoom conferenceRoom)
        {
            var newEntity = await _context.ConferenceRooms.AddAsync(conferenceRoom);
            await SaveAsync();

            return newEntity.Entity;
        }

        public async Task<bool> DeleteConferenceRoom(Guid id)
        {
            var conferenceRoomToDelete = _context.ConferenceRooms.FirstOrDefault(r => r.Id == id);

            if (conferenceRoomToDelete == null)
            {
                return false;
            }

            var deletedRoom = _context.Remove(conferenceRoomToDelete);

            return await SaveAsync();
        }

        public async Task<ConferenceRoom> GetConferenceRoomById(Guid id)
        {
            return await _context.ConferenceRooms.Include(r => r.Services)
                .Include(r => r.Bookings)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> UpdateConferenceRoom(ConferenceRoom conferenceRoom)
        {
            _context.Update(conferenceRoom);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<List<ConferenceRoom>> GetAvailableConferenceRoom(DateTime startDateTime, DateTime endDataDateTime, int capacity)
        {
            //витягую зали, де місткість >= необхідній + де немає жодного блонювання
            return await _context.ConferenceRooms.Include(r => r.Bookings)
                .Where(r => r.Capacity >= capacity && !r.Bookings.Any(b => b.StartDateTime < endDataDateTime 
                                                                           && endDataDateTime > startDateTime)).ToListAsync();
        }
    }
}
