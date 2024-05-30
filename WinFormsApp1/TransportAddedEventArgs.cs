using TransportLibrary;

namespace View
{ 
    /// <summary>
    /// Класс
    /// </summary>
    internal class TransportAddedEventArgs : EventArgs
    {
        //TODO: XML+
        /// <summary>
        /// Свойство TransportBase.
        /// </summary>
        public TransportBase TransportBase { get; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="transportBase"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public TransportAddedEventArgs(TransportBase transportBase)
        {
            if (transportBase == null)
            {
                throw new ArgumentNullException();
            }

            TransportBase = transportBase;
        }

    }
}
