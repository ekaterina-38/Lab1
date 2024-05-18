using System.Security.Cryptography.Xml;
using TransportLibrary;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace View
{
    /// <summary>
    /// Класс DataForm.
    /// </summary>
    public partial class DataForm : Form
    {
        private Button buttonAgree;

        private Button buttonCancel;
        
        private GroupBox groupBoxData;

        private GroupBox groupBoxDataHybridCar;

        private GroupBox groupBoxDataHelicopter;

        private ComboBox comboBoxTransport;

        private ComboBox comboBoxFuel;

        private TextBox textBoxСapacity;

        private TextBox textBoxMass;

        public EventHandler TransportAdded;

        /// <summary>
        /// Конструктор DataForm.
        /// </summary>
        public DataForm()
        {
            InitializeComponent();
            FillComboBox(["Машина", "Гибридная машина", "Вертолет"],
                comboBoxTransport);
            comboBoxTransport.SelectedIndexChanged += new EventHandler(AddGroupBoxData);
            comboBoxTransport.SelectedIndexChanged += new EventHandler(FillComboBoxFuel);
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

                    transport.Mass = Convert.ToDouble(textBoxMass.Text);

                }
                    break;

                case "Гибридная машина":
                {
                    transport = new HybridCar();

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

                    transport.Mass = Convert.ToDouble(textBoxMass.Text);
                }
                    break;

                case "Вертолет":
                {
                    transport = new Helicopter();

                    Motor motor = new Motor();

                    string typeFuel = comboBoxFuel.Text;

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
                        groupBoxDataHybridCar.Visible = false;
                        groupBoxDataHelicopter.Visible = false;
                    }
                    break;

                case "Гибридная машина":
                    {
                        groupBoxDataHybridCar.Visible = true;
                        groupBoxDataHelicopter.Visible = false;

                    }
                    break;

                case "Вертолет":
                    {
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

        /// <summary>
        /// Заполнение comboBox массивом данных comboBox.
        /// </summary>
        /// <param name="dataSource">Массив данных.</param>
        /// <param name="comboBox">ComboBox.</param>
        private void FillComboBox(object[] dataSource, ComboBox  comboBox)
        {
            comboBox.DataSource = dataSource;
            comboBox.SelectedItem = dataSource.GetValue(0);
        }

        private void FillComboBoxFuel(object sender, EventArgs e)
        {
            object key = comboBoxTransport.SelectedItem;

            Dictionary<object, object[]> fuelTypes = new()
            {
                {
                    "Машина",
                    ["Бензин", "Дизель", "Газ", "Электричество"]},
                {
                    "Гибридная машина",
                    ["Бензин", "Дизель", "Газ", "Электричество"]},
                {
                    "Вертолет", ["Авиационный керосин", "Авиационный бензин"]
                },

            };

            FillComboBox(fuelTypes[key], comboBoxFuel);
        }

    }
}
