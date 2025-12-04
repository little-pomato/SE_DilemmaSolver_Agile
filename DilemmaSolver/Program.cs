using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DilemmaSolver
{
    ////為了測試Mode2_AddList
    //public class TestAddListForm : Form
    //{
    //    public TestAddListForm()
    //    {
    //        this.Text = "Test Mode2_AddList";
    //        this.Width = 600;
    //        this.Height = 400;

    //        Mode2_AddList addList = new Mode2_AddList();
    //        addList.Dock = DockStyle.Fill;

    //        this.Controls.Add(addList);
    //    }

    //    private void InitializeComponent()
    //    {
    //        this.SuspendLayout();
    //        // 
    //        // TestAddListForm
    //        // 
    //        this.ClientSize = new System.Drawing.Size(278, 244);
    //        this.Name = "TestAddListForm";
    //        this.Load += new System.EventHandler(this.TestAddListForm_Load);
    //        this.ResumeLayout(false);

    //    }

    //    private void TestAddListForm_Load(object sender, EventArgs e)
    //    {

    //    }
    //}
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //Application.Run(new TestAddListForm()); // 為了測試Mode2_AddList
        }
    }
}
