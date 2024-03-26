using PeopleLibrary;

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
            //List<Person> listPerson1 = new List<Person> { };
            //List<Person> listPerson2 = new List<Person> { };

            //PersonList firstList =
            //    new PersonList(listPerson1, "Список Детей:");

            //PersonList secondList =
            //    new PersonList(listPerson2, "Список Взрослых:");

            //Console.WriteLine("Вывод содержимого списков: \n");

            //firstList.AddPerson(Child.GetRandom(Gender.Female));
            //firstList.AddPerson(new Child("Александра", "Петрова", 15,
            //    Gender.Female, "Школа", Adult.GetRandom(Gender.Female),
            //    Adult.GetRandom(Gender.Male)));

            //secondList.AddPerson(new Adult("Виктор", "Кузнецов", 42,
            //    Gender.Male, 3650, 567895, null, "Инженер"));
            //secondList.AddPerson(new Adult("Виктория", "Кузнецова", 40,
            //    Gender.Female, 3421, 553421, null, "Стоматолог"));

            //Adult.Marriage(secondList, 0, 1);

            //secondList.AddPerson(Adult.GetRandom(Gender.Female));
            //secondList.AddPerson(Adult.GetRandom(Gender.Male));

            //ConsolePerson.Print(firstList);

            //ConsolePerson.Print(secondList);

            //Console.WriteLine($"Тип данных 4-го человека списке:" +
            //    $" {secondList.LookForIndex(3).GetType()}");

            //_ = Console.ReadKey();

            Child child = RandomPerson.GetRandomChild();
        }
    }
}
