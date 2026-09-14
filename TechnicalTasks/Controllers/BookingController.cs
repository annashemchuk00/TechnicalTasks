using Microsoft.AspNetCore.Mvc;
using TechnicalTasks.Domain.Interfaces;
using TechnicalTasks.Domain.Models;

namespace TechnicalTasks.Api.Controllers
{
    /// <summary>
    /// Управління бронюванням конференц-залів.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingManager _bookingManager;

        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }

        /// <summary>
        /// Створити нове бронювання конференц-залу.
        /// </summary>
        /// <param name="model">Дані для створення бронювання (зал, час, сервіси)</param>
        /// <returns>Інформацію про створене бронювання та підсумкову вартість</returns>
        /// <response code="200">Бронювання успішно створено</response>
        /// <response code="400">Некоректний інтервал часу, зал зайнятий або не працює в ці години</response>
        /// <response code="404">Зал або вибрані сервіси не знайдено</response>
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingModel model)
        {
            return Ok(await _bookingManager.CreateBooking(model));
        }
    }
}
