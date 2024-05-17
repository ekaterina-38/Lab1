using TransportLibrary;

namespace View
{
    /// <summary>
    /// Класс DataForm.
    /// </summary>
    public partial class DataForm : Form
    {
        private Button buttonAgree;

        private Button buttonCancel;

        private Panel panelInputs;

        private GroupBox groupBoxData;

        private ComboBox comboBoxTransport;

        private ComboBox comboBoxFuel;

        private TextBox textBoxСapacity;

        private TextBox textBoxMass;

        private TextBox textBoxDistance;

        public EventHandler TransportAdded;

        /// <summary>
        /// Конструктор DataForm.
        /// </summary>
        public DataForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод нажатия на кнопку "Ок"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void AgreeButtonClick(object sender, EventArgs e)
        {
            string typeTransport = comboBoxTransport.Text;

            Car car = new Car();
            Motor motor = new Motor();

            string typeFuel = comboBoxFuel.Text;

            switch (typeFuel)
            {
                case "Бензин":
                    {
                        motor.TypeFuel = TypeFuel.Petrol;
                    }
                    break;
                case "Дизель":
                    {
                        motor.TypeFuel = TypeFuel.Diesel;
                    }
                    break;
                case "Электричество":
                    {
                        motor.TypeFuel = TypeFuel.Electricity;
                    }
                    break;
                case "Газ":
                    {
                        motor.TypeFuel = TypeFuel.Gas;
                    }
                    break;
                default:
                    break;
            }

            motor.Capacity = Convert.ToDouble(textBoxСapacity.Text);

            car.Mass = Convert.ToDouble(textBoxMass.Text);

            double distance = Convert.ToDouble(textBoxDistance.Text);


            BasicForm basicForm = Application.OpenForms.OfType<BasicForm>().FirstOrDefault();
            if (basicForm != null)
            {
                //basicForm.transportList.Add(car);
                //basicForm.gridControlTransport.Rows.Add(car.GetType().Name, distance, car.CalculateFuel(distance));
                TransportAdded?.Invoke(this, new TransportAddedEventArgs(car));
            }

            Close();
        }

        /// <summary>
        /// Метод нажатия на кнопку "Отмена"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void CancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }


    }
}
