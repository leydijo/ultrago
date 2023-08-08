using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ultrago.Models.Dto;
using Ultrago.Services.Interfaces;

namespace UltragoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;
        public GuestController(IGuestService guestService) 
        {
            _guestService = guestService;
        }

        [Authorize]
        [HttpPost("createGuest")]
        public async Task<IActionResult> CreateGuest([FromBody] GuestDto guestDto)
        {
            var response = await _guestService.CreateGuestAsync(guestDto);

            if (response.Data == null)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }


    }
}
