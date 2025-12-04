namespace DilemmaSolver
{
    partial class Mode2_ChooseRandom
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSpinWheel = new System.Windows.Forms.Button();
            this.btnDice = new System.Windows.Forms.Button();
            this.btnCoin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Viner Hand ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(15, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 68);
            this.button1.TabIndex = 1;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(74, 110);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(277, 447);
            this.treeView1.TabIndex = 11;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 20F);
            this.label1.Location = new System.Drawing.Point(395, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 27);
            this.label1.TabIndex = 12;
            this.label1.Text = "請選擇隨機的方式";
            // 
            // btnSpinWheel
            // 
            this.btnSpinWheel.Font = new System.Drawing.Font("SimSun", 12F);
            this.btnSpinWheel.Location = new System.Drawing.Point(400, 191);
            this.btnSpinWheel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSpinWheel.Name = "btnSpinWheel";
            this.btnSpinWheel.Size = new System.Drawing.Size(101, 42);
            this.btnSpinWheel.TabIndex = 13;
            this.btnSpinWheel.Text = "轉盤";
            this.btnSpinWheel.UseVisualStyleBackColor = true;
            this.btnSpinWheel.Click += new System.EventHandler(this.btnSpinWheel_Click);
            // 
            // btnDice
            // 
            this.btnDice.Font = new System.Drawing.Font("SimSun", 12F);
            this.btnDice.Location = new System.Drawing.Point(533, 191);
            this.btnDice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDice.Name = "btnDice";
            this.btnDice.Size = new System.Drawing.Size(101, 42);
            this.btnDice.TabIndex = 14;
            this.btnDice.Text = "骰子";
            this.btnDice.UseVisualStyleBackColor = true;
            this.btnDice.Click += new System.EventHandler(this.btnDice_Click);
            // 
            // btnCoin
            // 
            this.btnCoin.Font = new System.Drawing.Font("SimSun", 12F);
            this.btnCoin.Location = new System.Drawing.Point(665, 191);
            this.btnCoin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCoin.Name = "btnCoin";
            this.btnCoin.Size = new System.Drawing.Size(101, 42);
            this.btnCoin.TabIndex = 15;
            this.btnCoin.Text = "硬幣";
            this.btnCoin.UseVisualStyleBackColor = true;
            this.btnCoin.Click += new System.EventHandler(this.btnCoin_Click);
            // 
            // Mode2_ChooseRandom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCoin);
            this.Controls.Add(this.btnDice);
            this.Controls.Add(this.btnSpinWheel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Mode2_ChooseRandom";
            this.Size = new System.Drawing.Size(1007, 514);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSpinWheel;
        private System.Windows.Forms.Button btnDice;
        private System.Windows.Forms.Button btnCoin;
    }
}
