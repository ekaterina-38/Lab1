using System;

namespace PeopleLibrary
{
    public class RandomPerson
    {
        /// <summary>
        /// Метод рандомного создания людей.
        /// </summary>
        /// <returns> Объект класса Person.</returns>
        public static Person GetRandomPerson()
        {
            Person person = new Person();
            GetRandomData(person);
            return person;
        }

        /// <summary>
        /// Виртуальный метод генерации случайных данных людей.
        /// </summary>
        public static void GetRandomData(Person person)
        {
            Random random = new Random();

            person.Gender =
                (Gender)random.Next(Enum.GetValues(typeof(Gender)).Length);

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
        /// <param name="gender">Пол человека,которого нужно создать.</param>
        /// <returns></returns>
        public static Adult GetRandomAdult()
        {
            Adult adult = new Adult();

            GetRandomDataAdult(adult);

            return adult;
        }

        /// <summary>
        /// Метод генерации случайных данных о Взрослом человеке.
        /// </summary>
        /// <param name="gender">Пол человека,которого нужно создать.</param>
        public static void GetRandomDataAdult(Adult adult)
        {
            GetRandomData(adult);

            Random random = new Random();

            string[] nameWork = { "Сбербанк", "Росатом", "МТС", "Яндекс",
                "Аэрофолот", "Газпром нефть" };

            if (adult.Age > 75)
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
        /// Метод рандомного создания Ребенка.
        /// </summary>
        /// <returns>Ребенок.</returns>
        public static Child GetRandomChild()
        {
            Child child = new Child();

            GetRandomData(child);

            return child;
        }

        /// <summary>
        /// Метод генерации данных о Ребенке.
        /// </summary>
        /// <param name="gender">Пол ребенка, которого нужно создать.</param>
        public static void GetRandomDataChild(Child child)
        {
            GetRandomData(child);

            Random random = new Random();

            var namesStudy = new List<string>();

            if (child.Age <= 1)
            {
                namesStudy.AddRange(new[] { "Домашнее обучение" });
            }
            else if (child.Age > 1 && child.Age <= 7)
            {
                namesStudy.AddRange(new[] { "Домашнее обучение", "Детский сад" });
            }
            else
            {
                namesStudy.AddRange(new[] { "Домашнее обучение", "Школа", "Лицей" });
            }

            child.NameStudy = namesStudy[random.Next(namesStudy.Count)];
        }
    }
}
