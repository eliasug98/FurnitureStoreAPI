using Microsoft.AspNetCore.Mvc;
using FurnitureStore.API.Services.Interfaces;
using FurnitureStore.API.DTOs.EmailDTO;

namespace FurnitureStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.SendEmail(request);

            return Ok();
        }
    }
}
