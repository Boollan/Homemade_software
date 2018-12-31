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
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
        }

        private void user_Load(object sender, EventArgs e)
        {
            menu menu = new menu();
            textBox1_user.Text=menu.name_menu;
            
        }

        SqlUser SQLUSER = new SqlUser();
        private void buttonyes_user_Click(object sender, EventArgs e)//修改账号的密码
        {
            if (textBox3.Text.Trim()==textBox2.Text.Trim())
            {
                try
                {
                    using (SqlConnection con = new SqlConnection("Server="+SQLUSER.Server_user+";user="+SQLUSER.user_user+";pwd="+SQLUSER.pwd_user+";database="+SQLUSER.database_user+""))
                    {
                        con.Open();
                        SqlCommand com = new SqlCommand("select * from Boollan003 where name='" + textBox1_user.Text.Trim() + "'", con);
                        SqlDataReader dtr = com.ExecuteReader();

                        if (dtr.Read())
                        {
                            string sqlpassword = dtr.GetString(dtr.GetOrdinal("password"));
                            if (sqlpassword == textBox1.Text.Trim())
                            {
                                dtr.Close();
                                SqlCommand command = new SqlCommand("update Boollan003 set password='" + textBox2.Text.Trim() + "' where name='" + textBox1_user.Text.Trim() + "'", con);
                                command.ExecuteNonQuery();
                                MessageBox.Show("密码修改成功");
                                this.textBox1.Text = "";
                                this.textBox2.Text = "";
                                this.textBox3.Text = "";

                            }
                            else
                            {
                                MessageBox.Show("原密码错误");
                                this.textBox1.Text = "";
                                this.textBox2.Text = "";
                                this.textBox3.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("异常错误", "错误");
                        }

                        con.Close();
                    }


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());

                }
                finally
                {

                }
            }
            else
            {
                MessageBox.Show("确认密码错误");
            }
        }
    }
}
