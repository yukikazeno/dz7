namespace Latypova
{
    public class WorkTask
    {
        public string Title { get; }
        public TaskTarget Target { get; }

        public WorkTask(string title, TaskTarget target)
        {
            Title = title;
            Target = target;
        }
    }
}
