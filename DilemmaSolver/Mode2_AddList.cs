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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DilemmaSolver
{
    public partial class Mode2_AddList: UserControl
    {
        public event Action<string, List<string>> Switch_to_ChooseRandom;
        public event Action Switch_to_MainPage;
        private string filePath = Path.GetFullPath(
            Path.Combine(Application.StartupPath, @"..\..\list.txt")
        );

        public Mode2_AddList()
        {
            InitializeComponent();
            //string filePath = "D:\\下載(C)\\SE_DilemmaSolver-Mode1_waterfall\\DilemmaSolver\\list.txt";
            LoadTreeViewFromTextFile(filePath);

            string imagePath = Path.Combine(Application.StartupPath, "Images", "Add_list.jpg");

            this.BackgroundImage = Image.FromFile(imagePath);
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // 顯示調整
            treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            treeView1.DrawNode += treeView1_DrawNode;
            treeView1.ItemHeight = 28;
            
        }

        public enum TreeEditResult
        {
            Success,
            NoInput,
            NoSelection,
            NotCategory,
            LastCategoryCannotDelete
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Switch_to_MainPage?.Invoke();
        }

        private void Mode2_AddList_Load(object sender, EventArgs e)
        {
            //string filePath = "D:\\下載(C)\\SE_DilemmaSolver-Mode1_waterfall\\DilemmaSolver\\list.txt";
            LoadTreeViewFromTextFile(filePath);

            // AfterSelect 事件綁定 (+=)
        }

        private void LoadTreeViewFromTextFile(string filePath)
        {
            treeView1.Nodes.Clear();

            try
            {
                // 一次性讀取所有行
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string trimmedLine = line.Trim();

                    // 忽略空白行
                    if (string.IsNullOrWhiteSpace(trimmedLine))
                    {
                        continue;
                    }

                    char[] delimiters = new char[] { ' ' };

                    string[] parts = trimmedLine.Split(
                        delimiters,
                        StringSplitOptions.RemoveEmptyEntries // 忽略因多個連續空白產生的空字串
                    );

                    // 確保至少有一個項目 (種類)
                    if (parts.Length < 1)
                    {
                        continue;
                    }

                    // 第0項是種類
                    string parentText = parts[0];
                    TreeNode parentNode = new TreeNode(parentText);
                    treeView1.Nodes.Add(parentNode);

                    // 處理剩餘的項目 (選項1, 選項2, ...)
                    for (int i = 1; i < parts.Length; i++)
                    {
                        string childText = parts[i];
                        parentNode.Nodes.Add(new TreeNode(childText));
                    }
                }

                // 展開所有節點
                //treeView1.ExpandAll();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"錯誤：找不到檔案 {filePath}", "檔案錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"讀取檔案時發生錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveTreeViewToTextFile()
        {
            List<string> lines = new List<string>();

            foreach (TreeNode parent in treeView1.Nodes)
            {
                List<string> parts = new List<string>();
                parts.Add(parent.Text);

                foreach (TreeNode child in parent.Nodes)
                {
                    parts.Add(child.Text);
                }

                lines.Add(string.Join(" ", parts));
            }

            File.WriteAllLines(filePath, lines);
        }

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            bool isParent = (e.Node.Parent == null);

            // 字體
            Font nodeFont = isParent
                ? new Font("微軟正黑體", 10, FontStyle.Bold)
                : new Font("微軟正黑體", 9, FontStyle.Regular);

            Color textColor = isParent ? Color.DarkBlue : Color.Black;

            // 留白
            Rectangle nodeBounds = e.Bounds;
            nodeBounds.Width += 4; // 加寬

            // 文字
            TextRenderer.DrawText(
                e.Graphics,
                e.Node.Text,
                nodeFont,
                nodeBounds,
                textColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );

            e.DrawDefault = false; // 關預設
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 是否有選中
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("請先選取一個類別！");
                return;
            }

            TreeNode selected = treeView1.SelectedNode;

            // 確保選到的是類別
            if (selected.Parent != null)
            {
                MessageBox.Show("請選取一個類別，而不是項目！");
                return;
            }

            // 類別裡沒有任何項目
            if (selected.Nodes.Count == 0)
            {
                MessageBox.Show("此清單尚未新增任何項目，請選擇有項目的清單！");
                return;
            }

            // 收集子項
            List<string> items = new List<string>();
            foreach (TreeNode child in selected.Nodes)
            {
                items.Add(child.Text);
            }

            string selectedText = selected.Text;
            Switch_to_ChooseRandom?.Invoke(selectedText, items);
        }

        private TreeEditResult TryAddCategory(string rawText)
        {
            if (string.IsNullOrWhiteSpace(rawText))
                return TreeEditResult.NoInput;

            treeView1.Nodes.Add(new TreeNode(rawText.Trim()));
            SaveTreeViewToTextFile();

            return TreeEditResult.Success;
        }

        // 新增種類
        private void button2_Click(object sender, EventArgs e)
        {
            var result = TryAddCategory(textBox1.Text);

            if (result == TreeEditResult.NoInput)
            {
                MessageBox.Show("請輸入種類名稱！");
                return;
            }

            textBox1.Clear();
            treeView1.CollapseAll();
        }

        private TreeEditResult TryAddItem(string rawText, out TreeNode newNode)
        {
            newNode = null;

            if (treeView1.SelectedNode == null)
                return TreeEditResult.NoSelection;

            TreeNode parent = treeView1.SelectedNode;

            if (parent.Parent != null)
                return TreeEditResult.NotCategory;

            if (string.IsNullOrWhiteSpace(rawText))
                return TreeEditResult.NoInput;

            newNode = new TreeNode(rawText.Trim());
            parent.Nodes.Add(newNode);

            SaveTreeViewToTextFile();
            return TreeEditResult.Success;
        }

        // 新增選項
        private void button3_Click(object sender, EventArgs e)
        {
            var result = TryAddItem(textBox1.Text, out TreeNode newNode);

            switch (result)
            {
                case TreeEditResult.NoSelection:
                    MessageBox.Show("請先選取一個種類！");
                    break;

                case TreeEditResult.NotCategory:
                    MessageBox.Show("請選取種類而不是選項！");
                    break;

                case TreeEditResult.NoInput:
                    MessageBox.Show("請輸入選項名稱！");
                    break;

                case TreeEditResult.Success:
                    textBox1.Clear();
                    treeView1.CollapseAll();
                    newNode.Parent.Expand();
                    break;
            }
        }

        private TreeEditResult TryDeleteSelectedNode(out TreeNode parentNode)
        {
            parentNode = null;

            if (treeView1.SelectedNode == null)
                return TreeEditResult.NoSelection;

            TreeNode node = treeView1.SelectedNode;

            if (node.Parent == null)
            {
                if (treeView1.Nodes.Count == 1)
                    return TreeEditResult.LastCategoryCannotDelete;

                node.Remove();
            }
            else
            {
                parentNode = node.Parent;
                node.Remove();
            }

            SaveTreeViewToTextFile();
            return TreeEditResult.Success;
        }

        // 刪除
        private void button6_Click(object sender, EventArgs e)
        {
            var result = TryDeleteSelectedNode(out TreeNode parent);

            switch (result)
            {
                case TreeEditResult.NoSelection:
                    MessageBox.Show("請選取要刪除的項目！");
                    break;

                case TreeEditResult.LastCategoryCannotDelete:
                    MessageBox.Show("至少需要保留一個類別！");
                    break;

                case TreeEditResult.Success:
                    treeView1.CollapseAll();
                    parent?.Expand();
                    break;
            }
        }

        private TreeEditResult TryRenameSelectedNode(string rawText, out TreeNode node)
        {
            node = null;

            if (treeView1.SelectedNode == null)
                return TreeEditResult.NoSelection;

            if (string.IsNullOrWhiteSpace(rawText))
                return TreeEditResult.NoInput;

            node = treeView1.SelectedNode;
            node.Text = rawText.Trim();

            SaveTreeViewToTextFile();
            return TreeEditResult.Success;
        }

        // 修改
        private void button8_Click(object sender, EventArgs e)
        {
            var result = TryRenameSelectedNode(textBox1.Text, out TreeNode node);

            switch (result)
            {
                case TreeEditResult.NoSelection:
                    MessageBox.Show("請先選取要修改的項目！");
                    break;

                case TreeEditResult.NoInput:
                    MessageBox.Show("請輸入新名稱！");
                    break;

                case TreeEditResult.Success:
                    textBox1.Clear();
                    treeView1.CollapseAll();
                    node.Parent?.Expand();
                    break;
            }
        }
    }
}
