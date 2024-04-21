namespace TransportLibrary
{
    /// <summary>
    /// Класс Гибридная Машина.
    /// </summary>
    public class HybridCar : Car
    {
        /// <summary>
        /// Гибридный двигатель.
        /// </summary>
        private Motor _hybridMotor;

        /// <summary>
        /// Гибридный двигатель.
        /// </summary>
        public Motor HybridMotor
        {
            get => _hybridMotor;
            set
            {
                if (value == Motor)
                {
                    throw new ArgumentException("Вид топлива основного мотора" +
                        " и гибридного должны отличаться");
                }

                if (value is null)
                {
                    throw new NullReferenceException
                              ("Передано null");
                }

                _hybridMotor = value;
            }
        }

        /// <summary>
        /// Конструктор класса Машина.
        /// </summary>
        /// <param name="motor">Двигатель.</param>
        /// <param name="mass">Масса.</param>
        /// <param name="hybridMotor">Гибридный двигатель.</param>
        /// <param name="fielPer100km">Расход на 100 км.</param>
        public HybridCar(Motor motor, double mass, Motor hybridMotor) :
            base(motor, mass)
        {
            HybridMotor = hybridMotor;
        }

        /// <summary>
        /// Конструктор с параметрами по умолчанию.
        /// </summary>
        public HybridCar() : this(new Motor(100, TypeFuel.Petrol), 1,
            new Motor(50, TypeFuel.Electricity))
        { }

        /// <summary>
        /// Переопределенный метод расчета расхода топлива.
        /// </summary>
        /// <param name="distanceBasicMotor">Расстояние, пройденное на основном
        /// двигателе.</param>
        /// <param name="distanceHybridMotor">Расстояние, пройденное на гибридном
        /// двигателе.</param>
        /// <returns>Расход топлива.</returns>
        public double CalculateFuel(double distanceBasicMotor, double distanceHybridMotor)
        {
            double coeffСonsumption = Motor.СalculateConsumption();

            double coeffСonsumptionHybrid = Motor.СalculateConsumption();

            return Mass * (distanceBasicMotor * coeffСonsumption + distanceHybridMotor
                * coeffСonsumptionHybrid);
        }
    }
}
