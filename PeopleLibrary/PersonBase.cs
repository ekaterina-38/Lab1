using System.Globalization;
using System.Text.RegularExpressions;

namespace PeopleLibrary
{
    /// <summary>
    /// Класс Человек.
    /// </summary>
    public abstract class PersonBase
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
        /// Конструктор класса Человек.
        /// </summary>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="name">Имя.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">Пол.</param>
        public PersonBase(string lastName, string name, int age, Gender gender)
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException
                        ("Введена пустая или null строка");
                }
                else if (!СheckLanguage(value))
                {
                    throw new ArgumentOutOfRangeException
                        ("Фамилия должна быть одного языка " +
                        "и не должна содержать цифры");
                }
                else
                {
                    _lastName = ChangeRegister(value);
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException
                        ("Введена пустая или null строка");
                }
                else
                {
                    if (!СheckLanguage(value))
                    {
                        throw new ArgumentOutOfRangeException
                            ("Имя должно быть одного языка " +
                            "и не должно содержать цифры");
                    }

                    if (!СheckFullName(_lastName, value))
                    {
                        throw new ArgumentException
                            ("Фамилия и Имя должны быть одного языка");
                    }
                    else
                    {
                        _name = ChangeRegister(value);
                    }
                }
            }
        }

        /// <summary>
        /// Определение свойства Возраст.
        /// </summary>
        public virtual int Age
        {
            get
            {
                return _age;
            }

            set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new ArgumentOutOfRangeException($"Введите корректный" +
                        $" возраст (от {MinAge} до {MaxAge} лет)");
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
        public Gender Gender { get; set; }

        /// <summary>
        /// Максимальный возраст человека.
        /// </summary>
        public virtual int MaxAge { get; } = 120;

        /// <summary>
        /// Минимальный возраст человека.
        /// </summary>
        public virtual int MinAge { get; }

        /// <summary>
        /// Метод вывода данных о человеке.
        /// </summary>
        /// <returns>Данные о Человек.</returns>
        public virtual string GetInfo()
        {
            return $"Имя: {Name}, Фамилия: {LastName}," +
                   $" Возраст: {Age}, Пол: {Gender}";
        }

        /// <summary>
        /// Регулярное выражение для проверки Фамилии и Имени.
        /// </summary>
        /// <param name="checkValue">Слово, которое требует проверки.</param>
        /// <returns>Результат проверки(true/false).</returns>
        public static bool IsValidName(string checkValue)
        {
            Regex regex = new Regex("(^[a-zA-Z]+$)|(^[а-яА-Я]+$)");
            return regex.IsMatch(checkValue);
        }

        /// <summary>
        /// Проверка отдельно Имени, Фамилии.
        /// </summary>
        /// <param name="checkValue">Проверяемое слово.</param>
        /// <returns>Результат проверки.</returns>
        public static bool СheckLanguage(string checkValue)
        {
            if (checkValue.Contains("-"))
            {
                string[] parts = checkValue.Split('-');
                if (parts.Length == 2)
                {
                    string result = string.Join("", parts);

                    if (!IsValidName(result))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (!IsValidName(checkValue))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Проверка соответвия Фамилии и Имени.
        /// </summary>
        /// <param name="readName">Имя с клавиатуры.</param>
        /// <param name="readLastName">Фамилия с клавиатуры.</param>
        /// <returns>Результат проверки(true/false).</returns>
        public static bool СheckFullName(string readName, string readLastName)
        {
            string fullName = readLastName + readName;
            fullName = string.Join("", fullName.Split('-'));

            return IsValidName(fullName);
        }

        /// <summary>
        /// Преобразование регистров Имен и Фамилий.
        /// </summary>
        /// <param name="checkValue">Слово, которое требует преобразования.</param>
        /// <returns>Преобразованное слово.</returns>
        public static string ChangeRegister(string checkValue)
        {
            string result;
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            if (checkValue.Contains("-"))
            {
                string[] parts = checkValue.Split('-');

                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i] = textInfo.ToTitleCase(parts[i]);
                }

                result = string.Join("-", parts);

            }
            else
            {
                result = textInfo.ToTitleCase(checkValue);
            }

            return result;
        }
    }
}
