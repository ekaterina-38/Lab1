namespace TransportLibrary
{
    /// <summary>
    /// Вертолет.
    /// </summary>
    public class Helicopter : TransportBase
    {
        /// <summary>
        /// Ширина лопасти вертолета.
        /// </summary>
        private double _bladeWidth;

        /// <summary>
        /// Двигатель.
        /// </summary>
        private Motor _motor;

        /// <summary>
        /// Конструктор класса Вертолет.
        /// </summary>
        /// <param name="motor">Двигатель.</param>
        /// <param name="mass">Масса.</param>
        /// <param name="bladeWidth">Масса.</param>
        public Helicopter(Motor motor, double mass, double bladeWidth)
        {
            Motor = motor;
            Mass = mass;
            BladeWidth = bladeWidth;
        }

        /// <summary>
        /// Конструктор с параметрами по умолчанию.
        /// </summary>
        public Helicopter() : this(new Motor(250, TypeFuel.AviationKerosene), 10, 18)
        { }

        /// <summary>
        /// Свойство Ширина лопасти вертолета.
        /// </summary>
        public double BladeWidth
        {
            get => _bladeWidth;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException
                        ("Ширина должна быть положительной");
                }

                _bladeWidth = value;
            }
        }

        /// <summary>
        /// Свойство Двигатель.
        /// </summary>
        public Motor Motor
        {
            get => _motor;
            set
            {
                if (value is null)
                {
                    throw new NullReferenceException
                              ("Передано null");
                }

                _motor = value;
            }
        }

        /// <summary>
        /// Переопределенный метод расчета расхода топлива.
        /// </summary>
        /// <param name="distance">Расстояние пути(часы).</param>
        /// <returns>Расход топлива.</returns>
        public override double CalculateFuel(double distance)
        {
            double coeffСonsumption = Motor.СalculateConsumption();

            return distance * coeffСonsumption * Mass * BladeWidth;
        }
    }
}
