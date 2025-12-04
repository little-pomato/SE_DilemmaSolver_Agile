namespace DilemmaSolver
{
    partial class Mode2_SpinWheelScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.spinWheelControl1 = new DilemmaSolver.SpinWheelControl();
            this.btnSpin = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(83, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "清單：-";
            // 
            // SpinwheelControl1
            // 
            this.spinWheelControl1.Location = new System.Drawing.Point(40, 60);
            this.spinWheelControl1.Name = "spinWheelControl1";
            this.spinWheelControl1.Size = new System.Drawing.Size(260, 260);
            this.spinWheelControl1.TabIndex = 1;
            // 
            // btnSpin
            // 
            this.btnSpin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSpin.Location = new System.Drawing.Point(320, 140);
            this.btnSpin.Name = "btnSpin";
            this.btnSpin.Size = new System.Drawing.Size(120, 40);
            this.btnSpin.TabIndex = 2;
            this.btnSpin.Text = "Spin / 旋轉";
            this.btnSpin.UseVisualStyleBackColor = true;
            this.btnSpin.Click += new System.EventHandler(this.btnSpin_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(20, 320);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 30);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Mode2_SpinWheelScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSpin);
            this.Controls.Add(this.spinWheelControl1);
            this.Controls.Add(this.lblTitle);
            this.Name = "Mode2_SpinWheelScreen";
            this.Size = new System.Drawing.Size(470, 370);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion  
        private System.Windows.Forms.Label lblTitle;
        private DilemmaSolver.SpinWheelControl spinWheelControl1;
        private System.Windows.Forms.Button btnSpin;
        private System.Windows.Forms.Button btnBack;

    }
}
