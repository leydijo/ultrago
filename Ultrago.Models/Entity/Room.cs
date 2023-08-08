using System;
using System.Collections.Generic;

namespace Ultrago.Models.Entity;

public partial class Room
{
    public int Id { get; set; }

    public int IdHotel { get; set; }

    public string? TypeRoom { get; set; }

    public string? LocationRoom { get; set; }

    public decimal? CostBase { get; set; }

    public decimal? Taxes { get; set; }

    public bool? Enabled { get; set; }

    public string? Descripcion { get; set; }

    public virtual Hotel IdHotelNavigation { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
