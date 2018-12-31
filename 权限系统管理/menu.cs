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
                groupBox2.Text = "GM系统";
                button_information_menu.Text = "个人资料";
                button_Account_menu.Text = "账号系统";
                button_Capsule_menu.Text = "扭蛋游戏";
                /*GM*/
                button_Card_menu.Text = "卡密生成系统";
                button_currency_menu.Text = "查询用户系统";
                button_Player_menu.Text = "玩家等级系统";
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
        public static string grade;//等级
        public static string currency;//游戏币
        public static string gmgrade;//管理员等级


        SqlUser SQLUSER = new SqlUser();
        private void menu_Load(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection con = new SqlConnection("Server="+SQLUSER.Server_user+";user="+SQLUSER.user_user+";pwd="+SQLUSER.pwd_user+";database="+SQLUSER.database_user+""))
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
                        this.textBox_name_menu.Text = name_menu;
                        this.textBox_Player__menu.Text = Convert.ToString(grade);
                        this.textBox_currency_menu.Text = Convert.ToString(currency);
                        this.textBox_Gm_menu.Text = Convert.ToString(gmgrade);
                        con.Close();
                        
                    }
                    else
                    {

                        this.groupBox2.Visible = false;
                        this.textBox_Gm_menu.Visible = false;
                        this.label4.Visible = false;
                        this.label4_menu.Visible = false;
                        MessageBox.Show("意料之外的错误");

                    }


                }
                if (Convert.ToInt32(gmgrade)<5)
                {
                    label4_menu.Visible = true;
                    textBox_Gm_menu.Visible = true;
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

        private void button2_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Account account = new Account();
            account.Show();
        }

        private void button5_menu_Click(object sender, EventArgs e)//游戏币入口点
        {
            currency_system currency_System = new currency_system();
            this.Hide();
            currency_System.Show();

        }
    }
}
