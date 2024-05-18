using System.ComponentModel;

namespace TransportLibrary
{
    /// <summary>
    /// Вид топлива.
    /// </summary>
    public enum TypeFuel
    {
        /// <summary>
        /// Бензин.
        /// </summary>
        [Description("Бензин")]
        Petrol,

        /// <summary>
        /// Дизель.
        /// </summary>
        [Description("Дизель")]
        Diesel,

        /// <summary>
        /// Электричество.
        /// </summary>
        [Description("Электричество")]
        Electricity,

        /// <summary>
        /// Газ.
        /// </summary>
        [Description("Газ")]
        Gas,

        /// <summary>
        /// Авиационный керосин.
        /// </summary>
        [Description("Авиационный керосин")]
        AviationKerosene,

        /// <summary>
        /// Авиационный бензин.
        /// </summary>
        [Description("Авиационный бензин")]
        AviationGasoline,
    }
}
