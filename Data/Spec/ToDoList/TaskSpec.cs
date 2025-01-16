using Data.Entities.ToDoListDatabase;

namespace Data.Spec.ToDoList
{
    public class TaskSpec : BaseSpec<Data.Entities.ToDoListDatabase.Task>
    {
        public TaskSpec()
        {
            AddInclude(x => x.User);
            AddInclude(x => x.Layout);
            AddInclude(x => x.User.WorkPosition);
        }
    }
}
