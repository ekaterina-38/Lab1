namespace Lab1
{
    /// <summary>
    /// Класс Список Людей.
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Лист, хранящий перечень людей.
        /// </summary>
        private List<Person> _listPerson;

        /// <summary>
        /// Конструктор класса Список Людей.
        /// </summary>
        public PersonList()
        {
            _listPerson = new List<Person>();
        }

        /// <summary>
        /// Метод добавления людей в список.
        /// </summary>
        /// <param name="person">"Экземпляр класса Человек.</param>
        public void AddPersonList(Person person)
        {
            _listPerson.Add(person);
        }

        /// <summary>
        /// Метод очищения списка.
        /// </summary>
        public void ClearList()
        {
            _listPerson.Clear();
        }

        /// <summary>
        /// Метод удаления элемента списка по индексу.
        /// </summary>
        /// <param name="index">индекс элемента,который нужно удалить.</param>
        public void ClearListindex(int index)
        {
            _listPerson.RemoveAt(index);
        }

        /// <summary>
        /// Метод удаления диапазона элементов из списка.
        /// </summary>
        /// <param name="index1">индекс элемента,соответвующий началу диапазона.</param>
        /// <param name="index2">индекс элемента,соответвующий концу диапазона.</param>
        public void ClearListRange(int index1, int index2)
        {
            _listPerson.RemoveRange(index1, index2);
        }

        /// <summary>
        /// Метод получения количества элементов в списке.
        /// </summary>
        public void CountList()
        {
            Console.WriteLine(_listPerson.Count());
        }

        /// <summary>
        /// Метод поиска элемента по индексу.
        /// </summary>
        /// <param name="index">интересующий пользователя индекс.</param>
        public void LookForIndexList(int index)
        {
            if ((_listPerson.Count - 1) >= index)
            {
                Console.WriteLine($"Элемент с индексом {index}: {_listPerson[index].LastName}" +
                                                                $" {_listPerson[index].Name}, " +
                                                                $"возраст: {_listPerson[index].Age}, " +
                                                                $"пол: {_listPerson[index].Gender}");
            }
            else
            {
                Console.WriteLine($"Элемента с индексом {index} нет в списке");
            }
        }

        /// <summary>
        /// Метод возврата индекса элемента при наличии его в списке.
        /// </summary>
        /// <param name="person">Экземпляр класса Человек.</param>
        /// <returns>Возврат индекса элемента,если он есть в списке, иначе -1.</returns>
        public int LookForElementList(Person person)
        {
            for (int i = 0; i <= (_listPerson.Count - 1); i++)
            {
                if (_listPerson[i] == person)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Метод вывода списка людей.
        /// </summary>
        public void Print()
        {
            for (int i = 0; i <= (_listPerson.Count - 1); i++)
            {
                if (_listPerson.Count > 0)
                {
                    Console.WriteLine($"Список 1: {_listPerson[i].LastName} " +
                                              $"{_listPerson[i].Name}, " +
                                              $"возраст: {_listPerson[i].Age}, " +
                                              $"пол: {_listPerson[i].Gender} ");
                }
                else
                {
                    Console.WriteLine("Список пуст");
                }
            }
        }
    }
}
