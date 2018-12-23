using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 账户登陆系统
{
    public class account:login
    {
        public double te = 0;// 余额
        public double er = 0;//硬币

        public void Accountname()
        {
            Console.WriteLine("个人信息|账户充值|硬币购买|密码修改|");
            int temp = Convert.ToInt32(Console.ReadLine());
            switch (temp)
            {
                case 1:
                    Information();
                    break;
                default:
                    break;
            }





        }


        public void Information()
        {
            
            Console.Write("\n用户名:{0}\n账户余额:{1}\n硬币余额:{2}\n",this.User,this.te,this.er);
        }

    }
}
