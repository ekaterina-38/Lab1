using System.Security.Cryptography.Xml;
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

        private GroupBox groupBoxDataCar;
        
        private GroupBox groupBoxData;

        private GroupBox groupBoxDataHybridCar;

        private GroupBox groupBoxDataHelicopter;

        private ComboBox comboBoxTransport;

        private ComboBox comboBoxFuelCar;
        private ComboBox comboBoxFuelHybridCar;
        private ComboBox comboBoxFuelHelicopter;

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

            comboBoxTransport.SelectedIndexChanged += new EventHandler(AddGroupBoxData);
        }

        /// <summary>
        /// Метод нажатия на кнопку "Ок"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void AgreeButtonClick(object sender, EventArgs e)
        {
            string typeTransport = comboBoxTransport.Text;

            TransportBase transport = null;

            switch (typeTransport)
            {
                case "Машина":
                {
                    transport = new Car();
                    
                    Motor motor = new Motor();
                    
                    string typeFuel = comboBoxFuelCar.Text;
                    
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

                    transport.Mass = Convert.ToDouble(textBoxMass.Text);

                }
                    break;

                case "Гибридная машина":
                {
                    transport = new HybridCar();

                    Motor motor = new Motor();

                    string typeFuel = comboBoxFuelCar.Text;

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

                    transport.Mass = Convert.ToDouble(textBoxMass.Text);
                }
                    break;

                case "Вертолет":
                {
                    transport = new Helicopter();

                    Motor motor = new Motor();

                    string typeFuel = comboBoxFuelCar.Text;

                    switch (typeFuel)
                    {
                        case "Aвиационный керосин":
                        {
                            motor.TypeFuel = TypeFuel.Petrol;
                        }
                            break;

                        case "Aвиационный бензин":
                        {
                            motor.TypeFuel = TypeFuel.Diesel;
                        }
                            break;

                        default:
                            break;
                    }

                    motor.Capacity = Convert.ToDouble(textBoxСapacity.Text);

                    transport.Mass = Convert.ToDouble(textBoxMass.Text);
                }
                    break;
            }
            
            TransportAdded?.Invoke(this, new TransportAddedEventArgs(transport));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddGroupBoxData(object sender, EventArgs e)
        {
            string typeTransport = comboBoxTransport.Text;

            switch (typeTransport)
            {
                case "Машина":
                    {
                        groupBoxDataCar.Visible = true;
                        groupBoxDataHybridCar.Visible = false;
                        groupBoxDataHelicopter.Visible = false;
                    }
                    break;

                case "Гибридная машина":
                    {
                        groupBoxDataCar.Visible = false;
                        groupBoxDataHybridCar.Visible = true;
                        groupBoxDataHelicopter.Visible = false;

                    }
                    break;

                case "Вертолет":
                    {
                        groupBoxDataCar.Visible = false;
                        groupBoxDataHybridCar.Visible = false;
                        groupBoxDataHelicopter.Visible = true;
                    }
                    break;
            }
        }

        /// <summary>
        /// Метод нажатия на кнопку "Отмена"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void CancelButtonClick(object sender, EventArgs e)
        {
           // Close();
        }
    }
}
