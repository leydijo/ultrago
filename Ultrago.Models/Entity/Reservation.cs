namespace Ultrago.Models.Entity;

public partial class Reservation
{
    public int Id { get; set; }

    public int IdRoom { get; set; }

    public int IdGuest { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? DateEnd { get; set; }

    public int? NumberPeople { get; set; }

    public virtual ICollection<ContactEmergency> ContactEmergencies { get; set; } = new List<ContactEmergency>();

    public virtual Guest IdGuestNavigation { get; set; } = null!;

    public virtual Room IdRoomNavigation { get; set; } = null!;
}
