namespace Lab1
{
    /// <summary>
    /// Класс Список Людей
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Лист, хранящий перечень людей
        /// </summary>
        public List<Person> ListPerson;

        /// <summary>
        /// Конструктор класса Список Людей
        /// </summary>
        public PersonList()
        {
            // Пустой список
            ListPerson = new List<Person>();
        }

        /// <summary>
        /// Метод добавления людей в список
        /// </summary>
        /// <param name="person">"Экземпляр класса Человек</param>
        public void AddPersonList(Person person)
        {
            ListPerson.Add(person);
        }

        /// <summary>
        /// Метод очищения списка
        /// </summary>
        public void ClearList()
        {
            ListPerson.Clear();
        }

        /// <summary>
        /// Метод удаления элемента списка по индексу
        /// </summary>
        /// <param name="index">индекс элемента,который нужно удалить</param>
        public void ClearListindex(int index)
        {
            ListPerson.RemoveAt(index);
        }

        /// <summary>
        /// Метод удаления диапазона элементов из списка
        /// </summary>
        /// <param name="index1">индекс элемента,соответвующий началу диапазона</param>
        /// <param name="index2">индекс элемента,соответвующий концу диапазона</param>
        public void ClearListRange(int index1, int index2)
        {
            ListPerson.RemoveRange(index1, index2);
        }

        /// <summary>
        /// Метод получения количества элементов в списке
        /// </summary>
        public void CountList()
        {
            Console.WriteLine(ListPerson.Count());
        }

        /// <summary>
        /// Метод поиска элемента по индексу
        /// </summary>
        /// <param name="index">интересующий пользователя индекс</param>
        public void LookForIndexList(int index)
        {
            if ((ListPerson.Count - 1) >= index)
            {
                Console.WriteLine($"Элемент с индексом {index}: {ListPerson[index]._lastName}" +
                                                                $" {ListPerson[index]._name}, " +
                                                                $"возраст: {ListPerson[index]._age}, " +
                                                                $"пол: {ListPerson[index]._gender}");
            }
            else
            {
                Console.WriteLine($"Элемента с индексом {index} нет в списке");
            }
        }

        /// <summary>
        /// Метод возврата индекса элемента при наличии его в списке
        /// </summary>
        /// <param name="person">Экземпляр класса Человек</param>
        public int LookForElementList(Person person)
        {
            for (int i = 0; i <= (ListPerson.Count - 1); i++)
            {
                if (ListPerson[i] == person)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Метод вывода списка людей
        /// </summary>
        public void Print()
        {
            for (int i = 0; i <= (ListPerson.Count - 1); i++)
            {
                if (ListPerson.Count > 0)
                {
                    Console.WriteLine($"Список 1: {ListPerson[i]._lastName} " +
                                              $"{ListPerson[i]._name}, " +
                                              $"возраст: {ListPerson[i]._age}, " +
                                              $"пол: {ListPerson[i]._gender} ");
                }
                else
                {
                    Console.WriteLine("Список пуст");
                }
            }
        }
    }
}
