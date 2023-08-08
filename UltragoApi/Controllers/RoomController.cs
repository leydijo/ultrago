using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ultrago.Models.Dto;
using Ultrago.Services.Interfaces;

namespace UltragoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService) 
        {
            _roomService = roomService;
        }

        [Authorize]
        [HttpPost("createroom")]
        public async Task<IActionResult> CreateRoom([FromBody] RoomDto roomDto)
        {
            var response = await _roomService.CreateRoomAsync(roomDto);

            if (response == null)
            {
                return BadRequest(response);

            }
            return Ok(response);
        }


        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateActiveRoom(int id, [FromBody] RoomEnableDto roomEnableDto)
        {

            var response = await _roomService.UpdateRoomAsync(id, roomEnableDto);

            if (response == null)
            {
                return BadRequest(response);

            }
            return Ok(response);





        }
    }
}
