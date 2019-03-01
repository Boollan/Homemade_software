using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;

namespace cute_debug
{
    class ClassSQL
    {

        /*连接数据库参数*/
        private static string SQL_Server = ".";
        private static string SQL_User = "Boollan";
        private static string SQL_Pwd = "3838538";
        private static string SQL_Database = "Boollan";
        //连接字符串
        private static string sqlconstr = "Server=" + SQL_Server + ";user=" + SQL_User + ";pwd=" + SQL_Pwd + ";database=" + SQL_Database + "";


        // 设置发送方的邮件信息,例如使用网易的smtp
        static string smtpServer = "smtp.163.com"; //SMTP服务器
        static string mailFrom = "wyzaoz@163.com"; //登陆用户名
        static string userPassword = "xiaowei123";//登陆密码

        //创建用户信息表
        public static void SQLcon()
        {
            using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
            {
                sqlcon.Open();
                // 判断是否存在数据表
                SqlCommand cmd = new SqlCommand("select * from information_schema.TABLES where Table_NAME ='usertable'", sqlcon);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows == false)//返回值为true，存在，false不存在（SqlDataReader 的HasRows ，判断是否有数据）
                {
                    //创建用户表
                    string sql_user_table = "create table usertable(id int identity(1,1) primary key,username varchar(40) not null,pwd varchar(40) not null,mail varchar(40) not null,administrator varchar(40) not null,currency varchar(40) not null,Paypassowrd varchar(10),grade varchar(10))";
                    SqlCommand sqlcom = new SqlCommand(sql_user_table, sqlcon);
                    reader.Close();
                    sqlcom.ExecuteNonQuery();
                    sqlcom.Clone();
                    //该表不存在
                }
            }
        }

        //提交注册信息
        public static int SQLregiste(string username, string password, string mail)
        {
            SQLcon();//基础信息表创建
            SQLpersonatable();//创建资料表
            using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
            {
                sqlcon.Open();

                SqlCommand sqlcomselect = new SqlCommand("select * from usertable where username='" + username + "'", sqlcon);
                SqlDataReader sqlData = sqlcomselect.ExecuteReader();
                if (sqlData.Read() == false)
                {
                    sqlData.Close();
                    SqlCommand sqlcomselect1 = new SqlCommand("select * from usertable where mail='" + mail + "'", sqlcon);
                    SqlDataReader sqlData1 = sqlcomselect1.ExecuteReader();
                    if (sqlData1.Read()==false)
                    {
                        
                        sqlData1.Close();

                        //插入基本信息数据
                        SqlCommand com = new SqlCommand("insert usertable(username,pwd,mail,administrator,currency,grade)values('" + username + "','" + password + "','" + mail + "','0','0','0')", sqlcon);
                        com.ExecuteNonQuery();
                        //添加个人默认资料表
                        SqlCommand sqlCommand = new SqlCommand("insert information(username,name,mail,birthday,profession,country,phone)values('" + username + "',' ',' ',' ',' ',' ','')", sqlcon);
                        sqlCommand.ExecuteNonQuery();
                        return 100;
                    }
                    else
                    {
                        return 503;
                    }
                }
                else
                {
                    return 503;

                }
            }
        }

