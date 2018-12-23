using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 苹果手机_黑心商家利润计算
{
    class profit
    {
        public void ProfitCalculation(double total, double difference, double Taxation)
        {
            
            double TaxRate = total / Taxation;//不含税价格=含税价格/(1+税率) 去除税费的价格
            double taxre = total - TaxRate;//交税费用多少钱
            double Real = TaxRate - (difference/Taxation);//国内商家的具体利润
            double dwe = TaxRate - Real;


            Console.WriteLine("国内总价:{0:C}\t,国外网站总价:{1:C}\t,除税的价格:{2:C}\t,交税费:{3:C}\t,商家的大约利润{4:C}\t ,苹果手机成本价{5:C}\t\n", total, difference, TaxRate, taxre,Real,dwe);

            //商家赚钱的额度 
            //含税:
            double mei = 190000;
            double my1 = total*mei ;
            //不含税
            double my2 = TaxRate*mei ;
            //成本价
            double my3 = dwe*mei;
            //商家利润
            double my4 = Real*mei ;

            Console.WriteLine("原价的利润:{0:C}\t,不含税的利润:{1:C}\t,净利润:{2:C}\t,商家净利润{3:C}\t\n",my1,my2,my3,my4);


            Program rog = new Program();
            rog.ProfitCalculation();
            
        }



    }
}
