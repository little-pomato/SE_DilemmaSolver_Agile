namespace DilemmaSolver
{
    partial class Mode2_DiceScreen
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
            this.lblDice = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnRoll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDice
            // 
            this.lblDice.BackColor = System.Drawing.Color.LightSeaGreen;
            this.lblDice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDice.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.lblDice.ForeColor = System.Drawing.Color.White;
            this.lblDice.Location = new System.Drawing.Point(80, 40);
            this.lblDice.Name = "lblDice";
            this.lblDice.Size = new System.Drawing.Size(160, 160);
            this.lblDice.TabIndex = 0;
            this.lblDice.Text = "-";
            this.lblDice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(270, 105);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(96, 30);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total: -";
            // 
            // btnRoll
            // 
            this.btnRoll.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRoll.Location = new System.Drawing.Point(140, 230);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(120, 40);
            this.btnRoll.TabIndex = 2;
            this.btnRoll.Text = "Roll / 擲骰子";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // Mode2_DiceScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRoll);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblDice);
            this.Name = "Mode2_DiceScreen";
            this.Size = new System.Drawing.Size(400, 320);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion  
        private System.Windows.Forms.Label lblDice;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnRoll;

    }
}
