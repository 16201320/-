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

        public DataSet ListAdmin()
        {
            string sql = "select * from admin_info";
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

        public void QuitLogin(string account)
        {
            string sql = "update admin_info set last_logout_tm = getdate() where account = @account ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@account", account));

            int result = helper.ExecuteNonQuery(sql, paramList);
            return;
        }

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

        public void ChangePassword(string account, string newPwd)
        {
            string sql = "update admin_info set password = @password where account = @account ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@password", newPwd));
            paramList.Add(new SqlParameter("@account", account));

            int result = helper.ExecuteNonQuery(sql, paramList);
            return;
        }
    }
}
