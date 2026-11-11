namespace Tumakov
{
    class Program
    {
        static public BankAcc CreateAcc()
        {
            Console.Write("Введите данные счета \nНомер счета (если хотите сгенерировать номер автоматически нажмите Enter)");
            ulong? accNumber = ulong.TryParse(Console.ReadLine(), out ulong nu) ? nu : null;
            Console.Clear();
            Console.WriteLine("Выберите тип счета: \n1 - Сберегательный \n2 - Кредитный \n3 - Накопительный \n4 - Депозитный \n5 - Расчетный");
            AccType accType = (AccType)(int.TryParse(Console.ReadLine(), out int ty) ? ty : 0);
            Console.Clear();
            Console.Write("Введите текущий баланс: ");
            decimal balance = decimal.TryParse(Console.ReadLine(), out decimal bal) ? bal : 0;
            Console.Clear();
            BankAcc accOut = new BankAcc(accNumber, accType, balance);
            return accOut;
        }

        static void Task1()
        {
            List<BankAcc> accounts = new List<BankAcc>();
            byte runFlag = 1;
            while (runFlag == 1)
            {
                Console.WriteLine("Введите индекс действия: \n0. Выход \n1. Создать новый счет \n2. Перейти к работе с существующими счетами");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        runFlag = 0;
                        break;
                    case "1":
                        BankAcc acc = CreateAcc();
                        Console.Clear();
                        Console.WriteLine("Счет успешно создан:");
                        accounts.Add(acc);
                        Console.Clear();
                        break;
                    case "2":
                        int i = 0;
                        foreach (BankAcc account in accounts)
                        {
                            Console.Write(i);
                            account.DisplayInfo();
                            Console.WriteLine();
                            i++;
                        }
                        Console.WriteLine("Выберите аккаунт для работы: ");
                        int selectedIndex = int.TryParse(Console.ReadLine(), out int index) ? index : -1;
                        if (selectedIndex >= 0 && selectedIndex < accounts.Count)
                        {
                            BankAcc selectedAccount = accounts[selectedIndex];
                            Console.Write("Выберите действие: \n1. Положить деньги на счет \n2. Снять деньги со счета \n3. Перевести деньги на другой счет");
                            string actionChoice = Console.ReadLine();
                            switch(actionChoice)
                            {
                                case "1":
                                    Console.Write("Введите сумму для пополнения: ");
                                    decimal depositAmount = decimal.TryParse(Console.ReadLine(), out decimal depAmount) ? depAmount : 0;
                                    selectedAccount.PutMoney(depositAmount);
                                    Console.WriteLine($"Счет успешно пополнен на {depositAmount} руб.");
                                    break;
                                case "2":
                                    Console.Write("Введите сумму для снятия: ");
                                    decimal withdrawAmount = decimal.TryParse(Console.ReadLine(), out decimal withAmount) ? withAmount : 0;
                                    selectedAccount.TakeMoney(withdrawAmount);
                                    Console.WriteLine($"Со счета снято {withdrawAmount} руб.");
                                    break;
                                case "3":
                                    Console.Write("Введите индекс счета для перевода: ");
                                    int targetIndex = int.TryParse(Console.ReadLine(), out int tgtIndex) ? tgtIndex : -1;
                                    if (targetIndex >= 0 && targetIndex < accounts.Count && targetIndex != selectedIndex)
                                    {
                                        BankAcc targetAccount = accounts[targetIndex];
                                        Console.Write("Введите сумму для перевода: ");
                                        decimal transferAmount = decimal.TryParse(Console.ReadLine(), out decimal transAmount) ? transAmount : 0;
                                        selectedAccount.TransferMoney(targetAccount, transferAmount);
                                        Console.WriteLine($"Перевод на счет {targetAccount.AccNumber} выполнен на сумму {transferAmount} руб.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Неверный индекс счета для перевода.");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                        }
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                        break;
                }
            }
            Console.Clear();
        }

        static string Reverser(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static void Task2()
        {
            Console.Write("Введите строку для реверса: ");
            string input = Console.ReadLine();
            string reversed = Reverser(input);
            Console.WriteLine($"Реверс строки: {reversed}");
            Console.Clear();
        }

        static void Task3()
        {

            string fileName = Console.ReadLine();
            string upperFilePath = Path.Combine("Resources", "Files for task3", "CAPSfile.txt");
            if (!string.IsNullOrEmpty(fileName))
            {
                string filePath = Path.Combine("Resources", "Files for task3", fileName);
                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    content = content.ToUpper();
                    File.WriteAllText(upperFilePath, content);
                }
                else
                {
                    Console.WriteLine($"Файл {fileName} не найден. Завершение работы. . .");
                }
            }
            else
            {
                Console.WriteLine("Имя файла не может быть пустым.");
            }
            Console.Clear();
        }

        static bool CheckInterfaceWithIs(object obj)
        {
            if (obj is IFormattable)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool CheckInterfaceWithAs(object obj)
        {
            if (obj as IFormattable != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Task4()
        { 
            var testDateTime = DateTime.Now;
            var testString = "Hello, World!";
            var testInt = 42;
            var testArray = new int[] { 1, 2, 3 };

            Console.WriteLine($"Проверка интерфейса IFormattable с использованием 'is':");
            Console.WriteLine($"DateTime: {CheckInterfaceWithIs(testDateTime)}");
            Console.WriteLine($"String: {CheckInterfaceWithIs(testString)}");
            Console.WriteLine($"Int: {CheckInterfaceWithIs(testInt)}");
            Console.WriteLine($"Array: {CheckInterfaceWithIs(testArray)}");
            Console.WriteLine();
            Console.WriteLine($"Проверка интерфейса IFormattable с использованием 'as':");
            Console.WriteLine($"DateTime: {CheckInterfaceWithAs(testDateTime)}");
            Console.WriteLine($"String: {CheckInterfaceWithAs(testString)}");
            Console.WriteLine($"Int: {CheckInterfaceWithAs(testInt)}");
            Console.WriteLine($"Array: {CheckInterfaceWithAs(testArray)}");
            Console.ReadKey();
            Console.Clear();
        }

        static void SearchMail(ref string s)
        {
            string[] usersAndEmails = s.Split('#', '\n');
            s = string.Empty;
            string[] emails = new string[usersAndEmails.Length];
            for (int i = 1; i < emails.Length; i += 2)
            {
                s += usersAndEmails[i];
            }
        }

        static void HomeTask1()
        {
            string filePath = Path.Combine("Resources", "Files for hometask1", "Users.txt");
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл {filePath} не найден. Завершение работы. . .");
                return;
            }
            else
            {  
                string emails = File.ReadAllText(filePath);
                SearchMail(ref emails);
                File.AppendAllText(Path.Combine("Resources", "Files for hometask1", "Emails.txt"), emails);
            }
        }

        static void HomeTask2()
        {
            Song song1 = new Song();
            song1.SetName("Naki Kyoku");
            song1.SetAuthor("Boris");
            song1.SetPrev(null);

            Song song2 = new Song();
            song2.SetName("To the beach");
            song2.SetAuthor("Boris");
            song2.SetPrev(song1);

            Song song3 = new Song();
            song3.SetName("Akuma no Uta");
            song3.SetAuthor("Boris");
            song3.SetPrev(song2);

            Song song4 = new Song();
            song4.SetName("Akuma no Uta");
            song4.SetAuthor("Boris with Merzbow");
            song4.SetPrev(song3);

            List<Song> playlist = new List<Song> { song1, song2, song3, song4 };

            Console.WriteLine("Список песен:");
            foreach (Song song in playlist)
            {
                song.PrintInfo();
            }

            Console.WriteLine("\nВыберите песни для сравнения:");
            int firstIndex = int.TryParse(Console.ReadLine(), out int fi) ? fi : -1;
            int secondIndex = int.TryParse(Console.ReadLine(), out int si) ? si : -1;
            if (playlist[firstIndex].Equals(playlist[secondIndex]))
            {
                Console.WriteLine($"{playlist[firstIndex].name} и {playlist[secondIndex].name} одинаковые.");
            }
            else
            {
                Console.WriteLine($"{playlist[firstIndex].name} и {playlist[secondIndex].name} разные.");
            }
        }

        static void Main(string[] args)
        {
            byte runFlag = 1;
            while (runFlag == 1)
            {
                Console.WriteLine("Введите индекс задания: \n0. Выход \n1. Задание 1 \n2. Задание 2 \n3. Задание 3 \n4. Задание 4 \n5. Домашнее задание 1 \n6. Домашнее задание 2");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        runFlag = 0;
                        break;
                    case "1":
                        Task1();
                        break;
                    case "2":
                        Task2();
                        break;
                    case "3":
                        Task3();
                        break;
                    case "4":
                        Task4();
                        break;
                    case "5":
                        HomeTask1();
                        break;
                    case "6":
                        HomeTask2();
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                        break;
                }
            }
        }
    }
}
