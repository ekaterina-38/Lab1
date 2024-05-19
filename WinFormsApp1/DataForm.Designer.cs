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

        private Button buttonAgree;
        private Button buttonCancel;
        
        private ComboBox comboBoxTransport;
        private ComboBox comboBoxFuel;
        private ComboBox comboBoxHybridFuel;

        private GroupBox groupBoxData;
        private GroupBox groupBoxDataHybridCar;
        private GroupBox groupBoxDataHelicopter;

        private TextBox textBoxCapacity;
        private TextBox textBoxMass;
        private TextBox textBoxHybridCapacity;
        private TextBox textBoxBladeLength;

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
            comboBoxFuel = new ComboBox();
            comboBoxHybridFuel = new ComboBox();

            Label labelCapacity = new Label();
            Label labelMass = new Label();
            Label labelHybridCapacity = new Label();
            Label labelBladeLength = new Label();

            textBoxCapacity = new TextBox();
            textBoxMass = new TextBox();
            textBoxHybridCapacity = new TextBox();
            textBoxBladeLength = new TextBox();

            groupBoxData = new GroupBox();
            groupBoxDataHybridCar = new GroupBox();
            groupBoxDataHelicopter = new GroupBox();

            SuspendLayout();
            // 
            // buttonAgree
            // 
            buttonAgree.BackColor = SystemColors.ButtonHighlight;
            buttonAgree.ForeColor = SystemColors.ActiveCaptionText;
            buttonAgree.Location = new Point(460, 240);
            buttonAgree.Name = "agreeButton";
            buttonAgree.Size = new Size(100, 30);
            buttonAgree.Text = "Ок";
            buttonAgree.UseVisualStyleBackColor = false;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(580, 240);
            buttonCancel.Name = "cancelButton";
            buttonCancel.Size = new Size(100, 30);
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // comboBoxTransport
            // 
            comboBoxTransport.Location = new Point(50, 30);
            comboBoxTransport.Size = new Size(150, 30);
            // 
            // comboBoxFuel
            //
            comboBoxFuel.Location = new Point(20, 30);
            comboBoxFuel.Size = new Size(150, 30);
            // 
            // comboBoxHybridFuel
            //
            comboBoxHybridFuel.Location = new Point(20, 30);
            comboBoxHybridFuel.Size = new Size(150, 30);
            // 
            // labelCapacity
            //
            labelCapacity.Location = new Point(20, 70);
            labelCapacity.Size = new Size(150, 20);
            labelCapacity.Text = "Мощность л.с.";
            // 
            // labelMass
            //
            labelMass.Location = new Point(20, 130);
            labelMass.Size = new Size(150, 20);
            labelMass.Text = "Масса т.";
            // 
            // labelHybridCapacity
            //
            labelHybridCapacity.Location = new Point(20, 70);
            labelHybridCapacity.Size = new Size(150, 20);
            labelHybridCapacity.Text = "Мощность л.с.";
            // 
            // labelBladeLength
            //
            labelBladeLength.Location = new Point(20, 30);
            labelBladeLength.Size = new Size(150, 20);
            labelBladeLength.Text = "Длина лопастей м.";
            // 
            // textBoxCapacity
            //
            textBoxCapacity.Location = new Point(20, 90);
            textBoxCapacity.Size = new Size(150, 20);
            // 
            // textBoxMass
            //
            textBoxMass.Location = new Point(20, 150);
            textBoxMass.Size = new Size(150, 20);
            // 
            // textBoxHybridCapacity
            //
            textBoxHybridCapacity.Location = new Point(20, 90);
            textBoxHybridCapacity.Size = new Size(150, 20);
            // 
            // textBoxBladeLength
            //
            textBoxBladeLength.Location = new Point(20, 50);
            textBoxBladeLength.Size = new Size(150, 20);
            // 
            // groupBoxData
            //
            groupBoxData.Location = new Point(230, 30);
            groupBoxData.Name = "groupBoxDataCar";
            groupBoxData.Size = new Size(220, 200);
            groupBoxData.TabIndex = 0;
            groupBoxData.TabStop = false;
            groupBoxData.Text = "Ввод данных о двигателе и массе";
            groupBoxData.Controls.Add(labelCapacity);
            groupBoxData.Controls.Add(textBoxCapacity);
            groupBoxData.Controls.Add(labelMass);
            groupBoxData.Controls.Add(textBoxMass);
            groupBoxData.Controls.Add(comboBoxFuel);
            // 
            // groupBoxDataHybridCar
            // 
            groupBoxDataHybridCar.Location = new Point(460, 30);
            groupBoxDataHybridCar.Name = "groupBoxDataHybridCar";
            groupBoxDataHybridCar.Size = new Size(220, 200);
            groupBoxDataHybridCar.Text = "Ввод данных о 2-ом двигателе";
            groupBoxDataHybridCar.Visible = false;
            groupBoxDataHybridCar.Controls.Add(comboBoxHybridFuel);
            groupBoxDataHybridCar.Controls.Add(textBoxHybridCapacity);
            groupBoxDataHybridCar.Controls.Add(labelHybridCapacity);
            // 
            // groupBoxDataHelicopter
            // 
            groupBoxDataHelicopter.Location = new Point(460, 30);
            groupBoxDataHelicopter.Name = "groupBoxDataHelicopter";
            groupBoxDataHelicopter.Size = new Size(220, 100);
            groupBoxDataHelicopter.Text = "Ввод дополнительных данных";
            groupBoxDataHelicopter.Visible = false;
            groupBoxDataHelicopter.Controls.Add(textBoxBladeLength);
            groupBoxDataHelicopter.Controls.Add(labelBladeLength);
            // 
            // DataForm
            // 
            FormBorderStyle = FormBorderStyle.FixedSingle;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(730, 300);
            Controls.Add(buttonAgree);
            Controls.Add(buttonCancel);
            Controls.Add(comboBoxTransport);
            Controls.Add(groupBoxData);
            Controls.Add(groupBoxData);
            Controls.Add(groupBoxDataHybridCar);
            Controls.Add(groupBoxDataHelicopter);
            Name = "DataForm";
            Text = "Ввод данных";
            ResumeLayout(false);
        }

        #endregion
    }
}