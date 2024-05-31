using System.ComponentModel;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
using TransportLibrary;

namespace View
{
    /// <summary>
    /// Класс BasicForm.
    /// </summary>
    public partial class BasicForm : System.Windows.Forms.Form
    {   
        /// <summary>
        /// Лист для заполнения таблицы.
        /// </summary>
        private BindingList<TransportBase> _transportList = 
            new BindingList<TransportBase>();

        /// <summary>
        /// Отфильтрованный лист для заполнения таблицы.
        /// </summary>
        private BindingList<TransportBase> _filteredTransportList;

        /// <summary>
        ///  Поле для хранения состояния формы DataForm
        /// </summary>
        private bool _isDataFormOpen = false;

        /// <summary>
        ///  Поле для хранения состояния формы FindForm
        /// </summary>
        private bool _isFindFormOpen = false;

        /// <summary>
        /// Конструктор BasicForm.
        /// </summary>
        public BasicForm()
        {
            InitializeComponent();

            FillingDataGridView(_transportList);

            _buttonAddTransport.Click += AddTransportButtonClick;

            _buttonRemoveTransport.Click += RemoveTransportButtonClick;

            _buttonFindTransport.Click += FindTransportButtonClick;

            _buttonResetTransport.Click += ResetedFilter;
        }

        /// <summary>
        /// Обработчик отмены добавления данных в лист.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="transportBase"></param>
        private void CancelTransport(object sender, EventArgs transportBase)
        {
            TransportAddedEventArgs addedEventArgs = 
                transportBase as TransportAddedEventArgs;

            _transportList.Remove(addedEventArgs?.TransportBase);
        }

        /// <summary>
        /// Обработчик добавления данных в лист.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="transportBase"></param>
        private void AddedTransport(object sender, EventArgs transportBase)
        {
            TransportAddedEventArgs addedEventArgs = 
                transportBase as TransportAddedEventArgs;

            _transportList.Add(addedEventArgs?.TransportBase);
        }

        /// <summary>
        /// Метод нажатия на кнопку "Добавить"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void AddTransportButtonClick(object sender, EventArgs e)
        {
            if (!_isDataFormOpen)
            {
                _isDataFormOpen = true;

                DataForm DataForm = new DataForm();
                DataForm.FormClosed += (s, args) => { _isDataFormOpen = false; };
                DataForm.TransportAdded += AddedTransport;
                DataForm.TransportCancel += CancelTransport;
                DataForm.Show();
            }
        }

        /// <summary>
        /// Метод нажатия на кнопку "Удалить"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void RemoveTransportButtonClick(object sender, EventArgs e)
        {
            if (_gridControlTransport.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = _gridControlTransport.SelectedRows[0];

                _gridControlTransport.Rows.Remove(selectedRow);
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Метод заполнения таблицы "Список транспорта".
        /// </summary>
        private void FillingDataGridView(BindingList<TransportBase> transportList)
        {
            _gridControlTransport.DataSource = transportList;
        }

        /// <summary>
        /// Метод нажатия на кнопку "Найти"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void FindTransportButtonClick(object sender, EventArgs e)
        {
            if (!_isFindFormOpen)
            {
                _isFindFormOpen = true;

                FilterForm findForm = new FilterForm(_transportList);
                findForm.FormClosed += (s, args) => { _isFindFormOpen = false; };
                findForm.TransportFiltered += FilteredTransport;
                findForm.Show();
            }
        }

        /// <summary>
        /// Обработчик фильтрации данных.
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="transportList">Данные о событие.</param>
        private void FilteredTransport(object sender, EventArgs transportList)
        {
            TransportFilterEventArgs filterEventArgs = 
                transportList as TransportFilterEventArgs;

            _filteredTransportList = filterEventArgs?.FilteredTransportList;

            FillingDataGridView(_filteredTransportList);
        }

        /// <summary>
        /// Метод нажатия на кнопку "Сбросить".
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void ResetedFilter(object sender, EventArgs e)
        {
            FillingDataGridView(_transportList);
        }
    }
}
