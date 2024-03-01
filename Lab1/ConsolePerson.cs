namespace Lab1
{
    /// <summary>
    /// Класс вывода.
    /// </summary>
    public class ConsolePerson
    {
        /// <summary>
        /// Метод заполнения данных о Людях с клавиатуры.
        /// </summary>
        /// <returns>Объект класса Person.</returns>
        public static Person ConsoleReadPerson()
        {
            Person person = new Person();

            string readGender;

            List<Action> actions = new List<Action>()
            {
                ()=>
                    {
                        Console.Write($"\nВведите фамилию человека: ");
                        person.LastName = Console.ReadLine();
                    },
                ()=>
                    {
                        Console.Write($"\nВведите имя человека: ");
                        person.Name = Console.ReadLine();
                    },
                ()=>
                    {
                        Console.Write($"\nВведите возраст человека: ");
                        person.Age = Convert.ToInt32(Console.ReadLine());
                    },
                ()=>
                    {
                        Console.Write("\nВведите Пол человека М(M)/Ж(F): ");
                        readGender = Console.ReadLine().ToUpper();
                        switch (readGender)
                        {
                            case "F":
                            case "Ж":
                                {
                                    person.Gender = Gender.Female;
                                    break;
                                }

                            case "M":
                            case "М":
                                {
                                    person.Gender = Gender.Male;
                                    break;
                                }

                            default:
                                {
                                    Console.WriteLine(
                                        "\nВведите Пол человека М(M)/Ж(F): ");
                                    throw new ArgumentOutOfRangeException(
                                        "Пол человека М(M)/Ж(F)");
                                }

                        }
                    }
            };

            foreach (Action action in actions)
            {
                ExceptionHandler(action);
            }

            return person;
        }

        /// <summary>
        /// Обработчик исключений.
        /// </summary>
        /// <param name="action">Действие, которое требует проверки.</param>
        public static void ExceptionHandler(Action action)
        {
            var catchDictionary = new Dictionary<Type, Action<string>>
            {
                { typeof(NullReferenceException),
                (string message) =>
                {
                    Console.WriteLine($"Возникла ошибка: {message}");
                }
                },

                { typeof(ArgumentOutOfRangeException),
                (string message) =>
                {
                    Console.WriteLine($"Возникла ошибка: {message}");
                }
                },

                { typeof(ArgumentException),
                (string message) =>
                {
                    Console.WriteLine($"Возникла ошибка: {message}");
                }
                },

                { typeof(FormatException),
                (string message) =>
                {
                    Console.WriteLine($"Возникла ошибка: {message}");
                }
                },
            };

            while (true)
            {
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception ex)
                {
                    catchDictionary[ex.GetType()].Invoke(ex.Message);
                }
            }
        }

        /// <summary>
        /// Метод вывода списка людей.
        /// </summary>
        /// <param name="listperson">Список людей.</param>
        public static void Print(PersonList listperson)
        {
            Console.WriteLine(listperson.NameListPerson);

            int count = listperson.CountPerson();

            for (int index = 0; index < count; index++)
            {
                Person person = listperson.LookForIndex(index);
                Console.WriteLine(person.GetInfo());
            }

            Console.WriteLine();
        }
    }
}
