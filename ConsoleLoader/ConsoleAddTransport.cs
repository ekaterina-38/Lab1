using TransportLibrary;

namespace ConsoleLoader
{
    /// <summary>
    /// Класс.
    /// </summary>
    public static class ConsoleAddTransport
    {
        /// <summary>
        /// .
        /// </summary>
        /// <returns>.</returns>
        public static TransportBase ConsoleReadTransport()
        {
            TransportBase transport = new Car();

            Dictionary<Type, Action<string>> catchDictionary = new Dictionary<Type, Action<string>>()
            {
                {
                    typeof(ArgumentOutOfRangeException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение {message}");
                    }
                },
            };

            List<Action> actions = new()
            {
                ()=>
                {
                     Console.WriteLine("\nВыберите тип транспорта" +
                        "(для подтверждения нажмите Enter):" +
                        "\n1 - машина" +
                        "\n2 - машина-гибрид" +
                        "\n3 - вертолет");

                    string readTransport = Console.ReadLine();

                    switch (readTransport)
                    {
                        case "1":
                            {
                                transport = ReadCar();
                                break;
                            }

                        case "2":
                            {
                                transport = ReadHybridCar();
                                break;
                            }

                        case "3":
                            {
                                transport = ReadHelicopter();
                                break;
                            }

                        default:
                            {
                                Console.WriteLine("\nВыберите тип транспорта: " +
                                    "(для подтверждения нажмите Enter):" +
                                    "\n1 - машина" +
                                    "\n2 - машина-гибрид" +
                                    "\n3 - вертолет");
                                throw new ArgumentOutOfRangeException(
                                    "Неверно введен тип транспорта");
                            }
                    }
                },
            };

            ActionHandler(actions, catchDictionary);

            return transport;
        }

        /// <summary>
        /// Ввод машины.
        /// </summary>
        /// <returns>Машина.</returns>
        public static Car ReadCar()
        {
            Dictionary<Type, Action<string>> catchDictionary = new Dictionary<Type, Action<string>>()
            {
                {
                    typeof(ArgumentException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение {message}");
                    }
                },
                {
                    typeof(FormatException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение {message}");
                    }
                },
                {
                    typeof(OverflowException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение {message}");
                    }
                },

            };
            Car car = new Car();
            List<Action> actions = new()
            {
                ()=>
                {
                     Console.WriteLine($"\nВведите данные о двигателе");
                     car.Motor = ReadMotor();
                },

                ()=>
                {
                    Console.WriteLine($"\nВведите массу машины в тоннах:");
                    car.Mass = Convert.ToDouble(Console.ReadLine());
                },
            };

            ActionHandler(actions, catchDictionary);

            return car;
        }

        /// <summary>
        /// Ввод данных о вертолете.
        /// </summary>
        /// <returns>Вертолет.</returns>
        public static Helicopter ReadHelicopter()
        {
            Dictionary<Type, Action<string>> catchDictionary = new Dictionary<Type, Action<string>>()
            {
                {
                    typeof(ArgumentException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение {message}");
                    }
                },
                {
                    typeof(FormatException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение {message}");
                    }
                },
                {
                    typeof(OverflowException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение {message}");
                    }
                },

            };

            Helicopter helicopter = new Helicopter();
            List<Action> actions = new()
            {
                ()=>
                {
                     Console.WriteLine($"\nВведите данные о двигателе вертолета");
                     helicopter.Motor = ReadMotor();
                },

                ()=>
                {
                    Console.WriteLine($"\nВведите массу вертолета в тоннах:");
                    helicopter.Mass = Convert.ToDouble(Console.ReadLine());
                },
                ()=>
                {
                    Console.WriteLine($"\nВведите ширину лопастей вертолета:");
                    helicopter.BladeWidth = Convert.ToDouble(Console.ReadLine());
                },
            };

            ActionHandler(actions, catchDictionary);

            return helicopter;
        }

