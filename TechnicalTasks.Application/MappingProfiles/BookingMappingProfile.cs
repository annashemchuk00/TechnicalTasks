using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TechnicalTasks.Domain.Entities;
using TechnicalTasks.Domain.Models;
using TechnicalTasks.Shared.DTO;

namespace TechnicalTasks.Application.MappingProfiles
{
    public class BookingMappingProfile : Profile
    {
        public BookingMappingProfile()
        {
            CreateMap<BookingDTO, Booking>().ReverseMap();
            CreateMap<CreateBookingModel, Booking>();
            CreateMap<Service, ServiceDTO>();
            CreateMap<CreateServiceModel, Service>();
        }
    }
}
