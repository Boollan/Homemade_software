using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试版本_瞎搞
{
    class Account:home//账户
    {
        
        double _balance = 0;//账号余额
        public double Balance
        {
            get
            {
                
                return _balance;
            }

            set
            {
                if (value<10000)
                {
                    _balance = value;
                }
                else
                {

                }
            }
        }

        

        public void informatione()//个人信息
        {
            Console.WriteLine("\n用户名:{0}\n 昵称:{1}\n 账户余额:{2}\n 游戏币:{3}\n ",User,Nickname,Balance,Gamecurr);
        }

        //游戏币
       private double _gamecurr=0;//游戏币余额
        public double Gamecurr
        {
            get
            {
                return _gamecurr;
            }

            set
            {
                if (value<10000)
                {
                    _gamecurr = value;
                }
               
            }
        }

        public void Gamecurrency()//游戏币
        {
            gamecucyTxT();

        }

        public void gamecucyTxT()
        {
            Console.WriteLine("=====欢迎使用游戏币系统=====");
            Console.WriteLine("|游戏币余额|购买游戏币|游戏币使用|首页菜单|");
            double temp = Convert.ToDouble(Console.ReadLine());
            switch (temp)
            {
                case 1:
                    Console.WriteLine("\n 游戏币余额:{0}",Gamecurr);
                    break;
                case 2:
                    Console.WriteLine("2");
                    break;
                case 3:
                    Console.WriteLine("展示只用");
                    break;
                case 4:
                    home home = new home();
                    home.Home();
                    break;
                default:
                    Console.WriteLine("您没有输入任何值");
                    break;
            }                      
        }

        public void Recharge()//余额充值
        {
            Console.WriteLine("|卡密充值|支付宝充值|微信充值|管理员充值|");
            double temp =Convert.ToDouble( Console.ReadLine());
            switch (temp)
            {
                case 1:
                    Kalman();
                    break;
                case 2:
                    Console.WriteLine("开发中~");
                    break;
                case 3:
                    Console.WriteLine("开发中~");
                    break;
                case 4:
                    Console.WriteLine("开发中~");
                    break;
                default:
                    Console.WriteLine("您什么都没输入");
                    break;
            }
        }

        public void Kalman()//卡密充值方式
        {
            int Kalman =  383853866;//1000元
            Console.Write("卡密:");
            int temp = Convert.ToInt32(Console.ReadLine());

            if (temp==Kalman)
            {
                Balance = +1000;
                Console.WriteLine("充值成功. 金额{0} 账户余额{2}",1000,Balance);
            }
            else
            {
                Console.WriteLine("您输入的卡密不正确或已被使用");
                
            }

        }



    }
}
