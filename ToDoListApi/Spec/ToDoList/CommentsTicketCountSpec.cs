using Data.Entities.ToDoListDatabase;

namespace Data.Spec.ToDoList;

public class CommentsTicketCountSpec(BaseSpecParams baseSpecParams, int ticketID) : BaseSpec<Comment>(x => x.TicketId == ticketID)
{
}
