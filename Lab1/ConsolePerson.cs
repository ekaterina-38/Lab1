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
        /// <returns>jj.</returns>
        public static Person ConsoleReadPerson()
        {
            Console.Write($"\nВведите Фамилию человека: ");
            string readLastName = Console.ReadLine();

            Console.Write($"\nВведите Имя человека: ");
            string readName = Console.ReadLine();

            Console.Write($"\nВведите Возраст человека: ");
            int readAge = Convert.ToInt32(Console.ReadLine());

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

            return new Person(readLastName, readName, readAge, gender);
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
