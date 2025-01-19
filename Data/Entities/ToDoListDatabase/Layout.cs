using System;
using System.Collections.Generic;

namespace Data.Entities.ToDoListDatabase;

public partial class Layout
{
    public int LayoutId { get; set; }

    public string Name { get; set; } = null!;

    public string Path { get; set; } = null!;

    public string? Description { get; set; }

    public int LocationId { get; set; }

    public virtual Location Location { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
