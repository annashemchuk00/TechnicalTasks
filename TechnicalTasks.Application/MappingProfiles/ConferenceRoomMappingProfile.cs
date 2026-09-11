using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TechnicalTasks.Domain.Entities;
using TechnicalTasks.Domain.Models;
using TechnicalTasks.Shared.DTO;

namespace TechnicalTasks.Application.MappingProfiles
{
    public class ConferenceRoomMappingProfile : Profile
    {
        public ConferenceRoomMappingProfile()
        {
            CreateMap<Service, ServiceDTO>();
            CreateMap<CreateServiceModel, Service>();
            CreateMap<CreateConferenceRoomModel, ConferenceRoom>();
            CreateMap<ConferenceRoom, ConferenceRoomDTO>();
            CreateMap<UpdateConferenceRoomModel, ConferenceRoom>();

        }
    }
}
