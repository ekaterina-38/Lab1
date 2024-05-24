using System.ComponentModel;
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
        /// Конструктор BasicForm.
        /// </summary>
        public BasicForm()
        {
            InitializeComponent();

            FillingDataGridView();

            _buttonAddTransport.Click += new
                EventHandler(AddTransportButtonClick);

            _buttonRemoveTransport.Click += new
                EventHandler(RemoveTransportButtonClick);
        }

        /// <summary>
        /// Обработчик отмены добавления данных в лист.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="transportBase"></param>
        private void CancelTransport(object sender, EventArgs transportBase)
        {
            TransportAddedEventArgs addedEventArgs = transportBase as
                TransportAddedEventArgs;

            _transportList.Remove(addedEventArgs?.TransportBase);
        }

        /// <summary>
        /// Обработчик добавления данных в лист.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="transportBase"></param>
        private void AddedTransport(object sender, EventArgs transportBase)
        {
            TransportAddedEventArgs addedEventArgs = transportBase as
                TransportAddedEventArgs;

            _transportList.Add(addedEventArgs?.TransportBase);
        }

        /// <summary>
        /// Метод нажатия на кнопку "Добавить"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void AddTransportButtonClick(object sender, EventArgs e)
        {
            DataForm DataForm = new DataForm();
            DataForm.TransportAdded += new EventHandler(AddedTransport);
            DataForm.TransportCancel += new EventHandler(CancelTransport);
            DataForm.Show();
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
        private void FillingDataGridView()
        {
            _gridControlTransport.DataSource = _transportList;
        }
    }
}
