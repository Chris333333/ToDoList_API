using System;
using System.Collections.Generic;

namespace Data.Entities.ToDoListDatabase;

public partial class Task
{
    public int TaskId { get; set; }

    public string Task1 { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime CreateDt { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime? CompletedDt { get; set; }

    public int? LayoutId { get; set; }

    public virtual Layout? Layout { get; set; }

    public virtual User User { get; set; } = null!;
}
