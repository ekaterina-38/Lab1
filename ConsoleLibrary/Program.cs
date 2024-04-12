using PeopleLibrary;

namespace ConsoleLibrary
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
            List<PersonBase> listPerson = new List<PersonBase> { };

            PersonList firstList =
                new PersonList(listPerson, "Список Взрослых и Детей:\n");

            RandomPeople.GetList(firstList, 7);

            ConsolePerson.Print(firstList);

            var people = firstList.LookForIndex(3);

            Type typePeople = people.GetType();

            Console.WriteLine($"Тип данных 4-го человека списке:" +
                $" {typePeople}");

            if (typePeople == typeof(Adult))
            {

                ((Adult)people).DriveCar();
            }

            if (typePeople == typeof(Child))
            {
                ((Child)people).DriveBike();
            }

            _ = Console.ReadKey();
        }
    }
}
