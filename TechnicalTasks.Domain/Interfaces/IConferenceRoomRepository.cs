using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTasks.Domain.Entities;

namespace TechnicalTasks.Domain.Interfaces
{
    public interface IConferenceRoomRepository
    {
        Task<ConferenceRoom> CreateConferenceRoom(ConferenceRoom conferenceRoom);

        Task<bool> DeleteConferenceRoom(Guid id);

        Task<ConferenceRoom> GetConferenceRoomById(Guid id);

        Task<bool> UpdateConferenceRoom(ConferenceRoom conferenceRoom);
    }
}
