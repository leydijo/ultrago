using System.Globalization;
using System.Text.Json.Serialization;

namespace Ultrago.Models.Dto
{
    public class GuestDto
    {

        public string? Names { get; set; }

        public string? Surname { get; set; }

        public string? DateBirth { get; set; }

        public string? Gender { get; set; }

        public string? TypeDocument { get; set; }

        public string? DocumentNumber { get; set; }

        public string? Email { get; set; }

        public string? PhoneContact { get; set; }

        [JsonIgnore]
        public DateTime? DateBirths
        {
            get
            {
                if (DateTime.TryParseExact(DateBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }
                return null;
            }
        }
    }
}
