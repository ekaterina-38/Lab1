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
                _comboBoxTransport);

            FillComboBoxFuel();

            _comboBoxTransport.SelectedIndexChanged += new
                EventHandler(AddGroupBoxData);

            _comboBoxTransport.SelectedIndexChanged += new
                EventHandler(comboBoxTransportFillComboBoxFuel);

            _comboBoxFuel.SelectedIndexChanged += new
                EventHandler(FillComboBoxHybridFuel);

            _buttonAgree.Click += new EventHandler(AgreeButtonClick);

            _buttonCancel.Click += new EventHandler(CancelButtonClick);

#if DEBUG
            _buttonRandom.Click += new EventHandler(RandomButtonClick);
#endif

            _textBoxCapacity.KeyPress += new
                KeyPressEventHandler(TextBoxKeyPress);

            _textBoxMass.KeyPress += new
                KeyPressEventHandler(TextBoxKeyPress);

            _textBoxHybridCapacity.KeyPress += new
                KeyPressEventHandler(TextBoxKeyPress);

            _textBoxBladeLength.KeyPress += new
                KeyPressEventHandler(TextBoxKeyPress);

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
                string typeTransport = _comboBoxTransport.Text;

                TransportBase transport = null;

                switch (typeTransport)
                {
                    case "Машина":
                        {
                            Motor motor = new Motor();
                            motor.TypeFuel = (TypeFuel)_comboBoxFuel.SelectedItem;
                            motor.Capacity = Convert.ToDouble(_textBoxCapacity.Text);
                            double mass = Convert.ToDouble(_textBoxMass.Text);

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
                            motor.TypeFuel = (TypeFuel)_comboBoxFuel.SelectedItem;
                            motor.Capacity = Convert.ToDouble(_textBoxCapacity.Text);

                            Motor additionalMotor = new Motor();
                            additionalMotor.TypeFuel = (TypeFuel)_comboBoxHybridFuel.SelectedItem;
                            additionalMotor.Capacity = Convert.ToDouble(_textBoxHybridCapacity.Text);

                            double mass = Convert.ToDouble(_textBoxMass.Text);

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
                            motor.TypeFuel = (TypeFuel)_comboBoxFuel.SelectedItem;
                            motor.Capacity = Convert.ToDouble(_textBoxCapacity.Text);
                            double mass = Convert.ToDouble(_textBoxMass.Text);
                            double bladeLength = Convert.ToDouble(_textBoxBladeLength.Text);

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
            string typeTransport = _comboBoxTransport.Text;

            switch (typeTransport)
            {
                case "Машина":
                {
                    _groupBoxDataHybridCar.Visible = false;
                    _groupBoxDataHelicopter.Visible = false;
                }
                    break;

                case "Гибридная машина":
                {
                    _groupBoxDataHybridCar.Visible = true;
                    _groupBoxDataHelicopter.Visible = false;

                }
                    break;

                case "Вертолет":
                {
                    _groupBoxDataHybridCar.Visible = false;
                    _groupBoxDataHelicopter.Visible = true;
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
        /// Заполнение ComboBoxFuel массивом данных
        /// в соответствии с выбранным типом транспорта.
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void comboBoxTransportFillComboBoxFuel(object sender, EventArgs e)
        {
            FillComboBoxFuel();
        }

        /// <summary>
        /// Заполнение  ComboBoxFuel массивом данных
        /// в соответствии с выбранным типом транспорта.
        /// </summary>
        private void FillComboBoxFuel()
        {
            object key = _comboBoxTransport.SelectedItem;

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

            FillComboBox(fuelTypes[key], _comboBoxFuel);
        }

        /// <summary>
        /// Заполнение ComboBoxHybridFuel массивом данных
        /// в соответствии с выбранным ComboBoxHybrid.
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void FillComboBoxHybridFuel(object sender, EventArgs e)
        {
            if (_groupBoxDataHybridCar.Visible == true)
            {
                TypeFuel valueComboBoxFuel = (TypeFuel)_comboBoxFuel.SelectedItem;
                TypeFuel[] valuesComboBoxHybridFuel = 
                    _comboBoxFuel.Items.Cast<TypeFuel>().ToArray();
                int index = Array.IndexOf(valuesComboBoxHybridFuel, valueComboBoxFuel);

                if (index > -1)
                {
                    TypeFuel[] newArray = new TypeFuel[valuesComboBoxHybridFuel.Length - 1];
                    Array.Copy(valuesComboBoxHybridFuel, 0, newArray, 0, index);
                    Array.Copy(valuesComboBoxHybridFuel, index + 1, newArray, index,
                        valuesComboBoxHybridFuel.Length - index - 1);

                    FillComboBox(newArray, _comboBoxHybridFuel);
                    return;
                }

                FillComboBox(valuesComboBoxHybridFuel, _comboBoxHybridFuel);
            }            
        }

        /// <summary>
        /// Проверка данных вводимых в textBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxKeyPress(object sender, KeyPressEventArgs e)
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

#if DEBUG
        /// <summary>
        ///  Заполнение данными полей textBox. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RandomButtonClick(object sender, EventArgs e)
        {
            Random random = new Random();

            int mass = Convert.ToInt32(_textBoxMass.Text = random.Next(1, 15).ToString());

            _textBoxCapacity.Text = Convert.ToString(mass * 100);

            _textBoxHybridCapacity.Text = Convert.ToString(mass * 80);

            _textBoxBladeLength.Text = random.Next(10, 20).ToString();
        }
#endif
    }
}
