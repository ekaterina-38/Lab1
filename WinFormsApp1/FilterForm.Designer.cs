namespace View
{
    /// <summary>
    /// Класс FilterForm. 
    /// </summary>
    partial class FilterForm
    {
        /// <summary>
        /// Кнопка "ОК".
        /// </summary>
        private Button _buttonAgree;

        /// <summary>
        /// GroupBox для критериев поиска.
        /// </summary>
        private GroupBox _groupBoxFilter;

        /// <summary>
        /// CheckBox для машины.
        /// </summary>
        private CheckBox _checkBoxFindCar;

        /// <summary>
        /// CheckBox для гибридной машины.
        /// </summary>
        private CheckBox _checkBoxFindHybridCar;

        /// <summary>
        /// CheckBox для вертолета.
        /// </summary>
        private CheckBox _checkBoxFindHelicopter;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            _buttonAgree = new Button();

            _checkBoxFindCar = new CheckBox();
            _checkBoxFindHybridCar = new CheckBox();
            _checkBoxFindHelicopter = new CheckBox();

            _groupBoxFilter = new GroupBox();

            // 
            // _buttonAgree
            // 
            _buttonAgree.BackColor = SystemColors.ButtonHighlight;
            _buttonAgree.ForeColor = SystemColors.ActiveCaptionText;
            _buttonAgree.Location = new Point(150, 250);
            _buttonAgree.Name = "_buttonAgree";
            _buttonAgree.Size = new Size(100, 30);
            _buttonAgree.TabIndex = 0;
            _buttonAgree.Text = "ОК";
            _buttonAgree.UseVisualStyleBackColor = false;
            // 
            // _checkBoxFindCar
            // 
            _checkBoxFindCar.Text = "Машина";
            _checkBoxFindCar.AutoSize = true;
            _checkBoxFindCar.Location = new System.Drawing.Point(20, 30);
            // 
            // _checkBoxFindHybridCar
            // 
            _checkBoxFindHybridCar.Text = "Гибридная машина";
            _checkBoxFindHybridCar.AutoSize = true;
            _checkBoxFindHybridCar.Location = new System.Drawing.Point(20, 60);
            // 
            // _checkBoxFindHelicopter
            // 
            _checkBoxFindHelicopter.Text = "Вертолет";
            _checkBoxFindHelicopter.AutoSize = true;
            _checkBoxFindHelicopter.Location = new System.Drawing.Point(20, 90);
            // 
            // _groupBoxFilter
            // 
            _groupBoxFilter.Location = new Point(30, 30);
            _groupBoxFilter.Name = "_groupBoxFilter";
            _groupBoxFilter.Size = new Size(180, 120);
            _groupBoxFilter.TabIndex = 0;
            _groupBoxFilter.TabStop = false;
            _groupBoxFilter.Text = "Поиск по типу транспорта";
            _groupBoxFilter.Controls.Add(_checkBoxFindCar);
            _groupBoxFilter.Controls.Add(_checkBoxFindHybridCar);
            _groupBoxFilter.Controls.Add(_checkBoxFindHelicopter);

            // 
            // FindForm
            // 
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(300, 300);
            Text = "Поиск";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Controls.Add(_groupBoxFilter);
            Controls.Add(_buttonAgree);
        }

        #endregion
    }
}