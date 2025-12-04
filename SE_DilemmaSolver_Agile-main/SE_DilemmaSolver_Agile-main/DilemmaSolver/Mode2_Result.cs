using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DilemmaSolver
{
    public partial class Mode2_Result : UserControl
    {
        public Mode2_Result()
        {
            InitializeComponent();
        }

        public Mode2_Result(string listName, string toolName, string chosenItem)
            : this()
        {
            // kalau sudah punya label-label ini di Designer, pakai versi ini:
            // lblListName.Text = $"清單：{listName}";
            // lblTool.Text     = $"工具：{toolName}";
            // lblResult.Text   = $"結果：{chosenItem}";

            // versi aman (kalau label belum ada) – sementara pakai MessageBox:
            MessageBox.Show(
                $"List: {listName}\nTool: {toolName}\nResult: {chosenItem}",
                "Mode2 Result");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
