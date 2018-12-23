using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 测试版本_瞎搞
{

    class Program//入口店
    {

//        [DllImport("User32.dll")]//调用外部动态数据库
        
//        public static extern int MessageBox(int h, string m, string c, int type);//声明一个方法提示框

//        private static void Button3_Click(string sender, int information)//调用浏览器
//        {
//            int informationINT = information;
//            //调用系统默认的浏览器   
//            System.Diagnostics.Process.Start(sender);
//            if (informationINT == 404)
//            {
//                //Console.WriteLine("错误404,支付系统为内部版本展示之用\n");
//                MessageBox(0, "错误404,支付系统为内部版本展示之用", "温馨提示",0);
//                Help();
//            }
//            else
//            {
//                if (informationINT == 101)
//                {
//                    Console.WriteLine("跳转中...\n");
//                    //Console.WriteLine("---请完成支付---\n");
//                    MessageBox(0, "---请完成支付---", "温馨提示",0);
//                    Help();
//                }
//                else
//                {

//                }
//                //Console.WriteLine("遇到意外错误");
//                MessageBox(0, "遇到意外错误", "温馨提示",0);
//            }
//            Help();
//        }

//        public static void Help()//提示用户输入
//        {

//            Console.WriteLine("----[帮助文档] " + " [游戏币购买] " + " [账户充值] " + " [联系客服]----");
//            Console.Write("请选择:");
//            string help = Console.ReadLine();



//            if (Equals(help, "帮助文档") == true)
//            {
//                Help();
//            }
//            else
//            {
//                if (Equals(help, "游戏币购买") == true)
//                {
//                    GameRecharge();
//                }
//                else
//                {
//                    if (Equals(help, "账户充值") == true)
//                    {
//                        Recharge();
//                    }
//                    else
//                    {
//                        if (Equals(help, "联系客服") == true)
//                        {
//                            Console.WriteLine("请联系qq:2769772982");
//                            Help();
//                        }
//                        else
//                        {
//                            if (int.Parse(help) == 1)
//                            {
//                                Help();
//                            }
//                            else
//                            {
//                                if (int.Parse(help) == 2)
//                                {
//                                    GameRecharge();
//                                }
//                                else
//                                {
//                                    if (int.Parse(help) == 3)
//                                    {
//                                        Recharge();
//                                    }
//                                    else
//                                    {
//                                        if (int.Parse(help) == 4)
//                                        {
//                                            Console.WriteLine("请联系qq:2769772982");
//                                            Help();
//                                        }
//                                        Console.WriteLine("您没有输入指定的任何内容");
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//        }
//        //余额储存验证{
//        public static int AccountBalance = 0;//账户余额
//        public static int GameAccountBalance = 0;//游戏币余额

//        public static void GameRecharge()//充值游戏币界面
//        {

//            Console.WriteLine("------------Boollan软件“游戏币”购买系统-------------");
//            Console.Write("请输入要购买游戏币的数量:");

//            int GameRecharge = int.Parse(Console.ReadLine());
//            if (AccountBalance >= GameRecharge)
//            {
//                AccountBalance = AccountBalance - GameRecharge;//扣除余额
//                GameAccountBalance = GameAccountBalance + GameRecharge;//游戏币数量增加
//                                                                       //Console.WriteLine("您本次购买游戏币数量为: " + GameRecharge + "游戏币\n 账户余额:" + AccountBalance + "欢迎继续充值使用");
//                                                                       //Help();
//                MessageBox(0, "您本次购买游戏币数量为: " + GameRecharge + "游戏币\n 账户余额:" + AccountBalance + "欢迎继续充值使用", "温馨提示",0);
//                Help();
//            }
//            else
//            {
//                //Console.WriteLine("您的账户余额不足请充值\n账户余额:" + AccountBalance + "  请充值购买");
//                //Help();
//                MessageBox(0, "您的账户余额不足请充值\n账户余额: " + AccountBalance + "  请充值购买","温馨提示",0);
                
//                Help();

//            }
//;


//        }
        
//        public static void Recharge()//账户余额充值首界面
//        {
//            Console.WriteLine("============Bollan软件账户“余额”充值系统=============");
//            Console.WriteLine("充值的方式: [密卡充值] [微信充值] [支付宝充值] [人工代充]");
//            Console.Write("请选择:");
//            string Recharge = Console.ReadLine();
//            if (Equals(Recharge, "密卡充值") == true)
//            {
//                DenseCardRecharge();
//            }
//            else
//            {
//                if (Equals(Recharge, "微信充值") == true)
//                {
//                    //Button3_Click("https://pay.weixin.qq.com/index.php/core/home/login?return_url=%2F", 101);
//                    Button3_Click("https://ss0.bdstatic.com/70cFvHSh_Q1YnxGkpoWK1HF6hhy/it/u=1450683666,3263234170&fm=26&gp=0.jpg", 404);
//                    Help();
//                }
//                else
//                {
//                    if (Equals(Recharge, "支付宝充值") == true)
//                    {
//                        //Button3_Click("https://www.alipay.com/", 101);

//                        Button3_Click("https://ss0.bdstatic.com/70cFvHSh_Q1YnxGkpoWK1HF6hhy/it/u=2084802166,1536153494&fm=26&gp=0.jpg", 404);

//                        Help();

//                    }
//                    else
//                    {
//                        if (Equals(Recharge, "在线客服") == true)
//                        {
//                            Console.WriteLine("QQ添加:2769772980");
//                            Help();

//                        }
//                        else
//                        {
//                            if (Convert.ToInt32(Recharge) == 1)
//                            {
//                                DenseCardRecharge();
//                            }
//                            else
//                            {
//                                if (Convert.ToInt32(Recharge) == 2)
//                                {
//                                    //Button3_Click("https://pay.weixin.qq.com/index.php/core/home/login?return_url=%2F", 101);
//                                    Button3_Click("https://ss0.bdstatic.com/70cFvHSh_Q1YnxGkpoWK1HF6hhy/it/u=1450683666,3263234170&fm=26&gp=0.jpg", 404);
//                                    Help();
//                                }
//                                else
//                                {
//                                    if (Convert.ToInt32(Recharge) == 3)
//                                    {
//                                        //Button3_Click("https://www.alipay.com/", 101);

//                                        Button3_Click("https://ss0.bdstatic.com/70cFvHSh_Q1YnxGkpoWK1HF6hhy/it/u=2084802166,1536153494&fm=26&gp=0.jpg", 404);

//                                        Help();
//                                    }
//                                    else
//                                    {
//                                        if (Convert.ToInt32(Recharge) == 4)
//                                        {
//                                            Console.WriteLine("QQ添加:2769772980");
//                                            Help();
//                                        }

//                                        Console.WriteLine("您没有输入对应数字,");
//                                        Help();

//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//        }
        
//        public static void DenseCardRecharge()//账户余额卡密充值
//        {
//            int DenseCardRechargeIs = 383853866;//内部卡密 可用于写成数据库验证
//            int DenseCardRechargeIsi = 500;//内部卡密的金额 可用于写成数据库验证金额
//            Console.Write("请输入卡密:");

//            int DenseCardRecharge = int.Parse(Console.ReadLine());

//            if (DenseCardRecharge == DenseCardRechargeIs)
//            {
//                AccountBalance = +DenseCardRechargeIsi;
//                //Console.WriteLine("您本次充值账户金额为:" + DenseCardRechargeIsi + "元\n 账户余额:" + AccountBalance + "元\n欢迎继续充值使用");
//                MessageBox(0, "您本次充值账户金额为:" + DenseCardRechargeIsi + "元\n 账户余额:" + AccountBalance + "元\n欢迎继续充值使用", "温馨提示",0);
//                Help();
//            }
//            else
//            {
//                //Console.WriteLine("卡密不正确或已被使用\n");
//                MessageBox(0, "卡密不正确或已被使用\n", "温馨提示",0);
//                Help();
//            }


//        }

//        public static void UserPassword()//用户登录验证
//        {
//            object UserLink = "Boollan";
//            object PassWodLink = "xiaowei123++..";
//            //本地账户系统
//            Console.Write("账户:");
//            object User = Console.ReadLine();
//            Console.Write("密码:");
//            object PassWord = Console.ReadLine();
//            //验证判断
//            if (Equals(UserLink, User) == true)
//            {
//                if (Equals(PassWodLink, PassWord) == true)
//                {
//                    //Console.WriteLine("登录成功\n");
//                    MessageBox(0,"登录成功","温馨提示",0);
//                    Help();
//                }
//            }
//            else
//            {
//                //Console.WriteLine("登录失败\n");
//                MessageBox(0,"登陆失败","温馨提示",0);
//                UserPassword();
//            }
//        }



//        ~Program()//内存释放
//        {

//        }

        

        static void Main(string[] args)
        {
           
            login login = new login();
            login.Loginlog();
            Console.ReadKey();
        }
    }
}
