using System.Security.Cryptography.Xml;
using TransportLibrary;

namespace View
{
    /// <summary>
    /// Класс DataForm.
    /// </summary>
    partial class DataForm
    {
        /// <summary>
        /// Необходимая переменная дизайнера.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Метод для явного освобождения ресурсов.
        /// </summary>
        /// <param name="disposing">true если ресурсы необходимо удалить,иначе false.</param>
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
        /// Метод инициализации компонентов (кнопки,текстовые поля и т.д.)
        /// </summary>
        private void InitializeComponent()
        {
            buttonAgree = new Button();

            buttonCancel = new Button();

            comboBoxTransport = new ComboBox();

            comboBoxFuelCar = new ComboBox();

            comboBoxFuelHybridCar = new ComboBox();

            comboBoxFuelHelicopter = new ComboBox();

            panelInputs = new Panel();

            groupBoxData = new GroupBox();

            groupBoxDataCar = new GroupBox();

            groupBoxDataHybridCar = new GroupBox();

            groupBoxDataHelicopter = new GroupBox();

            textBoxСapacity = new TextBox();

            Label labelCapacity = new Label();

            textBoxMass = new TextBox();

            Label labelMass = new Label();
            
            textBoxDistance = new TextBox();

            Label labelDistance = new Label();

            SuspendLayout();
            // 
            // buttonAgree
            // 
            buttonAgree.BackColor = SystemColors.ButtonHighlight;
            buttonAgree.ForeColor = SystemColors.ActiveCaptionText;
            buttonAgree.Location = new Point(225, 330);
            buttonAgree.Name = "agreeButton";
            buttonAgree.Size = new Size(100, 30);
            buttonAgree.Text = "Ок";
            buttonAgree.UseVisualStyleBackColor = false;
            buttonAgree.Click += AgreeButtonClick;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(350, 330);
            buttonCancel.Name = "cancelButton";
            buttonCancel.Size = new Size(100, 30);
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += CancelButtonClick;
            // 
            // comboBoxTransport
            // 
            comboBoxTransport.Location = new Point(50, 50);
            comboBoxTransport.Size = new Size(150, 30);
            comboBoxTransport.Items.Add("Машина");
            comboBoxTransport.Items.Add("Гибридная машина");
            comboBoxTransport.Items.Add("Вертолет");
            comboBoxTransport.SelectedIndex = 0;
            // 
            // comboBoxFuelCar
            //
            comboBoxFuelCar.Location = new Point(20, 20);
            comboBoxFuelCar.Size = new Size(150, 30);
            comboBoxFuelCar.Items.Add("Бензин");
            comboBoxFuelCar.Items.Add("Дизель");
            comboBoxFuelCar.Items.Add("Электричество");
            comboBoxFuelCar.Items.Add("Газ");
            comboBoxFuelCar.SelectedIndex = 0;
            // 
            // comboBoxFuelHybridCar
            //
            comboBoxFuelHybridCar.Location = new Point(20, 20);
            comboBoxFuelHybridCar.Size = new Size(150, 30);
            comboBoxFuelHybridCar.Items.Add("Бензин");
            comboBoxFuelHybridCar.Items.Add("Дизель");
            comboBoxFuelHybridCar.Items.Add("Электричество");
            comboBoxFuelHybridCar.Items.Add("Газ");
            comboBoxFuelHybridCar.SelectedIndex = 0;
            // 
            // comboBoxFuelHelicopter
            //
            comboBoxFuelHelicopter.Location = new Point(20, 20);
            comboBoxFuelHelicopter.Size = new Size(150, 30);
            comboBoxFuelHelicopter.Items.Add("Aвиационный керосин");
            comboBoxFuelHelicopter.Items.Add("Aвиационный бензин");
            comboBoxFuelHelicopter.SelectedIndex = 0;
            // 
            // labelCapacity
            //
            labelCapacity.Location = new Point(20, 20);
            labelCapacity.Size = new Size(150, 20);
            labelCapacity.Text = "Мощность л.с.";
            // 
            // textBoxСapacity
            //
            textBoxСapacity.Location = new Point(20, 60);
            textBoxСapacity.Size = new Size(150, 20);
            // 
            // labelMass
            //
            labelMass.Location = new Point(20, 100);
            labelMass.Size = new Size(150, 20);
            labelMass.Text = "Масса т.";
            // 
            // textBoxMass
            //
            textBoxMass.Location = new Point(20, 140);
            textBoxMass.Size = new Size(150, 20);
            // 
            // labelDistance
            //
            labelDistance.Location = new Point(20, 200);
            labelDistance.Size = new Size(150, 20);
            labelDistance.Text = "Расстояние км.";
            // 
            // textBoxDistance
            //
            textBoxDistance.Location = new Point(20, 220);
            textBoxDistance.Size = new Size(150, 20);
            // 
            // groupBoxDataBasic
            //
            groupBoxData.Location = new Point(230, 120);
            groupBoxData.Name = "groupBoxDataCar";
            groupBoxData.Size = new Size(220, 200);
            groupBoxData.TabIndex = 0;
            groupBoxData.TabStop = false;
            groupBoxData.Text = "Ввод данных";
            groupBoxData.Controls.Add(labelCapacity);
            groupBoxData.Controls.Add(textBoxСapacity);
            groupBoxData.Controls.Add(labelMass);
            groupBoxData.Controls.Add(textBoxMass);
            // 
            // groupBoxDataCar
            // 
            groupBoxDataCar.Location = new Point(230, 50);
            groupBoxDataCar.Name = "groupBoxDataCar";
            groupBoxDataCar.Size = new Size(220, 60);
            groupBoxDataCar.Controls.Add(comboBoxFuelCar);
            // 
            // groupBoxDataHybridCar
            // 
            groupBoxDataHybridCar.Location = new Point(230, 50);
            groupBoxDataHybridCar.Name = "groupBoxDataHybridCar";
            groupBoxDataHybridCar.Size = new Size(220, 60);
            groupBoxDataHybridCar.Controls.Add(comboBoxFuelHybridCar);
            // 
            // groupBoxDataHelicopter
            // 
            groupBoxDataHelicopter.Location = new Point(230, 50);
            groupBoxDataHelicopter.Name = "groupBoxDataHelicopter";
            groupBoxDataHelicopter.Size = new Size(220, 60);
            groupBoxDataHelicopter.Controls.Add(comboBoxFuelHelicopter);
            // 
            // DataForm
            // 
            FormBorderStyle = FormBorderStyle.FixedSingle;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(500, 380);
            Controls.Add(buttonAgree);
            Controls.Add(buttonCancel);
            Controls.Add(comboBoxTransport);
            Controls.Add(groupBoxData);
            Controls.Add(groupBoxDataCar);
            Controls.Add(groupBoxDataHybridCar);
            Controls.Add(groupBoxDataHelicopter);
            Controls.Add(panelInputs);
            Name = "DataForm";
            Text = "Ввод данных";
            ResumeLayout(false);
        }

        #endregion
    }
}