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
    public partial class cz : Form
    {
        public cz()
        {
            InitializeComponent();
        }

        SqlUser SQLUSER = new SqlUser();
        private void buttonyes_user_Click(object sender, EventArgs e)
        {
            //try
            //{
            using (SqlConnection con = new SqlConnection("Server="+SQLUSER.Server_user+";user="+SQLUSER.user_user+";pwd="+SQLUSER.pwd_user+";database="+SQLUSER.database_user+""))
            {
                con.Open();
                SqlCommand com = new SqlCommand("select * from Kalman where cdk='" + textBox1.Text.Trim() + "' ", con);
                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    string yesnocdk = reader.GetString(reader.GetOrdinal("effective"));
                    string mony = reader.GetString(reader.GetOrdinal("money"));
                    if (Convert.ToInt32(yesnocdk) == 1)
                    {
                        reader.Close();
                        SqlCommand com1 = new SqlCommand("select * from Boollan003 where name='" + textBoxuser_recharge.Text + "'", con);
                        SqlDataReader reader1 = com1.ExecuteReader();
                        if (reader1.Read())
                        {

                            string e12 = reader1.GetString(reader1.GetOrdinal("currency"));
                            int monyme = Convert.ToInt32(mony) + Convert.ToInt32(e12);//拥有的余额和充值余额的和
                            reader1.Close();
                            SqlCommand com2 = new SqlCommand("update Boollan003 set currency='" + monyme.ToString() + "'  where name='" + textBoxuser_recharge.Text + "'", con);
                            com2.ExecuteNonQuery();
                            SqlCommand com3 = new SqlCommand("update Kalman set effective='0'  where cdk='" + textBox1.Text.Trim() + "' ", con);
                            com3.ExecuteNonQuery();
                            textBoxreg_recharge.Text = monyme.ToString();
                            MessageBox.Show("充值成功\n当前余额为:" + monyme.ToString() + "","感谢"+textBoxuser_recharge.Text+"充值");
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("卡密已被使用或无效");
                    }

                }
                else
                {
                    MessageBox.Show("卡密错误");
                }

            }
        }
        //catch (Exception ex)
        //{
        //    MessageBox.Show(ex.Message.ToString());

        //}
        //}

        private void cz_Load(object sender, EventArgs e)
        {
            menu menu1 = new menu();
            this.textBoxuser_recharge.Text = menu.name_menu;
            this.textBoxreg_recharge.Text = menu.currency;
        }
    }
}
