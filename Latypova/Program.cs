namespace Latypova
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee timur = new Employee("Тимур", "Генеральный директор");

            Employee rashid = new Employee("Рашид", "Финансовый директор");
            Employee ilham = new Employee("О Ильхам", "Директор по автоматизации");

            Employee lukas = new Employee("Лукас", "Главный бухгалтер");

            Employee orkadiy = new Employee("Оркадий", "Начальник инф. систем", TaskTarget.Management);
            Employee volodya = new Employee("Володя", "Зам. начальника инф. систем", TaskTarget.Management);

            Employee ilshat = new Employee("Ильшат", "Главный системщик", TaskTarget.SysAdmins);
            Employee ivanych = new Employee("Иваныч", "Зам. главного системщика", TaskTarget.SysAdmins);
            Employee ilya = new Employee("Илья", "Системщик", TaskTarget.SysAdmins);
            Employee vitya = new Employee("Витя", "Системщик", TaskTarget.SysAdmins);
            Employee zhenya = new Employee("Женя", "Системщик", TaskTarget.SysAdmins);

            Employee sergey = new Employee("Сергей", "Главный разработчик", TaskTarget.Developers);
            Employee lyaysan = new Employee("Ляйсан", "Зам. главного разработчика", TaskTarget.Developers);
            Employee marat = new Employee("Марат", "Разработчик", TaskTarget.Developers);
            Employee dina = new Employee("Дина", "Разработчик", TaskTarget.Developers);
            Employee ildar = new Employee("Ильдар", "Разработчик", TaskTarget.Developers);
            Employee anton = new Employee("Антон", "Разработчик", TaskTarget.Developers);

            rashid.AddManager(timur);
            ilham.AddManager(timur);

            lukas.AddManager(rashid);

            orkadiy.AddManager(ilham);
            volodya.AddManager(ilham);
            volodya.AddManager(orkadiy);

            ilshat.AddManager(orkadiy);
            ilshat.AddManager(volodya);
            ivanych.AddManager(ilshat);
            ilya.AddManager(ivanych);
            vitya.AddManager(ivanych);
            zhenya.AddManager(ivanych);

            sergey.AddManager(orkadiy);
            sergey.AddManager(volodya);
            lyaysan.AddManager(sergey);
            marat.AddManager(lyaysan);
            dina.AddManager(lyaysan);
            ildar.AddManager(lyaysan);
            anton.AddManager(lyaysan);

            WorkTask task1 = new WorkTask("Настроить локальную сеть в бухгалтерии", TaskTarget.SysAdmins);
            WorkTask task2 = new WorkTask("Автоматизировать отчёты одной кнопкой", TaskTarget.Developers);
            WorkTask task3 = new WorkTask("Подготовить план развития ИТ-отдела", TaskTarget.Management);

            lukas.AssignTask(timur, task2); 
            orkadiy.AssignTask(ilham, task3);
            sergey.AssignTask(volodya, task2);
            lyaysan.AssignTask(sergey, task2);
            dina.AssignTask(lyaysan, task2);
            dina.AssignTask(sergey, task2);
            ilya.AssignTask(ivanych, task1);
        }
    }
}