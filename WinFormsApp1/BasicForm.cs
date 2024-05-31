using System.ComponentModel;
using System.Security.Cryptography.Xml;
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
        /// ��������������� ���� ��� ���������� �������.
        /// </summary>
        private BindingList<TransportBase> _filteredTransportList;

        /// <summary>
        ///  ���� ��� �������� ��������� ����� DataForm
        /// </summary>
        private bool _isDataFormOpen = false;

        /// <summary>
        ///  ���� ��� �������� ��������� ����� FindForm
        /// </summary>
        private bool _isFindFormOpen = false;

        /// <summary>
        /// ����������� BasicForm.
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
        /// ���������� ������ ���������� ������ � ����.
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
        /// ���������� ���������� ������ � ����.
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
        /// ����� ������� �� ������ "��������"
        /// </summary>
        /// <param name="sender">�������.</param>
        /// <param name="e">������ � �������.</param>
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
        private void FillingDataGridView(BindingList<TransportBase> transportList)
        {
            _gridControlTransport.DataSource = transportList;
        }

        /// <summary>
        /// ����� ������� �� ������ "�����"
        /// </summary>
        /// <param name="sender">�������.</param>
        /// <param name="e">������ � �������.</param>
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
        /// ���������� ���������� ������.
        /// </summary>
        /// <param name="sender">�������.</param>
        /// <param name="transportList">������ � �������.</param>
        private void FilteredTransport(object sender, EventArgs transportList)
        {
            TransportFilterEventArgs filterEventArgs = 
                transportList as TransportFilterEventArgs;

            _filteredTransportList = filterEventArgs?.FilteredTransportList;

            FillingDataGridView(_filteredTransportList);
        }

        /// <summary>
        /// ����� ������� �� ������ "��������".
        /// </summary>
        /// <param name="sender">�������.</param>
        /// <param name="e">������ � �������.</param>
        private void ResetedFilter(object sender, EventArgs e)
        {
            FillingDataGridView(_transportList);
        }
    }
}