        //登录验证
        public static int SQLLandlogin(string username, string password)
        {
            using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("select * from usertable where username='" + username + "'", sqlcon);
                SqlDataReader sqlData = sqlcom.ExecuteReader();
                if (sqlData.Read() == true)
                {
                    string nameuser = sqlData.GetString(sqlData.GetOrdinal("username"));
                    string pwd = sqlData.GetString(sqlData.GetOrdinal("pwd"));
                    if (username == nameuser)
                    {
                        if (password == pwd)
                        {
                            return 100;
                        }
                        else
                        {
                            return 404;
                        }
                    }
                    else
                    {
                        return 502;
                    }
                }
                else
                {
                    return 502;
                }
            }
        }

        //数据库信息信息传递到HOME
        public static void SQLLandpassHome(string username)
        {
            using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("select * from usertable where username='" + username + "' ", sqlcon);
                SqlDataReader sqlData = sqlcom.ExecuteReader();
                if (sqlData.Read() == true)
                {
                    string sqlusername = sqlData.GetString(sqlData.GetOrdinal("username"));
                    string sqlgrade = sqlData.GetString(sqlData.GetOrdinal("grade"));
                    string sqlcurrency = sqlData.GetString(sqlData.GetOrdinal("currency"));
                    string sqladministrator = sqlData.GetString(sqlData.GetOrdinal("administrator"));
                    sqlcon.Close();
                    data.Username = sqlusername;
                    data.Grade = Convert.ToInt32(sqlgrade);
                    data.Currency = Convert.ToInt32(sqlcurrency);
                    data.Administrator = Convert.ToInt32(sqladministrator);



                }
            }
        }

        //个人资料表创建
        public static void SQLpersonatable()
        {
            using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
            {
                sqlcon.Open();
                // 判断是否存在数据表
                SqlCommand cmd = new SqlCommand("select * from information_schema.TABLES where Table_NAME ='information'", sqlcon);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows == false)//返回值为true，存在，false不存在（SqlDataReader 的HasRows ，判断是否有数据）
                {
                    //创建用户表
                    string sql_user_information = "create table information(id int identity(1,1) primary key,username varchar(40) not null,name varchar(40),mail varchar(40),birthday varchar(40),profession varchar(40),country varchar(50),phone varchar(20))";
                    SqlCommand sqlcom = new SqlCommand(sql_user_information, sqlcon);
                    reader.Close();
                    sqlcom.ExecuteNonQuery();
                    sqlcom.Clone();
                    //该表不存在
                }
            }
        }

        //个人资料查询
        public static void SQLpersonadata(string username)
        {
            using (SqlConnection sqlcon = new SqlConnection(sqlconstr))
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("select * from information where username='" + username.ToString() + "' ", sqlcon);
                SqlDataReader sqlData = sqlcom.ExecuteReader();
                if (sqlData.Read() == true)
                {
                    string sqlname = sqlData.GetString(sqlData.GetOrdinal("name"));
                    string sqlmail = sqlData.GetString(sqlData.GetOrdinal("mail"));
                    string sqlbirthday = sqlData.GetString(sqlData.GetOrdinal("birthday"));
                    string sqlprofession = sqlData.GetString(sqlData.GetOrdinal("profession"));
                    string sqlcountry = sqlData.GetString(sqlData.GetOrdinal("country"));
                    string sqlphone = sqlData.GetString(sqlData.GetOrdinal("phone"));
                    sqlcon.Close();

                    data.Name = sqlname;
                    data.Mail = sqlmail;
                    data.Birthday = sqlbirthday;
                    data.Profession = sqlprofession;
                    data.Country = sqlcountry;
                    data.Phone = sqlphone;
                }






            }
        }

        //个人资料编辑
        public static bool SQLpersonaDataediting()
        {
            using (SqlConnection sqlcon=new SqlConnection(sqlconstr))
            {
                sqlcon.Open();
                SqlCommand sqlcomname = new SqlCommand("update information set name='"+data.Name.ToString()+"' where username='"+data.Username.ToString()+"'", sqlcon);
                SqlCommand sqlcommail = new SqlCommand("update information set mail='" + data.Mail.ToString() + "' where username='" + data.Username.ToString() + "'", sqlcon);
                SqlCommand sqlcombirthday = new SqlCommand("update information set birthday='" + data.Birthday.ToString() + "' where username='" + data.Username.ToString() + "'", sqlcon);
                SqlCommand sqlcomprofession = new SqlCommand("update information set profession='" + data.Profession.ToString() + "' where username='" + data.Username.ToString() + "'", sqlcon);
                SqlCommand sqlcomcountry = new SqlCommand("update information set country='" + data.Country.ToString() + "' where username='" + data.Username.ToString() + "'", sqlcon);
                SqlCommand sqlcomphone = new SqlCommand("update information set phone='" + data.Phone.ToString() + "' where username='" + data.Username.ToString() + "'", sqlcon);
                sqlcomname.ExecuteNonQuery();
                sqlcommail.ExecuteNonQuery();
                sqlcombirthday.ExecuteNonQuery();
                sqlcomprofession.ExecuteNonQuery();
                sqlcomcountry.ExecuteNonQuery();
                sqlcomphone.ExecuteNonQuery();
                return true;


            }
        }

        //邮箱发送
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailTo">要发送的邮箱</param>
        /// <param name="mailSubject">邮箱主题</param>
        /// <param name="mailContent">邮箱内容</param>
        /// <param name="mailname">邮件名称</param>
        /// <returns>返回发送邮箱的结果</returns>
        public static bool SendEmail(string mailTo, string mailSubject, string mailContent,string mailname)
        {
            // 邮件服务设置
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            smtpClient.Host = smtpServer; //指定SMTP服务器
            smtpClient.Credentials = new System.Net.NetworkCredential(mailFrom, userPassword);//用户名和密码

            // 发送邮件设置       
            MailMessage mailMessage = new MailMessage(mailFrom, mailTo); // 发送人和收件人
            mailMessage.Subject = mailSubject;//主题
            mailMessage.Body = mailContent;//内容
            mailMessage.BodyEncoding = Encoding.UTF8;//正文编码
            mailMessage.IsBodyHtml = true;//设置为HTML格式
            mailMessage.Priority = MailPriority.Low;//优先级
            mailMessage.From = new MailAddress(mailname+"<wyzaoz@163.com>");
            
            try
            {
                smtpClient.Send(mailMessage); // 发送邮件
                return true;
            }
            catch (SmtpException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        //获取邮箱的当前用户名
        public static string mail_user(string mail)
        {
            using (SqlConnection sqlcon =new SqlConnection(sqlconstr))
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("select * from usertable where mail='"+mail+"'", sqlcon);
                SqlDataReader sqlData = sqlcom.ExecuteReader();
                if (sqlData.Read()==true)
                {
                  string username_reg  =  sqlData.GetString(sqlData.GetOrdinal("username"));

                   return  username_reg;
                }
                else
                {
                    return"";
                }
            }
        }

        //更改密码
        public static  bool Password_change(string username ,string pwd)
        {
            using (SqlConnection sqlcon =new SqlConnection(sqlconstr))
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("select * from usertable where username='"+username+"'", sqlcon);
                SqlDataReader sqlData = sqlcom.ExecuteReader();
                if (sqlData.Read()==true)
                {
                    sqlcom.Clone();
                    sqlData.Close();

                    SqlCommand sqlCommand = new SqlCommand("update usertable set pwd='"+pwd+"' where username='"+username+"'", sqlcon);
                    sqlCommand.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
