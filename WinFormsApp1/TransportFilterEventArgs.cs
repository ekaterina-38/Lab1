﻿using System.ComponentModel;
using TransportLibrary;

namespace View
{
    /// <summary>
    /// Класс отдает данные событию при фильтрации.
    /// </summary>
    internal class TransportFilterEventArgs : EventArgs
    {
        /// <summary>
        /// Свойство для получения отфильтрованного списка.
        /// </summary>
        public BindingList<TransportBase> FilteredTransportList { get; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="filterTransportList">Отфильтрованный список
        /// транспорта.</param>
        /// <exception cref="ArgumentNullException">Проверка списка
        /// на null</exception>
        public TransportFilterEventArgs(BindingList<TransportBase>
            filterTransportList)
        {
            if (filterTransportList == null)
            {
                throw new ArgumentNullException();
            }

            FilteredTransportList = filterTransportList;
        }


    }
}
