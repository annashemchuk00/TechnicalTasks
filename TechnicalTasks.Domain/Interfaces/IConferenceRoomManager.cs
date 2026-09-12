using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalTasks.Domain.Models;
using TechnicalTasks.Shared.DTO;

namespace TechnicalTasks.Domain.Interfaces
{
    public interface IConferenceRoomManager
    {
        Task<ConferenceRoomDTO> CreateConferenceRoom(CreateConferenceRoomModel model);

        Task<bool> DeleteConferenceRoom(Guid id);

        Task<ConferenceRoomDTO> GetConferenceRoomById(Guid id);

        Task<bool> UpdateConferenceRoom(Guid id, UpdateConferenceRoomModel model);

        Task<List<ConferenceRoomDTO>> GetAvailableConferenceRoom(DateTime startDateTime, DateTime endDataDateTime, int capacity);
    }
}
