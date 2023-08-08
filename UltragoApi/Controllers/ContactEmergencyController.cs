using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ultrago.Models.Dto;
using Ultrago.Services.Interfaces;

namespace UltragoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactEmergencyController : ControllerBase
    {
        private readonly IContactEmergencyService _contactEmergencyService;
        public ContactEmergencyController(IContactEmergencyService contactEmergencyService)
        {
            _contactEmergencyService = contactEmergencyService;
        }

        [Authorize]
        [HttpPost("createEmergencyContact")]
        public async Task<IActionResult> CreateEmergencyContact([FromBody] ContactEmergencyDto contactEmergencyDto)
        {
            var response = await _contactEmergencyService.CreateContactEmergencyAsync(contactEmergencyDto);

            if (response == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
