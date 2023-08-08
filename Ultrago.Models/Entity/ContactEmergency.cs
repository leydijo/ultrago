using System;
using System.Collections.Generic;

namespace Ultrago.Models.Entity;

public partial class ContactEmergency
{
    public int Id { get; set; }

    public string? FullNames { get; set; }

    public string? PhoneContact { get; set; }

    public int? IdReserva { get; set; }

    public virtual Reservation? IdReservaNavigation { get; set; }
}
