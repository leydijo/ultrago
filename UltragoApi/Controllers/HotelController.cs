using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ultrago.Models.Dto;
using Ultrago.Services.Interfaces;

namespace UltragoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [Authorize]
        [HttpPost("createHotel")]
        public async Task<IActionResult> CreateHotel([FromBody] HotelDto hotel)
        {
            var response = await _hotelService.CreateHotelAsync(hotel);

            if (response == null)
            {
                return BadRequest(response);

            }
            return Ok(response);
        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateActiveHotel(int id, [FromBody] HotelEnableDto hotelEnableDto)
        {

            var response = await _hotelService.UpdateHotelAsync(id, hotelEnableDto);

            if (response == null)
            {
                return BadRequest(response);

            }
            return Ok(response);

        }


    }
}
