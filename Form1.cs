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


            // �����µ�ѡ��
            ToolStripMenuItem option1 = new ToolStripMenuItem("�½�");
            option1.Click += toolStripButton5_Click;
            ToolStripMenuItem option2 = new ToolStripMenuItem("���ļ�");
            option2.Click += toolStripButton4_Click;
            ToolStripMenuItem option3 = new ToolStripMenuItem("�����ļ�");
            option3.Click += toolStripButton3_Click;
            // ��ѡ����ӵ���ť�������˵�
            toolStripDropDownButton1.DropDownItems.Add(option1);
            toolStripDropDownButton1.DropDownItems.Add(option2);
            toolStripDropDownButton1.DropDownItems.Add(option3);

            /*
            panel1 = new Panel();
            panel1.Padding = new Padding(0, toolStrip2.Height, 0, 0);
            panel1.Dock = DockStyle.Fill;  // ����Panel���Form1������������Ĳ���
            this.Controls.Add(panel1);  // ��Panel��ӵ�Form1
            */
        }
        private void init()
        {
            // ����������͵�ToolStripComboBox
            foreach (FontFamily font in FontFamily.Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            // ��ѡ�е��������ͷ�������ʱ������ѡ���ı�������
            toolStripComboBox1.SelectedIndexChanged += (sender, e) =>
            {
                // ��ȡ�û�ѡ�����������
                string selectedFontFamily = toolStripComboBox1.SelectedItem.ToString();

                // ��ȡѡ�е��ı��������С����ʽ
                float fontSize = selectedForm2.yourTextBox.SelectionFont.Size;
                FontStyle fontStyle = selectedForm2.yourTextBox.SelectionFont.Style;

                // ����ѡ���ı�������
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
            newForm.MdiParent = this;  // ����Form2��MDI������ΪForm1
            //newForm.Dock = DockStyle.Fill;
            newForm.Activated += (s, e) =>
            {
                this.selectedForm2 = newForm;
                toolStripTextBox1.Text = "";
            };
            this.selectedForm2 = newForm;
            /*
            newForm.TopLevel = false;  // ����TopLevel����Ϊfalse������Form2�Ϳ��Ա���ӵ�Panel��
            this.panel1.Controls.Add(newForm);  // ��Form2��ӵ�Panel��
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
            // ����OpenFileDialog�ؼ�
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt�ļ�(*.txt)|*.txt|RTF�ļ�(*.rtf)|*.rtf"; // �����ļ����͹�����Ϊ.txt�ļ�
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // ��ȡ����ʾ�ļ�����
                selectedForm2.filePath = openFileDialog.FileName;
                selectedForm2.Text += selectedForm2.filePath;
                //string fileContent = File.ReadAllText(selectedForm2.filePath);

                // ����������TextBox
                selectedForm2.yourTextBox.Multiline = true; // ����Ϊ����ģʽ
                selectedForm2.yourTextBox.ScrollBars = RichTextBoxScrollBars.Both; // ���ù�����
                selectedForm2.yourTextBox.WordWrap = true; // �����Զ�����
                selectedForm2.yourTextBox.Dock = DockStyle.Fill; // ����Ϊ���ģʽ
                selectedForm2.yourTextBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);// ���ļ����ݼ��ص�TextBox�ؼ���

                // ����һ���µ������Ĳ˵�
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                // ��Ӳ˵���
                ToolStripMenuItem menuItem1 = new ToolStripMenuItem("����");
                ToolStripMenuItem menuItem2 = new ToolStripMenuItem("ճ��");
                ToolStripMenuItem menuItem3 = new ToolStripMenuItem("����");
                ToolStripMenuItem menuItem4 = new ToolStripMenuItem("ճ��");
                ToolStripMenuItem menuItem5 = new ToolStripMenuItem("ճ��");
                contextMenu.Items.Add(menuItem1);
                contextMenu.Items.Add(menuItem2);
                contextMenu.Items.Add(menuItem3);
                contextMenu.Items.Add(menuItem4);
                contextMenu.Items.Add(menuItem5);
                // Ϊ�˵�����ӵ���¼�������
                menuItem1.Click += (s, e) =>
                {
                    // �����ﴦ��ѡ��1�ĵ���¼�
                    if (selectedForm2.yourTextBox.SelectionLength > 0)
                        selectedForm2.yourTextBox.Copy();
                };
                menuItem2.Click += (s, e) =>
                {
                    // �����ﴦ��ѡ��2�ĵ���¼�
                    if (Clipboard.ContainsText())
                    {
                        selectedForm2.yourTextBox.Paste();
                    }
                };
                menuItem3.Click += (s, e) =>
                {
                    // �����ﴦ��ѡ��3�ĵ���¼�
                    if (selectedForm2.yourTextBox.SelectedText != "")
                    {
                        selectedForm2.yourTextBox.Cut();
                    }
                };
                menuItem4.Click += (s, e) =>
                {
                    // �����ﴦ��ѡ��4�ĵ���¼�
                };
                menuItem5.Click += (s, e) =>
                {
                    // �����ﴦ��ѡ��5�ĵ���¼�
                };
                // �������Ĳ˵�����ΪRichTextBox�������Ĳ˵�
                selectedForm2.yourTextBox.ContextMenuStrip = contextMenu;

                selectedForm2.yourTextBox.TextChanged += (s, e) =>
                {
                    toolStripTextBox1.Text = "";
                };
                selectedForm2.yourTextBox.SelectionStart = selectedForm2.yourTextBox.Text.Length; // �������궨λ���ı�����ĩ��
                selectedForm2.yourTextBox.SelectionChanged += (sender, e) =>
                {

                    // ����Լ��ѡ�е��ı��Ƿ��ѼӴ֣������ݽ�����°�ť��״̬
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
                // ��TextBox��ӵ�������
                selectedForm2.Controls.Add(selectedForm2.yourTextBox);
                selectedForm2.yourTextBox.BringToFront(); // ��TextBox���ڶ���
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
                // ����SaveFileDialog�ؼ�
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "�ı��ļ�|*.txt|RTF�ļ�|*.rtf"; // �����ļ����͹�����Ϊ.txt�ļ�
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

            toolStripTextBox1.Text = "�ѱ���";
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.MdiParent = this;  // ����Form2��MDI������ΪForm1
            //newForm.Dock = DockStyle.Fill;
            newForm.Activated += (s, e) =>
            {
                this.selectedForm2 = newForm;
                toolStripTextBox1.Text = "";
            };
            this.selectedForm2 = newForm;
            /*
            newForm.TopLevel = false;  // ����TopLevel����Ϊfalse������Form2�Ϳ��Ա���ӵ�Panel��
            this.panel1.Controls.Add(newForm);  // ��Form2��ӵ�Panel��
            */
            newForm.Show();
            newForm.isCreated = true;
            if (selectedForm2.filePath != "")
            {
                return;
            }
            // ����������TextBox
            selectedForm2.yourTextBox = new RichTextBox();
            selectedForm2.yourTextBox.Multiline = true; // ����Ϊ����ģʽ
            selectedForm2.yourTextBox.ScrollBars = RichTextBoxScrollBars.Both; // ���ù�����
            selectedForm2.yourTextBox.WordWrap = true; // �����Զ�����
            selectedForm2.yourTextBox.Dock = DockStyle.Fill; // ����Ϊ���ģʽ
            selectedForm2.yourTextBox.Text = ""; // ���ļ����ݼ��ص�TextBox�ؼ���
            selectedForm2.yourTextBox.TextChanged += (s, e) =>
            {
                toolStripTextBox1.Text = "";
            };
            selectedForm2.yourTextBox.SelectionStart = selectedForm2.yourTextBox.Text.Length; // �������궨λ���ı�����ĩ��
            selectedForm2.yourTextBox.SelectionChanged += (sender, e) =>
            {
                // �����������Ĵ���
                // ���磬����Լ��ѡ�е��ı��Ƿ��ѼӴ֣������ݽ�����°�ť��״̬
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

            // ��TextBox��ӵ�������
            selectedForm2.Controls.Add(selectedForm2.yourTextBox);
            selectedForm2.yourTextBox.BringToFront(); // ��TextBox���ڶ���
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
            // ��ȡѡ�е��ı�
            string selectedText = selectedForm2.yourTextBox.SelectedText;

            // �����ѡ�е��ı�
            if (!string.IsNullOrEmpty(selectedText))
            {
                // ��ȡѡ�е��ı�������
                Font currentFont = selectedForm2.yourTextBox.SelectionFont;
                // ���currentFontΪnull����ô����һ���µ�Font������ΪĬ������
                if (currentFont == null)
                {
                    currentFont = new Font("Arial", 10, FontStyle.Regular);
                }
                // �ж�ѡ�е��ı��Ƿ��ѼӴ�
                bool isBold = currentFont != null && currentFont.Bold;

                // ���ѡ�е��ı��ѼӴ֣���ȡ���Ӵ֣����򣬼Ӵ�

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

                toolStripButton7.Checked = !isBold; // �л���ť��ѡ��״̬

                // ����ѡ���ı�������
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
            // ��ȡѡ�е��ı�������
            Font currentFont = selectedForm2.yourTextBox.SelectionFont;

            // �ж�ѡ�е��ı��Ƿ�����б
            bool isItalic = currentFont != null && currentFont.Italic;
            // ���currentFontΪnull����ô����һ���µ�Font������ΪĬ������
            if (currentFont == null)
            {
                currentFont = new Font("Arial", 10, FontStyle.Regular);
            }
            // ���ѡ�е��ı�����б����ȡ����б��������б
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

            toolStripButton8.Checked = !isItalic; // �л���ť��ѡ��״̬

            // ����ѡ���ı�������
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
            // ��ȡѡ�е��ı�������
            Font currentFont = selectedForm2.yourTextBox.SelectionFont;
            // ���currentFontΪnull����ô����һ���µ�Font������ΪĬ������
            if (currentFont == null)
            {
                currentFont = new Font("Arial", 10, FontStyle.Regular);
            }
            // �ж�ѡ�е��ı��Ƿ����»���
            bool isUnderline = currentFont != null && currentFont.Underline;

            // ���ѡ�е��ı����»��ߣ���ȡ���»��ߣ������»���
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

            toolStripButton9.Checked = !isUnderline;// �л���ť��ѡ��״̬

            // ����ѡ���ı�������
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
                // ��ȡ�û�ѡ�������
                Font selectedFont = fontDialog.Font;

                // ����ѡ���ı�������
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

        private void �´���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.MdiParent = this;  // ����Form2��MDI������ΪForm1
            //newForm.Dock = DockStyle.Fill;
            newForm.Activated += (s, e) =>
            {
                this.selectedForm2 = newForm;
                toolStripTextBox1.Text = "";
            };
            this.selectedForm2 = newForm;
            /*
            newForm.TopLevel = false;  // ����TopLevel����Ϊfalse������Form2�Ϳ��Ա���ӵ�Panel��
            this.panel1.Controls.Add(newForm);  // ��Form2��ӵ�Panel��
            */
            newForm.Show();
            newForm.isCreated = true;
        }

        private void ���з�ʽToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ˮƽToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ˮƽ����
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ��ֱToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ��ֱ����
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        private void ˮƽToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // ˮƽ����
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ��ֱToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // ��ֱ����
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
            // ����ѡ���ı�Ϊ�����
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
            // ����ѡ���ı�Ϊ���ж���
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
            // ����ѡ���ı�Ϊ�Ҷ���
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
            // ���ز���
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
            // �ָ�����
            if (selectedForm2.yourTextBox.CanRedo)
            {
                selectedForm2.yourTextBox.Redo();
            }
        }
    }
}
