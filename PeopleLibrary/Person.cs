using System.Globalization;
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
        /// Максимальный и минимальный возраст человека.
        /// </summary>
        private const int _maxAge = 150, _minAge = 0;

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
        /// Конструктор по умолчанию класса Человек.
        /// </summary>
        public Person() : this("Иванов", "Иван", 18, Gender.Male)
        { }

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
                //TODO: проверить null и пустую строку? +
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException
                              ("Введена пустая строка");
                }
                else if (!СheckLanguage(value))
                {
                    //TODO: exception +
                    throw new ArgumentOutOfRangeException
                              ("Фамилия должна быть одного языка");
                }
                else
                {
                    _lastName = BigLetter(value);
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
                //TODO: проверить null и пустую строку? +
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException
                              ("Введена пустая строка");
                }
                else
                {
                    if (!СheckLanguage(value))
                    {
                        //TODO: exception +  
                        throw new ArgumentOutOfRangeException
                                  ("Имя должно быть одного языка");
                    }
                    if (!СheckFullName(_lastName, value))
                    {
                        //TODO: exception +
                        throw new ArgumentException
                                  ("Фамилия и Имя должны быть одного языка");
                    }
                    else
                    {
                        _name = BigLetter(value);
                    }
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
                //TODO: проверить на бессмертие +
                if (value < _minAge || value > _maxAge)
                {
                    //TODO: RSDN +
                    throw new ArgumentOutOfRangeException
                              ("Введите корректный возраст");
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
        /// Регулярное выражение для проверки Фамилии и Имени.
        /// </summary>
        /// <param name="name">Слово, которое требует проверки.</param>
        /// <returns>Результат проверки(true/false).</returns>
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
            if (read.Contains("-"))
            {
                string[] parts = read.Split('-');
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
            else if (!IsValidName(read))
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
        /// <param name="read">Слово, которое требует преобразования.</param>
        /// <returns>Преобразованное слово.</returns>
        public static string BigLetter(string read)
        {
            string result;
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            if (read.Contains("-"))
            {
                string[] parts = read.Split('-');

                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i] = textInfo.ToTitleCase(parts[i]);
                }

                result = string.Join("-", parts);

            }
            else
            {
                result = textInfo.ToTitleCase(read);
            }

            return result;
        }

        /// <summary>
        /// Метод рандомного создания людей.
        /// </summary>
        /// <returns> Объект класса Person.</returns>
        public static Person GetRandomPerson()
        {
            Person person = new Person();

            Random random = new Random();

            string[] namesWonem = { "Екатерина", "Ольга", "Надежда", "Любовь", "Ирина", "Анастасия", "Кира" };
            string[] namesMen = { "Владимир", "Артем", "Степан", "Виктор", "Александр", "Дмитрий", "Валентин" };
            string[] lastNames = { "Иванов", "Васнецов", "Ольгин", "Кулагин", "Ефремов", "Ласточкин", "Морозов", "Туклинин" };

            person.Gender = (Gender)random.Next(Enum.GetValues(typeof(Gender)).Length);

            if (person.Gender == Gender.Female)
            {
                person.Name = namesWonem[random.Next(namesWonem.Length)];
                person.LastName = lastNames[random.Next(lastNames.Length)] + "а";
            }
            else if (person.Gender == Gender.Male)
            {
                person.Name = namesMen[random.Next(namesMen.Length)];
                person.LastName = lastNames[random.Next(lastNames.Length)];
            }

            person.Age = random.Next(_minAge, _maxAge);

            return person;
        }
    }
}
