using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DilemmaSolver
{
    public partial class MainPage: UserControl
    {
        public event Action Switch_to_Mode1;
        public event Action Switch_to_Mode2;
        
        public MainPage()
        {
            InitializeComponent();

            string imagePath = Path.Combine(Application.StartupPath, "Images", "Choose_mode.jpg");

            this.BackgroundImage = Image.FromFile(imagePath);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Switch_to_Mode1?.Invoke();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Switch_to_Mode2?.Invoke();
        }
    }
}
