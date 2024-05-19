using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using TransportLibrary;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace View
{
    /// <summary>
    /// Класс DataForm.
    /// </summary>
    public partial class DataForm : Form
    {

        /// <summary>
        /// Конструктор DataForm.
        /// </summary>
        public DataForm()
        {
            InitializeComponent();
            FillComboBox(["Машина", "Гибридная машина", "Вертолет"],
                comboBoxTransport);
            FillComboBoxFuel();
            comboBoxTransport.SelectedIndexChanged += new EventHandler(AddGroupBoxData);
            comboBoxTransport.SelectedIndexChanged += new EventHandler(comboBoxTransport_FillComboBoxFuel);
            comboBoxFuel.SelectedIndexChanged += new EventHandler(FillComboBoxHybridFuel);
            buttonAgree.Click += new EventHandler(AgreeButtonClick);
            buttonCancel.Click += new EventHandler(CancelButtonClick);
            buttonRandom.Click += new EventHandler(RandomButtonClick);

            textBoxCapacity.KeyPress += new KeyPressEventHandler(textBoxKeyPress);
            textBoxMass.KeyPress += new KeyPressEventHandler(textBoxKeyPress);
            textBoxHybridCapacity.KeyPress += new KeyPressEventHandler(textBoxKeyPress);
            textBoxBladeLength.KeyPress += new KeyPressEventHandler(textBoxKeyPress);

        }

        /// <summary>
        /// Свойство  для обработки события добавления.
        /// </summary>
        public EventHandler TransportAdded
        {
            get;
            set;
        }

        /// <summary>
        /// Свойство  для обработки события отмена.
        /// </summary>
        public EventHandler TransportCancel
        {
            get;
            set;
        }

        /// <summary>
        /// Свойство для хранения последнего добавленного объекта.
        /// </summary>
        private TransportBase LastTransport
        {
            get;
            set;
        }

        /// <summary>
        /// Метод нажатия на кнопку "Ок"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void AgreeButtonClick(object sender, EventArgs e)
        {
            try
            {
                string typeTransport = comboBoxTransport.Text;

                TransportBase transport = null;

                switch (typeTransport)
                {
                    case "Машина":
                        {
                            Motor motor = new Motor();
                            motor.TypeFuel = (TypeFuel)comboBoxFuel.SelectedItem;
                            motor.Capacity = Convert.ToDouble(textBoxCapacity.Text);
                            double mass = Convert.ToDouble(textBoxMass.Text);

                            transport = new Car()
                            {
                                Motor = motor,
                                Mass = mass
                            };
                        }
                        break;

                    case "Гибридная машина":
                        {
                            Motor motor = new Motor();
                            motor.TypeFuel = (TypeFuel)comboBoxFuel.SelectedItem;
                            motor.Capacity = Convert.ToDouble(textBoxCapacity.Text);

                            Motor additionalMotor = new Motor();
                            additionalMotor.TypeFuel = (TypeFuel)comboBoxHybridFuel.SelectedItem;
                            additionalMotor.Capacity = Convert.ToDouble(textBoxHybridCapacity.Text);

                            double mass = Convert.ToDouble(textBoxMass.Text);

                            transport = new HybridCar()
                            {
                                Motor = motor,
                                AdditionalMotor = additionalMotor,
                                Mass = mass,
                            };

                        }
                        break;

                    case "Вертолет":
                        {
                            Motor motor = new Motor();
                            motor.TypeFuel = (TypeFuel)comboBoxFuel.SelectedItem;
                            motor.Capacity = Convert.ToDouble(textBoxCapacity.Text);
                            double mass = Convert.ToDouble(textBoxMass.Text);
                            double bladeLength = Convert.ToDouble(textBoxBladeLength.Text);

                            transport = new Helicopter()
                            {
                                Motor = motor,
                                Mass = mass,
                                BladeLength = bladeLength
                            };
                        }
                        break;
                }

                TransportAdded?.Invoke(this, new TransportAddedEventArgs(transport));

                LastTransport = transport;
            }
            catch
            {
                MessageBox.Show("Введите данные.", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Метод добавления GroupBox на форму.
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
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
            if (LastTransport != null)
            {
                TransportCancel?.Invoke(this, new TransportAddedEventArgs(LastTransport));
            }   
        }

        /// <summary>
        /// Заполнение comboBox массивом данных comboBox.
        /// </summary>
        /// <param name="dataSource">Массив данных.</param>
        /// <param name="comboBox">ComboBox.</param>
        private void FillComboBox <T>(T[] dataSource, ComboBox  comboBox)
        {
            comboBox.DataSource = dataSource;
            comboBox.SelectedItem = dataSource.GetValue(0);
        }

        /// <summary>
        /// Заполнение ComboBoxFuel массивом данных.
        /// в соответствии с выбранным типом транспорта.
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void comboBoxTransport_FillComboBoxFuel(object sender, EventArgs e)
        {
            FillComboBoxFuel();
        }
        private void FillComboBoxFuel()
        {
            object key = comboBoxTransport.SelectedItem;

            Dictionary<object, TypeFuel[]> fuelTypes = new()
            {
                {
                    "Машина",
                    [TypeFuel.Petrol, TypeFuel.Diesel, TypeFuel.Gas, TypeFuel.Electricity]},
                {
                    "Гибридная машина",
                    [TypeFuel.Petrol, TypeFuel.Diesel, TypeFuel.Gas, TypeFuel.Electricity]},
                {
                    "Вертолет",
                    [TypeFuel.AviationKerosene, TypeFuel.AviationGasoline]
                },

            };

            FillComboBox(fuelTypes[key], comboBoxFuel);
        }

        /// <summary>
        /// Заполнение ComboBoxHybridFuel массивом данных
        /// в соответствии с выбранным ComboBoxHybrid.
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void FillComboBoxHybridFuel(object sender, EventArgs e)
        {
            if (groupBoxDataHybridCar.Visible == true)
            {
                TypeFuel valueComboBoxFuel = (TypeFuel)comboBoxFuel.SelectedItem;
                TypeFuel[] valuesComboBoxHybridFuel = 
                    comboBoxFuel.Items.Cast<TypeFuel>().ToArray();
                int index = Array.IndexOf(valuesComboBoxHybridFuel, valueComboBoxFuel);

                if (index > -1)
                {
                    TypeFuel[] newArray = new TypeFuel[valuesComboBoxHybridFuel.Length - 1];
                    Array.Copy(valuesComboBoxHybridFuel, 0, newArray, 0, index);
                    Array.Copy(valuesComboBoxHybridFuel, index + 1, newArray, index,
                        valuesComboBoxHybridFuel.Length - index - 1);

                    FillComboBox(newArray, comboBoxHybridFuel);
                    return;
                }

                FillComboBox(valuesComboBoxHybridFuel, comboBoxHybridFuel);
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && textBox.Text.Contains(","))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '0' && string.IsNullOrEmpty(textBox.Text.Trim('0')))
            {
                e.Handled = true;
            }
        }

        private void RandomButtonClick(object sender, EventArgs e)
        {
            Random random = new Random();

            textBoxCapacity.Text = random.Next(1, 300).ToString();

            textBoxHybridCapacity.Text = random.Next(1, 300).ToString();

            textBoxMass.Text = random.Next(1, 15).ToString();

            textBoxBladeLength.Text = random.Next(10, 20).ToString();
        }
    }
}
