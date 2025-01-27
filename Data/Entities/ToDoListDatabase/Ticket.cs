﻿using System;
using System.Collections.Generic;

namespace Data.Entities.ToDoListDatabase;

public partial class Ticket
{
    public int TicketId { get; set; }

    public string Titile { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime CreateDt { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime? CompletedDt { get; set; }

    public int? LayoutId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Layout? Layout { get; set; }

    public virtual User User { get; set; } = null!;
}
