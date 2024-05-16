using System.Data;
using System.Windows.Forms;

namespace View
{
    partial class BasicForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox = new GroupBox();
            gridControl = new DataGridView();
            addTransportButton = new Button();
            removeTransportButton = new Button();
            SuspendLayout();
            // 
            // gridControl
            // 
            gridControl.BackgroundColor = SystemColors.ButtonHighlight;
            gridControl.Name = "gridControl";
            gridControl.Dock = DockStyle.Fill;
            gridControl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridControl.DefaultCellStyle.ForeColor = Color.Black;
            gridControl.Columns.Add("TypeTransport", "Вид транспорта");
            gridControl.Columns.Add("Distance", "Расстояние");
            gridControl.Columns.Add("FuelConsumption", "Расход топлива");
            // 
            // addTransportButton
            // 
            addTransportButton.BackColor = SystemColors.ButtonHighlight;
            addTransportButton.ForeColor = SystemColors.ActiveCaptionText;
            addTransportButton.Location = new Point(525, 390);
            addTransportButton.Name = "addTransportButton";
            addTransportButton.Size = new Size(100, 30);
            addTransportButton.TabIndex = 1;
            addTransportButton.Text = "Добавить";
            addTransportButton.UseVisualStyleBackColor = false;
            addTransportButton.Click += addTransportButtonClick;
            // 
            // removeTransportButton
            // 
            removeTransportButton.BackColor = SystemColors.ButtonHighlight;
            removeTransportButton.ForeColor = SystemColors.ActiveCaptionText;
            removeTransportButton.Location = new Point(650, 390);
            removeTransportButton.Name = "removeTransportButton";
            removeTransportButton.Size = new Size(100, 30);
            removeTransportButton.TabIndex = 2;
            removeTransportButton.Text = "Удалить";
            removeTransportButton.UseVisualStyleBackColor = false;
            removeTransportButton.Click += removeTransportButtonClick;
            // 
            // groupBox
            // 
            groupBox.Location = new Point(50, 10);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(700, 350);
            groupBox.TabIndex = 0;
            groupBox.TabStop = false;
            groupBox.Text = "Список транспорта";
            groupBox.Controls.Add(gridControl);
            // 
            // BasicForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox);
            Controls.Add(addTransportButton);
            Controls.Add(removeTransportButton);
            ForeColor = Color.Bisque;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "BasicForm";
        }

        private void addTransportButtonClick(object sender, EventArgs e)
        {
            DataForm DataForm = new DataForm();
            DataForm.Show();
        }

        private void removeTransportButtonClick(object sender, EventArgs e)
        {
            if (gridControl.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = gridControl.SelectedRows[0];

                gridControl.Rows.Remove(selectedRow);
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
    }
}
