using System;
using System.Collections.Generic;

namespace Data.Entities.ToDoListDatabase;

public partial class Comment
{
    public int CommentId { get; set; }

    public string Content { get; set; } = null!;

    public int TicketId { get; set; }

    public int UserId { get; set; }

    public DateTime CreateDt { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
