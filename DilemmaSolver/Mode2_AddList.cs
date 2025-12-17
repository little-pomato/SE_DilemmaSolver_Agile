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

        // 新增種類
        private void button2_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("請輸入種類名稱！");
                return;
            }

            treeView1.Nodes.Add(new TreeNode(text));
            SaveTreeViewToTextFile();
            textBox1.Clear();

            // 規則：新增「類別」→ 全部收起
            treeView1.CollapseAll();
        }

        // 新增選項
        private void button3_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("請先選取一個種類！");
                return;
            }

            TreeNode parent = treeView1.SelectedNode;

            if (parent.Parent != null)
            {
                MessageBox.Show("請選取種類而不是選項！");
                return;
            }

            string text = textBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("請輸入選項名稱！");
                return;
            }

            parent.Nodes.Add(new TreeNode(text));
            SaveTreeViewToTextFile();
            textBox1.Clear();

            // 規則：新增「選項」→ 全部收回 → 只展開該類別
            treeView1.CollapseAll();
            parent.Expand();
        }

        // 刪除
        private void button6_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("請選取要刪除的項目！");
                return;
            }

            TreeNode node = treeView1.SelectedNode;

            // 如果是類別（parent == null）
            if (node.Parent == null)
            {
                // 只剩一個類別時不可刪
                if (treeView1.Nodes.Count == 1)
                {
                    MessageBox.Show("至少需要保留一個類別，無法刪除最後一個類別！");
                    return;
                }

                // 刪除類別
                node.Remove();
                SaveTreeViewToTextFile();

                // 規則：刪除「類別」→ 全部收起
                treeView1.CollapseAll();
            }
            else
            {
                // 刪除選項
                TreeNode parent = node.Parent;
                node.Remove();
                SaveTreeViewToTextFile();

                // 規則：刪除「選項」→ 全部收起 → 展開原本的類別
                treeView1.CollapseAll();
                parent.Expand();
            }
        }

        // 修改
        private void button8_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("請先選取要修改的項目！");
                return;
            }

            string newText = textBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(newText))
            {
                MessageBox.Show("請輸入新名稱！");
                return;
            }

            TreeNode node = treeView1.SelectedNode;

            node.Text = newText;
            SaveTreeViewToTextFile();
            textBox1.Clear();

            // 先收起全部
            treeView1.CollapseAll();

            if (node.Parent != null)
            {
                // 修改「選項」→ 展開父類別
                node.Parent.Expand();
            }

            //MessageBox.Show("已成功修改！");
        }
    }
}
