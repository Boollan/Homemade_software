using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cute_gashapon_CDK_SYSTEM
{
    public class HOEM_ARR
    {
        /*SQL user*/
        private static string sql = "Server=.;user=Boollan;pwd=3838538;database=Boollan";
        /*SQL名称*/
        private static string lable = "Boollan";

        /*end*/
        /*账户数据*/
        private static string user;//账户名
        private static string pwd;//密码
        private static string cuy;//游戏币
        private static string grd;//玩家等级
        private static string gmgrd;//管理员级别

        public static string Sql
        {
            get
            {
                return sql;
            }

            set
            {
                sql = value;
            }
        }

        public static string User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        public static string Pwd
        {
            get
            {
                return pwd;
            }

            set
            {
                pwd = value;
            }
        }

        public static string Cuy
        {
            get
            {
                return cuy;
            }

            set
            {
                cuy = value;
            }
        }

        public static string Grd
        {
            get
            {
                return grd;
            }

            set
            {
                grd = value;
            }
        }

        public static string Gmgrd
        {
            get
            {
                return gmgrd;
            }

            set
            {
                gmgrd = value;
            }
        }


        /*字段属性*/

    }
}
