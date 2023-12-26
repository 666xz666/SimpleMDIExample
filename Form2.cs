using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMDIExample
{
    public partial class Form2 : Form
    {
        public bool isCreated;
        public string filePath;
        public RichTextBox yourTextBox;
        public Form2()
        {
            InitializeComponent();
            yourTextBox=new RichTextBox();
            filePath = "";
            isCreated = false;
            this.Text = "";
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
