using System.Text.RegularExpressions;

namespace Lab1
{
    /// <summary>
    /// Класс вывода.
    /// </summary>
    public static class ConsolePerson
    {
        /// <summary>
        /// Метод вывода списка людей.
        /// </summary>
        /// <param name="listperson">список людей.</param>
        public static void Print(PersonList listperson)
        {
            Console.WriteLine(listperson.NamelistPerson);

            int count = listperson.CountList();

            for (int index = 0; index <= count; index++)
            {
                Person person = listperson.LookForIndexList(index);
                Console.WriteLine(person.GetInfo());
            }

            Console.WriteLine();
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="fullName">.</param>
        /// <returns>.</returns>
        public static bool IsValidName(string fullName)
        {
            Regex regex = new Regex("(^[a-zA-Z]+$)|(^[а-яА-Я]+$)");
            return regex.IsMatch(fullName);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <returns>jj.</returns>
        public static Person ConsoleReadPerson()
        {
            string fullName;
            string readLastName;
            string readName;
            string result = string.Empty;
            do
            {
                do
                {
                    Console.Write($"\nВведите Фамилию человека: ");
                    readLastName = Console.ReadLine();

                    bool containsDash = readLastName.Contains("-");

                    if (containsDash)
                    {
                        string[] parts = readLastName.Split('-');
                        if (parts.Length == 2)
                        {
                            result = string.Join("", parts);

                            if (!IsValidName(result))
                            {
                                Console.WriteLine("Фамилия должна содержать буквы только одного языка " +
                                                  "(либо русского, либо английского алфавита)!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Фамилия должна 2 или 1 ");
                        }
                    }

                    else if (!IsValidName(readLastName))
                    {
                        Console.WriteLine("Фамилия должна содержать буквы только одного языка " +
                                          "(либо русского, либо английского алфавита)!");
                        result = readLastName;
                    }
                }
                while (!IsValidName(result));

                do
                {
                    Console.Write($"\nВведите Имя человека: ");
                    readName = Console.ReadLine();

                    bool containsDash = readLastName.Contains("-");

                    if (containsDash)
                    {
                        string[] parts = readName.Split('-');
                        if (parts.Length == 2)
                        {
                            result = string.Join("", parts);

                            if (!IsValidName(result))
                            {
                                Console.WriteLine("Имя должно содержать буквы только одного языка" +
                                                   "(либо русского, либо английского алфавита)!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Имя должно 2 или 1 ");
                        }
                    }

                    else if (!IsValidName(readName))
                    {
                        Console.WriteLine("Имя должно содержать буквы только одного языка" +
                                          "(либо русского, либо английского алфавита)!");
                        result = readName;
                    }
                }
                while (!IsValidName(result));

                fullName = readLastName + readName;

                if (!IsValidName(fullName))
                {
                    Console.WriteLine("Имя и Фамилия должны быть " +
                                      "на одном языке (русском, либо английском)!");
                }
            }
            while (!IsValidName(fullName));

            int age;

            do
            {
                Console.Write($"\nВведите Возраст человека: ");
                string readAge = Console.ReadLine();

                if (!int.TryParse(readAge, out age))
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                    age = -1;
                    continue;
                }

                // Проверяем, если возраст отрицательный
                if (age < 0)
                {
                    Console.WriteLine("Возраст не может быть отрицательным. Попробуйте еще раз.");
                }
            }
            while (age < 0);

            Console.Write($"\nВведите Пол человека: ");
            string readGender = Console.ReadLine();
            Gender gender;

            if (readGender == "женский")
            {
                gender = Gender.женский;
            }
            else if (readGender == "мужской")
            {
                gender = Gender.мужской;
            }
            else
            {
                throw new Exception("Ошибка в gender");
            }

            return new Person(readLastName, readName, age, gender);
        }

        /// <summary>
        /// Метод рандомного создания людей.
        /// </summary>
        /// <returns>Созданного человека.</returns>
        public static Person GetRandomPerson()
        {
            Random random = new Random();

            string[] namesWonem = { "Екатерина", "Ольга", "Надежда", "Любовь", "Ирина", "Анастасия", "Кира" };
            string[] namesMen = { "Владимир", "Артем", "Степан", "Виктор", "Александр", "Дмитрий", "Валентин" };
            string[] firstNames = { "Иванов", "Васнецов", "Ольгин", "Кулагин", "Ефремов", "Ласточкин", "Морозов", "Туклинин" };

            Gender gender = (Gender)random.Next(Enum.GetValues(typeof(Gender)).Length);

            string name = "";
            string firstName = "";

            if (gender == Gender.женский)
            {
                name = namesWonem[random.Next(namesWonem.Length)];
                firstName = firstNames[random.Next(firstNames.Length)] + "а";
            }
            else if (gender == Gender.мужской)
            {
                name = namesMen[random.Next(namesMen.Length)];
                firstName = firstNames[random.Next(firstNames.Length)];
            }

            int age = random.Next(1, 101);

            return new Person(firstName, name, age, gender);
        }
    }
}
