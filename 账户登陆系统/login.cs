using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 账户登陆系统
{
    public class login
    {
        private string _User;
        private string _Password;


        //登陆
        public void Loginuser()
        {
            Console.Write("账号:");
            User = Console.ReadLine();
            Console.Write("密码:");
            Password = Console.ReadLine();
            Verification();
        }
        //验证
        public string Username = "admin";
        public string Passwrodname = "admin";

        public string User
        {
            get
            {
                return _User;
            }

            set
            {
                _User = value;
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
            }
        }

        public void Verification()
        {
            if (Equals(User,Username)==true)
            {
                if (Equals(Password,Passwrodname)==true)
                {
                    //跳转到功能
                    home home = new home();
                    home.HomeUser();
                }
                else
                {
                    Console.WriteLine("密码错误");
                    Loginuser();
                }
            }
            else
            {
                Console.WriteLine("账号不存在");
                Loginuser();
            }
        }
    }
}
