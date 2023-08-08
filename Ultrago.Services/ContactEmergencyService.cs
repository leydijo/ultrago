
using Microsoft.EntityFrameworkCore;
using Ultrago.Models.Dto;
using Ultrago.Models.Entity;
using Ultrago.Models.Response;
using Ultrago.Services.Interfaces;

namespace Ultrago.Services
{
    public class ContactEmergencyService : IContactEmergencyService
    {
        private readonly UltragoContext _context;

        public ContactEmergencyService(UltragoContext context)
        {
            _context = context;
        }

        public async Task<Response<ContactEmergencyDto>> CreateContactEmergencyAsync(ContactEmergencyDto contactEmergencyDto)
        {
            var reservation = await _context.Reservations
                .Include(r => r.IdGuestNavigation)
                .FirstOrDefaultAsync(r => r.IdGuestNavigation.Names  == contactEmergencyDto.Name);


            if (reservation == null)
            {
                return new Response<ContactEmergencyDto>
                {
                    Message = "Hotel with this name already exists."
                };
            }
            var contactEmergency = new ContactEmergency
            {
                FullNames = contactEmergencyDto.FullNames,
                PhoneContact = contactEmergencyDto.PhoneContact,
                IdReserva = reservation.Id
            };

            // Añadir el contacto de emergencia al contexto y guardar los cambios
            _context.ContactEmergencies.Add(contactEmergency);
            await _context.SaveChangesAsync();

            return new Response<ContactEmergencyDto>
            {
               
                Message = "Emergency contact created successfully."
            };
        }
    }
}
