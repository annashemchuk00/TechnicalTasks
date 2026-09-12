using Microsoft.AspNetCore.Mvc;
using TechnicalTasks.Domain.Interfaces;
using TechnicalTasks.Domain.Models;

namespace TechnicalTasks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceRoomController : Controller
    {
        private readonly IConferenceRoomManager _conferenceRoomManager;

        public ConferenceRoomController(IConferenceRoomManager conferenceRoomManager)
        {
            _conferenceRoomManager = conferenceRoomManager;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateConferenceRoom(CreateConferenceRoomModel model)
        {
            return Ok(await _conferenceRoomManager.CreateConferenceRoom(model));
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> DeleteConferenceRoom(Guid id)
        {
            return Ok(await _conferenceRoomManager.DeleteConferenceRoom(id));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConferenceRoomById(Guid id)
        {
            return Ok(await _conferenceRoomManager.GetConferenceRoomById(id));
        }

        [HttpPut("update/{id:guid}")]
        public async Task<IActionResult> UpdateConferenceRoom(Guid id, UpdateConferenceRoomModel model)
        {
            var result = await _conferenceRoomManager.UpdateConferenceRoom(id, model);
            
            return Ok(result);
        }

        [HttpGet("available/conference/room")]
        public async Task<IActionResult> GetAvailableConferenceRoom([FromQuery] DateTime startDateTime, [FromQuery] DateTime endDataDateTime,
            [FromQuery] int capacity)
        {
            return Ok(await _conferenceRoomManager.GetAvailableConferenceRoom(startDateTime, endDataDateTime, capacity));
        }
    }
}
