namespace DilemmaSolver
{
    partial class Mode2_CoinScreen
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
            this.lblCoinText = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnFlip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCoinText
            // 
            this.lblCoinText.BackColor = System.Drawing.Color.LightSeaGreen;
            this.lblCoinText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCoinText.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblCoinText.ForeColor = System.Drawing.Color.White;
            this.lblCoinText.Location = new System.Drawing.Point(100, 40);
            this.lblCoinText.Name = "lblCoinText";
            this.lblCoinText.Size = new System.Drawing.Size(200, 200);
            this.lblCoinText.TabIndex = 0;
            this.lblCoinText.Text = "";
            this.lblCoinText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.lblInfo.Location = new System.Drawing.Point(180, 250);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(92, 21);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Result / 結果";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFlip
            // 
            this.btnFlip.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnFlip.Location = new System.Drawing.Point(150, 290);
            this.btnFlip.Name = "btnFlip";
            this.btnFlip.Size = new System.Drawing.Size(120, 40);
            this.btnFlip.TabIndex = 2;
            this.btnFlip.Text = "Flip / 擲硬幣";
            this.btnFlip.UseVisualStyleBackColor = true;
            this.btnFlip.Click += new System.EventHandler(this.btnFlip_Click);
            // 
            // Mode2_CoinScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFlip);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblCoinText);
            this.Name = "Mode2_CoinScreen";
            this.Size = new System.Drawing.Size(400, 360);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion 

        private System.Windows.Forms.Label lblCoinText;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnFlip;

    }
}
