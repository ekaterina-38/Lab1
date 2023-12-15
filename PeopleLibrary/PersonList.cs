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
        /// Название списка.
        /// </summary>
        private string _namelistPerson;

        /// <summary>
        /// Конструктор класса Список Людей.
        /// </summary>
        /// <param name="namelistPerson">Название Списка.</param>
        public PersonList(string namelistPerson)
        {
            _namelistPerson = namelistPerson;
            _listPerson = new List<Person>();
        }

        /// <summary>
        /// Конструктор класса Список Людей 2.
        /// </summary>
        /// <param name="listPerson">Список Людей.</param>
        /// <param name="namelistPerson">Название Списка.</param>
        public PersonList(List<Person> listPerson, string namelistPerson)
        {
            _namelistPerson = namelistPerson;
            _listPerson = listPerson;
        }

        //TODO: XML
        public string NamelistPerson
        {
            //TODO: проверки
            get { return _namelistPerson; }
            set { _namelistPerson = value; }
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

        //TODO: rename (Delete By Index)
        /// <summary>
        /// Метод удаления элемента списка по индексу.
        /// </summary>
        /// <param name="index">индекс элемента,который нужно удалить.</param>
        public void ClearListindex(int index)
        {
            //TODO: duplication
            if ((_listPerson.Count - 1) < index || index < 0)
            {
                //TODO: RSDN
                throw new IndexOutOfRangeException($"Элемента с индексом {index} нет в списке");
            }
            else
            {
                _listPerson.RemoveAt(index);
            }
        }

        //TODO: rename
        /// <summary>
        /// Метод удаления диапазона элементов из списка.
        /// </summary>
        /// <param name="index1">индекс элемента,соответвующий началу диапазона.</param>
        /// <param name="count">число удаляемых элементов.</param>
        public void ClearListRange(int index1, int count)
        {
            //TODO: duplication
            if (((_listPerson.Count - 1) < index1 || index1 < 0))
            {
                throw new IndexOutOfRangeException($"Элемента с индексом {index1} нет в списке");
            }
            else if ((_listPerson.Count - 1) < index1 + count || count < 0)
            {
                throw new IndexOutOfRangeException($"Число удаляемых элементов {count} за пределами данного списка");
            }
            else
            {
                _listPerson.RemoveRange(index1, count);
            }
        }

        /// <summary>
        /// Метод получения количества элементов в списке.
        /// </summary>
        public int CountList()
        {
            return _listPerson.Count() - 1;
        }

        /// <summary>
        /// Метод поиска элемента по индексу.
        /// </summary>
        /// <param name="index">интересующий пользователя индекс.</param>
        /// <returns>person.</returns>
        public Person LookForIndexList(int index)
        {
            //TODO: duplication
            if ((_listPerson.Count - 1) < index || index < 0)
            {
                throw new IndexOutOfRangeException($"Элемента с индексом {index} нет в списке");
            }
            else
            {
                return _listPerson[index];
            }
        }

        /// <summary>
        /// Метод возврата индекса элемента при наличии его в списке.
        /// </summary>
        /// <param name="person">Экземпляр класса Человек.</param>
        /// <returns>Возврат индекса элемента,если он есть в списке, иначе -1.</returns>
        public int LookForElementList(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("Аргумент person не может быть null");
            }
            for (int index = 0; index <= (_listPerson.Count - 1); index++)
            {
                if (_listPerson[index] == person)
                {
                    return index;
                }
            }

            throw new InvalidOperationException($"Элемента {person} нет в списке");
        }
    }
}
