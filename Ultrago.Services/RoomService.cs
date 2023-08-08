using Microsoft.EntityFrameworkCore;
using Ultrago.Models.Dto;
using Ultrago.Models.Entity;
using Ultrago.Models.Response;
using Ultrago.Services.Interfaces;

namespace Ultrago.Services
{
    public class RoomService : IRoomService
    {
        private readonly UltragoContext _context;

        public RoomService(UltragoContext context)
        {
            _context = context;
        }
        public async Task<Response<RoomDto>> CreateRoomAsync(RoomDto roomDto)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Name == roomDto.Hotel);

            if (hotel == null)
            {
                return new Response<RoomDto>
                {
                    Message = "No hotel found with this name."
                };
            }

            var room = new Room
            {
                IdHotel = hotel.Id,
                TypeRoom = roomDto.TypeRoom,
                CostBase = (decimal)roomDto.CostBase,
                Taxes = (decimal)roomDto.Taxes,
                Enabled = roomDto.Enabled
            };


            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();


            return new Response<RoomDto>
            {
                Message = $"Room  created successfully."
            };
        }


        public async Task<Response<RoomDto>> UpdateRoomAsync(int id, RoomEnableDto roomEnableDto)
        {
            var room = await _context.Rooms
                .Include(r => r.IdHotelNavigation)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (room == null)
            {

                return new Response<RoomDto>
                {
                    Message = "No hotel found"
                };
            }
            room.Enabled = roomEnableDto.Enabled;
            await _context.SaveChangesAsync();
            
            var roomDto = new RoomDto
            {
                Hotel = room.IdHotelNavigation.Name,
                CostBase = room.CostBase,
                Taxes = room.Taxes,
                LocationRoom = room.LocationRoom,
                TypeRoom = room.TypeRoom,
                Enabled = (bool)room.Enabled

            };

            return new Response<RoomDto>
            {
                Data = roomDto,
                Message = $"Room updated successfully."
            };

        }
    }
}
