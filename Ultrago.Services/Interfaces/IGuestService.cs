using Ultrago.Models.Dto;
using Ultrago.Models.Response;

namespace Ultrago.Services.Interfaces
{
    public interface IGuestService
    {
        Task<Response<GuestDto>> CreateGuestAsync(GuestDto guestDto);
    }
}
