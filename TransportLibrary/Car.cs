
namespace TransportLibrary
{
    /// <summary>
    /// Класс Машина.
    /// </summary>
    public class Car : TransportBase
    {
        /// <summary>
        /// Свойство Двигатель.
        /// </summary>
        public Motor Motor { get; set; }

        /// <summary>
        /// Конструктор класса Машина.
        /// </summary>
        /// <param name="motor">Двигатель.</param>
        /// <param name="mass">Масса.</param>
        /// <param name="fielPer100km">Расход на 100 км.</param>
        public Car(Motor motor, double mass)
        {
            Motor = motor;
            Mass = mass;
        }

        /// <summary>
        /// Конструктор с параметрами по умолчанию.
        /// </summary>
        public Car() : this(new Motor(100, TypeFuel.Petrol), 1)
        { }

        /// <summary>
        /// Переопределенный метод расчета расхода топлива.
        /// </summary>
        /// <param name="distance">Растояние пути.</param>
        /// <returns>Расход топлива.</returns>
        public override double CalculateFuel(double distance)
        {
            double koeff = Motor.СalculationFuelСonsumption();

            return distance * koeff * Mass;
        }
    }
}
