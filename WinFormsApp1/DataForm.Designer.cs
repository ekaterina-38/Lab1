using System.Security.Cryptography.Xml;
using TransportLibrary;

namespace View
{
    partial class DataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboBox;
        private ComboBox comboBox1;
        private TextBox textBox;
        private TextBox textBox1;
        private TextBox textBox2;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            agreeButton = new Button();

            cancelButton = new Button();

            comboBox = new ComboBox();

            comboBox1 = new ComboBox();

            panelInputs = new Panel();

            groupBox = new GroupBox();

            textBox = new TextBox();

            Label label = new Label();

            textBox1 = new TextBox();

            Label label1 = new Label();
            
            textBox2 = new TextBox();

            Label label2 = new Label();

            SuspendLayout();
            // 
            // agreeButton
            // 
            agreeButton.BackColor = SystemColors.ButtonHighlight;
            agreeButton.ForeColor = SystemColors.ActiveCaptionText;
            agreeButton.Location = new Point(225, 330);
            agreeButton.Name = "agreeButton";
            agreeButton.Size = new Size(100, 30);
            agreeButton.TabIndex = 1;
            agreeButton.Text = "Ок";
            agreeButton.UseVisualStyleBackColor = false;
            agreeButton.Click += agreeButtonClick;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(350, 330);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 30);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButtonClick;
            // 
            // comboBox
            // 
            comboBox.Location = new Point(50, 50);
            comboBox.Size = new Size(150, 30);
            comboBox.Items.Add("Машина");
            comboBox.Items.Add("Гибридная машина");
            comboBox.Items.Add("Вертолет");
            comboBox.SelectedIndex = 0;
            comboBox.SelectedIndexChanged += new EventHandler(comboBoxSelectedIndexChanged);
            // 
            // panelInputs
            //
            panelInputs.Dock = DockStyle.Fill;
            // 
            // comboBox1
            //
            comboBox1.Location = new Point(20, 40);
            comboBox1.Size = new Size(150, 30);
            comboBox1.Items.Add("Бензин");
            comboBox1.Items.Add("Дизель");
            comboBox1.Items.Add("Электричество");
            comboBox1.Items.Add("Газ");
            comboBox1.SelectedIndex = 0;
            // 
            // label
            //
            label.Location = new Point(20, 80);
            label.Size = new Size(150, 20);
            label.Text = "Мощность л.с.";
            // 
            // textBox
            //
            textBox.Location = new Point(20, 100);
            textBox.Size = new Size(150, 20);
            // 
            // label1
            //
            label1.Location = new Point(20, 140);
            label1.Size = new Size(150, 20);
            label1.Text = "Масса т.";
            // 
            // textBox1
            //
            textBox1.Location = new Point(20, 160);
            textBox1.Size = new Size(150, 20);
            // 
            // label2
            //
            label2.Location = new Point(20, 200);
            label2.Size = new Size(150, 20);
            label2.Text = "Расстояние км.";
            // 
            // textBox2
            //
            textBox2.Location = new Point(20, 220);
            textBox2.Size = new Size(150, 20);
            // 
            // groupBox
            // 
            groupBox.Location = new Point(230, 50);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(220, 260);
            groupBox.TabIndex = 0;
            groupBox.TabStop = false;
            groupBox.Text = "Ввод данных";
            groupBox.Controls.Add(comboBox1);
            groupBox.Controls.Add(label);
            groupBox.Controls.Add(textBox);
            groupBox.Controls.Add(label1);
            groupBox.Controls.Add(textBox1);
            groupBox.Controls.Add(label2);
            groupBox.Controls.Add(textBox2);
            // 
            // DataForm
            // 
            FormBorderStyle = FormBorderStyle.FixedSingle;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(500, 380);
            Controls.Add(agreeButton);
            Controls.Add(cancelButton);
            Controls.Add(comboBox);
            Controls.Add(groupBox);
            Controls.Add(panelInputs);
            Name = "DataForm";
            Text = "Ввод данных";
            ResumeLayout(false);
        }

        private void agreeButtonClick(object sender, EventArgs e)
        {
            string typeTransport = comboBox.Text;

            Car car = new Car();
            Motor motor = new Motor();

            string typeFuel = comboBox1.Text;

            switch(typeFuel)
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

            motor.Capacity = Convert.ToDouble(textBox.Text);

            car.Mass = Convert.ToDouble(textBox1.Text);

            double distance = Convert.ToDouble(textBox2.Text);


            BasicForm basicForm = Application.OpenForms.OfType<BasicForm>().FirstOrDefault();
            if (basicForm != null)
            {
                basicForm.transportList.Add(car);
                basicForm.gridControl.Rows.Add(car.GetType().Name, distance, car.CalculateFuel(distance));
            }
            Close();
        }

        private void cancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }
        private void comboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string selectedValue = comboBox.SelectedItem.ToString();

            TransportBase transport = null;

            switch (selectedValue)
            {
                case "Машина":
                    AddInputField("Масса:");
                    AddInputField("Поле 2:");
                    //transport = new Car();
                    break;
                case "Гибридная машина":
                    //transport = new HybridCar();
                    break;
                case "Вертолет":
                    //transport = new Helicopter();
                    break;
                default:
                    break;
            }

            if (transport != null)
            {
                //transportList.Add(transport);
            }
        }

        private void AddInputField(string labelText)
        {
            Label label = new Label();
            label.Text = labelText;
            label.Location = new Point(300, 50); 
            label.Size = new Size(100, 20);

            TextBox textBox = new TextBox();
            textBox.Location = new Point(300, 70);
            textBox.Size = new Size(150, 20);     

            panelInputs.Controls.Add(textBox);
            panelInputs.Controls.Add(label);
        }

        #endregion
    }
}