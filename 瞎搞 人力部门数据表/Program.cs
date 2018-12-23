using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 瞎搞_人力部门数据表
{
    class Program
    {
        public struct ClerkName
        {
            public string Name;
            public int Agr;
            public string Dgep;
            public char Gender;
        }

        public static void Dataentry()
        {
            Console.WriteLine("欢迎使用录入系统请按,提示输入.");
            Console.Write("表明:");
            string surface = Console.ReadLine();

            Console.Write("姓名:");
            string Name = Console.ReadLine();

            Console.Write("年龄:");
            int Agr = int.Parse(Console.ReadLine());

            Console.Write("工作部门:");
            string Dgep = Console.ReadLine();

            Console.Write("性别:");
            char Gender = char.Parse(Console.ReadLine());
            DataProcessing(Name, Agr, Dgep, Gender);
            Console.WriteLine("以下是输入的内容:");
            Console.WriteLine("姓名:{0}"+
                              "年龄:{1}"+
                              "部门:{2}"+
                              "性别:{3}",Name,Agr,Dgep,Gender);
        }
        
        public static void DataProcessing(string name, int agr, string Dgep, char Gender)
        {
            ClerkName SurfaceDepartment = new ClerkName();
            SurfaceDepartment.Name = name;
            SurfaceDepartment.Agr = agr;
            SurfaceDepartment.Dgep = Dgep;
            SurfaceDepartment.Gender = Gender;
        }
        public static void LookupData()
        {
           
        }



        public static void Main(string[] args)
        {
            Dataentry();//录入数据


            



            Console.ReadKey();
        }
    }
}
