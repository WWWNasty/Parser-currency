using Abstraction.Interfaces;
using DataAccessLayer.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ParserСurrency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallbackController : ControllerBase
    {
        /// <summary>
        /// Конфигурация приложения
        /// </summary>
        private readonly IResponseClient _vkResponseClientService;

        public CallbackController(IResponseClient vkResponseClientService)
        {
            _vkResponseClientService = vkResponseClientService;
        }

        [HttpPost]
        public IActionResult CallbackAsync(Updates updates)
        {
            var response = _vkResponseClientService.SendResponse(updates);

            // Возвращаем "ok" серверу Callback API
            return Ok(response);
        }
    }
}