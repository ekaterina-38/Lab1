using System.ComponentModel;
using System.Xml.Serialization;
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
        ///  ���� ��� �������� ��������� ����� DataForm.
        /// </summary>
        private bool _isDataFormOpen = false;

        /// <summary>
        ///  ���� ��� �������� ��������� ����� FindForm.
        /// </summary>
        private bool _isFindFormOpen = false;

        /// <summary>
        /// ���� ��� ���������� � �������� �����.
        /// </summary>
        private readonly XmlSerializer _serializerXml =
            new XmlSerializer(typeof(BindingList<TransportBase>));

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

            _buttonSaveTransport.Click += SaveFile;

            _buttonOpenTransport.Click += OpenFile;

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
        /// ����� ������� �� ������ "��������".
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
                _gridControlTransport.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                foreach (DataGridViewRow row in _gridControlTransport.SelectedRows)
                {
                    _gridControlTransport.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("�������� ������ ��� ��������.",
                    "��������������", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
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

        /// <summary>
        /// ����� ��� ���������� ������ � ����.
        /// </summary>
        /// <param name="sender">�������.</param>
        /// <param name="e">������ � �������.</param>
        private void SaveFile(object sender, EventArgs e)
        {
            if (!_transportList.Any() || _transportList is null)
            {
                MessageBox.Show("������ ����!","��������������",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "����� (*tran.)|*.tran|��� ����� (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName.ToString();

                using (var file = File.Create(filePath))
                {
                    _serializerXml.Serialize(file, _transportList);
                }
            }
        }

        /// <summary>
        /// ����� ��� �������� ������ �� �����.
        /// </summary>
        /// <param name="sender">�������.</param>
        /// <param name="e">������ � �������.</param>
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "����� (*.tran)|*.tran|��� ����� (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            string filePath = openFileDialog.FileName.ToString();

            try
            {
                using (var file = new StreamReader(filePath))
                {
                    _transportList = (BindingList<TransportBase>)
                        _serializerXml.Deserialize(file);
                }

                _gridControlTransport.DataSource = _transportList;
            }
            catch (Exception)
            {
                MessageBox.Show("�� ������� ��������� ����!", "��������������",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
