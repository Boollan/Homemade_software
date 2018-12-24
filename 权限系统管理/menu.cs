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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            {
                this.Text = "Boollan";
                groupBox1.Text = "用户面板";
                groupBox2.Text = "管理员系统";
                button1_menu.Text = "个人资料";
                button2_menu.Text = "账号系统";
                button3_menu.Text = "扭蛋游戏";
                /*GM*/
                button4_menu.Text = "卡密生成系统";
                button5_menu.Text = "游戏币系统";
                button6_menu.Text = "玩家等级系统";
                /*GM*/


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

        public static string name_menu = Land.name;//账号
        //int grade_menu=0;//等级
        //int currency_menu=0;//游戏币
        //int gmgrade_menu=0;//管理员等级

        string grade;
        string currency;
        string gmgrade;

        private void menu_Load(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection con = new SqlConnection("Server=.;user=Boollan;pwd=3838538;database=Boollan"))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("select * from Boollan003 where name='"+name_menu+"'", con);
                    SqlDataReader sdr = com.ExecuteReader();
                    if (sdr.Read()==true)
                    {
                        
                        grade =  sdr.GetString(sdr.GetOrdinal("grade"));
                        currency = sdr.GetString(sdr.GetOrdinal("currency"));
                        gmgrade = sdr.GetString(sdr.GetOrdinal("gmgrade"));
                        sdr.Close();
                        this.textBox1_menu.Text = name_menu;
                        this.textBox2_menu.Text = Convert.ToString(grade);
                        this.textBox3_menu.Text = Convert.ToString(currency);
                        this.textBox4_menu.Text = Convert.ToString(gmgrade);
                        con.Close();
                    }
                    else
                    {

                        MessageBox.Show("意料之外的错误");
                    }


                }
                if (Convert.ToInt32(gmgrade)<5)
                {
                    label4_menu.Visible = true;
                    textBox4_menu.Visible = true;
                    groupBox2.Visible = true;
                    groupBox2.Enabled = true;
                    label4.Visible = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void button4_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            cdk cdk = new cdk();
            cdk.Show();
        }
    }
}
