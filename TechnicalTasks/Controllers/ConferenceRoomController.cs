using Microsoft.AspNetCore.Mvc;
using TechnicalTasks.Domain.Interfaces;
using TechnicalTasks.Domain.Models;

namespace TechnicalTasks.Api.Controllers
{
    /// <summary>
    /// Управління конференц-залами та їх доступністю.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceRoomController : Controller
    {
        private readonly IConferenceRoomManager _conferenceRoomManager;
        private readonly IBookingManager _bookingManager;

        public ConferenceRoomController(IConferenceRoomManager conferenceRoomManager, IBookingManager bookingManager)
        {
            _conferenceRoomManager = conferenceRoomManager;
            _bookingManager = bookingManager;
        }

        /// <summary>
        /// Створити новий конференц-зал.
        /// </summary>
        /// <param name="model">Дані для створення залу</param>
        /// <returns>Створений конференц-зал</returns>
        /// <response code="200">Зал успішно створено</response>
        /// <response code="400">Передано некоректні дані</response>
        [HttpPost("create")]
        public async Task<IActionResult> CreateConferenceRoom(CreateConferenceRoomModel model)
        {
            return Ok(await _conferenceRoomManager.CreateConferenceRoom(model));
        }

        /// <summary>
        /// Видалити конференц-зал за ідентифікатором.
        /// </summary>
        /// <param name="id">Унікальний ідентифікатор (GUID) залу</param>
        /// <response code="200">Зал успішно видалено</response>
        /// <response code="404">Зал не знайдено</response>
        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> DeleteConferenceRoom(Guid id)
        {
            return Ok(await _conferenceRoomManager.DeleteConferenceRoom(id));
        }

        /// <summary>
        /// Отримати детальну інформацію про конференц-зал за ID.
        /// </summary>
        /// <param name="id">Унікальний ідентифікатор залу</param>
        /// <response code="200">Повертає інформацію про зал</response>
        /// <response code="404">Зал з таким ID не знайдено</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConferenceRoomById(Guid id)
        {
            return Ok(await _conferenceRoomManager.GetConferenceRoomById(id));
        }

        /// <summary>
        /// Оновити дані конференц-залу.
        /// </summary>
        /// <param name="id">ID залу для оновлення</param>
        /// <param name="model">Нові дані залу</param>
        /// <response code="200">Зал успішно оновлено</response>
        /// <response code="400">Помилка у переданих даних</response>
        /// <response code="404">Зал не знайдено</response>
        [HttpPut("update/{id:guid}")]
        public async Task<IActionResult> UpdateConferenceRoom(Guid id, UpdateConferenceRoomModel model)
        {
            var result = await _conferenceRoomManager.UpdateConferenceRoom(id, model);
            
            return Ok(result);
        }

        /// <summary>
        /// Отримати список доступних залів на вказаний період часу та місткість.
        /// </summary>
        /// <param name="startDateTime">Дата та час початку оренди</param>
        /// <param name="endDataDateTime">Дата та час завершення оренди</param>
        /// <param name="capacity">Необхідна місткість осіб</param>
        /// <returns>Список доступних залів</returns>
        /// <response code="200">Повертає список вільних залів</response>
        /// <response code="400">Некоректний інтервал дат або значення місткості</response>
        [HttpGet("available/conference/room")]
        public async Task<IActionResult> GetAvailableConferenceRoom([FromQuery] DateTime startDateTime, [FromQuery] DateTime endDataDateTime,
            [FromQuery] int capacity)
        {
            return Ok(await _conferenceRoomManager.GetAvailableConferenceRoom(startDateTime, endDataDateTime, capacity));
        }
    }
}
