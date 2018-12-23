using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试版本_瞎搞
{
    class home:login//首页
    {
        public void Home()
        {
            Console.WriteLine("====欢迎====");
            Console.WriteLine("|账号信息|账号充值|游戏币|游戏抽奖|");//相应的界面功能
            double temp = Convert.ToDouble(Console.ReadLine());
            switch (temp)
            {
                case 1:
                    Account account = new Account();
                    account.informatione();
                    break;
                case 2:
                    Account account1 = new Account();
                    account1.Recharge();
                    break;
                case 3:
                    Account account2 = new Account();
                    account2.Gamecurrency();
                    break;
                case 4:
                    Console.WriteLine("开发中~");
                    break;
                default:
                    Console.WriteLine("您什么都没有输入");
                    break;
            }



        }
    }
}
