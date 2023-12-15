using System.Globalization;

namespace Lab1
{
    /// <summary>
    /// Класс вывода.
    /// </summary>
    public class ConsolePerson
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
        /// Проверка отдельно Имени, Фамилии.
        /// </summary>
        /// <param name="read">проверяемое слово.</param>
        /// <returns>проверенное слово.</returns>
        public static string СheckWord()
        {
            string read;

            do
            {
                read = Console.ReadLine();

                if (!Person.СheckLanguage(read))
                {
                    read = string.Empty;
                    Console.WriteLine("Некорректный ввод! Имя или фамилия должны быть" +
                        " введены с использованием букв одного алфавита.\nПопробуйте еще раз: ");
                }
            }
            while (string.IsNullOrEmpty(read));

            return read;
        }

        /// <summary>
        /// Преобразование регистров Имен и Фамилий.
        /// </summary>
        /// <param name="read">слово, которое требует преобразования.</param>
        /// <returns>преобразованное слово.</returns>
        public static string BigLetter(string read)
        {
            string result;
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            if (read.Contains("-"))
            {
                string[] parts = read.Split('-');

                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i] = textInfo.ToTitleCase(parts[i]);
                }

                result = string.Join("-", parts);

            }
            else
            {
                result = textInfo.ToTitleCase(read);
            }

            return result;
        }

        /// <summary>
        /// Метод заполнения данных о Людях с клавиатуры.
        /// </summary>
        /// <returns>Объект класса Person.</returns>
        public static Person ConsoleReadPerson()
        {
            string readLastName;
            string readName;

            // Ввод Фамилии и Имени.
            do
            {
                Console.Write($"Введите Фамилию человека: ");
                readLastName = СheckWord();

                Console.Write($"\nВведите Имя человека: ");
                readName = СheckWord();

                if (!Person.СheckFullName(readName, readLastName))
                {
                    Console.WriteLine("Некорректный ввод! Фамилия и Имя должны быть одного языка.");
                }
            }
            while (!Person.СheckFullName(readName, readLastName));

            // Преобразование регистров Фамилии и Имени.
            readName = BigLetter(readName);
            readLastName = BigLetter(readLastName);

            // Ввод возраста человека.
            int age;

            do
            {
                Console.Write($"\nВведите Возраст человека: ");
                string readAge = Console.ReadLine();

                if (!int.TryParse(readAge, out age))
                {
                    Console.WriteLine("Некорректный ввод! Возраст должен состоять из цифр.");
                    age = -1;
                    continue;
                }

                // Проверяем, если возраст отрицательный
                if (age < 0)
                {
                    Console.WriteLine("Некорректный ввод! Возраст не может быть отрицательным.");
                }
            }
            while (age < 0);

            // Ввод пола человека.
            string readGender;
            Gender gender = Gender.женский;

            do
            {
                Console.Write($"\nВведите Пол человека: ");
                readGender = Console.ReadLine();

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
                    Console.WriteLine("Некорректный ввод! Введите мужской или женский. ");
                    readGender = string.Empty;
                }
            }
            while (string.IsNullOrEmpty(readGender));

            return new Person(readLastName, readName, age, gender);
        }

        /// <summary>
        /// Метод рандомного создания людей.
        /// </summary>
        /// <returns> Объект класса Person.</returns>
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
