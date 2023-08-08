using Ultrago.Models.Dto;
using Ultrago.Models.Response;

namespace Ultrago.Services.Interfaces
{
    public interface IContactEmergencyService
    {
        Task<Response<ContactEmergencyDto>> CreateContactEmergencyAsync(ContactEmergencyDto contactEmergencyDto);
    }
}
