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
        /// Кнопка "Добавить".
        /// </summary>
        private Button _buttonAgree;
        
        /// <summary>
        /// Кнопка "Отменить".
        /// </summary>
        private Button _buttonCancel;

        /// <summary>
        /// Кнопка "Заполнить".
        /// </summary>
        private Button _buttonRandom;

        /// <summary>
        /// ComboBox выбор транспорта.
        /// </summary>
        private ComboBox _comboBoxTransport;

        /// <summary>
        /// ComboBox выбор основного топлива.
        /// </summary>
        private ComboBox _comboBoxFuel;

        /// <summary>
        /// ComboBox выбор дополнительного топлива.
        /// </summary>
        private ComboBox _comboBoxHybridFuel;

        /// <summary>
        /// GroupBox для основных данных(топливо, мощность, масса).
        /// </summary>
        private GroupBox _groupBoxData;

        /// <summary>
        /// GroupBox для дополнительных данных(топливо, мощность).
        /// </summary>
        private GroupBox _groupBoxDataHybridCar;

        /// <summary>
        /// GroupBox для дополнительных данных(длина лопастей).
        /// </summary>
        private GroupBox _groupBoxDataHelicopter;

        /// <summary>
        /// TextBox для ввода мощности.
        /// </summary>
        private TextBox _textBoxCapacity;

        /// <summary>
        /// TextBox для ввода массы.
        /// </summary>
        private TextBox _textBoxMass;

        /// <summary>
        /// TextBox для ввода мощности гибридной машины.
        /// </summary>
        private TextBox _textBoxHybridCapacity;

        /// <summary>
        /// TextBox для ввода длины лопастей вертолета.
        /// </summary>
        private TextBox _textBoxBladeLength;

        /// <summary>
        /// Метод для явного освобождения ресурсов.
        /// </summary>
        /// <param name="disposing">true если ресурсы необходимо
        /// удалить,иначе false.</param>
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
            _buttonAgree = new Button();
            _buttonCancel = new Button();
#if DEBUG
            _buttonRandom = new Button();
#endif
            _comboBoxTransport = new ComboBox();
            _comboBoxFuel = new ComboBox();
            _comboBoxHybridFuel = new ComboBox();

            Label labelCapacity = new Label();
            Label labelMass = new Label();
            Label labelHybridCapacity = new Label();
            Label labelBladeLength = new Label();

            _textBoxCapacity = new TextBox();
            _textBoxMass = new TextBox();
            _textBoxHybridCapacity = new TextBox();
            _textBoxBladeLength = new TextBox();

            _groupBoxData = new GroupBox();
            _groupBoxDataHybridCar = new GroupBox();
            _groupBoxDataHelicopter = new GroupBox();

            SuspendLayout();
            // 
            // buttonAgree
            // 
            _buttonAgree.BackColor = SystemColors.ButtonHighlight;
            _buttonAgree.ForeColor = SystemColors.ActiveCaptionText;
            _buttonAgree.Location = new Point(460, 240);
            _buttonAgree.Name = "agreeButton";
            _buttonAgree.Size = new Size(100, 30);
            _buttonAgree.Text = "Ок";
            _buttonAgree.UseVisualStyleBackColor = false;
            // 
            // buttonCancel
            // 
            _buttonCancel.Location = new Point(580, 240);
            _buttonCancel.Name = "cancelButton";
            _buttonCancel.Size = new Size(100, 30);
            _buttonCancel.Text = "Отмена";
            _buttonCancel.UseVisualStyleBackColor = false;
#if DEBUG
            // 
            // buttonRandom 
            // 
            _buttonRandom.BackColor = SystemColors.ButtonHighlight;
            _buttonRandom.ForeColor = SystemColors.ActiveCaptionText;
            _buttonRandom.Location = new Point(340, 240);
            _buttonRandom.Name = "buttonRandom";
            _buttonRandom.Size = new Size(100, 30);
            _buttonRandom.Text = "Заполнить";
            _buttonRandom.UseVisualStyleBackColor = false;
