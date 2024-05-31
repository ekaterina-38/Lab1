﻿using System.ComponentModel;
using System.Security.Cryptography.Xml;
using TransportLibrary;

namespace View
{
    /// <summary>
    /// Класс FilterForm.
    /// </summary>
    public partial class FilterForm : Form
    {
        /// <summary>
        /// Исходный список транспорта.
        /// </summary>
        private BindingList<TransportBase> _transportList;

        /// <summary>
        /// Отфильтрованный список транспорта.
        /// </summary>
        private BindingList<TransportBase> _filteredTransportList;

        /// <summary>
        /// Событие на фильтрацию списка.
        /// </summary>
        public EventHandler TransportFiltered;

        /// <summary>
        /// Конструктор FilterForm.
        /// </summary>
        /// <param name="transportList">Исходный список транспорта.</param>
        public FilterForm(BindingList<TransportBase> transportList)
        {
            _transportList = transportList;

            InitializeComponent();

            _buttonAgree.Click += new EventHandler(AgreeButtonClick);
        }

        /// <summary>
        /// Метод нажатия на кнопку "ОК"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void AgreeButtonClick(object sender, EventArgs e)
        {         
            _filteredTransportList = new BindingList<TransportBase>();

            if (_checkBoxFindCar.Checked)
            {
                FilteredTypeTransport(_transportList,
                    _filteredTransportList,
                    typeof(Car));
            }

            if (_checkBoxFindHybridCar.Checked)
            {
                FilteredTypeTransport(_transportList,
                    _filteredTransportList,
                    typeof(HybridCar));
            }

            if (_checkBoxFindHelicopter.Checked)
            {
                FilteredTypeTransport(_transportList,
                    _filteredTransportList,
                    typeof(Helicopter));
            }

            CheckedData();

            TransportFiltered.Invoke(this,
            new TransportFilterEventArgs(_filteredTransportList));
        }

        /// <summary>
        /// Метод фильтрации по данным транспорта.
        /// </summary>
        private void CheckedData()
        {
            BindingList<TransportBase> transportList = 
                new BindingList<TransportBase>();

            bool statusCheckBox = _checkBoxFindCar.Checked
                || _checkBoxFindHybridCar.Checked
                || _checkBoxFindHelicopter.Checked;
            
            transportList = statusCheckBox
                ? [.. _filteredTransportList]
                : [.. _transportList];

            if (_checkBoxMass.Checked)
            {
                if (!string.IsNullOrEmpty(_textBoxMass.Text))
                {
                    FilteredMass(transportList,
                    Convert.ToDouble(_textBoxMass.Text));
                    _filteredTransportList = transportList;
                }
                else
                {
                    MessageBox.Show("Введите массу.", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (_checkBoxCapacity.Checked)
            {
                if (!string.IsNullOrEmpty(_textBoxCapacity.Text))
                {
                    FilteredCapacity(transportList,
                    Convert.ToDouble(_textBoxCapacity.Text));
                    _filteredTransportList = transportList;
                }
                else
                {
                    MessageBox.Show("Введите мощность.", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Метод фильтрации данных по типу транспорта.
        /// </summary>
        /// <typeparam name="TransportBase">Тип списка.</typeparam>
        /// <param name="transportList">Исходный список.</param>
        /// <param name="filteredTransportList">Отфильтрованный список.</param>
        /// <param name="typeTransport">Тип транспорта.</param>
        private static void FilteredTypeTransport<TransportBase>( 
            BindingList<TransportBase> transportList,
            BindingList<TransportBase> filteredTransportList,
            Type typeTransport)
        {
            foreach (var transport in transportList)
            {
                if (typeTransport == transport.GetType())
                {
                    filteredTransportList.Add(transport);
                }
            }
        }

        /// <summary>
        /// Метод фильтрации данных по массе.
        /// </summary>
        /// <param name="transportList">Отфильтрованный список.</param>
        /// <param name="Mass">Масса.</param>
        private static void FilteredMass(
            BindingList<TransportBase> transportList, double Mass)
        {
            for (int i = transportList.Count - 1; i >= 0; i--)
            {
                if (transportList[i].Mass != Mass)
                {
                    transportList.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Метод фильтрации данных по мощности.
        /// </summary>
        /// <param name="transportList">Исходный список.</param>
        /// <param name="Capacity">Мощность.</param>
        private static void FilteredCapacity(
            BindingList<TransportBase> transportList, double Capacity)
        {
            for (int i = transportList.Count - 1; i >= 0; i--)
            {
                if (transportList[i] is Car car)
                {
                    if (car.Motor.Capacity != Capacity)
                    {
                        transportList.RemoveAt(i);
                    }
                }
                else if (transportList[i] is Helicopter helicopter)
                {
                    if (helicopter.Motor.Capacity != Capacity)
                    {
                        transportList.RemoveAt(i);
                    };
                }
            }
        }
    }
}
