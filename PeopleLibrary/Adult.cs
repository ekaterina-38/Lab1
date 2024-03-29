
namespace PeopleLibrary
{
    /// <summary>
    /// Класс Взрослый Человек.
    /// </summary>
    public class Adult : Person
    {
        /// <summary>
        /// Серия паспорта.
        /// </summary>
        private int _seriesPassport;

        /// <summary>
        /// Номер паспорта.
        /// </summary>
        private int _numberPassport;

        /// <summary>
        /// Партнер.
        /// </summary>
        private Adult? _partner;

        /// <summary>
        /// Место работы.
        /// </summary>
        private string _nameWork;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="name">Имя.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="seriesPassport">Серия паспорта.</param>
        /// <param name="numberPassport">Номер паспорта.</param>
        /// <param name="partner">Партнер.</param>
        /// <param name="nameWork">Название работы.</param>
        public Adult(string lastName, string name, int age, Gender gender,
            int seriesPassport, int numberPassport, Adult partner,
            string nameWork) : base(lastName, name, age, gender)
        {
            SeriesPassport = seriesPassport;
            NumberPassport = numberPassport;
            Partner = partner;
            NameWork = nameWork;
        }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Adult() : this("Иван", "Иванов", 25, Gender.Male, 1111,
            111111, null, null)
        { }

        /// <summary>
        /// Свойство для поля Серия Паспорта.
        /// </summary>
        public int SeriesPassport
        {
            get
            {
                return _seriesPassport;
            }

            set
            {
                if (!CheckPassport(value, 4))
                {
                    throw new ArgumentOutOfRangeException
                        ("Серия паспорта должна содержать 4 цифры");
                }
                else
                {
                    _seriesPassport = value;
                }
            }
        }

        /// <summary>
        /// Свойство для поля Номер Паспорта.
        /// </summary>
        public int NumberPassport
        {
            get
            {
                return _numberPassport;
            }

            set
            {
                if (!CheckPassport(value, 6))
                {
                    throw new ArgumentOutOfRangeException
                        ("Номер паспорта должен содержать 6 цифр");
                }
                else
                {
                    _numberPassport = value;
                }
            }
        }

        /// <summary>
        /// Свойство для поля Партнер.
        /// </summary>
        public Adult? Partner
        {
            get { return _partner; }

            set
            {
                if (value?.Gender == Gender)
                {
                    throw new ArgumentException
                        ("Невозможно создать однополый брак");
                }

                if (value?.Partner is not null || Partner is not null)
                {
                    throw new ArgumentException
                        ("Человек уже в браке");
                }

                _partner = value;

                if (value is not null)
                {
                    value._partner = this;
                }
            }
        }

        /// <summary>
        /// Свойство для поля Место работы.
        /// </summary>
        public string NameWork
        {
            get
            {
                return _nameWork;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _nameWork = "Безработный";
                }
                else
                {
                    _nameWork = value;
                }
            }
        }

        /// <summary>
        /// Свойство для поля минимальный возраст.
        /// </summary>
        public override int MinAge { get; } = 19;

        /// <summary>
        /// Метод проверки данных паспорта.
        /// </summary>
        /// <param name="data">Номер/Серия.</param>
        /// <param name="fieldSize">Допустимый размер поля.</param>
        /// <returns>Результат проверки(true/false).</returns>
        private static bool CheckPassport(int data, int fieldSize)
        {
            return data.ToString().Length == fieldSize;
        }

        /// <summary>
        /// Переопределенный метод получения информации.
        /// </summary>
        /// <returns>Информация о Взрослом человеке.</returns>
        public override string GetInfo()
        {
            string info = $"{base.GetInfo()}\nМесто работы: {NameWork},\n" +
                $"Данные паспорта: {SeriesPassport} {NumberPassport}\n";

            if (Partner == null)
            {
                info += $"Партнер: не в браке\n";
            }
            else
            {
                info += $"Партнер: {Partner.LastName} {Partner.Name}\n";
            }

            return info;
        }

        /// <summary>
        /// Метод создания семьи.
        /// </summary>
        /// <param name="list">Список людей.</param>
        /// <param name="manIndex">Индекс мужчины в списке.</param>
        /// <param name="womenIndex">Индекс женщины в списке.</param>
        public static void Marriage(PersonList list, int manIndex, int womenIndex)
        {
            ((Adult)list.LookForIndex(manIndex)).Partner =
            ((Adult)list.LookForIndex(womenIndex));
        }

        /// <summary>
        /// Метод водить машину.
        /// </summary>
        public static void DriveCar()
        {
            Console.WriteLine($"Водит машину");
        }
    }
}