#endif
            // 
            // comboBoxTransport
            // 
            _comboBoxTransport.Location = new Point(50, 30);
            _comboBoxTransport.Size = new Size(150, 30);
            // 
            // comboBoxFuel
            //
            _comboBoxFuel.Location = new Point(20, 30);
            _comboBoxFuel.Size = new Size(150, 30);
            // 
            // comboBoxHybridFuel
            //
            _comboBoxHybridFuel.Location = new Point(20, 30);
            _comboBoxHybridFuel.Size = new Size(150, 30);
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
            _textBoxCapacity.Location = new Point(20, 90);
            _textBoxCapacity.Size = new Size(150, 20);
            // 
            // textBoxMass
            //
            _textBoxMass.Location = new Point(20, 150);
            _textBoxMass.Size = new Size(150, 20);
            // 
            // textBoxHybridCapacity
            //
            _textBoxHybridCapacity.Location = new Point(20, 90);
            _textBoxHybridCapacity.Size = new Size(150, 20);
            // 
            // textBoxBladeLength
            //
            _textBoxBladeLength.Location = new Point(20, 50);
            _textBoxBladeLength.Size = new Size(150, 20);
            // 
            // groupBoxData
            //
            _groupBoxData.Location = new Point(230, 30);
            _groupBoxData.Name = "groupBoxDataCar";
            _groupBoxData.Size = new Size(220, 200);
            _groupBoxData.TabIndex = 0;
            _groupBoxData.TabStop = false;
            _groupBoxData.Text = "Ввод данных о двигателе и массе";
            _groupBoxData.Controls.Add(labelCapacity);
            _groupBoxData.Controls.Add(_textBoxCapacity);
            _groupBoxData.Controls.Add(labelMass);
            _groupBoxData.Controls.Add(_textBoxMass);
            _groupBoxData.Controls.Add(_comboBoxFuel);
            // 
            // groupBoxDataHybridCar
            // 
            _groupBoxDataHybridCar.Location = new Point(460, 30);
            _groupBoxDataHybridCar.Name = "groupBoxDataHybridCar";
            _groupBoxDataHybridCar.Size = new Size(220, 200);
            _groupBoxDataHybridCar.Text = "Ввод данных о 2-ом двигателе";
            _groupBoxDataHybridCar.Visible = false;
            _groupBoxDataHybridCar.Controls.Add(_comboBoxHybridFuel);
            _groupBoxDataHybridCar.Controls.Add(_textBoxHybridCapacity);
            _groupBoxDataHybridCar.Controls.Add(labelHybridCapacity);
            // 
            // groupBoxDataHelicopter
            // 
            _groupBoxDataHelicopter.Location = new Point(460, 30);
            _groupBoxDataHelicopter.Name = "groupBoxDataHelicopter";
            _groupBoxDataHelicopter.Size = new Size(220, 100);
            _groupBoxDataHelicopter.Text = "Ввод дополнительных данных";
            _groupBoxDataHelicopter.Visible = false;
            _groupBoxDataHelicopter.Controls.Add(_textBoxBladeLength);
            _groupBoxDataHelicopter.Controls.Add(labelBladeLength);
            // 
            // DataForm
            // 
            FormBorderStyle = FormBorderStyle.FixedSingle;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(730, 300);
            Controls.Add(_buttonAgree);
            Controls.Add(_buttonCancel);
#if DEBUG
            Controls.Add(_buttonRandom);
#endif
            Controls.Add(_comboBoxTransport);
            Controls.Add(_groupBoxData);
            Controls.Add(_groupBoxData);
            Controls.Add(_groupBoxDataHybridCar);
            Controls.Add(_groupBoxDataHelicopter);
            Name = "DataForm";
            Text = "Ввод данных";
            ResumeLayout(false);
        }

#endregion
    }
}