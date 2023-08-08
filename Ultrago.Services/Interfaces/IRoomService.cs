using Ultrago.Models.Dto;
using Ultrago.Models.Response;

namespace Ultrago.Services.Interfaces
{
    public interface IRoomService
    {
        Task<Response<RoomDto>> CreateRoomAsync(RoomDto room);
        Task<Response<RoomDto>> UpdateRoomAsync(int id, RoomEnableDto roomEnableDto);
    }
}
