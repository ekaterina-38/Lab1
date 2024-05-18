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
        private GroupBox groupBoxTransport;
        private DataGridView gridControlTransport;
        private Button buttonAddTransport;
        private Button buttonRemoveTransport;

        private BindingList<TransportBase> transportList = new BindingList<TransportBase>();

        /// <summary>
        /// Конструктор BasicForm.
        /// </summary>
        public BasicForm()
        {
            InitializeComponent();
            FillingDataGridView();
            buttonAddTransport.Click += new EventHandler(AddTransportButtonClick);
            buttonRemoveTransport.Click += new EventHandler(RemoveTransportButtonClick);

        }

        /// <summary>
        /// Обработчик.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="transportBase"></param>
        private void TransportAdded(object sender, EventArgs transportBase)
        {
            TransportAddedEventArgs addedEventArgs = transportBase as TransportAddedEventArgs;

            transportList.Add(addedEventArgs?.TransportBase);
        }

        /// <summary>
        /// Метод нажатия на кнопку "Добавить"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void AddTransportButtonClick(object sender, EventArgs e)
        {
            DataForm DataForm = new DataForm();
            DataForm.TransportAdded += new EventHandler(TransportAdded);
            DataForm.Show();
        }

        /// <summary>
        /// Метод нажатия на кнопку "Удалить"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void RemoveTransportButtonClick(object sender, EventArgs e)
        {
            if (gridControlTransport.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = gridControlTransport.SelectedRows[0];

                gridControlTransport.Rows.Remove(selectedRow);
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Метод заполнения таблицы "Список транспорта".
        /// </summary>
        private void FillingDataGridView()
        {
            gridControlTransport.DataSource = transportList;
        }


    }
}
