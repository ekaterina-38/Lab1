using TransportLibrary;

namespace View
{
    /// <summary>
    /// Класс BasicForm.
    /// </summary>
    public partial class BasicForm : System.Windows.Forms.Form
    {
        private GroupBox groupBoxTransport;

        public DataGridView gridControlTransport;

        private Button buttonAddTransport;

        private Button buttonRemoveTransport;

        public List<TransportBase> transportList = new List<TransportBase>();

        /// <summary>
        /// Конструктор BasicForm.
        /// </summary>
        public BasicForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод нажатия на кнопку "Добавить"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void addTransportButtonClick(object sender, EventArgs e)
        {
            DataForm DataForm = new DataForm();
            DataForm.Show();
        }

        /// <summary>
        /// Метод нажатия на кнопку "Удалить"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void removeTransportButtonClick(object sender, EventArgs e)
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
        /// <param name="distance">Расстояние пути.</param>
        public void FillingDataGridView(double distance)
        {
            gridControlTransport.Rows.Clear();
            foreach (var transport in transportList)
            {
                gridControlTransport.Rows.Add(transport.GetType().Name, distance, transport.CalculateFuel(distance));
            }
        }
    }
}
