using Data.Entities.ToDoListDatabase;

namespace Data.Spec.ToDoList
{
    public class UserSpec : BaseSpec<User>
    {
        public UserSpec()
        {
            AddInclude(x => x.Location);
            AddInclude(x => x.WorkPosition);
        }
    }
}
