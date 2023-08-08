using System.Globalization;

using Ultrago.Models.Dto;
using Ultrago.Models.Entity;
using Ultrago.Models.Response;
using Ultrago.Services.Interfaces;

namespace Ultrago.Services
{
    public class GuestService : IGuestService
    {
        private readonly UltragoContext _context;
        public GuestService(UltragoContext context)
        {
            _context = context;
        }


       public async Task<Response<GuestDto>> CreateGuestAsync(GuestDto guestDto)
        {
            var guest = new Guest
            {
                Names = guestDto.Names,
                Surname = guestDto.Surname,
                DateBirth = DateTime.ParseExact(guestDto.DateBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                Gender = guestDto.Gender,
                TypeDocument = guestDto.TypeDocument,
                DocumentNumber = guestDto.DocumentNumber,
                Email = guestDto.Email,
                PhoneContact = guestDto.PhoneContact
            };

           
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();

            return new Response<GuestDto>
            {
                Data = guestDto,
                Message = "Guest created successfully."
            };
        }
    }
}
