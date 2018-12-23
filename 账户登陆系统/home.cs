using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 账户登陆系统
{
    public class home
    {
        public void HomeUser()
        {
            Console.WriteLine("|账号系统|");//注:账号系统包含：{个人信息,账号充值,游戏币购买}
            int ampe = Convert.ToInt32(Console.ReadLine());
            switch (ampe)
            {
                case 1:

                    account account = new account();
                    account.Accountname();
                    break;
                default:
                    Console.WriteLine("您什么都没输入");
                    break;
            }
        }




    }
}
