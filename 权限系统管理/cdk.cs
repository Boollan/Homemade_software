using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 权限系统管理
{
    public partial class cdk : Form
    {
        public cdk()
        {
            InitializeComponent();
        }

        public static int mer = 0;

        string result;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Trim() != "" && Convert.ToInt32(textBox2.Text.Trim()) > 0)
                {
                    //35个字符
                    string str = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    Random r = new Random();
                    result = string.Empty;
                    //生成一个8位长的随机字符，具体长度可以自己更改            
                    for (int i = 0; i < 32; i++)
                    {
                        //这里下界是0，随机数可以取到，上界应该是35，因为随机数取不到上界，也就是最大74，符合我们的题意
                        int m = r.Next(0, 36);
                        string s = str.Substring(m, 1);
                        result += s;
                    }
                    textBox1.Text = "";
                    textBox1.Text = result;
                    mer = Convert.ToInt32(textBox2.Text.Trim());
                    //----


                    using (SqlConnection con = new SqlConnection("Server=.;user=Boollan;pwd=3838538;database=Boollan"))
                    {
                        con.Open();
                        SqlCommand com = new SqlCommand("select * from Kalman where cdk='" + result + "'", con);
                        SqlDataReader sdr = com.ExecuteReader();

                        if (sdr.Read()==false)
                        {
                            sdr.Close();
                            SqlCommand cmd = new SqlCommand("insert Kalman(cdk,effective,money)values('"+result+"','1','"+mer+"')", con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("卡密添加成功: 卡密:"+result+"金额:"+mer);
                        }
                        else
                        {

                            MessageBox.Show("卡密已存在");
                        }


                    }





                }
                else
                {
                    MessageBox.Show("请输入金额不得小于0");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message+"请输入整数");
            }
            
            
        }
        private Point mousePoint = new Point();
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.mousePoint.X = e.X;
            this.mousePoint.Y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Top = Control.MousePosition.Y - mousePoint.Y;
                this.Left = Control.MousePosition.X - mousePoint.X;
            }
           
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否退出？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
                Application.Exit();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu menu = new menu();
            menu.Show();
        }
    }
}
