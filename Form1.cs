using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimpleMDIExample
{
    public partial class Form1 : Form
    {

        public Form2 selectedForm2;
        //Panel panel1;

        public Form1()
        {

            InitializeComponent();


            // 创建新的选项
            ToolStripMenuItem option1 = new ToolStripMenuItem("新建");
            option1.Click += toolStripButton5_Click;
            ToolStripMenuItem option2 = new ToolStripMenuItem("打开文件");
            option2.Click += toolStripButton4_Click;
            ToolStripMenuItem option3 = new ToolStripMenuItem("保存文件");
            option3.Click += toolStripButton3_Click;
            // 将选项添加到按钮的下拉菜单
            toolStripDropDownButton1.DropDownItems.Add(option1);
            toolStripDropDownButton1.DropDownItems.Add(option2);
            toolStripDropDownButton1.DropDownItems.Add(option3);

            /*
            panel1 = new Panel();
            panel1.Padding = new Padding(0, toolStrip2.Height, 0, 0);
            panel1.Dock = DockStyle.Fill;  // 设置Panel填充Form1除工具栏以外的部分
            this.Controls.Add(panel1);  // 将Panel添加到Form1
            */
        }
        private void init()
        {
            // 添加字体类型到ToolStripComboBox
            foreach (FontFamily font in FontFamily.Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            // 当选中的字体类型发生更改时，设置选中文本的字体
            toolStripComboBox1.SelectedIndexChanged += (sender, e) =>
            {
                // 获取用户选择的字体类型
                string selectedFontFamily = toolStripComboBox1.SelectedItem.ToString();

                // 获取选中的文本的字体大小和样式
                float fontSize = selectedForm2.yourTextBox.SelectionFont.Size;
                FontStyle fontStyle = selectedForm2.yourTextBox.SelectionFont.Style;

                // 设置选中文本的字体
                selectedForm2.yourTextBox.SelectionFont = new Font(selectedFontFamily, fontSize, fontStyle);
            };
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.MdiParent = this;  // 设置Form2的MDI父窗口为Form1
            //newForm.Dock = DockStyle.Fill;
            newForm.Activated += (s, e) =>
            {
                this.selectedForm2 = newForm;
                toolStripTextBox1.Text = "";
            };
            this.selectedForm2 = newForm;
            /*
            newForm.TopLevel = false;  // 设置TopLevel属性为false，这样Form2就可以被添加到Panel中
            this.panel1.Controls.Add(newForm);  // 将Form2添加到Panel中
            */
            newForm.Show();
            newForm.isCreated = true;
            if (selectedForm2 == null)
            {
                return;
            }
            if (selectedForm2.filePath != "")
            {
                return;
            }
            // 创建OpenFileDialog控件
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt文件(*.txt)|*.txt|RTF文件(*.rtf)|*.rtf"; // 设置文件类型过滤器为.txt文件
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 读取并显示文件内容
                selectedForm2.filePath = openFileDialog.FileName;
                selectedForm2.Text += selectedForm2.filePath;
                //string fileContent = File.ReadAllText(selectedForm2.filePath);

                // 创建并配置TextBox
                selectedForm2.yourTextBox.Multiline = true; // 设置为多行模式
                selectedForm2.yourTextBox.ScrollBars = RichTextBoxScrollBars.Both; // 启用滚动条
                selectedForm2.yourTextBox.WordWrap = true; // 启用自动换行
                selectedForm2.yourTextBox.Dock = DockStyle.Fill; // 设置为填充模式
                selectedForm2.yourTextBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);// 将文件内容加载到TextBox控件中

                // 创建一个新的上下文菜单
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                // 添加菜单项
                ToolStripMenuItem menuItem1 = new ToolStripMenuItem("复制");
                ToolStripMenuItem menuItem2 = new ToolStripMenuItem("粘贴");
                ToolStripMenuItem menuItem3 = new ToolStripMenuItem("剪切");
                ToolStripMenuItem menuItem4 = new ToolStripMenuItem("粘贴");
                ToolStripMenuItem menuItem5 = new ToolStripMenuItem("粘贴");
                contextMenu.Items.Add(menuItem1);
                contextMenu.Items.Add(menuItem2);
                contextMenu.Items.Add(menuItem3);
                contextMenu.Items.Add(menuItem4);
                contextMenu.Items.Add(menuItem5);
                // 为菜单项添加点击事件处理器
                menuItem1.Click += (s, e) =>
                {
                    // 在这里处理选项1的点击事件
                    if (selectedForm2.yourTextBox.SelectionLength > 0)
                        selectedForm2.yourTextBox.Copy();
                };
                menuItem2.Click += (s, e) =>
                {
                    // 在这里处理选项2的点击事件
                    if (Clipboard.ContainsText())
                    {
                        selectedForm2.yourTextBox.Paste();
                    }
                };
                menuItem3.Click += (s, e) =>
                {
                    // 在这里处理选项3的点击事件
                    if (selectedForm2.yourTextBox.SelectedText != "")
                    {
                        selectedForm2.yourTextBox.Cut();
                    }
                };
                menuItem4.Click += (s, e) =>
                {
                    // 在这里处理选项4的点击事件
                };
                menuItem5.Click += (s, e) =>
                {
                    // 在这里处理选项5的点击事件
                };
                // 将上下文菜单设置为RichTextBox的上下文菜单
                selectedForm2.yourTextBox.ContextMenuStrip = contextMenu;

                selectedForm2.yourTextBox.TextChanged += (s, e) =>
                {
                    toolStripTextBox1.Text = "";
                };
                selectedForm2.yourTextBox.SelectionStart = selectedForm2.yourTextBox.Text.Length; // 将输入光标定位到文本的最末端
                selectedForm2.yourTextBox.SelectionChanged += (sender, e) =>
                {

                    // 你可以检查选中的文本是否已加粗，并根据结果更新按钮的状态
                    Font currentFont = selectedForm2.yourTextBox.SelectionFont;
                    bool isBold = currentFont != null && currentFont.Bold;
                    toolStripButton7.Checked = isBold;
                    bool isItalic = currentFont != null && currentFont.Italic;
                    toolStripButton8.Checked = isItalic;
                    bool isUnderline = currentFont != null && currentFont.Underline;
                    toolStripButton9.Checked = isUnderline;
                    Font selectedTextFont = selectedForm2.yourTextBox.SelectionFont;
                    if (selectedTextFont != null)
                    {
                        toolStripComboBox1.Text = selectedTextFont.Name;
                    }
                };
                // 将TextBox添加到窗口中
                selectedForm2.Controls.Add(selectedForm2.yourTextBox);
                selectedForm2.yourTextBox.BringToFront(); // 将TextBox置于顶层
            }
            init();
            selectedForm2.isCreated = true;
        }


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (selectedForm2 == null)
            {
                return;
            }
            if (!selectedForm2.isCreated)
            {
                return;
            }
            if (selectedForm2.filePath == "")
            {
                // 创建SaveFileDialog控件
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "文本文件|*.txt|RTF文件|*.rtf"; // 设置文件类型过滤器为.txt文件
                string filePath="";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    filePath = saveFileDialog.FileName;
                    if (Path.GetExtension(filePath).ToLower() == ".rtf")
                    {
                        selectedForm2.yourTextBox.SaveFile(filePath, RichTextBoxStreamType.RichText);
                    }
                    else if (Path.GetExtension(filePath).ToLower() == ".txt")
                    {
                        selectedForm2.yourTextBox.SaveFile(filePath, RichTextBoxStreamType.PlainText);
                    }
                }
                selectedForm2.Text = filePath;
            }
            else
            {


                if (Path.GetExtension(selectedForm2.filePath).ToLower() == ".rtf")
                {
                    selectedForm2.yourTextBox.SaveFile(selectedForm2.filePath, RichTextBoxStreamType.RichText);
                }
                else if (Path.GetExtension(selectedForm2.filePath).ToLower() == ".txt")
                {
                    selectedForm2.yourTextBox.SaveFile(selectedForm2.filePath, RichTextBoxStreamType.PlainText);
                }
            }

            toolStripTextBox1.Text = "已保存";
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.MdiParent = this;  // 设置Form2的MDI父窗口为Form1
            //newForm.Dock = DockStyle.Fill;
            newForm.Activated += (s, e) =>
            {
                this.selectedForm2 = newForm;
                toolStripTextBox1.Text = "";
            };
            this.selectedForm2 = newForm;
            /*
            newForm.TopLevel = false;  // 设置TopLevel属性为false，这样Form2就可以被添加到Panel中
            this.panel1.Controls.Add(newForm);  // 将Form2添加到Panel中
            */
            newForm.Show();
            newForm.isCreated = true;
            if (selectedForm2.filePath != "")
            {
                return;
            }
            // 创建并配置TextBox
            selectedForm2.yourTextBox = new RichTextBox();
            selectedForm2.yourTextBox.Multiline = true; // 设置为多行模式
            selectedForm2.yourTextBox.ScrollBars = RichTextBoxScrollBars.Both; // 启用滚动条
            selectedForm2.yourTextBox.WordWrap = true; // 启用自动换行
            selectedForm2.yourTextBox.Dock = DockStyle.Fill; // 设置为填充模式
            selectedForm2.yourTextBox.Text = ""; // 将文件内容加载到TextBox控件中
            selectedForm2.yourTextBox.TextChanged += (s, e) =>
            {
                toolStripTextBox1.Text = "";
            };
            selectedForm2.yourTextBox.SelectionStart = selectedForm2.yourTextBox.Text.Length; // 将输入光标定位到文本的最末端
            selectedForm2.yourTextBox.SelectionChanged += (sender, e) =>
            {
                // 在这里添加你的代码
                // 例如，你可以检查选中的文本是否已加粗，并根据结果更新按钮的状态
                Font currentFont = selectedForm2.yourTextBox.SelectionFont;
                bool isBold = currentFont != null && currentFont.Bold;
                toolStripButton7.Checked = isBold;
                bool isItalic = currentFont != null && currentFont.Italic;
                toolStripButton8.Checked = isItalic;
                bool isUnderline = currentFont != null && currentFont.Underline;
                toolStripButton9.Checked = isUnderline;
                Font selectedTextFont = selectedForm2.yourTextBox.SelectionFont;
                if (selectedTextFont != null)
                {
                    toolStripComboBox1.Text = selectedTextFont.Name;
                }
            };

            // 将TextBox添加到窗口中
            selectedForm2.Controls.Add(selectedForm2.yourTextBox);
            selectedForm2.yourTextBox.BringToFront(); // 将TextBox置于顶层
            init();
            selectedForm2.isCreated = true;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (selectedForm2 == null)
            {
                return;
            }
            if (!selectedForm2.isCreated)
            {
                return;
            }
            // 获取选中的文本
            string selectedText = selectedForm2.yourTextBox.SelectedText;

            // 如果有选中的文本
            if (!string.IsNullOrEmpty(selectedText))
            {
                // 获取选中的文本的字体
                Font currentFont = selectedForm2.yourTextBox.SelectionFont;
                // 如果currentFont为null，那么创建一个新的Font对象作为默认字体
                if (currentFont == null)
                {
                    currentFont = new Font("Arial", 10, FontStyle.Regular);
                }
                // 判断选中的文本是否已加粗
                bool isBold = currentFont != null && currentFont.Bold;

                // 如果选中的文本已加粗，则取消加粗；否则，加粗

                FontStyle newFontStyle;
                if (isBold)
                {
                    newFontStyle = currentFont.Style & ~FontStyle.Bold;
                }
                else
                {
                    newFontStyle = currentFont.Style | FontStyle.Bold;
                }
                Font newFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);

                toolStripButton7.Checked = !isBold; // 切换按钮的选中状态

                // 设置选中文本的字体
                selectedForm2.yourTextBox.SelectionFont = newFont;
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (selectedForm2 == null)
            {
                return;
            }
            if (selectedForm2 == null)
            {
                return;
            }
            if (!selectedForm2.isCreated)
            {
                return;
            }
            // 获取选中的文本的字体
            Font currentFont = selectedForm2.yourTextBox.SelectionFont;

            // 判断选中的文本是否已倾斜
            bool isItalic = currentFont != null && currentFont.Italic;
            // 如果currentFont为null，那么创建一个新的Font对象作为默认字体
            if (currentFont == null)
            {
                currentFont = new Font("Arial", 10, FontStyle.Regular);
            }
            // 如果选中的文本已倾斜，则取消倾斜；否则，倾斜
            FontStyle newFontStyle;
            if (isItalic)
            {
                newFontStyle = currentFont.Style & ~FontStyle.Italic;
            }
            else
            {
                newFontStyle = currentFont.Style | FontStyle.Italic;
            }
            Font newFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);

            toolStripButton8.Checked = !isItalic; // 切换按钮的选中状态

            // 设置选中文本的字体
            selectedForm2.yourTextBox.SelectionFont = newFont;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (selectedForm2 == null)
            {
                return;
            }
            if (!selectedForm2.isCreated)
            {
                return;
            }
            // 获取选中的文本的字体
            Font currentFont = selectedForm2.yourTextBox.SelectionFont;
            // 如果currentFont为null，那么创建一个新的Font对象作为默认字体
            if (currentFont == null)
            {
                currentFont = new Font("Arial", 10, FontStyle.Regular);
            }
            // 判断选中的文本是否已下划线
            bool isUnderline = currentFont != null && currentFont.Underline;

            // 如果选中的文本已下划线，则取消下划线；否则，下划线
            FontStyle newFontStyle;
            if (isUnderline)
            {
                newFontStyle = currentFont.Style & ~FontStyle.Underline;
            }
            else
            {
                newFontStyle = currentFont.Style | FontStyle.Underline;
            }
            Font newFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);

            toolStripButton9.Checked = !isUnderline;// 切换按钮的选中状态

            // 设置选中文本的字体
            selectedForm2.yourTextBox.SelectionFont = newFont;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                // 获取用户选择的字体
                Font selectedFont = fontDialog.Font;

                // 设置选中文本的字体
                selectedForm2.yourTextBox.SelectionFont = selectedFont;
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {


        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void 新窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.MdiParent = this;  // 设置Form2的MDI父窗口为Form1
            //newForm.Dock = DockStyle.Fill;
            newForm.Activated += (s, e) =>
            {
                this.selectedForm2 = newForm;
                toolStripTextBox1.Text = "";
            };
            this.selectedForm2 = newForm;
            /*
            newForm.TopLevel = false;  // 设置TopLevel属性为false，这样Form2就可以被添加到Panel中
            this.panel1.Controls.Add(newForm);  // 将Form2添加到Panel中
            */
            newForm.Show();
            newForm.isCreated = true;
        }

        private void 排列方式ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 水平ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 水平排列
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 竖直ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 竖直排列
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        private void 水平ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // 水平排列
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 竖直ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // 竖直排列
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            if (selectedForm2 == null)
            {
                return;
            }
            if (!selectedForm2.isCreated)
            {
                return;
            }
            // 设置选中文本为左对齐
            selectedForm2.yourTextBox.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButton6_Click_1(object sender, EventArgs e)
        {
            if (selectedForm2 == null)
            {
                return;
            }
            if (!selectedForm2.isCreated)
            {
                return;
            }
            // 设置选中文本为居中对齐
            selectedForm2.yourTextBox.SelectionAlignment = HorizontalAlignment.Center;

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (selectedForm2 == null)
            {
                return;
            }
            if (!selectedForm2.isCreated)
            {
                return;
            }
            // 设置选中文本为右对齐
            selectedForm2.yourTextBox.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {

            if (selectedForm2.yourTextBox.SelectedText != "")
            {
                selectedForm2.yourTextBox.Cut();
            }
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {

            if (selectedForm2.yourTextBox.SelectionLength > 0)
                selectedForm2.yourTextBox.Copy();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {

            if (Clipboard.ContainsText())
            {
                selectedForm2.yourTextBox.Paste();
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            if (selectedForm2 == null)
            {
                return;
            }
            if (!selectedForm2.isCreated)
            {
                return;
            }
            // 撤回操作
            if (selectedForm2.yourTextBox.CanUndo)
            {
                selectedForm2.yourTextBox.Undo();
            }
        }

        private void toolStripButton10_Click_1(object sender, EventArgs e)
        {
            if (selectedForm2 == null)
            {
                return;
            }
            if (!selectedForm2.isCreated)
            {
                return;
            }
            // 恢复操作
            if (selectedForm2.yourTextBox.CanRedo)
            {
                selectedForm2.yourTextBox.Redo();
            }
        }
    }
}
