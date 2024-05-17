using System.Data;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Класс BasicForm.
    /// </summary>
    partial class BasicForm
    {
        /// <summary>
        ///  Необходимая переменная дизайнера.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Метод для явного освобождения ресурсов.
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
            // 
            // groupBoxTransport
            // 
            groupBoxTransport = new GroupBox();
            gridControlTransport = new DataGridView();
            buttonAddTransport = new Button();
            buttonRemoveTransport = new Button();
            //SuspendLayout();
            // 
            // gridControlTransport
            // 
            gridControlTransport.BackgroundColor = SystemColors.ButtonHighlight;
            gridControlTransport.Name = "gridControl";
            gridControlTransport.Dock = DockStyle.Fill;
            gridControlTransport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridControlTransport.DefaultCellStyle.ForeColor = Color.Black;
            //gridControlTransport.Columns.Add("TypeTransport", "Вид транспорта");
            //gridControlTransport.Columns.Add("Distance", "Расстояние");
            //gridControlTransport.Columns.Add("FuelConsumption", "Расход топлива");
            // 
            // buttonAddTransport
            // 
            buttonAddTransport.BackColor = SystemColors.ButtonHighlight;
            buttonAddTransport.ForeColor = SystemColors.ActiveCaptionText;
            buttonAddTransport.Location = new Point(525, 390);
            buttonAddTransport.Name = "addTransportButton";
            buttonAddTransport.Size = new Size(100, 30);
            buttonAddTransport.TabIndex = 1;
            buttonAddTransport.Text = "Добавить";
            buttonAddTransport.UseVisualStyleBackColor = false;
            // 
            // buttonRemoveTransport
            // 
            buttonRemoveTransport.BackColor = SystemColors.ButtonHighlight;
            buttonRemoveTransport.ForeColor = SystemColors.ActiveCaptionText;
            buttonRemoveTransport.Location = new Point(650, 390);
            buttonRemoveTransport.Name = "removeTransportButton";
            buttonRemoveTransport.Size = new Size(100, 30);
            buttonRemoveTransport.TabIndex = 2;
            buttonRemoveTransport.Text = "Удалить";
            buttonRemoveTransport.UseVisualStyleBackColor = false;
            // 
            // groupBoxTransport
            // 
            groupBoxTransport.Location = new Point(50, 10);
            groupBoxTransport.Name = "groupBox";
            groupBoxTransport.Size = new Size(700, 350);
            groupBoxTransport.TabIndex = 0;
            groupBoxTransport.TabStop = false;
            groupBoxTransport.Text = "Список транспорта";
            groupBoxTransport.Controls.Add(gridControlTransport);
            // 
            // BasicForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBoxTransport);
            Controls.Add(buttonAddTransport);
            Controls.Add(buttonRemoveTransport);
            ForeColor = Color.Bisque;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "BasicForm";
        }

        #endregion
    }
}
