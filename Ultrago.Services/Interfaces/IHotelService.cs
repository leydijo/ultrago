using Ultrago.Models.Dto;
using Ultrago.Models.Entity;
using Ultrago.Models.Response;

namespace Ultrago.Services.Interfaces
{
    public interface IHotelService
    {
        Task<Response<HotelDto>> CreateHotelAsync(HotelDto hotel);
        Task<Response<RoomService>> AddRoomToHotelAsync(int hotelId, RoomService room);
        Task<Response<HotelDto>> UpdateHotelAsync(int id, HotelEnableDto hotelEnableDto);
        Task EnableDisableHotelAsync(int hotelId, bool isEnabled);
        Task<IEnumerable<Response<Reservation>>> GetHotelReservationsAsync(int hotelId);
        Task<Response<Reservation>> GetReservationDetailsAsync(int reservationId);
    }
}
