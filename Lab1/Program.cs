namespace Lab1
{
    /// <summary>
    /// Класс Программа.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Метод Main.
        /// </summary>
        internal static void Main()
        {
            Console.WriteLine
            ("a. Автоматически создано два списка людей.\n " +
             "В каждом из списков содержатся записи о трех людях.\n " +
             "Для продолжения нажмите любую кнопку\n");

            List<Person> listPerson1 = new List<Person>
            {
                new Person("Казакова", "Ольга", 27, Gender.Female),
                new Person("Тулин", "Михаил", 35, Gender.Male),
                new Person("Панин", "Семен", 42, Gender.Male)
            };

            List<Person> listPerson2 = new List<Person>
            {
                new Person("Пичугина", "Екатерина", 23, Gender.Female),
                new Person("Лопатин", "Владимир", 60, Gender.Male),
                new Person("Липатов", "Евгений", 25, Gender.Male)
            };

            PersonList firstList =
                new PersonList(listPerson1, "Первый список");

            PersonList secondList =
                new PersonList(listPerson2, "Второй список");

            _ = Console.ReadKey();
            Console.WriteLine("b. Вывод содержимого списков: \n");

            ConsolePerson.Print(firstList);

            ConsolePerson.Print(secondList);

            _ = Console.ReadKey();
            Console.WriteLine("c. Добавление нового " +
                              "человека в 1-ый список: \n");

            firstList.AddPerson
                (new Person("Евстатов", "Данил", 17, Gender.Male));

            ConsolePerson.Print(firstList);

            _ = Console.ReadKey();
            Console.WriteLine
            ("d. Добавление 2-го человека 1-го списка в конец 2-го списка\n" +
            "В итоге, один и тот же человек находится в обоих cписках\n");

            int index = 1;

            secondList.AddPerson(firstList.LookForIndex(index));

            ConsolePerson.Print(secondList);
            ConsolePerson.Print(firstList);

            _ = Console.ReadKey();
            Console.WriteLine
            ("\ne. Удаление 2-го человека из 1-го списка.\n" +
             "В итоге, удаление человека из 1-го списка не привело" +
             " к уничтожению этого же человека во 2-ом списке\n");

            firstList.DeleteByIndex(index);
            ConsolePerson.Print(secondList);
            ConsolePerson.Print(firstList);

            _ = Console.ReadKey();
            Console.WriteLine("\nf. Очищение второго списка\n");

            secondList.Clear();

            ConsolePerson.Print(secondList);

            _ = Console.ReadKey();

            Console.WriteLine("\n4 пункт. Ввод пользователя с клавиатуры\n");

            firstList.AddPerson(ConsolePerson.ConsoleReadPerson());
            ConsolePerson.Print(firstList);

            _ = Console.ReadKey();

            Console.WriteLine("\n5 пункт. Рандомное создание людей\n");

            firstList.AddPerson(Person.GetRandomPerson());
            ConsolePerson.Print(firstList);

            _ = Console.ReadKey();
        }
    }
}
