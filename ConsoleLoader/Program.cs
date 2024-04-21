using TransportLibrary;

namespace ConsoleLoader
{
    /// <summary>
    /// Класс Программа.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Метод Main.
        /// </summary>
        internal static void Main()
        {
            TransportBase transport = ConsoleTransport.SelectTransport();
            ConsoleTransport.СalculateСonsumptionFuel(transport);
            _ = Console.ReadKey();
        }
    }
}
