namespace SimpleMDIExample
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            toolStripDropDownButton2 = new ToolStripDropDownButton();
            水平ToolStripMenuItem1 = new ToolStripMenuItem();
            竖直ToolStripMenuItem1 = new ToolStripMenuItem();
            toolStrip2 = new ToolStrip();
            toolStripButton5 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton12 = new ToolStripButton();
            toolStripButton13 = new ToolStripButton();
            toolStripButton14 = new ToolStripButton();
            toolStripComboBox1 = new ToolStripComboBox();
            toolStripButton11 = new ToolStripButton();
            toolStripButton10 = new ToolStripButton();
            toolStripButton7 = new ToolStripButton();
            toolStripButton8 = new ToolStripButton();
            toolStripButton9 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton6 = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            toolStripTextBox1 = new ToolStripTextBox();
            toolStrip1.SuspendLayout();
            toolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ControlLight;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, toolStripDropDownButton2 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(659, 32);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.Font = new Font("Microsoft YaHei UI", 14F);
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(63, 29);
            toolStripDropDownButton1.Text = "文件";
            toolStripDropDownButton1.Click += toolStripDropDownButton1_Click;
            // 
            // toolStripDropDownButton2
            // 
            toolStripDropDownButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton2.DropDownItems.AddRange(new ToolStripItem[] { 水平ToolStripMenuItem1, 竖直ToolStripMenuItem1 });
            toolStripDropDownButton2.Font = new Font("Microsoft YaHei UI", 14F);
            toolStripDropDownButton2.Image = (Image)resources.GetObject("toolStripDropDownButton2.Image");
            toolStripDropDownButton2.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            toolStripDropDownButton2.Size = new Size(63, 29);
            toolStripDropDownButton2.Text = "窗口";
            toolStripDropDownButton2.Click += toolStripDropDownButton2_Click;
            // 
            // 水平ToolStripMenuItem1
            // 
            水平ToolStripMenuItem1.Name = "水平ToolStripMenuItem1";
            水平ToolStripMenuItem1.Size = new Size(122, 30);
            水平ToolStripMenuItem1.Text = "水平";
            水平ToolStripMenuItem1.Click += 水平ToolStripMenuItem1_Click;
            // 
            // 竖直ToolStripMenuItem1
            // 
            竖直ToolStripMenuItem1.Name = "竖直ToolStripMenuItem1";
            竖直ToolStripMenuItem1.Size = new Size(122, 30);
            竖直ToolStripMenuItem1.Text = "竖直";
            竖直ToolStripMenuItem1.Click += 竖直ToolStripMenuItem1_Click;
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = SystemColors.ControlLight;
            toolStrip2.ImageScalingSize = new Size(20, 20);
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripButton5, toolStripButton4, toolStripButton3, toolStripButton12, toolStripButton13, toolStripButton14, toolStripComboBox1, toolStripButton11, toolStripButton10, toolStripButton7, toolStripButton8, toolStripButton9, toolStripButton2, toolStripButton6, toolStripButton1, toolStripTextBox1 });
            toolStrip2.Location = new Point(0, 32);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(659, 27);
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton5
            // 
            toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton5.Image = (Image)resources.GetObject("toolStripButton5.Image");
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(24, 24);
            toolStripButton5.Text = "新建";
            toolStripButton5.Click += toolStripButton5_Click;
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(24, 24);
            toolStripButton4.Text = "打开文件";
            toolStripButton4.Click += toolStripButton4_Click;
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Font = new Font("Microsoft YaHei UI", 16F);
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(24, 24);
            toolStripButton3.Text = "保存";
            toolStripButton3.Click += toolStripButton3_Click;
            // 
            // toolStripButton12
            // 
            toolStripButton12.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton12.Image = (Image)resources.GetObject("toolStripButton12.Image");
            toolStripButton12.ImageTransparentColor = Color.Magenta;
            toolStripButton12.Name = "toolStripButton12";
            toolStripButton12.Size = new Size(24, 24);
            toolStripButton12.Text = "剪切";
            toolStripButton12.Click += toolStripButton12_Click;
            // 
            // toolStripButton13
            // 
            toolStripButton13.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton13.Image = (Image)resources.GetObject("toolStripButton13.Image");
            toolStripButton13.ImageTransparentColor = Color.Magenta;
            toolStripButton13.Name = "toolStripButton13";
            toolStripButton13.Size = new Size(24, 24);
            toolStripButton13.Text = "复制";
            toolStripButton13.Click += toolStripButton13_Click;
            // 
            // toolStripButton14
            // 
            toolStripButton14.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton14.Image = (Image)resources.GetObject("toolStripButton14.Image");
            toolStripButton14.ImageTransparentColor = Color.Magenta;
            toolStripButton14.Name = "toolStripButton14";
            toolStripButton14.Size = new Size(24, 24);
            toolStripButton14.Text = "粘贴";
            toolStripButton14.Click += toolStripButton14_Click;
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(95, 27);
            toolStripComboBox1.Click += toolStripComboBox1_Click;
            // 
            // toolStripButton11
            // 
            toolStripButton11.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton11.Image = (Image)resources.GetObject("toolStripButton11.Image");
            toolStripButton11.ImageTransparentColor = Color.Magenta;
            toolStripButton11.Name = "toolStripButton11";
            toolStripButton11.Size = new Size(24, 24);
            toolStripButton11.Text = "撤销";
            toolStripButton11.Click += toolStripButton11_Click;
            // 
            // toolStripButton10
            // 
            toolStripButton10.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton10.Image = (Image)resources.GetObject("toolStripButton10.Image");
            toolStripButton10.ImageTransparentColor = Color.Magenta;
            toolStripButton10.Name = "toolStripButton10";
            toolStripButton10.Size = new Size(24, 24);
            toolStripButton10.Text = "恢复";
            toolStripButton10.Click += toolStripButton10_Click_1;
            // 
            // toolStripButton7
            // 
            toolStripButton7.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton7.Image = (Image)resources.GetObject("toolStripButton7.Image");
            toolStripButton7.ImageTransparentColor = Color.Magenta;
            toolStripButton7.Name = "toolStripButton7";
            toolStripButton7.Size = new Size(24, 24);
            toolStripButton7.Text = "加粗";
            toolStripButton7.Click += toolStripButton7_Click;
            // 
            // toolStripButton8
            // 
            toolStripButton8.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton8.Image = (Image)resources.GetObject("toolStripButton8.Image");
            toolStripButton8.ImageTransparentColor = Color.Magenta;
            toolStripButton8.Name = "toolStripButton8";
            toolStripButton8.Size = new Size(24, 24);
            toolStripButton8.Text = "倾斜";
            toolStripButton8.Click += toolStripButton8_Click;
            // 
            // toolStripButton9
            // 
            toolStripButton9.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton9.Image = (Image)resources.GetObject("toolStripButton9.Image");
            toolStripButton9.ImageTransparentColor = Color.Magenta;
            toolStripButton9.Name = "toolStripButton9";
            toolStripButton9.Size = new Size(24, 24);
            toolStripButton9.Text = "下划线";
            toolStripButton9.Click += toolStripButton9_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(24, 24);
            toolStripButton2.Text = "左对齐";
            toolStripButton2.Click += toolStripButton2_Click_1;
            // 
            // toolStripButton6
            // 
            toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton6.Image = (Image)resources.GetObject("toolStripButton6.Image");
            toolStripButton6.ImageTransparentColor = Color.Magenta;
            toolStripButton6.Name = "toolStripButton6";
            toolStripButton6.Size = new Size(24, 24);
            toolStripButton6.Text = "居中";
            toolStripButton6.Click += toolStripButton6_Click_1;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(24, 24);
            toolStripButton1.Text = "右对齐";
            toolStripButton1.Click += toolStripButton1_Click_1;
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.BackColor = SystemColors.ControlLight;
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(79, 27);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(659, 584);
            Controls.Add(toolStrip2);
            Controls.Add(toolStrip1);
            IsMdiContainer = true;
            Margin = new Padding(2, 3, 2, 3);
            Name = "Form1";
            Text = "多文档文本编辑器";
            Load += Form1_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStrip toolStrip2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton7;
        private ToolStripButton toolStripButton8;
        private ToolStripButton toolStripButton9;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripDropDownButton toolStripDropDownButton2;
        private ToolStripMenuItem 水平ToolStripMenuItem1;
        private ToolStripMenuItem 竖直ToolStripMenuItem1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton6;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton10;
        private ToolStripButton toolStripButton11;
        private ToolStripButton toolStripButton12;
        private ToolStripButton toolStripButton13;
        private ToolStripButton toolStripButton14;
    }
}
