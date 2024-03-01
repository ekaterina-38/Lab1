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
        private string _nameListPerson;

        /// <summary>
        /// Конструктор класса Список Людей.
        /// </summary>
        /// <param name="nameListPerson">Название Списка.</param>
        public PersonList(string nameListPerson)
        {
            _nameListPerson = nameListPerson;
            _listPerson = new List<Person>();
        }

        /// <summary>
        /// Конструктор класса Список Людей 2.
        /// </summary>
        /// <param name="listPerson">Список Людей.</param>
        /// <param name="nameListPerson">Название Списка.</param>
        public PersonList(List<Person> listPerson, string nameListPerson)
        {
            _nameListPerson = nameListPerson;
            _listPerson = listPerson;
        }

        /// <summary>
        /// Определение свойства название списка.
        /// </summary>
        public string NameListPerson
        {
            get
            {
                return _nameListPerson;
            }
            set
            {
                if (string.IsNullOrEmpty(_nameListPerson))
                {
                    throw new ArgumentNullException
                        ("Имя списка не задано");
                }
                else
                {
                    _nameListPerson = value;
                }
            }
        }

        /// <summary>
        /// Метод добавления людей в список.
        /// </summary>
        /// <param name="person">"Экземпляр класса Человек.</param>
        public void AddPerson(Person person)
        {
            _listPerson.Add(person);
        }

        /// <summary>
        /// Метод очищения списка.
        /// </summary>
        public void Clear()
        {
            _listPerson.Clear();
        }

        /// <summary>
        /// Метод проверки наличия элемента в списке. 
        /// </summary>
        /// <param name="index">Интересующий пользователя индекс.</param>
        /// <exception cref="IndexOutOfRangeException">Индекс элемента списка
        /// находится вне диапазона допустимых значений</exception>
        public void CheckByIndex(int index)
        {
            if ((_listPerson.Count - 1) < index || index < 0)
            {
                throw new IndexOutOfRangeException
                    ($"Элемента с индексом {index} нет в списке");
            }
        }

        /// <summary>
        /// Метод поиска элемента по индексу.
        /// </summary>
        /// <param name="index">Интересующий пользователя индекс.</param>
        /// <returns>Человек.</returns>
        public Person LookForIndex(int index)
        {
            CheckByIndex(index);
            return _listPerson[index];
        }

        /// <summary>
        /// Метод удаления элемента списка по индексу.
        /// </summary>
        /// <param name="index">Индекс удаляемого элемента.</param>
        public void DeleteByIndex(int index)
        {
            CheckByIndex(index);
            _listPerson.RemoveAt(index);
        }

        /// <summary>
        /// Метод удаления диапазона элементов из списка.
        /// </summary>
        /// <param name="index">Индекс элемента,
        /// соответвующий началу диапазона.</param>
        /// <param name="count">Число удаляемых элементов.</param>
        /// <exception cref="IndexOutOfRangeException">Индекс элемента списка
        /// находится вне диапазона списка</exception>
        public void DeletByRange(int index, int count)
        {
            CheckByIndex(index);
            if ((_listPerson.Count - 1) < index + count || count < 0)
            {
                throw new IndexOutOfRangeException
                    ($"Число удаляемых элементов {count} " +
                     $"за пределами данного списка");
            }
            else
            {
                _listPerson.RemoveRange(index, count);
            }
        }

        /// <summary>
        /// Метод получения количества элементов в списке.
        /// </summary>
        public int CountPerson()
        {
            return _listPerson.Count();
        }

        /// <summary>
        /// Метод возврата индекса элемента при наличии его в списке.
        /// </summary>
        /// <param name="person">Экземпляр класса Человек.</param>
        /// <returns>Возврат индекса элемента,если он есть в списке,
        /// иначе -1.</returns>
        /// <exception cref="ArgumentNullException">Передано значение
        /// null</exception>
        /// <exception cref="InvalidOperationException">Переданого значения
        /// нет в списке</exception>
        public int LookForElement(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException
                    ("Аргумент person не может быть null");
            }
            for (int index = 0; index <= (_listPerson.Count - 1); index++)
            {
                if (_listPerson[index] == person)
                {
                    return index;
                }
            }

            throw new InvalidOperationException
                ($"Элемента {person} нет в списке");
        }
    }
}
