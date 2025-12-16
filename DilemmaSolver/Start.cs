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
    public partial class Start : UserControl
    {
        //事件：切換到MainPage
        public event Action Switch_to_MainPage;


        public Start()
        {
            InitializeComponent();

            string imagePath = Path.Combine(Application.StartupPath, "Images", "Start.jpg");

            this.BackgroundImage = Image.FromFile(imagePath);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Start_MouseClick(object sender, MouseEventArgs e)
        {
            Switch_to_MainPage?.Invoke();
        }
    }
}
