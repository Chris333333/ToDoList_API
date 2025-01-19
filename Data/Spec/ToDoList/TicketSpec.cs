using Data.Entities.ToDoListDatabase;

namespace Data.Spec.ToDoList
{
    public class TicketSpec : BaseSpec<Ticket>
    {
        public TicketSpec()
        {
            AddInclude(x => x.User);
            AddInclude(x => x.Layout);
            AddInclude(x => x.User.WorkPosition);
        }
    }
}
