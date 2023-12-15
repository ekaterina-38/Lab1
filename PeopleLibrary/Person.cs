using System.Text.RegularExpressions;

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
            get
            {
                return _lastName;
            }
            set
            {
                //TODO: проверить null и пустую строку?
                if (!СheckLanguage(value))
                {
                    //TODO: exception
                    throw new Exception("Фамилия должна быть одного языка");
                }
                else
                {
                    _lastName = value;
                }
            }
        }

        /// <summary>
        /// Определение свойства Имя.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                //TODO: проверить null и пустую строку?
                if (!СheckLanguage(value))
                {
                    //TODO: exception
                    throw new Exception("Имя должно быть одного языка");
                }
                else if (!СheckFullName(_lastName, value))
                {
                    //TODO: exception
                    throw new Exception("Фамилия и Имя должны быть одного языка");
                }
                else
                {
                    _name = value;
                }
            }
        }

        /// <summary>
        /// Определение свойства Возраст.
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                //TODO: проверить на бессмертие
                if (value < 0)
                {
                    //TODO: RSDN
                    throw new ArgumentOutOfRangeException("Возраст должен быть больше нуля.");
                }
                else
                {
                    _age = value;
                }
            }
        }

        /// <summary>
        /// Определение свойства Пол человека.
        /// </summary>
        public Gender Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }

        /// <summary>
        /// Метод вывода данных о человеке.
        /// </summary>
        public string GetInfo()
        {
            return $"Имя: {_name}, Фамилия: {_lastName}," +
                   $" возраст: {_age}, пол: {_gender}";
        }

        /// <summary>
        /// Регулярное выражение для проверки Фамилии и Имени по требованию языка.
        /// </summary>
        /// <param name="name">слово, которое требует проверки.</param>
        /// <returns>результат проверки(true/false).</returns>
        public static bool IsValidName(string name)
        {
            Regex regex = new Regex("(^[a-zA-Z]+$)|(^[а-яА-Я]+$)");
            return regex.IsMatch(name);
        }

        /// <summary>
        /// Проверка отдельно Имени, Фамилии.
        /// </summary>
        /// <param name="read">Проверяемое слово.</param>
        /// <returns>Результат проверки.</returns>
        public static bool СheckLanguage(string read)
        {
            //TODO: название?
            bool control = true;

            if (read.Contains("-"))
            {
                string[] parts = read.Split('-');
                if (parts.Length == 2)
                {
                    string result = string.Join("", parts);

                    if (!IsValidName(result))
                    {
                        control = false;
                    }
                }
                else
                {
                    control = false;
                }
            }
            else if (!IsValidName(read))
            {
                control = false;
            }

            return control;
        }

        /// <summary>
        /// Проверка соответвия Фамилии и Имени.
        /// </summary>
        /// <param name="readName">имя с клавиатуры.</param>
        /// <param name="readLastName">фамилия с клавиатуры.</param>
        /// <returns>результат проверки(true/false).</returns>
        public static bool СheckFullName(string readName, string readLastName)
        {
            //TODO: название?
            bool boolName = true;
            string fullName = readLastName + readName;
            fullName = string.Join("", fullName.Split('-'));

            if (!IsValidName(fullName))
            {
                boolName = false;
            }

            return boolName;
        }
    }
}
