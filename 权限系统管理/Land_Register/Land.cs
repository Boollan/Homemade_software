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
using System.Threading;

namespace 权限系统管理
{
    public partial class Land : Form
    {
        public Land()
        {
            InitializeComponent();
            {
                this.Size = new Size(700, 500);
                this.labeluser_Land.Text = "账号";
                this.labelpwd_Land.Text = "密码";

                this.buttonland_Land.Text = "登陆";
                this.buttonregister_Land.Text = "注册界面";
                this.textBox2_Land.PasswordChar = '*';



            }
        }

        public static string name;


        SqlUser SQLUSER = new SqlUser();

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1_Land.Text.Trim() != "" && textBox1_Land.Text.Trim().Length < 20 && textBox2_Land.Text.Trim() != "" && textBox2_Land.Text.Trim().Length < 20)
            {
                using (SqlConnection con = new SqlConnection("Server=" + SQLUSER.Server_user + ";user=" + SQLUSER.user_user + ";pwd=" + SQLUSER.pwd_user + ";database=" + SQLUSER.database_user + ""))
                {
                    try
                    {
                        con.Open();
                        SqlCommand com = new SqlCommand("select * from Boollan003 where name='" + textBox1_Land.Text.Trim() + "'", con);
                        SqlDataReader dar = com.ExecuteReader();
                        if (dar.Read() == true)
                        {
                            string sqlpassword = dar.GetString(dar.GetOrdinal("password"));
                            name = dar.GetString(dar.GetOrdinal("name"));
                            if (textBox2_Land.Text.Trim() == sqlpassword)
                            {
                                //执行跳转
                                menu menu = new menu();
                                this.Hide();
                                menu.Show();

                            }
                            else
                            {
                                MessageBox.Show("您输入的密码错误", "温馨提示");
                            }
                        }
                        else
                        {
                            MessageBox.Show("用户名不存在请先注册", "温馨提示");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("错误：服务器连接失败或其他错误");
                    }

                }
            }
            else
            {
                MessageBox.Show("抱歉抱歉你您输入的信息有误\n用户不能为空,长度不大于20位", "银古温馨提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            register register = new register();
            this.Hide();
            register.Show();
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

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void Land_Load(object sender, EventArgs e)
        {

        }
    }
}

