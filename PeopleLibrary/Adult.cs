using System.ComponentModel.Design;

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
        public Adult() : this("Иван", "Иванов", 25, Gender.Male, 1234, 654321, null, null)
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
        /// Свойство для поля партнер.
        /// </summary>
        public Adult? Partner
        {
            get { return _partner; }
            set
            {
                if (value?.Gender == Gender)
                {
                    throw new ArgumentOutOfRangeException
                        ("Невозможно создать однополый брак");
                }
                if (value?.Partner is not null || Partner is not null)
                {
                    throw new ArgumentOutOfRangeException
                        ("Человек уже в браке");
                }

                _partner = value;

                if (value is not null)
                {
                    value._partner = this;
                };
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
        /// Свойство для поля максимальный возраст.
        /// </summary>
        protected override int MaxAge { get; } = 150;

        /// <summary>
        /// Свойство для поля минимальный возраст.
        /// </summary>
        protected override int MinAge { get; } = 19;

        /// <summary>
        /// Метод проверки данных паспорта.
        /// </summary>
        /// <param name="data">Номер/Серия</param>
        /// <param name="fieldSize">Допустимый размер поля</param>
        /// <returns>Результат проверки(true/false)</returns>
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
                
            if(Partner == null)
            {
                info += $"Партнер: не в браке\n";
            }
            else
            {
                info += $"Партнер: {Partner.LastName} {Partner.Name}\n";
            }

            return info ;       
        }

        /// <summary>
        /// Метод создания рандомного Взрослого человека.
        /// </summary>
        /// <returns>Взрослый человек.</returns>
        public static Adult GetRandom()
        {
            Adult adult = new Adult();

            adult.GetRandomData();

            return adult;
        }

        /// <summary>
        /// Метод генерации случайных данных о Взрослом человеке.
        /// </summary>
        protected override void GetRandomData()
        {
            base.GetRandomData();

            Random random = new Random();

            string[] nameWork = { "Сбербанк", "Росатом", "МТС", "Яндекс",
                "Аэрофолот", "Газпром нефть" };
            NameWork = nameWork[random.Next(nameWork.Length)];

            int[] seriesPassport = { 1235, 5241, 7542, 2452,
                2542, 5245 };
            SeriesPassport = seriesPassport[random.Next(seriesPassport.Length)];

            int[] numberPassport = { 123544, 512441, 175142, 244512,
                125142, 521451 };
            NumberPassport = numberPassport[random.Next(numberPassport.Length)];
        }

        /// <summary>
        /// Метод создания семьи. 
        /// </summary>
        /// <param name="list">Список людей.</param>
        public static void Marriage (PersonList list)
        {
            int manIndex = list.LookForGender(Gender.Male);
            int womenIndex = list.LookForGender(Gender.Female);

            ((Adult)list.LookForIndex(manIndex)).Partner =
            ((Adult)list.LookForIndex(womenIndex));
        }

    }
}
