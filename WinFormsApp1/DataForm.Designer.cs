using TransportLibrary;

namespace View
{
    partial class DataForm
    {
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
            agreeButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // agreeButton
            // 
            agreeButton.BackColor = SystemColors.ButtonHighlight;
            agreeButton.ForeColor = SystemColors.ActiveCaptionText;
            agreeButton.Location = new Point(225, 290);
            agreeButton.Name = "agreeButton";
            agreeButton.Size = new Size(100, 30);
            agreeButton.TabIndex = 1;
            agreeButton.Text = "Ок";
            agreeButton.UseVisualStyleBackColor = false;
            agreeButton.Click += agreeButtonClick;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(350, 290);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 30);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButtonClick;
            // 
            // DataForm
            // 
            FormBorderStyle = FormBorderStyle.FixedSingle;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(500, 350);
            Controls.Add(agreeButton);
            Controls.Add(cancelButton);
            Name = "DataForm";
            Text = "Ввод данных";
            ResumeLayout(false);
        }

        private void agreeButtonClick(object sender, EventArgs e)
        {
            Car transport1 = new Car();
            transport1.Mass = 10;
            
            Helicopter helicopter1 = new Helicopter();
            helicopter1.BladeLength = 18;

            BasicForm basicForm = Application.OpenForms.OfType<BasicForm>().FirstOrDefault();
            if (basicForm != null)
            {
                basicForm.gridControl.Rows.Add(transport1.Mass, helicopter1.BladeLength);
            }

            Close();
        }

        private void cancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }
    }
    #endregion
}