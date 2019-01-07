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

namespace cute_gashapon_CDK_SYSTEM
{
    public partial class HOME : Form
    {
        public HOME()
        {
            InitializeComponent();
        }
        private Point mousePoint = new Point();//获取鼠标

        private void panel1_MouseDown(object sender, MouseEventArgs e)//确定鼠标的位置
        {
            base.OnMouseDown(e);
            this.mousePoint.X = e.X;
            this.mousePoint.Y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)//修改窗口位置
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Top = Control.MousePosition.Y - mousePoint.Y;
                this.Left = Control.MousePosition.X - mousePoint.X;
            }
        }

        private void panel2_Click(object sender, EventArgs e)//最小化
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否退出？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
                Application.Exit();
            }
        }//自定义退出

        private void button10_Click(object sender, EventArgs e)//同步数据
        {
            HOEM_ARR arr = new HOEM_ARR();
            HOEM_ARR.User = textBox_home_user.Text.Trim();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(HOEM_ARR.Sql))
                {
                    sqlcon.Open();
                    SqlCommand Sqlcom = new SqlCommand("select * from Boollan003 where name='" + HOEM_ARR.User + "'", sqlcon);
                    SqlDataReader Sdr = Sqlcom.ExecuteReader();
                    if (Sdr.Read())
                    {
                        HOEM_ARR.User = Sdr.GetString(Sdr.GetOrdinal("name"));
                        HOEM_ARR.Pwd = Sdr.GetString(Sdr.GetOrdinal("password"));
                        HOEM_ARR.Grd = Sdr.GetString(Sdr.GetOrdinal("grade"));
                        HOEM_ARR.Gmgrd = Sdr.GetString(Sdr.GetOrdinal("gmgrade"));
                        HOEM_ARR.Cuy = Sdr.GetString(Sdr.GetOrdinal("currency"));

                        textBox_cuy_user_home.Text = HOEM_ARR.User;
                        textBox_pwd_user_home.Text = HOEM_ARR.User;
                        textBox_user_user_home.Text = HOEM_ARR.User;
                        textBox_grd_user_home.Text = HOEM_ARR.User;
                        textBox_gmgrd_user_home.Text = HOEM_ARR.User;
                        /*功能同步*/
                        textBox_cuy_home.Text = HOEM_ARR.Cuy;
                        textBox_grd_grd_home.Text = HOEM_ARR.Grd;
                        textBox_gmgrd_gm_home.Text = HOEM_ARR.Gmgrd;
                        groupBox_CUY_HOME.Enabled = true;
                        groupBox_PWD_HOME.Enabled = true;
                        groupBox_USER_HOME.Enabled = true;
                        groupBox_GAMEGRD_HOME.Enabled = true;
                        groupBox_GMGRD_HOME.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("用户名不存在");
                    }
                }
                /*账户名同步*/





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }





        }

        private void button_cuy_ok_home_Click(object sender, EventArgs e)
        {
            if (textBox_cuy_add_home.Text.Trim() != "")
            {
                HOEM_ARR.Cuy = (Convert.ToInt32(HOEM_ARR.Cuy) + Convert.ToInt32(textBox_cuy_add_home.Text.Trim())).ToString();
                sqlupdate(HOEM_ARR.User);
                textBox_cuy_home.Text = HOEM_ARR.Cuy;
            }
            else
            {
                MessageBox.Show("不能为空");
            }

        }//添加游戏币功能

        private static void sqlupdate(string user)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(HOEM_ARR.Sql))
                {
                    sqlcon.Open();
                    SqlCommand sqlcompwd = new SqlCommand("update Boollan003 set password='" + HOEM_ARR.Pwd + "' where name='" + user + "'", sqlcon);
                    SqlCommand sqlcomcuy = new SqlCommand("update Boollan003 set currency='" + HOEM_ARR.Cuy + "' where name='" + user + "'", sqlcon);//同步游戏币
                    SqlCommand sqlcomgrd = new SqlCommand("update Boollan003 set grade='" + HOEM_ARR.Grd + "' where name='" + user + "'", sqlcon);
                    SqlCommand sqlcomgmgrd = new SqlCommand("update Boollan003 set gmgrade='" + HOEM_ARR.Gmgrd + "' where name='" + user + "'", sqlcon);
                    sqlcompwd.ExecuteNonQuery();
                    sqlcomcuy.ExecuteNonQuery();
                    sqlcomgrd.ExecuteNonQuery();
                    sqlcomgmgrd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ex.Source);
                throw;
            }

            



        }//更新数据库

        private void button_grd_ok_home_Click(object sender, EventArgs e)
        {
            if (textBox_grd_add_home.Text.Trim() != "")
            {
                HOEM_ARR.Grd = (Convert.ToInt32(HOEM_ARR.Grd) + Convert.ToInt32(textBox_grd_add_home.Text.Trim())).ToString();
                sqlupdate(HOEM_ARR.User);
                textBox_grd_grd_home.Text = HOEM_ARR.Grd;
            }
            else
            {
                MessageBox.Show("不能为空");
            }
        }//修改玩家等级功能

        private void button_gmgrd_ok_home_Click(object sender, EventArgs e)
        {
            if (textBox_gmgrd_add_home.Text.Trim()!=""&&Convert.ToInt32(textBox_gmgrd_add_home.Text.Trim())<6&&Convert.ToInt32(textBox_gmgrd_add_home.Text.Trim())>-1)
            {
                HOEM_ARR.Gmgrd=  textBox_gmgrd_add_home.Text.Trim();
                sqlupdate(HOEM_ARR.User);
                textBox_gmgrd_gm_home.Text = HOEM_ARR.Gmgrd;
            }
            else
            {
                MessageBox.Show("不符合规范");
            }
        }//修改GM等级

        private void button_pwd_ok_home_Click(object sender, EventArgs e)
        {
            if (textBox_pwd_newpwd_home.Text.Trim() != "" && textBox_pwd_newpwd_home.Text.Trim().Length > 5 && textBox_pwd_newpwd_home.Text.Trim().Length<21)
            {
               HOEM_ARR.Pwd= textBox_pwd_newpwd_home.Text.Trim();
                sqlupdate(HOEM_ARR.User);
            }
            else
            {
                MessageBox.Show("不符合规范");
            }
        }//修改密码功能

        public static string user_set;
        private void button_user_ok_home_Click(object sender, EventArgs e)
        {
            if (textBox_user_add_home.Text.Trim()!=""&&textBox_user_add_home.Text.Trim().Length>0&&textBox_user_add_home.Text.Trim().Length<11)
            {
                using (SqlConnection sqlcon=new SqlConnection(HOEM_ARR.Sql))
                {
                    sqlcon.Open();
                    SqlCommand sqlcom = new SqlCommand("select * from Boollan003 where name='"+textBox_user_add_home.Text.Trim()+"'", sqlcon);
                    SqlDataReader sdr = sqlcom.ExecuteReader();
                    if (sdr.Read()==false)
                    {
                        SqlCommand sqlcomuser = new SqlCommand("update Boollan003 set name='" + user_set + "' where name='" + HOEM_ARR.User + "'", sqlcon);
                        user_set = textBox_user_add_home.Text.Trim();
                        sqlupdate(HOEM_ARR.User);
                        MessageBox.Show("请同步后在进行否则功能无效", "重要提示");
                    }
                    else
                    {
                        MessageBox.Show("已存在当前用户名");
                    }
                }
                
            }
            else
            {
                MessageBox.Show("不符合规范");
            }
        }//修改用户功能
    }
}
