using System.ComponentModel;
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
            try
            {
                _filteredTransportList = new BindingList<TransportBase>();

                if (_checkBoxFindCar.Checked)
                {
                    FilteredTypeTransport(_transportList, _filteredTransportList,
                        typeof(Car));
                }

                if (_checkBoxFindHybridCar.Checked)
                {
                    FilteredTypeTransport(_transportList, _filteredTransportList,
                        typeof(HybridCar));
                }

                if (_checkBoxFindHelicopter.Checked)
                {
                    FilteredTypeTransport(_transportList, _filteredTransportList,
                        typeof(Helicopter));
                }

                TransportFiltered.Invoke(this,
                new TransportFilterEventArgs(_filteredTransportList));
            }
            catch
            {
                MessageBox.Show("Введите данные.", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            foreach (TransportBase transport in transportList)
            {
                if (typeTransport.IsInstanceOfType(transport))
                {
                    filteredTransportList.Add(transport);
                }
            }
        }
    }
}
