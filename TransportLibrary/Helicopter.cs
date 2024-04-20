namespace TransportLibrary
{
    /// <summary>
    /// .
    /// </summary>
    public class Helicopter : TransportBase
    {
        /// <summary>
        /// Масса.
        /// </summary>
        private double _bladeWidth;

        /// <summary>
        /// Свойство Ширина лопасти.
        /// </summary>
        public double BladeWidth
        {
            get => _bladeWidth;
            set
            {
                if (value < 0)
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
        public Motor Motor { get; set; }

        /// <summary>
        /// Конструктор класса Вертолет.
        /// </summary>
        /// <param name="motor">Двигатель.</param>
        /// <param name="mass">Масса.</param>
        /// <param name="bladeWidth">Масса.</param>
        /// <param name="fielPer100km">Расход на 100 км.</param>
        public Helicopter(Motor motor, double mass, double bladeWidth)
        {
            Motor = motor;
            Mass = mass;
            BladeWidth = bladeWidth;
        }

        /// <summary>
        /// Конструктор с параметрами по умолчанию.
        /// </summary>
        public Helicopter() : this(new Motor(250, TypeFuel.AviationKerosene), 10, 8)
        { }

        /// <summary>
        /// Переопределенный метод расчета расхода топлива.
        /// </summary>
        /// <param name="distance">Растояние пути.</param>
        /// <returns>Расход топлива.</returns>
        public override double CalculateFuel(double distance)
        {
            double koeff = Motor.СalculationFuelСonsumption();

            return distance * koeff * Mass * BladeWidth;
        }
    }
}
