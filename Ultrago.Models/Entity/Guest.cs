using System;
using System.Collections.Generic;

namespace Ultrago.Models.Entity;

public partial class Guest
{
    public int Id { get; set; }

    public string? Names { get; set; }

    public string? Surname { get; set; }

    public DateTime? DateBirth { get; set; }

    public string? Gender { get; set; }

    public string? TypeDocument { get; set; }

    public string? DocumentNumber { get; set; }

    public string? Email { get; set; }

    public string? PhoneContact { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
