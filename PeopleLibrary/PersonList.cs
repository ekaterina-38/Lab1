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

        //TODO: XML +
        /// <summary>
        /// Определение свойства название списка.
        /// </summary>
        public string NamelistPerson
        {
            //TODO: проверки +
            get
            {
                return _namelistPerson;
            }
            set
            {
                if (string.IsNullOrEmpty(_namelistPerson))
                {
                    throw new ArgumentNullException
                        ("Имя списка не задано");
                }
                else
                {
                    _namelistPerson = value;
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
        /// <param name="index">интересующий пользователя индекс.</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void CheckByIndex(int index)
        {
            //TODO: duplication +
            if ((_listPerson.Count - 1) < index || index < 0)
            {
                //TODO: RSDN +
                throw new IndexOutOfRangeException
                    ($"Элемента с индексом {index} нет в списке");
            }
        }

        /// <summary>
        /// Метод поиска элемента по индексу.
        /// </summary>
        /// <param name="index">интересующий пользователя индекс.</param>
        /// <returns>person.</returns>
        public Person LookForIndex(int index)
        {
            //TODO: duplication +
            CheckByIndex(index);
            return _listPerson[index];
        }

        //TODO: rename (Delete By Index) +
        /// <summary>
        /// Метод удаления элемента списка по индексу.
        /// </summary>
        /// <param name="index">индекс удаляемого элемента.</param>
        public void DeleteByIndex(int index)
        {
            //TODO: duplication +
            CheckByIndex(index);
            _listPerson.RemoveAt(index);
        }

        //TODO: rename+
        /// <summary>
        /// Метод удаления диапазона элементов из списка.
        /// </summary>
        /// <param name="index1">индекс элемента,
        /// соответвующий началу диапазона.</param>
        /// <param name="count">число удаляемых элементов.</param>
        public void DeletByRange(int index1, int count)
        {
            //TODO: duplication +
            CheckByIndex(index1);
            if ((_listPerson.Count - 1) < index1 + count || count < 0)
            {
                throw new IndexOutOfRangeException
                    ($"Число удаляемых элементов {count} " +
                     $"за пределами данного списка");
            }
            else
            {
                _listPerson.RemoveRange(index1, count);
            }
        }

        /// <summary>
        /// Метод получения количества элементов в списке.
        /// </summary>
        public int Count()
        {
            return _listPerson.Count() - 1;
        }

        /// <summary>
        /// Метод возврата индекса элемента при наличии его в списке.
        /// </summary>
        /// <param name="person">Экземпляр класса Человек.</param>
        /// <returns>Возврат индекса элемента,если он есть в списке,
        /// иначе -1.</returns>
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
