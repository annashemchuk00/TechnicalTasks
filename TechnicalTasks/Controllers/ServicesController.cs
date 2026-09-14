using Microsoft.AspNetCore.Mvc;
using TechnicalTasks.Domain.Interfaces;

namespace TechnicalTasks.Api.Controllers
{
    /// <summary>
    /// Управління додатковими послугами та сервісами залів.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesManager _servicesManager;

        public ServicesController(IServicesManager manager)
        {
            _servicesManager = manager;
        }

        /// <summary>
        /// Отримати список усіх доступних сервісів та послуг.
        /// </summary>
        /// <returns>Перелік усіх сервісів із цінами та описом</returns>
        /// <response code="200">Список сервісів успішно отримано</response>
        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            return Ok(await _servicesManager.GetAllServices());
        }
    }
}
