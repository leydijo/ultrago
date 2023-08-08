namespace Ultrago.Models.Dto
{
    public class ReservationDto
    {
       
        public string Habitacion { get; set; }

        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? DateEnd { get; set; }
        public int? NumberPeople { get; set; }
    }
}
