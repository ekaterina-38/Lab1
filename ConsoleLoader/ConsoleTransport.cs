using System;
using System.Data;
using TransportLibrary;

namespace ConsoleLoader
{
    /// <summary>
    /// Класс для консольного ввода транспорта.
    /// </summary>
    public static class ConsoleTransport
    {
        /// <summary>
        /// Метод Выбора Транспорта для расчета расхода топлива.
        /// </summary>
        /// <returns>Транспорт.</returns>
        public static TransportBase SelectTransport()
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
                     Console.WriteLine("\nВыберите тип транспорта:" +
                        "\n\t1 - машина" +
                        "\n\t2 - машина-гибрид" +
                        "\n\t3 - вертолет");

                    char readTransport = Console.ReadKey().KeyChar;

                    switch (readTransport)
                    {
                        case '1':
                            {
                                transport = ReadCar();
                                break;
                            }

                        case '2':
                            {
                                transport = ReadHybridCar();
                                break;
                            }

                        case '3':
                            {
                                transport = ReadHelicopter();
                                break;
                            }

                        default:
                            {
                                Console.WriteLine("\nВыберите тип транспорта: " +
                                    "\n\t1 - машина" +
                                    "\n\t2 - машина-гибрид" +
                                    "\n\t3 - вертолет");
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
        /// Метод Ввода данных о Машине.
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
                     Console.WriteLine($"\n\nВведите данные о двигателе");
                     car.Motor = ReadMotor();
                },

                ()=>
                {
                    Console.Write($"\nВведите массу машины в тоннах (нажмите Enter): ");
                    car.Mass = Convert.ToDouble(Console.ReadLine());
                },
            };

            ActionHandler(actions, catchDictionary);

            return car;
        }

        /// <summary>
        /// Метод Ввода данных о Вертолете.
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
                     Console.WriteLine($"\nВведите данные о двигателе");
                     helicopter.Motor = ReadMotor();
                },

                ()=>
                {
                    Console.Write($"\nВведите массу вертолета в тоннах (нажмите Enter): ");
                    helicopter.Mass = Convert.ToDouble(Console.ReadLine());
                },
                ()=>
                {
                    Console.Write($"\nВведите длину лопастей вертолета в метрах (нажмите Enter): ");
                    helicopter.BladeWidth = Convert.ToDouble(Console.ReadLine());
                },
            };

            ActionHandler(actions, catchDictionary);

            return helicopter;
        }

        /// <summary>
        /// Метод Ввода данных о Гибридной машине.
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
                     Console.WriteLine($"\nВведите данные об основном двигателе");
                     hybridCar.Motor = ReadMotor();
                },

                ()=>
                {
                    Console.WriteLine($"\nВведите данные о дополнительном двигателе");
                    hybridCar.HybridMotor = ReadMotor();
                },

                ()=>
                {
                    Console.Write($"\nВведите массу машины в тоннах (нажмите Enter): ");
                    hybridCar.Mass = Convert.ToDouble(Console.ReadLine());
                },
            };

            ActionHandler(actions, catchDictionary);

            return hybridCar;
        }

        /// <summary>
        /// Метод Ввода данных о двигателе.
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
                        Console.WriteLine($"Возникло исключение: {message}");
                    }
                },
                {
                    typeof(ArgumentException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение: {message}");
                    }
                },
                {
                    typeof(FormatException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение: {message}");
                    }
                },
                {
                    typeof(OverflowException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение: {message}");
                    }
                },
            };

            Motor motor = new Motor();

            List<Action> actions = new()
            {
                ()=>
                {
                    Console.WriteLine($"\n\tВыберите вид топлива: " +
                        $"\n\t1 - бензин" +
                         "\n\t2 - дизель" +
                         "\n\t3 - электричество" +
                         "\n\t4 - газ" +
                         "\n\t5 - авиационный керосин" +
                         "\n\t6 - авиационный бензин");

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
                    Console.Write($"\n\tВведите мощность двигателя в л.с (нажмите Enter): ");

                    motor.Capacity = Convert.ToDouble(Console.ReadLine());
                },
            };

            ActionHandler(actions, catchDictionary);

            return motor;
        }

        /// <summary>
        /// Метод Обработки действий.
        /// </summary>
        /// <param name="assignActions">Действие, которое требует проверки.</param>
        /// <param name="catchDictionary">Словарь исключений.</param>
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
                }
            }
        }

        /// <summary>
        /// Расчет расхода топлива.
        /// </summary>
        /// <param name="transport">.</param>
        public static void СalculateСonsumptionFuel(TransportBase transport)
        {
            if (transport is HybridCar newHybridCar)
            {
                Console.Write($"\nВведите расстояние в км для двигателя," +
                    $" работающего на {newHybridCar.Motor.TypeFuel} (нажмите Enter): ");

                double firstDistance = Convert.ToDouble(Console.ReadLine());

                Console.Write($"\nВведите расстояние в км для двигателя," +
                    $" работающего на {newHybridCar.HybridMotor.TypeFuel} (нажмите Enter): ");

                double secondDistance = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine($"\nРасход топлива для прохождения расстояния" +
                    $" {firstDistance + secondDistance} км составит " +
                    $"{Math.Round(newHybridCar.CalculateFuel(firstDistance, secondDistance), 1)} л.");
            }
            else if (transport is Car newCar)
            {
                Console.Write("\nВведите расстояние в км (нажмите Enter): ");

                double distance = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine($"\nРасход топлива для прохождения расстояния" +
                   $" {distance} км составит {Math.Round(newCar.CalculateFuel(distance), 1)} л.");
            }

            else if (transport is Helicopter newHelicopter)
            {
                Console.Write("\nВведите длительность полета в часах (нажмите Enter): ");

                double distance = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine($"\nРасход топлива для полета" +
                    $" {distance} ч составит {Math.Round(newHelicopter.CalculateFuel(distance), 1)} л.");
            }
        }
    }
}
