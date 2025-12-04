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
    public partial class Mode2_ChooseRandom: UserControl
    {
        private string listName;             // The list that be selected
        private List<string> itemList;           // Items of the list

        // default
        public Mode2_ChooseRandom()
        {
            InitializeComponent();
        }

        // selected list and its items
        public Mode2_ChooseRandom(string selectedList, List<string> selectedItems)
        {
            InitializeComponent();

            listName = selectedList;
            itemList = selectedItems;

            // drawing style
            treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            treeView1.DrawNode += treeView1_DrawNode;
            treeView1.ItemHeight = 28;

            DisplayListItems();
        }

        // displays the selected list and its items in the TreeView
        private void DisplayListItems()
        {
            treeView1.Nodes.Clear();

            TreeNode parentNode = new TreeNode(listName);
            treeView1.Nodes.Add(parentNode);

            foreach (var item in itemList)
            {
                parentNode.Nodes.Add(new TreeNode(item));
            }

            treeView1.ExpandAll();
        }

        // custom drawing
        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            bool isParent = (e.Node.Parent == null);

            Font nodeFont = isParent
                ? new Font("微軟正黑體", 10, FontStyle.Bold)
                : new Font("微軟正黑體", 9, FontStyle.Regular);

            Color textColor = isParent ? Color.DarkBlue : Color.Black;

            Rectangle nodeBounds = e.Bounds;
            nodeBounds.Width += 4;

            TextRenderer.DrawText(
                e.Graphics,
                e.Node.Text,
                nodeFont,
                nodeBounds,
                textColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );

            e.DrawDefault = false;
        }

        // Helper Function to change screens / 用於更換畫面的協助函式
        private void SwitchTo(UserControl next)
        {
            if (this.Parent == null) return;

            next.Dock = DockStyle.Fill;
            var parent = this.Parent;
            parent.Controls.Clear();
            parent.Controls.Add(next);
            next.BringToFront();
        }

        private void btnSpinWheel_Click(object sender, EventArgs e)
        {
            // to open Spin Wheel Screen 
            var wheelScreen = new Mode2_SpinWheelScreen(listName, itemList);
            SwitchTo(wheelScreen);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void btnDice_Click(object sender, EventArgs e)
        {
            // to open Dice Screen
            var diceScreen = new Mode2_DiceScreen(listName, itemList);
            SwitchTo(diceScreen);
        }

        private void btnCoin_Click(object sender, EventArgs e)
        {
            // to open Coin Screen
            var coinScreen = new Mode2_CoinScreen(listName, itemList);
            SwitchTo(coinScreen);
        }
    }
}
