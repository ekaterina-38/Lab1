﻿using System.Security.Cryptography.Xml;
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
            comboBoxFuel = new ComboBox();

            Label labelCapacity = new Label();
            Label labelMass = new Label();

            textBoxСapacity = new TextBox();
            textBoxMass = new TextBox();

            groupBoxData = new GroupBox();
            groupBoxDataHybridCar = new GroupBox();
            groupBoxDataHelicopter = new GroupBox();

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
            // 
            // comboBoxFuel
            //
            comboBoxFuel.Location = new Point(20, 30);
            comboBoxFuel.Size = new Size(150, 30);
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
            // textBoxСapacity
            //
            textBoxСapacity.Location = new Point(20, 90);
            textBoxСapacity.Size = new Size(150, 20);
            // 
            // textBoxMass
            //
            textBoxMass.Location = new Point(20, 150);
            textBoxMass.Size = new Size(150, 20);
            // 
            // groupBoxData
            //
            groupBoxData.Location = new Point(230, 50);
            groupBoxData.Name = "groupBoxDataCar";
            groupBoxData.Size = new Size(220, 200);
            groupBoxData.TabIndex = 0;
            groupBoxData.TabStop = false;
            groupBoxData.Text = "Ввод данных";
            groupBoxData.Controls.Add(labelCapacity);
            groupBoxData.Controls.Add(textBoxСapacity);
            groupBoxData.Controls.Add(labelMass);
            groupBoxData.Controls.Add(textBoxMass);
            groupBoxData.Controls.Add(comboBoxFuel);
            // 
            // groupBoxDataHybridCar
            // 
            groupBoxDataHybridCar.Location = new Point(460, 50);
            groupBoxDataHybridCar.Name = "groupBoxDataHybridCar";
            groupBoxDataHybridCar.Size = new Size(200, 60);
            // 
            // groupBoxDataHelicopter
            // 
            groupBoxDataHelicopter.Location = new Point(230, 50);
            groupBoxDataHelicopter.Name = "groupBoxDataHelicopter";
            groupBoxDataHelicopter.Size = new Size(220, 60);
            // 
            // DataForm
            // 
            FormBorderStyle = FormBorderStyle.FixedSingle;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(700, 380);
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