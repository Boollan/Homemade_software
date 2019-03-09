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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cute_debug
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            {
            }
        }

        //关闭线程
        private  void HOME_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
            
        }

        //加载
        private void HOME_Loaded(object sender, RoutedEventArgs e)
        {
            /*加载用户信息*/
            textbox_user.Text = data.Username;
            textbox_gred.Text = data.Grade.ToString();
            textbox_currency.Text = data.Currency.ToString();
            textbox_GM.Text = data.Administrator.ToString();
            textbox_vip.Text = data.Vip.ToString();
            /**/
        }

        //个人资料
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PersonalInformation personalInformation = new PersonalInformation();
            personalInformation.Show();
        }

        //账号系统
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            account account = new account();
            account.Show();
        }

        //卡密系统
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            kami_Sytem kami_Sytem = new kami_Sytem();
            kami_Sytem.Show();
            this.Hide();

        }
    }
}
