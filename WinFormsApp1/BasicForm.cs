using System.ComponentModel;
using System.Windows.Forms;
using TransportLibrary;

namespace View
{
    /// <summary>
    /// ����� BasicForm.
    /// </summary>
    public partial class BasicForm : System.Windows.Forms.Form
    {   
        /// <summary>
        /// ���� ��� ���������� �������.
        /// </summary>
        private BindingList<TransportBase> _transportList = 
            new BindingList<TransportBase>();

        /// <summary>
        /// ����������� BasicForm.
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
        /// ���������� ������ ���������� ������ � ����.
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
        /// ���������� ���������� ������ � ����.
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
        /// ����� ������� �� ������ "��������"
        /// </summary>
        /// <param name="sender">�������.</param>
        /// <param name="e">������ � �������.</param>
        private void AddTransportButtonClick(object sender, EventArgs e)
        {
            DataForm DataForm = new DataForm();
            DataForm.TransportAdded += new EventHandler(AddedTransport);
            DataForm.TransportCancel += new EventHandler(CancelTransport);
            DataForm.Show();
        }

        /// <summary>
        /// ����� ������� �� ������ "�������"
        /// </summary>
        /// <param name="sender">�������.</param>
        /// <param name="e">������ � �������.</param>
        private void RemoveTransportButtonClick(object sender, EventArgs e)
        {
            if (_gridControlTransport.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = _gridControlTransport.SelectedRows[0];

                _gridControlTransport.Rows.Remove(selectedRow);
            }
            else
            {
                MessageBox.Show("�������� ������ ��� ��������.",
                    "��������������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// ����� ���������� ������� "������ ����������".
        /// </summary>
        private void FillingDataGridView()
        {
            _gridControlTransport.DataSource = _transportList;
        }
    }
}
