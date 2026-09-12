using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TechnicalTasks.Domain.Entities;
using TechnicalTasks.Domain.Interfaces;
using TechnicalTasks.Domain.Models;
using TechnicalTasks.Shared.DTO;

namespace TechnicalTasks.Application.Managers
{
    public class ConferenceRoomManager : IConferenceRoomManager
    {
        private readonly IConferenceRoomRepository _conferenceRoomRepository;
        private readonly IMapper _mapper;

        public ConferenceRoomManager(IConferenceRoomRepository repository, IMapper mapper)
        {
            _conferenceRoomRepository = repository;
            _mapper = mapper;
        }


        public async Task<ConferenceRoomDTO> CreateConferenceRoom(CreateConferenceRoomModel model)
        {
            var conferenceRoomToAdd = _mapper.Map<ConferenceRoom>(model);
            var createdEntity = await _conferenceRoomRepository.CreateConferenceRoom(conferenceRoomToAdd);
            var dto = _mapper.Map<ConferenceRoomDTO>(createdEntity);
            return dto;
        }

        public Task<bool> DeleteConferenceRoom(Guid id)
        {
            return _conferenceRoomRepository.DeleteConferenceRoom(id);
        }

        public async Task<List<ConferenceRoomDTO>> GetAvailableConferenceRoom(DateTime startDateTime, DateTime endDataDateTime, int capacity)
        {
            //перевірка вхідних даних
            if(startDateTime >= endDataDateTime || startDateTime < DateTime.Now || capacity <= 0)
            {
                throw new ArgumentException("Некоректні дані");
            } 
            
            var entity = await _conferenceRoomRepository.GetAvailableConferenceRoom(startDateTime, endDataDateTime, capacity);
            return _mapper.Map<List<ConferenceRoomDTO>>(entity);
        }

        public async Task<ConferenceRoomDTO> GetConferenceRoomById(Guid id)
        {
            var conferenceRoom = await _conferenceRoomRepository.GetConferenceRoomById(id);
            return _mapper.Map<ConferenceRoomDTO>(conferenceRoom);
        }

        public async Task<bool> UpdateConferenceRoom(Guid id, UpdateConferenceRoomModel model)
        {
            var entity = await _conferenceRoomRepository.GetConferenceRoomById(id);
            _mapper.Map(model, entity);

            return true;
        }
    }
}
