
namespace PeopleLibrary
{
    /// <summary>
    /// Класс рандомного создания Людей.
    /// </summary>
    public static class RandomPeople
    {

        /// <summary>
        /// Метод генерации рандомного пола у Человека.
        /// </summary>
        /// <param name="person">Объект класса Person.</param>
        public static void RandomGender(Person person)
        {
            Random random = new Random();

            person.Gender =
                (Gender)random.Next(Enum.GetValues(typeof(Gender)).Length);
        }

        /// <summary>
        /// Метод генерации рандомных данных о Человеке.
        /// </summary>
        /// <param name="person">Объект класса Person.</param>
        public static void GetDataPerson(Person person)
        {
            Random random = new Random();

            string[] lastNames = { "Иванов", "Васнецов", "Ольгин", "Кулагин",
                "Ефремов", "Ласточкин", "Морозов"};

            if (person.Gender == Gender.Female)
            {
                string[] namesWonem = { "Екатерина", "Ольга", "Надежда",
                "Любовь", "Ирина", "Анастасия" };
                person.Name = namesWonem[random.Next(namesWonem.Length)];
                person.LastName =
                    lastNames[random.Next(lastNames.Length)] + "а";
            }
            else if (person.Gender == Gender.Male)
            {
                string[] namesMen = { "Владимир", "Артем", "Степан","Виктор",
                "Александр", "Дмитрий"};

                person.Name = namesMen[random.Next(namesMen.Length)];
                person.LastName = lastNames[random.Next(lastNames.Length)];
            }

            person.Age = random.Next(person.MinAge, person.MaxAge);
        }

        /// <summary>
        /// Метод создания рандомного Взрослого человека.
        /// </summary>
        /// <returns>Объект класса Adult.</returns>
        public static Adult GetAdult()
        {
            Adult adult = new Adult();

            RandomGender(adult);

            GetDataPerson(adult);

            GetDataAdult(adult);

            GetPartner(adult);

            return adult;
        }

        /// <summary>
        /// Перегруженный метод создания рандомного Взрослого человека.
        /// </summary>
        /// <param name="gender">Пол человека.</param>
        /// <returns>Объект класса Adult.</returns>
        public static Adult GetAdult(Gender gender)
        {
            Adult adult = new Adult();

            adult.Gender = gender;

            GetDataPerson(adult);

            GetDataAdult(adult);

            GetPartner(adult);

            return adult;
        }

        /// <summary>
        /// Метод генерации рандомных данных о Взрослом человеке.
        /// </summary>
        /// <param name="adult">Объект класса Adult.</param>
        public static void GetDataAdult(Adult adult)
        {
            Random random = new Random();

            string[] nameWork = { "Сбербанк", "Росатом", "МТС", "Яндекс",
                "Аэрофолот", "Газпром нефть" };

            if (adult.Age > 65)
            {
                adult.NameWork = "На пенсиии";
            }
            else
            {
                adult.NameWork = nameWork[random.Next(nameWork.Length)];
            }

            int[] seriesPassport = { 1235, 5241, 7542, 2452,
                2542, 5245 };
            adult.SeriesPassport = seriesPassport[random.Next(seriesPassport.Length)];

            int[] numberPassport = { 123544, 512441, 175142, 244512,
                125142, 521451 };
            adult.NumberPassport = numberPassport[random.Next(numberPassport.Length)];

        }

        /// <summary>
        /// Метод создания партнера для Взрослого.
        /// </summary>
        /// <param name="adult">Объект класса Adult.</param>
        public static void GetPartner(Adult adult)
        {
            Random random = new Random();

            if (random.Next(2) == 0)
            {
                Adult partner = new Adult();

                if (adult.Gender == Gender.Female)
                {
                    partner.Gender = Gender.Male;
                    GetDataPerson(partner);
                    GetDataAdult(partner);
                    adult.Partner = partner;
                    adult.LastName = partner.LastName + "а";
                }
                else
                {
                    //TODO: подумать +

                    partner.Gender = Gender.Female;
                    GetDataPerson(partner);
                    GetDataAdult(partner);
                    adult.Partner = partner;
                    partner.LastName = adult.LastName + "а";
                }
            }
        }

        /// <summary>
        /// Метод создания рандомного Ребенка.
        /// </summary>
        /// <returns>Объект класса Child.</returns>
        public static Child GetChild()
        {
            Child child = new Child();

            RandomGender(child);

            GetDataPerson(child);

            GetDataChild(child);

            return child;
        }

        /// <summary>
        /// Метод генерации рандомных данных о Ребенке.
        /// </summary>
        /// <param name="child">Объект класса Child.</param>
        public static void GetDataChild(Child child)
        {
            Random random = new Random();

            var namesStudy = new List<string>();

            if (child.Age <= 1)
            {
                namesStudy.AddRange(new[] { "Домашнее обучение" });
            }
            else if (child.Age >= 2 && child.Age <= 7)
            {
                namesStudy.AddRange(new[] { "Домашнее обучение", "Детский сад" });
            }
            else
            {
                namesStudy.AddRange(new[] { "Домашнее обучение", "Школа", "Лицей" });
            }

            child.NameStudy = namesStudy[random.Next(namesStudy.Count)];

            int countParents = random.Next(3);

            if (countParents == 0)
            {
                GetParents(child);
            }
            else if (countParents == 1)
            {
                GetOneParent(child);
            }
        }

        /// <summary>
        /// Метод создания обоих родителей для ребенка.
        /// </summary>
        /// <param name="child">Объект класса Child.</param>
        public static void GetParents(Child child)
        {
            child.Father = GetAdult(Gender.Male);
            child.Mother = GetAdult(Gender.Female);

            if (child.Gender == Gender.Female)
            {
                child.LastName = child.Father.LastName + "а";
                child.Mother.LastName = child.Father.LastName + "а";
            }
            else
            {
                child.LastName = child.Father.LastName;
                child.Mother.LastName = child.Father.LastName + "а";
            }
        }

        /// <summary>
        /// Метод создания одного родителя для ребенка.
        /// </summary>
        /// <param name="child">Объект класса Child.</param>
        public static void GetOneParent(Child child)
        {
            Adult adult = GetAdult();

            if (adult.Gender == Gender.Female)
            {
                child.Mother = adult;

                if (child.Gender == Gender.Female)
                {
                    child.LastName = child.Mother.LastName;
                }
                else
                {
                    child.LastName = RemoveLastLetter(child.Mother.LastName);
                }
            }
            else
            {
                child.Father = adult;

                if (child.Gender == Gender.Female)
                {
                    child.LastName = child.Father.LastName + "а";
                }
                else
                {
                    child.LastName = child.Father.LastName;
                }
            }
        }

        /// <summary>
        /// Метод удаления последней буквы в фамилии.
        /// </summary>
        /// <param name="lastName">Фамилия.</param>
        /// <returns>Скорректированная фамилия.</returns>
        private static string RemoveLastLetter(string lastName)
        {
            return lastName.Substring(0, lastName.Length - 1);
        }

        /// <summary>
        /// Метод создания списка Взрослых и Детей.
        /// </summary>
        /// <param name="list">Список.</param>
        /// <param name="countElements">Количество элементов в списке.</param>
        public static void GetList(PersonList list, int countElements)
        {
            Random random = new Random();

            for (int i = 0; i < countElements; i++)
            {
                if (random.Next(2) == 0)
                {
                    list.AddPerson(GetChild());
                }
                else
                {
                    list.AddPerson(GetAdult());
                }
            }
        }
    }
}
