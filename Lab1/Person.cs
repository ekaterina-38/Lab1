namespace Lab1
{
    /// <summary>
    /// Класс Человек.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Фамилия.
        /// </summary>
        private string _lastName;

        /// <summary>
        /// Имя.
        /// </summary>
        private string _name;

        /// <summary>
        /// Возраст.
        /// </summary>
        private int _age;

        /// <summary>
        /// Пол человека.
        /// </summary>
        private Gender _gender;

        /// <summary>
        /// Конструктор класса Человек.
        /// </summary>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="name">Имя.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">Пол.</param>
        public Person(string lastName, string name, int age, Gender gender)
        {
            LastName = lastName;
            Name = name;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Определение свойства Фамилия.
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        /// <summary>
        /// Определение свойства Имя.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Определение свойства Возраст.
        /// </summary>
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        /// <summary>
        /// Определение свойства Пол человека.
        /// </summary>
        public Gender Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        /// <summary>
        /// Метод вывода данных о человеке.
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"{_lastName} {_name}, возраст: {_age}, пол: {_gender}");
        }
    }
}