        /// <summary>
        /// Ввод данных о Гибридной машине.
        /// </summary>
        /// <returns>Гибридная машина.</returns>
        public static HybridCar ReadHybridCar()
        {
            Dictionary<Type, Action<string>> catchDictionary = new Dictionary<Type, Action<string>>()
            {
                {
                    typeof(ArgumentException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение {message}");
                    }
                },
                {
                    typeof(FormatException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение {message}");
                    }
                },
                {
                    typeof(OverflowException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение {message}");
                    }
                },

            };

            HybridCar hybridCar = new HybridCar();
            List<Action> actions = new()
            {
                ()=>
                {
                     Console.WriteLine($"\nВведите данные о двигателе вертолета");
                     hybridCar.Motor = ReadMotor();
                },

                ()=>
                {
                    Console.WriteLine($"\nВведите массу вертолета в тоннах:");
                    hybridCar.Mass = Convert.ToDouble(Console.ReadLine());
                },
                ()=>
                {
                    Console.WriteLine($"\nВведите ширину лопастей вертолета:");
                    hybridCar.HybridMotor = ReadMotor();
                },
            };

            ActionHandler(actions, catchDictionary);

            return hybridCar;
        }

        /// <summary>
        /// Ввод данных о двигатели с консоли.
        /// </summary>
        /// <returns>Двигатель.</returns>
        /// <exception cref="ArgumentOutOfRangeException">.</exception>
        public static Motor ReadMotor()
        {
            Dictionary<Type, Action<string>> catchDictionary = new Dictionary<Type, Action<string>>()
            {
                {
                    typeof(ArgumentOutOfRangeException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение {message}");
                    }
                },
                {
                    typeof(ArgumentException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение {message}");
                    }
                },
                {
                    typeof(FormatException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение {message}");
                    }
                },
                {
                    typeof(OverflowException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение {message}");
                    }
                },
            };

            Motor motor = new Motor();

            List<Action> actions = new()
            {
                ()=>
                {
                    Console.WriteLine($"\nВыберите вид топлива: " +
                        "(для подтверждения нажмите Enter):" +
                        $"\n1 - бензин" +
                         "\n2 - дизель" +
                         "\n3 - электричество" +
                         "\n4 - газ");

                    char keyInfo = Console.ReadKey().KeyChar;

                    Dictionary<char, TypeFuel> сonsumptionFuel = new()
                    {
                        {'1', TypeFuel.Petrol},
                        {'2', TypeFuel.Diesel},
                        {'3', TypeFuel.Electricity},
                        {'4', TypeFuel.Gas},
                        {'5', TypeFuel.AviationKerosene},
                        {'6', TypeFuel.AviationGasoline},
                    };

                    if(!сonsumptionFuel.ContainsKey(keyInfo))
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                     motor.TypeFuel = сonsumptionFuel[keyInfo];
                },

                ()=>
                {
                    Console.WriteLine($"\nВведите мощность двигателя в л.с:");

                    motor.Capacity = Convert.ToDouble(Console.ReadLine());
                },
            };

            ActionHandler(actions, catchDictionary);

            return motor;
        }

        /// <summary>
        /// Зацикливает выполнение программы до ее корректного завершения.
        /// </summary>
        /// <param name="assignActions">Действия для создания фигуры.</param>
        /// действия в случае возникновения исключений.</param>
        private static void ActionHandler(List<Action> assignActions,
            Dictionary<Type, Action<string>> catchDictionary)
        {
            foreach (var assignAction in assignActions)
            {
                while (true)
                {
                    try
                    {
                        assignAction.Invoke();
                        break;
                    }
                    catch (Exception ex)
                    {
                        catchDictionary[ex.GetType()].Invoke(ex.Message);
                    }

                    Console.WriteLine("\n!Ошибка ввода!\nПопробуйте снова:\n");
                }
            }
        }
    }
}
