namespace TransportLibrary
{
    /// <summary>
    /// Абстрактный класс Транспорт.
    /// </summary>
    public abstract class TransportBase
    {
        /// <summary>
        /// Масса.
        /// </summary>
        private double _mass;

        /// <summary>
        /// Свойство Масса.
        /// </summary>
        public double Mass
        {
            get => _mass;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException
                        ("Масса должна быть положительной");
                }

                _mass = value;
            }
        }

        /// <summary>
        /// Информация о транспорте.
        /// </summary>
        public abstract string Info { get; }

        /// <summary>
        /// Тип транспорта.
        /// </summary>
        public abstract string TypeTransport { get; }

        /// <summary>
        /// Расход топлива.
        /// </summary>
        public abstract string FuelConsumption { get; }

        /// <summary>
        /// Метод расчета расхода топлива.
        /// </summary>
        /// <param name="distance">Расстояние.</param>
        /// <returns>Расход топлива (л).</returns>
        public abstract double CalculateFuel(double distance);
    }
}
