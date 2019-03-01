using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cute_debug
{
    class Interaction
    {

        //注册界面逻辑判断
        public static bool Registrationlogic(string username, string password, string yespassword, string mail, string Verification)
        {
            if (username.Length < 17 && username != "" && password.Length < 17 && password != "" && yespassword == password && mail.IndexOf('@') > 1 && mail != "" && Verification == yzm && Verification != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //登录界面逻辑判断
        public static bool Landlogin(string username, string password)
        {
            if (username != "" && username.Length < 17 && password != "" && password.Length < 17)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //个人资料保存 传值
        public static void personapass(string name, string mail, string birthday, string profession, string country, string phone)
        {
            data.Name = name.ToString();
            data.Mail = mail.ToString();
            data.Birthday = birthday.ToString();
            data.Profession = profession.ToString();
            data.Country = country.ToString();
            data.Phone = phone.ToString();

        }

        //找回密码验证码
        static string yzm = "";
        public static string retpwd()
        {

            //定义一个字符串，这里面包含所有需要的验证码的元素；
            string a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            //以下写在按钮的点击事件内
            //实例化随机数
            Random b = new Random();
            yzm = "";
            //循环6次得到一个随机的六位数验证码
            for (int i = 0; i < 6; i++)
            {
                yzm = yzm + a.Substring(b.Next(0, a.Length), 1);
            }
            return "您的验证码是:" + yzm;
        }

        //验证验证码
        public static bool verification(string verif)
        {
            if (verif == yzm)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       

    }
}
