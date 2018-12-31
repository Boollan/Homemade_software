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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
            {
                this.Size = new Size(683, 461);
                this.Text = "Boollan";
                this.ShowIcon = true;
                this.label1_register.Text = "账号";
                this.label2_register.Text = "密码";
                this.label3_register.Text = "支付密码";
                this.button1_register.Text = "注册";
                this.button2_register.Text = "登陆界面";
               


            }
        }


        SqlUser SQLUSER = new SqlUser();


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1_register.Text.Trim() != "" && textBox1_register.Text.Trim().Length < 20 && textBox2_register.Text.Trim() != "" && textBox2_register.Text.Trim().Length < 20&&textBox3_register.Text.Trim()!=""&&textBox3_register.Text.Trim().Length<7)
            {
                using (SqlConnection con = new SqlConnection("Server="+SQLUSER.Server_user+";user="+SQLUSER.user_user+";pwd="+SQLUSER.pwd_user+";database="+SQLUSER.database_user+""))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("select * from Boollan003 where name='" + textBox1_register.Text.Trim() + "'", con);
                    SqlDataReader dar = com.ExecuteReader();
                    if (dar.Read() == false)
                    {
                        
                        dar.Close();
                        SqlCommand cominsert = new SqlCommand("insert Boollan003(name,password,paypassword,grade,gmgrade,currency)values('"+textBox1_register.Text.Trim()+"','"+textBox2_register.Text.Trim()+"','"+textBox3_register.Text.Trim()+"',0,5,0)", con);
                        cominsert.ExecuteNonQuery();
                        MessageBox.Show("注册成功", "温馨提示");
                        textBox1_register.Text = "";
                        textBox2_register.Text = "";
                        textBox3_register.Text = "";

                        Land land = new Land();
                        this.Hide();
                        land.Show();
                    }
                    else
                    {
                        MessageBox.Show("您注册的名称已存在,请更名后在注册", "温馨提示");
                    }
                }
            }
            else
            {
                MessageBox.Show("抱歉抱歉你您输入的信息有误\n用户不能为空,长度不大于20位","银古温馨提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Land land = new Land();
            this.Hide();
            land.Show();
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

      
    }
}
