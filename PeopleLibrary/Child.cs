namespace PeopleLibrary
{
    /// <summary>
    /// Класс Ребенок.
    /// </summary>
    public class Child : Person
    {
        /// <summary>
        /// Название Места учебы.
        /// </summary>
        private string _nameStudy;

        /// <summary>
        /// Мать.
        /// </summary>
        private Adult? _mother;

        /// <summary>
        /// Отец.
        /// </summary>
        private Adult? _father;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="name">Имя.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="nameStudy">Место учебы.</param>
        /// <param name="mother">Мать.</param>
        /// <param name="father">Отец.</param>
        public Child(string lastName, string name, int age, Gender gender,
            string nameStudy, Adult? mother, Adult? father) :
            base(lastName, name, age, gender)
        {
            NameStudy = nameStudy;
            Mother = mother;
            Father = father;
        }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Child() : this("Иван", "Иванов", 7, Gender.Male, "Школа",
            null, null)
        { }

        /// <summary>
        /// Свойство для поля Место учебы.
        /// </summary>
        public string NameStudy
        {
            get
            {
                return _nameStudy;
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
                    _nameStudy = value;
                }
            }
        }

        /// <summary>
        /// Свойство для поля Мать.
        /// </summary>
        public Adult? Mother
        {
            get
            {
                return _mother;
            }

            set
            {
                if (value?.Gender != Gender.Female && value is not null)
                {

                    throw new ArgumentException
                        ("Мать должна быть женского пола");
                }

                if (Mother is not null)
                {
                    throw new ArgumentException
                        ("У ребенка уже есть мать");
                }
                else
                {
                    _mother = value;
                }
            }
        }

        /// <summary>
        /// Свойство для поля Отец.
        /// </summary>
        public Adult? Father
        {
            get { return _father; }

            set
            {
                if (value?.Gender != Gender.Male && value is not null)
                {
                    throw new ArgumentException
                        ("Отец должен быть мужского пола");
                }

                if (Father is not null)
                {
                    throw new ArgumentException
                        ("У ребенка уже есть отец");
                }
                else
                {
                    _father = value;
                }
            }
        }

        /// <summary>
        /// Свойство для поля максимальный возраст.
        /// </summary>
        public override int MaxAge { get; } = 18;

        /// <summary>
        /// Переопределенный метод получения информации о Ребенке.
        /// </summary>
        /// <returns>Информация о Ребенке.</returns>
        public override string GetInfo()
        {
            string info = $"{base.GetInfo()}\nМесто учебы: {NameStudy}\n";

            if (Mother is not null)
            {
                info += $"Мать: {Mother.LastName} " + $"{Mother.Name}\n";
            }
            else
            {
                info += "Мать: нет информации\n";
            }

            if (Father is not null)
            {
                info += $"Отец: {Father.LastName} " + $"{Father.Name}\n";
            }
            else
            {
                info += "Отец: нет информации\n";
            }

            return info;
        }

        //TODO: not static +

        /// <summary>
        /// Метод кататься на велосипеде.
        /// </summary>
        public void DriveBike()
        {
            Console.WriteLine($"Катается на велосипеде");
        }
    }
}
