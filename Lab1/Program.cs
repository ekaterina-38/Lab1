using PeopleLibrary;
using System.Collections.Generic;

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
            List<Person> listPerson = new List<Person> { };

            PersonList firstList =
                new PersonList(listPerson, "Список Взрослых и Детей:\n");

            RandomPeople.GetList(firstList, 7);

            ConsolePerson.Print(firstList);

            Console.WriteLine($"Тип данных 4-го человека списке:" +
                $" {firstList.LookForIndex(3).GetType()}");

            _ = Console.ReadKey();
        }
    }
}
