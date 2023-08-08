using Microsoft.EntityFrameworkCore;
using Ultrago.Models.Dto;
using Ultrago.Models.Entity;
using Ultrago.Models.Response;
using Ultrago.Services.Interfaces;

namespace Ultrago.Services
{
    public class ReservationService : IReservationService
    {
        private readonly UltragoContext _context;
        public ReservationService(UltragoContext context)
        {
            _context = context;
        }

      
        public async Task<Response<ReservationDto>> CreateReservationAsync(ReservationDto reservationDto)
        {
            // Buscar la habitación por su nombre
            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.TypeRoom == reservationDto.Habitacion);
            if (room == null)
            {
                throw new Exception("Room not found.");
            }

            // Buscar el huésped por  nombre
            var guest = await _context.Guests.FirstOrDefaultAsync(g => g.Names == reservationDto.Name);
            if (guest == null)
            {
                throw new Exception("Guest not found.");
            }

            // Crear una nueva reserva
            var reservation = new Reservation
            {
                IdRoom = room.Id,
                IdGuest = guest.Id,
                StartDate = reservationDto.StartDate,
                DateEnd = reservationDto.DateEnd,
                NumberPeople = reservationDto.NumberPeople
            };


            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

           
            var createdReservationDto = new ReservationDto
            {
                
                Name = reservationDto.Name,
                Habitacion = reservationDto.Habitacion,
                StartDate= reservationDto.StartDate,
                DateEnd = reservationDto.DateEnd,
                NumberPeople = reservationDto.NumberPeople

            };

            return new Response<ReservationDto>
            {
                Data = createdReservationDto,
                Message = "Reservation created successfully."
            };


        }
    }
}
