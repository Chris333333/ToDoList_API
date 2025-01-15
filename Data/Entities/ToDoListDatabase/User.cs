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

    public virtual Location Location { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual WorkPosition WorkPosition { get; set; } = null!;
}
