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
            // Создание экземляра класса Человек.
            Person kate = new Person("Пичугина", "Екатерина", 23, Gender.женский);

            // Вывод информации о созданном экзепляре.
            kate.Print();

            // Создание экземпляра класса Список Людей.
            PersonList list = new PersonList();

            // Добавление человека в список.
            list.AddPersonList(kate);

            // Вывод информации о созданном экзепляре.
            list.Print();

            /* Вызов метода удаления элемента по индексу.
            list.ClearListindex(0);
            list.Print();*/

            /* Вызов метода очищения списка.
            list.ClearList();
            list.Print();*/

            // Метод возврата индекса элемента при наличии его в списке.
            Console.WriteLine(list.LookForElementList(kate));

            // Вызов метода удаления диапазона элементов в списке.
            list.ClearListRange(0, 1);

            // Вызов метода подсчета количества элементов в списке.
            list.CountList();

            // Вызов метода поиска элемента по индексу.
            list.LookForIndexList(0);
        }
    }
}
