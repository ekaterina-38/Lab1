using TransportLibrary;

namespace View
{
    /// <summary>
    /// ����� BasicForm.
    /// </summary>
    public partial class BasicForm : System.Windows.Forms.Form
    {
        private GroupBox groupBoxTransport;

        public DataGridView gridControlTransport;

        private Button buttonAddTransport;

        private Button buttonRemoveTransport;

        public List<TransportBase> transportList = new List<TransportBase>();

        /// <summary>
        /// ����������� BasicForm.
        /// </summary>
        public BasicForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ����� ������� �� ������ "��������"
        /// </summary>
        /// <param name="sender">�������.</param>
        /// <param name="e">������ � �������.</param>
        private void addTransportButtonClick(object sender, EventArgs e)
        {
            DataForm DataForm = new DataForm();
            DataForm.Show();
        }

        /// <summary>
        /// ����� ������� �� ������ "�������"
        /// </summary>
        /// <param name="sender">�������.</param>
        /// <param name="e">������ � �������.</param>
        private void removeTransportButtonClick(object sender, EventArgs e)
        {
            if (gridControlTransport.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = gridControlTransport.SelectedRows[0];

                gridControlTransport.Rows.Remove(selectedRow);
            }
            else
            {
                MessageBox.Show("�������� ������ ��� ��������.", "��������������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// ����� ���������� ������� "������ ����������".
        /// </summary>
        /// <param name="distance">���������� ����.</param>
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
