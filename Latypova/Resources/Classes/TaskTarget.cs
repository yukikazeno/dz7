namespace Latypova
{
    public class Employee
    {
        public string Name { get; }
        public string Position { get; }
        public TaskTarget? Department { get; }
        public List<Employee> DirectManagers { get; } = new List<Employee>();

        public Employee(string name, string position, TaskTarget? department = null)
        {
            Name = name;
            Position = position;
            Department = department;
        }

        public void AddManager(Employee manager)
        {
            if (manager != null && !DirectManagers.Contains(manager))
            {
                DirectManagers.Add(manager);
            }
        }

        public void AssignTask(Employee from, WorkTask task)
        {
            Console.WriteLine($"От {from.Name} ({from.Position}) даётся задача «{task.Title}» сотруднику {Name} ({Position}).");
            bool isDirectManager = DirectManagers.Contains(from);
            bool isTargetMatch = Department == null || Department == task.Target;

            if (isDirectManager && isTargetMatch)
            {
                Console.WriteLine($"    Результат: {Name} берёт задачу.\n");
            }
            else
            {
                string reason = !isDirectManager
                    ? $"{from.Name} не является прямым руководством"
                    : "задача не по профилю сотрудника";
                Console.WriteLine($"    Результат: {Name} не берёт задачу ({reason}).\n");
            }
        }
    }
}
