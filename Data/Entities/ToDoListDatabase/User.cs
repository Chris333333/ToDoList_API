using System;
using System.Collections.Generic;

namespace Data.Entities.ToDoListDatabase;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Login { get; set; } = null!;

    public int LocationId { get; set; }

    public int WorkPositionId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Location Location { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual WorkPosition WorkPosition { get; set; } = null!;
}
