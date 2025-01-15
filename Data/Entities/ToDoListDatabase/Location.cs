using System;
using System.Collections.Generic;

namespace Data.Entities.ToDoListDatabase;

public partial class Location
{
    public int LocationId { get; set; }

    public string Name { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual ICollection<Layout> Layouts { get; set; } = new List<Layout>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
