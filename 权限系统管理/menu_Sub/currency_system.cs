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
    public partial class currency_system : Form
    {
     
        public currency_system()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private Point mousePoint = new Point();

        private void panel_text_cusy_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.mousePoint.X = e.X;
            this.mousePoint.Y = e.Y;
        }

        private void panel_text_cusy_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Top = Control.MousePosition.Y - mousePoint.Y;
                this.Left = Control.MousePosition.X - mousePoint.X;
            }
        }

        private void panel_mini_cusy_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void panel_colse_cusy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否退出？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
                Application.Exit();
            }
        }

        private void button_baeke_cusy_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            this.Hide();
            menu.Show();
        }

        SqlUser SQLUSER = new SqlUser();

        private void button_yes_user_Click(object sender, EventArgs e)//用户点击了查询
        {
            if (textBoxsuer_cusy.Text.Trim() != "" && textBoxsuer_cusy.Text.Length < 20)
            {

                try
                {
                    using (SqlConnection con = new SqlConnection("Server="+SQLUSER.Server_user+";user="+SQLUSER.user_user+";pwd="+SQLUSER.pwd_user+";database="+SQLUSER.database_user+""))
                    {

                        con.Open();
                        SqlCommand com = new SqlCommand("select * from Boollan003 where name='" + textBoxsuer_cusy.Text.Trim() + "'", con);
                        SqlDataReader reader = com.ExecuteReader();
                        if (reader.Read())
                        {
                            textBox_cuy_cusy.Text = reader.GetString(reader.GetOrdinal("currency"));//游戏币
                            textBox_gerd_cusy.Text = reader.GetString(reader.GetOrdinal("grade"));//用户等级
                            textBox_Gmgerd_cusy.Text = reader.GetString(reader.GetOrdinal("gmgrade"));//GM等级

                        }
                        else
                        {
                            MessageBox.Show("您要查找的用户不存在");
                        }



                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }





            }
        }
    }
}
