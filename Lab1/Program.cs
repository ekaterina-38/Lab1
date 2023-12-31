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
            Console.WriteLine("a. Автоматически создано два списка людей.\n " +
                              "В каждом из списков содержатся записи о трех людях.\n " +
                              "Для продолжения нажмите любую кнопку\n");

            List<Person> listPerson1 = new List<Person>{new Person("Казакова", "Ольга", 27, Gender.женский),
                                                       new Person("Тулин", "Михаил", 35, Gender.мужской),
                                                       new Person("Панин", "Семен", 42, Gender.мужской)};

            List<Person> listPerson2 = new List<Person>{new Person("Пичугина", "Екатерина", 23, Gender.женский),
                                                       new Person("Лопатин", "Владимир", 60, Gender.мужской),
                                                       new Person("Липатов", "Евгений", 25, Gender.мужской)};

            // Создание первого списка, хранящего информацию о людях.
            PersonList firstList = new PersonList(listPerson1, "Первый список");

            // Создание второго списка, хранящего информацию о людях.
            PersonList secondList = new PersonList(listPerson2, "Второй список");

            _ = Console.ReadKey();
            Console.WriteLine("b. Вывод содержимого списков: \n");

            // Первый список
            firstList.Print();

            // Второй список
            secondList.Print();

            _ = Console.ReadKey();
            Console.WriteLine("c. Добавление нового человека в первый список: \n");

            // Добавление человека в первый список.
            firstList.AddPersonList(new Person("Казакова", "Ольга", 27, Gender.женский));

            // Первый список
            firstList.Print();

            _ = Console.ReadKey();
            Console.WriteLine("d. Добавление второго человека первого списка в конец второго списка\n" +
                              "В результате, один и тот же человек находится в обоих cписках\n");
            int index = 1;

            secondList.AddPersonList(firstList.LookForIndexList(index));

            secondList.LookForIndexList(secondList.LookForElementList(firstList.LookForIndexList(index))).Print();
            firstList.LookForIndexList(index).Print();

            _ = Console.ReadKey();
            Console.WriteLine("\ne. Удаление второго человека из первого списка.\n" +
                                "В результате, удаление человека из первого списка не привело " +
                                "к уничтожению этого же человека во втором списке\n");

            Person a = firstList.LookForIndexList(index);

            firstList.ClearListindex(index);
            secondList.LookForIndexList(secondList.LookForElementList(a)).Print();

            _ = Console.ReadKey();
            Console.WriteLine("\nf. Очищение второго списка\n");
            secondList.ClearList();

            // Второй список
            secondList.Print();

            /* Вызов метода удаления элемента по индексу.
            list.ClearListindex(0);
            list.Print();*/

            /* Вызов метода очищения списка.
            list.ClearList();
            list.Print();*/

            // Метод возврата индекса элемента при наличии его в списке.
            // Console.WriteLine(firstList.LookForElementList(kate));

            // Вызов метода удаления диапазона элементов в списке.
            // firstList.ClearListRange(0, 1);

            // Вызов метода подсчета количества элементов в списке.
            // firstList.CountList();

            // Вызов метода поиска элемента по индексу.
            // firstList.LookForIndexList(0);
        }
    }
}
