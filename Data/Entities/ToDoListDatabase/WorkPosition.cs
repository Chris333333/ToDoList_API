namespace Data.Entities.ToDoListDatabase;

public partial class WorkPosition
{
    public int WorkPositionId { get; set; }

    public string Name { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
