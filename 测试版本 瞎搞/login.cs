using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace 测试版本_瞎搞
{
    class login//登陆
    {

        string sql = "Server=.;user=Boollan;pwd=3838538;database=Boollan";



        //用户·登陆
        private string _User;
        private string _Password;

        //确认
        string UserVerification = "admin";
        string PasswordVerification = "admin";
        //用户密码属性
        public string User
        {
            get
            {
                return _User;
            }

            set
            {
                if (value.Length < 20)
                {
                    _User = value;
                }

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
                if (value.Length < 25)
                {
                    _Password = value;
                }

            }
        }
        private string _Nickname;//昵称
        public string Nickname
        {
            get
            {
                return _Nickname;
            }

            set
            {
                if (value.Length < 10)
                {
                    _Nickname = value;
                }

            }
        }

        public string Nickname1
        {
            get
            {
                return _Nickname;
            }

            set
            {
                _Nickname = value;
            }
        }

        public void Loginlog()//用户交互
        {


            Console.Write("账号:");
            User = Console.ReadLine();
            Console.Write("密码:");
            Password = Console.ReadLine();

            Verification(User, Password);
        }

        public void Verification(string user, string password)//判断密码正确否
        {

            //SQL Server 验证
            try
            {
                using (SqlConnection con = new SqlConnection("Server=.;user=Boollan;pwd=3838538;database=Boollan"))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("select * from Boollan  where name='"+User+"'", con);

                    using (SqlDataReader reader = com.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            string sqlpasswod = reader.GetString(reader.GetOrdinal("pwd"));

                            if (Password == sqlpasswod)
                            {
                                Console.WriteLine("登陆成功");
                            }
                            else
                            {
                                Console.WriteLine("登陆失败");
                            }
                        }
                        else
                        {
                            Console.WriteLine("账户不存在");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }








            //本地验证
            //if (Equals(user,UserVerification)==true)
            //{
            //    if (Equals(password,PasswordVerification)==true)
            //    {
            //        Console.WriteLine(User + Nickname);

            //        NicknameNO();
            //    }
            //}
            //else
            //{

            //    Console.WriteLine("您的账号不存在！");
            //}
        }

        public void NicknameNO()
        {
            int e = 0;
            if (e > 1)
            {
                NicknameNO();
            }
            else
            {

                Console.WriteLine("您好欢迎使用请创建昵称");
                Nickname = Console.ReadLine();
                if (Nickname != "")//非空验证
                {
                    Console.WriteLine("创建成功:{0}", Nickname);
                    e = +1;
                    home home = new home();
                    home.Home();
                }
                else
                {
                    Console.WriteLine("昵称不能为空");

                    NicknameNO();
                }
            }
        }


    }
}
