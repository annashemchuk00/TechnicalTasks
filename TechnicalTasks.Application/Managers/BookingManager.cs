using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTasks.Domain.Entities;
using TechnicalTasks.Domain.Exceptions;
using TechnicalTasks.Domain.Interfaces;
using TechnicalTasks.Domain.Models;
using TechnicalTasks.Shared.DTO;

namespace TechnicalTasks.Application.Managers
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        private readonly IConferenceRoomRepository _conferenceRoomRepository;
        private readonly IServicesRepository _servicesRepository;

        public BookingManager(IBookingRepository repository, IMapper mapper, IConferenceRoomRepository roomRepository, IServicesRepository servicesRepository)
        {
            _bookingRepository = repository;
            _mapper = mapper;
            _conferenceRoomRepository = roomRepository;
            _servicesRepository = servicesRepository;
        }

        public async Task<BookingDTO> CreateBooking(CreateBookingModel booking)
        {
            if (booking.StartDateTime >= booking.EndDateTime ||
                booking.StartDateTime < DateTime.Now)
            {
                throw new InvalidDateException();
            }

            if (booking.StartDateTime.Hour < 6
                    || booking.EndDateTime.Hour > 23)
            {
                throw new NonWorkingHoursException();
            }

            var isRoomFree =
                await _bookingRepository.IsRoomOccupiedAsync(booking.RoomId, booking.StartDateTime, booking.EndDateTime);

            var room = await _conferenceRoomRepository.GetConferenceRoomById(booking.RoomId);
            if (room == null) throw new RoomNotFoundException();

            var basePrice = room.BasePricePerHour;

            decimal totalPrice = 0;

            if (!isRoomFree)
            {
                for (var time = booking.StartDateTime; time < booking.EndDateTime; time = time.AddHours(1))
                {
                    switch (time.Hour)
                    {
                        case >= 6 and < 9:
                            totalPrice += basePrice * 0.9m;
                            break;
                        case >= 12 and < 14:
                            totalPrice += basePrice * 1.15m;
                            break;
                        case >= 18 and < 23:
                            totalPrice += basePrice * 0.8m;
                            break;
                        default:
                            totalPrice += basePrice;
                            break;
                    }
                }
            }
            else
            {
                throw new RoomOccupiedException();
            }

            var servicesId =  booking.SelectedServices.Select(s => s.Id).ToList();
            var services = await _servicesRepository.GetAllServices();
            var servicesPrice = services.Sum(s => s.Price);

            totalPrice += servicesPrice;

            var bookingEntity = _mapper.Map<Booking>(booking);
            var createdBooking = await _bookingRepository.CreateBooking(bookingEntity);

            return _mapper.Map<BookingDTO>(createdBooking);
        }
    }
}
