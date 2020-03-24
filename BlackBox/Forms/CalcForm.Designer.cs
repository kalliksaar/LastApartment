using System.ComponentModel;

namespace BlackBox.Forms
{
    partial class CalcForm
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
            this.OkBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.PopulationSlider = new System.Windows.Forms.TrackBar();
            this.PopulationTxtBox = new System.Windows.Forms.TextBox();
            this.PopulationLabel = new System.Windows.Forms.Label();
            this.OverstockLabel = new System.Windows.Forms.Label();
            this.OverStockValue = new System.Windows.Forms.Label();
            this.CalcBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PopulationSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // OkBtn
            // 
            this.OkBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkBtn.Location = new System.Drawing.Point(440, 224);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 1;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(330, 224);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 2;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // PopulationSlider
            // 
            this.PopulationSlider.Location = new System.Drawing.Point(51, 28);
            this.PopulationSlider.Maximum = 30000;
            this.PopulationSlider.Name = "PopulationSlider";
            this.PopulationSlider.Size = new System.Drawing.Size(486, 45);
            this.PopulationSlider.TabIndex = 4;
            this.PopulationSlider.TickFrequency = 500;
            this.PopulationSlider.Scroll += new System.EventHandler(this.PopolationSliderScroll);
            // 
            // PopulationTxtBox
            // 
            this.PopulationTxtBox.Location = new System.Drawing.Point(145, 79);
            this.PopulationTxtBox.Name = "PopulationTxtBox";
            this.PopulationTxtBox.Size = new System.Drawing.Size(129, 20);
            this.PopulationTxtBox.TabIndex = 5;
            // 
            // PopulationLabel
            // 
            this.PopulationLabel.AutoSize = true;
            this.PopulationLabel.Location = new System.Drawing.Point(73, 82);
            this.PopulationLabel.Name = "PopulationLabel";
            this.PopulationLabel.Size = new System.Drawing.Size(57, 13);
            this.PopulationLabel.TabIndex = 6;
            this.PopulationLabel.Text = "Population";
            // 
            // OverstockLabel
            // 
            this.OverstockLabel.AutoSize = true;
            this.OverstockLabel.Location = new System.Drawing.Point(73, 122);
            this.OverstockLabel.Name = "OverstockLabel";
            this.OverstockLabel.Size = new System.Drawing.Size(56, 13);
            this.OverstockLabel.TabIndex = 8;
            this.OverstockLabel.Text = "Overstock";
            // 
            // OverStockValue
            // 
            this.OverStockValue.AutoSize = true;
            this.OverStockValue.Location = new System.Drawing.Point(145, 122);
            this.OverStockValue.Name = "OverStockValue";
            this.OverStockValue.Size = new System.Drawing.Size(0, 13);
            this.OverStockValue.TabIndex = 9;
            // 
            // CalcBtn
            // 
            this.CalcBtn.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.CalcBtn.Location = new System.Drawing.Point(224, 224);
            this.CalcBtn.Name = "button1";
            this.CalcBtn.Size = new System.Drawing.Size(75, 23);
            this.CalcBtn.TabIndex = 10;
            this.CalcBtn.Text = "Calc";
            this.CalcBtn.UseVisualStyleBackColor = true;
            this.CalcBtn.Click += new System.EventHandler(this.CalcBtn_Click);
            // 
            // TestForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(572, 259);
            this.Controls.Add(this.CalcBtn);
            this.Controls.Add(this.OverStockValue);
            this.Controls.Add(this.OverstockLabel);
            this.Controls.Add(this.PopulationLabel);
            this.Controls.Add(this.PopulationTxtBox);
            this.Controls.Add(this.PopulationSlider);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OkBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestForm2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Overstock calculator";
            ((System.ComponentModel.ISupportInitialize)(this.PopulationSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TrackBar PopulationSlider;
        private System.Windows.Forms.TextBox PopulationTxtBox;
        private System.Windows.Forms.Label PopulationLabel;
        private System.Windows.Forms.Label OverstockLabel;
        private System.Windows.Forms.Label OverStockValue;
        private System.Windows.Forms.Button CalcBtn;


        #endregion

    }
}