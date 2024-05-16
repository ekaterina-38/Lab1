using TransportLibrary;

namespace View
{
    public partial class BasicForm : System.Windows.Forms.Form
    {
        private GroupBox groupBox;

        public DataGridView gridControl;

        private Button addTransportButton;

        private Button removeTransportButton;

        public List<TransportBase> transportList = new List<TransportBase>();

        public BasicForm()
        {
            InitializeComponent();
        }

        public void PopulateDataGridView( double distance)
        {
            gridControl.Rows.Clear();
            foreach (var transport in transportList)
            {
                gridControl.Rows.Add(transport.GetType().Name, distance, transport.CalculateFuel(distance));
            }
        }
    }
}
