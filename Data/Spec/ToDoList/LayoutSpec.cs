using Data.Entities.ToDoListDatabase;

namespace Data.Spec.ToDoList
{
    public class LayoutSpec : BaseSpec<Layout>
    {
        public LayoutSpec() {
            AddInclude(x => x.Location);
        }
    }
}
