using System;
using System.Collections.Generic;

namespace Ultrago.Models.Entity;

public partial class Hotel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Location { get; set; }

    public bool? Enabled { get; set; }

    public string? Description { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual User? User { get; set; }
}
