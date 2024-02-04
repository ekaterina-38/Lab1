namespace Lab1
{
    /// <summary>
    /// Класс вывода.
    /// </summary>
    public class ConsolePerson
    {
        /// <summary>
        /// Метод заполнения данных о Людях с клавиатуры.
        /// </summary>
        /// <returns>Объект класса Person.</returns>
        public static Person ConsoleReadPerson()
        {
            Person person1 = new Person();
            bool flag;
            do
            {
                Console.Write($"\nВведите фамилию человека: ");
                flag = false;
                try
                {
                    person1.LastName = Console.ReadLine();
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine($"Возникла ошибка: {ex.Message}");
                    flag = true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Возникла ошибка: {ex.Message}");
                    flag = true;
                }
            }
            while (flag);

            do
            {
                Console.Write($"\nВведите имя человека: ");
                flag = false;
                try
                {
                    person1.Name = Console.ReadLine();
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine($"Возникла ошибка: {ex.Message}");
                    flag = true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Возникла ошибка: {ex.Message}");
                    flag = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Возникла ошибка: {ex.Message}");
                    flag = true;
                }
            }
            while (flag);

            do
            {
                Console.Write($"\nВведите возраст человека: ");
                flag = false;
                try
                {
                    person1.Age = Convert.ToInt32(Console.ReadLine());
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Возникла ошибка: {ex.Message}");
                    flag = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Возникла ошибка: {ex.Message}");
                    flag = true;
                }
            }
            while (flag);

            // Ввод пола человека.
            string readGender;
            do
            {
                Console.Write($"\nВведите Пол человека: ");
                readGender = Console.ReadLine();

                if (readGender == "Female")
                {
                    person1.Gender = Gender.Female;
                }
                else if (readGender == "Male")
                {
                    person1.Gender = Gender.Male;
                }
                else
                {
                    Console.WriteLine("Введите пол: Male или Female.");
                    readGender = string.Empty;
                }
            }
            while (string.IsNullOrEmpty(readGender));

            return person1;
        }

        /// <summary>
        /// Метод вывода списка людей.
        /// </summary>
        /// <param name="listperson">список людей.</param>
        public static void Print(PersonList listperson)
        {
            Console.WriteLine(listperson.NamelistPerson);

            int count = listperson.Count();

            for (int index = 0; index <= count; index++)
            {
                Person person = listperson.LookForIndex(index);
                Console.WriteLine(person.GetInfo());
            }

            Console.WriteLine();
        }
    }
}
