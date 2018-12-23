using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 苹果手机_黑心商家利润计算
{
    class Program
    {

        public  void ProfitCalculation()
        {

            Console.Write("国内苹果手机总价:");
            double TotalPrice = Convert.ToDouble(Console.ReadLine());
            Console.Write("亚马逊网站价格:");
            double LowPrice = Convert.ToDouble(Console.ReadLine());
            Console.Write("税率:");
            double Taxation = Convert.ToDouble(Console.ReadLine());
            profit lrProfit = new profit();
            lrProfit.ProfitCalculation(TotalPrice, LowPrice, Taxation);
        }

        static void Main(string[] args)
        {
            //double TaxRate = 10999/1.17;//税率
            //double tar = 10999-TaxRate;
            //Console.WriteLine(TaxRate);
            //Console.WriteLine(tar);

            Program rogr = new Program();
            rogr.ProfitCalculation();//填入值

            Console.ReadKey();
        }
    }
}
