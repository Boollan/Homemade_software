using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 打开文件获取路径
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "获取文件路径";
            openFileDialog1.Filter = "文本文件(*.txt)|*.txt|Word文件(*.doc,*.docx)|*.doc;*.docx|全部文件(*.*)|*.*";
            openFileDialog1.FilterIndex = 3;
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                this.textBox1.Text = System.IO.Path.GetFullPath(openFileDialog1.FileName);

            }











        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
