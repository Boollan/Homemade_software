using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cute_debug
{
    class data
    {
        //基本信息
        private static string _username;
        private static int _grade;
        private static int _currency;
        private static int _administrator;
        private static int _vip;


        /*基本信息属性*/
        
        public static string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }//用户名

        public static int Currency
        {
            get
            {
                return _currency;
            }

            set
            {
                if (value.ToString().Length<10)
                {
                    _currency = value;
                }
                
            }
        }//余额

        public static int Administrator
        {
            get
            {
                return _administrator;
            }

            set
            {
                if (value<6&&value>-1)
                {
                    _administrator = value;

                }
            }
        }//管理员等级

        public static int Grade
        {
            get
            {
                return _grade;
            }

            set
            {
                _grade = value;
            }
        }//等级
        /*end*/
        public static int Vip
                {
                    get
                    {
                        return _vip;
                    }

                    set
                    {
                        _vip = value;
                    }
                }//会员等级
        //个人资料
        private static string _name;
        private static string _birthday;
        private static string _mail;
        private static string _profession;
        private static string _country;
        private static string _phone;

        /*个人资料属性*/
        public static string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public static string Birthday
        {
            get
            {
                return _birthday;
            }

            set
            {
                _birthday = value;
            }
        }

        public static string Mail
        {
            get
            {
                return _mail;
            }

            set
            {
                _mail = value;
            }
        }

        public static string Profession
        {
            get
            {
                return _profession;
            }

            set
            {
                _profession = value;
            }
        }

        public static string Country
        {
            get
            {
                return _country;
            }

            set
            {
                _country = value;
            }
        }

        public static string Phone
        {
            get
            {
                return _phone;
            }

            set
            {
                _phone = value;
            }
        }

        
    }
}
