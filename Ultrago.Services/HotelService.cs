using Microsoft.EntityFrameworkCore;
using Ultrago.Models.Dto;
using Ultrago.Models.Entity;
using Ultrago.Models.Response;
using Ultrago.Services.Interfaces;

namespace Ultrago.Services
{
    public class HotelService : IHotelService
    {
        private readonly UltragoContext _context;
        public HotelService(UltragoContext context)
        {
            _context = context;
        }
        public async Task<Response<HotelDto>> CreateHotelAsync(HotelDto hotelDto)
        {
            // Validar si el hotel existe
            var existsHotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Name == hotelDto.HotelName);
            if (existsHotel != null)
            {
                return new Response<HotelDto>
                {
                    Message = "Hotel with this name already exists."
                };
            }

            var hotel = new Hotel
            {
                Name = hotelDto.HotelName,
                Location = hotelDto.Location,
                Enabled = hotelDto.Enabled,
            };


            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();


            return new Response<HotelDto>
            {
                Message = $"Hotel {hotel.Name} created successfully."
            };
        }

        public async Task<Response<HotelDto>> UpdateHotelAsync(int id, HotelEnableDto hotelEnableDto)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);

            if (hotel == null)
            {
                return new Response<HotelDto>
                {
                    Message = "No hotel found"
                };
            }
            hotel.Enabled = hotelEnableDto.Enabled;
            await _context.SaveChangesAsync();
            // Mapear el hotel a un HotelDto para la respuesta
            var hotelDto = new HotelDto
            {
                HotelName = hotel.Name,
                Location = hotel.Location,
                Enabled = (bool)hotel.Enabled

            };

            return new Response<HotelDto>
            {
                Data = hotelDto,
                Message = $"Hotel {hotel.Name} updated successfully."
            };
        }

        public Task<Response<RoomService>> AddRoomToHotelAsync(int hotelId, RoomService room)
        {
            throw new NotImplementedException();
        }


        public Task EnableDisableHotelAsync(int hotelId, bool isEnabled)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Response<Reservation>>> GetHotelReservationsAsync(int hotelId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Reservation>> GetReservationDetailsAsync(int reservationId)
        {
            throw new NotImplementedException();
        }


    }
}
