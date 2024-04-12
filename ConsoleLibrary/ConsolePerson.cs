using PeopleLibrary;

namespace ConsoleLibrary
{
    /// <summary>
    /// Класс вывода.
    /// </summary>
    public class ConsolePerson
    {
        /// <summary>
        /// Метод вывода списка людей.
        /// </summary>
        /// <param name="listperson">Список людей.</param>
        public static void Print(PersonList listperson)
        {
            Console.WriteLine(listperson.NameListPerson);

            int count = listperson.CountPerson();

            for (int index = 0; index < count; index++)
            {
                PersonBase person = listperson.LookForIndex(index);
                Console.WriteLine(person.GetInfo());
            }

            Console.WriteLine();
        }
    }
}
