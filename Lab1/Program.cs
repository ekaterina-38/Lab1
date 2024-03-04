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
            List<Person> listPerson1 = new List<Person> { };
            List<Person> listPerson2 = new List<Person> { };

            PersonList firstList =
                new PersonList(listPerson1, "Список Детей:");

            PersonList secondList =
                new PersonList(listPerson2, "Список Взрослых:");

            Console.WriteLine("Вывод содержимого списков: \n");

            firstList.AddPerson(Child.GetRandom());
            firstList.AddPerson(Child.GetRandom());
            firstList.AddPerson(Child.GetRandom());
            secondList.AddPerson(Adult.GetRandom());
            secondList.AddPerson(Adult.GetRandom());
            secondList.AddPerson(Adult.GetRandom());

            ConsolePerson.Print(firstList);

            ConsolePerson.Print(secondList);

            _ = Console.ReadKey();

            Adult.Marriage(secondList);

            ConsolePerson.Print(secondList);
        }
    }
}
