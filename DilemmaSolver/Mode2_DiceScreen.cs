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
    public partial class Mode2_DiceScreen: UserControl
    {
        public event Action Switch_to_MainPage;
        public event Action Switch_to_ChooseRandom;

        private string _listName; // Variable to store the list name / 用於儲存列表名稱的變數
        private List<string> _items; // List of items / 項目列表
        private Random rng = new Random(); // Random number generator / 隨機數生成器
        private Dictionary<int, string> diceImages;
        private DiceEngine _engine = new DiceEngine();
        private int rollCount = 0; // track rolls

        public Mode2_DiceScreen()
        {
            InitializeComponent();

            lblDice.Text = "-"; // Initial text for dice label / 骰子標籤的初始文字
            lblTotal.Text = "Total: -"; // Initial text for total label / 總數標籤的初始文字
            btnRoll.Text = "Roll / 擲骰子";
            lblInfo.Text = "請擲骰子來決定";

            string imagePath = Path.Combine(Application.StartupPath, "Images", "Dice_screen.jpg");

            this.BackgroundImage = Image.FromFile(imagePath);
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // dice images mapping
            diceImages = new Dictionary<int, string>()
            {
                {1, Path.Combine(Application.StartupPath, "Images", "dice1.png")},
                {2, Path.Combine(Application.StartupPath, "Images", "dice2.png")},
                {3, Path.Combine(Application.StartupPath, "Images", "dice3.png")},
                {4, Path.Combine(Application.StartupPath, "Images", "dice4.png")},
                {5, Path.Combine(Application.StartupPath, "Images", "dice5.png")},
                {6, Path.Combine(Application.StartupPath, "Images", "dice6.png")}
            };

            picDice.Image = null; // reset dice image
        }

        public void SetData(string selectedList, List<string> selectedItems)
        {
            this._listName = selectedList;
            this._items = selectedItems;
            btnRoll.Enabled = true;
            lblDice.Text = "-"; // Initial text for dice label / 骰子標籤的初始文字
            lblTotal.Text = "Total: -"; // Initial text for total label / 總數標籤的初始文字
            btnRoll.Text = "Roll / 擲骰子";
            lblInfo.Text = "請擲骰子來決定";
            picDice.Image = null; // reset dice image
        }

        // FLIP ANIMATION
        private async Task PlayDiceFlipAnimation()
        {
            for (int i = 0; i < 10; i++)
            {
                int temp = rng.Next(1, 7);

                if (diceImages.ContainsKey(temp) && File.Exists(diceImages[temp]))
                {
                    using (var bmp = new Bitmap(diceImages[temp]))
                    {
                        picDice.Image = new Bitmap(bmp);
                    }
                }

                await Task.Delay(50);
            }
        }

        private async void btnRoll_Click(object sender, EventArgs e)
        {
            btnRoll.Enabled = false;

            // animation
            await PlayDiceFlipAnimation();

            // final result
            int dice = rng.Next(1, 7);
            string chosen = _engine.GetChosenItem(dice, _items);

            lblDice.Text = dice.ToString();
            lblTotal.Text = "Total: " + dice;

            if (diceImages.ContainsKey(dice) && File.Exists(diceImages[dice]))
            {
                using (var bmp = new Bitmap(diceImages[dice]))
                {
                    picDice.Image = new Bitmap(bmp);
                }
            }

            if (chosen != null)
            {
                lblInfo.Text = $"您的選擇是：\n【{chosen}】";
            }
            else
            {
                MessageBox.Show("清單項目不足以對應骰子結果！");
            }

            rollCount++;
            btnRoll.Text = _engine.GetButtonText(rollCount);

            btnRoll.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Switch_to_MainPage?.Invoke();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Switch_to_ChooseRandom?.Invoke();
        }
    }
}

public class DiceEngine
{
    // 1. 測試點數對應
    public string GetChosenItem(int diceValue, List<string> items)
    {
        int index = diceValue - 1;
        if (items != null && index >= 0 && index < items.Count)
        {
            return items[index];
        }
        return null;
    }

    // 2. 測試按鈕文字
    public string GetButtonText(int rollCount)
    {
        return rollCount >= 1 ? "Roll Again / 再擲一次" : "Roll / 擲骰子";
    }
}