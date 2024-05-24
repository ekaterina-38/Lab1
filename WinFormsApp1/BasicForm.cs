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
        private BindingList<TransportBase> transportList = new BindingList<TransportBase>();

        /// <summary>
        /// ����������� BasicForm.
        /// </summary>
        public BasicForm()
        {
            InitializeComponent();
            FillingDataGridView();
            buttonAddTransport.Click += new EventHandler(AddTransportButtonClick);
            buttonRemoveTransport.Click += new EventHandler(RemoveTransportButtonClick);
        }

        /// <summary>
        /// ���������� ������ ���������� ������ � ����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="transportBase"></param>
        private void CancelTransport(object sender, EventArgs transportBase)
        {
            TransportAddedEventArgs addedEventArgs = transportBase as TransportAddedEventArgs;

            transportList.Remove(addedEventArgs?.TransportBase);
        }

        /// <summary>
        /// ���������� ���������� ������ � ����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="transportBase"></param>
        private void AddedTransport(object sender, EventArgs transportBase)
        {
            TransportAddedEventArgs addedEventArgs = transportBase as TransportAddedEventArgs;

            transportList.Add(addedEventArgs?.TransportBase);
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
        private void FillingDataGridView()
        {
            gridControlTransport.DataSource = transportList;
        }


    }
}
