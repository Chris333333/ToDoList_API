using Data.Entities.ToDoListDatabase;

namespace Data.Spec.ToDoList;

public class CommentsTicketSpec : BaseSpec<Comment>
{
    public CommentsTicketSpec(BaseSpecParams baseSpecParams, int ticketID) : base(x => x.TicketId == ticketID)
    {
        AddInclude(x => x.User);
        ApplyPaging(baseSpecParams.PageSize * (baseSpecParams.PageIndex - 1), baseSpecParams.PageSize);
    }
}
