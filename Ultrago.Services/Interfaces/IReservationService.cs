using Ultrago.Models.Dto;
using Ultrago.Models.Response;

namespace Ultrago.Services.Interfaces
{
    public interface IReservationService
    {
        Task<Response<ReservationDto>> CreateReservationAsync(ReservationDto reservationDto);
    }
}
