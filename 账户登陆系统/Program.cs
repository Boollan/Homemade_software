using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 账户登陆系统
{
    public class Program
    {
        static void Main(string[] args)
        {
            login login = new login();
            login.Loginuser();
            Console.ReadKey();
        }
    }
}
