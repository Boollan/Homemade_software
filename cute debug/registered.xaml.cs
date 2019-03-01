using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace cute_debug
{
    /// <summary>
    /// registered.xaml 的交互逻辑
    /// </summary>
    public partial class registered : Window
    {
        public registered()
        {
            InitializeComponent();
        }
        //提交注册
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (Interaction.Registrationlogic(textbox_username.Text.Trim(),textbox_pwd.Password.Trim(), textbox_yespwd.Password.Trim(), textbox_mail.Text.Trim(),textbox_Verification.Text.Trim()) ==true)
            {
                if (message.messagetext(ClassSQL.SQLregiste(textbox_username.Text, textbox_pwd.Password, textbox_mail.Text))==100)
                {
                    System.Windows.Forms.MessageBox.Show("注册成功!","系统提示");
                    textbox_username.Text="";
                    textbox_pwd.Password = "";
                    textbox_yespwd.Password = "";
                    textbox_mail.Text = "";
                    textbox_Verification.Text = "";


                }
                else
                {
                    textbox_username.Text = "";
                    textbox_pwd.Password = "";
                    textbox_yespwd.Password = "";
                    textbox_mail.Text = "";
                    textbox_Verification.Text = "";
                }
            }
            else
            {
                textbox_username.Text = "";
                textbox_pwd.Password = "";
                textbox_yespwd.Password = "";
                textbox_mail.Text = "";
                textbox_Verification.Text = "";
                //message.messagetext(404);
                System.Windows.Forms.MessageBox.Show("您输入的注册信息 格式错误 ");
            }
        }

        //关闭线程
        private void Button_login_home_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Land land = new Land();
            land.Show();
        }

        //注册邮箱获取验证码
        private void Mail_verification_Click(object sender, RoutedEventArgs e)
        {
            ClassSQL.SendEmail(this.textbox_mail.Text.Trim(), "我们已收到您的注册请求 您的验证码已在邮箱内", Interaction.retpwd(),"感谢注册成为会员");
            System.Windows.Forms.MessageBox.Show("验证码发送成功","系统提示");
        }
    }
}
