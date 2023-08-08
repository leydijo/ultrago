using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ultrago.Models.Dto;
using Ultrago.Services;
using Ultrago.Services.Interfaces;

namespace UltragoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [Authorize]
        [HttpPost("reserve")]
        public async Task<IActionResult> ReserveRoom([FromBody] ReservationDto reservationDto)
        {
            var reservation = await _reservationService.CreateReservationAsync(reservationDto);

            if (reservation == null)
            {
                return BadRequest();
            }
            return Ok(reservation);
        }

    }
}
