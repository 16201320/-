using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using common;
using System.Data.SqlClient;

namespace 横梁涡流检测信息管理系统.SystemSetting
{
    class DLLAdmin
    {
        SqlHelper helper = null;

        public DLLAdmin()
        {
            helper = new SqlHelper();
        }


        //获取所有账号信息
        public DataSet ListAdmin()
        {
            string sql = "select ADMIN_ID as 编号,ACCOUNT_TYPE as 账号类型,ACCOUNT as 账号,NAME as 真实姓名,PASSWORD as 密码 ,LAST_LOGIN_TM as 上次登陆时间,LAST_LOGOUT_TM as 上次登出时间 from admin_info"; 
             DataSet ds = helper.ExecuteDataSetSql(sql);
            return ds;
        }

        public bool Exists(string account)
        {
            string sql = "select * from admin_info where account = @account";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@account", account));
            DataSet ds = helper.ExecuteDataSet(sql, paramList.ToArray());

            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        public bool Save(string account, string name)
        {
            string sql = "insert into admin_info( account, name, password) values(@account, @name, '123')";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@account", account));
            paramList.Add(new SqlParameter("@name", name));
            int result = helper.ExecuteNonQuery(sql, paramList);

            return result > 0;
        }

        public bool Update(string id, string account, string name)
        {
            string sql = "update admin_info set account = @account, name = @name where admin_id = @id";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@id", id));
            paramList.Add(new SqlParameter("@account", account));
            paramList.Add(new SqlParameter("@name", name));
            int result = helper.ExecuteNonQuery(sql, paramList);

            return result > 0;
        }

        public bool Delete(string id)
        {
            string sql = "delete from admin_info where admin_id = @id";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@id", id));

            int result = helper.ExecuteNonQuery(sql, paramList);

            return result > 0;
        }

        public bool ResetPwd(string id)
        {
            string sql = "update admin_info set password = '123' where admin_id = @id";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@id", id));

            int result = helper.ExecuteNonQuery(sql, paramList);

            return result > 0;
        }
        //登陆
        public bool Login(string account, string password)
        {
            string sql = "select * from admin_info where account = @account and password = @password";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@account", account));
            paramList.Add(new SqlParameter("@password", password));

            DataSet ds = helper.ExecuteDataSet(sql, paramList.ToArray());

            bool success = ds.Tables[0].Rows.Count > 0;

            if (success)
            {
                sql = "update admin_info set last_login_tm = getdate() where account = @account ";
                paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter("@account", account));

                int result = helper.ExecuteNonQuery(sql, paramList);

                return result > 0;
            }
            else
            {
                return false;
            }
        }
        //退出登陆
        public void QuitLogin(string account)
        {
            string sql = "update admin_info set last_logout_tm = getdate() where account = @account ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@account", account));

            int result = helper.ExecuteNonQuery(sql, paramList);
            return;
        }
        //获取密码
        public string GetPassword(string account)
        {
            string pwd = null;

            string sql = "select password from admin_info where account = @account";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@account", account));
            DataSet ds = helper.ExecuteDataSet(sql, paramList.ToArray());

            if (ds.Tables[0].Rows.Count > 0)
                pwd = ds.Tables[0].Rows[0]["password"].ToString();

            return pwd;

        }
        //更改密码
        public void ChangePassword(string account, string newPwd)
        {
            string sql = "update admin_info set password = @password where account = @account ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@password", newPwd));
            paramList.Add(new SqlParameter("@account", account));

            int result = helper.ExecuteNonQuery(sql, paramList);
            return;
        }

        //添加新用户
        public bool add(string ACCOUNT, string ACCOUNT_TYPE, string NAME, string PASSWORD)
        {
            bool ret = false;
            string sql = "insert into ADMIN_INFO (ACCOUNT,ACCOUNT_TYPE,NAME,PASSWORD)  " +
                                " values(@ACCOUNT,@ACCOUNT_TYPE,@NAME,@PASSWORD) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ACCOUNT", ACCOUNT));
            paramList.Add(new SqlParameter("@ACCOUNT_TYPE", ACCOUNT_TYPE));
            paramList.Add(new SqlParameter("@NAME", NAME));
            paramList.Add(new SqlParameter("@PASSWORD", PASSWORD));
            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }
            return ret;
        }
        //修改用户信息
        public bool Modify(string ADMIN_ID, string ACCOUNT, string ACCOUNT_TYPE, string NAME, string PASSWORD)
        {
            bool ret = false;
            string sql = "update ADMIN_INFO set ACCOUNT = @ACCOUNT, ACCOUNT_TYPE = @ACCOUNT_TYPE,NAME = @NAME,PASSWORD = @PASSWORD" +
                               "  where ADMIN_ID = @ADMIN_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ACCOUNT", ACCOUNT));
            paramList.Add(new SqlParameter("@ACCOUNT_TYPE", ACCOUNT_TYPE));
            paramList.Add(new SqlParameter("@NAME", NAME));
            paramList.Add(new SqlParameter("@PASSWORD", PASSWORD));
            paramList.Add(new SqlParameter("@ADMIN_ID", ADMIN_ID));
            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }
            return ret;
        }
        //删除用户
        public bool delete(string ADMIN_ID)
        {
            String sql = "delete from ADMIN_INFO  where ADMIN_ID = @ADMIN_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ADMIN_ID", ADMIN_ID));
            int result = helper.ExecuteNonQuery(sql, paramList);
            return (result > 0);
        }


    }
}
