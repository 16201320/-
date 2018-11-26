using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using common;

namespace 横梁涡流检测信息管理系统
{
    public class LatheDao
    {
        SqlHelper helper = null;
        public LatheDao()
        {
            helper = new SqlHelper();
        }

        // 删除车型信息
        public bool delete(string LATHE_ID)
        {
            String sql = "delete from LATHE_INFO  where LATHE_ID = @LATHE_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@LATHE_ID", LATHE_ID));
            int result = helper.ExecuteNonQuery(sql, paramList);
            return (result > 0);
        }

        //保存修改的车型信息
        public bool Modify(string LATHE_ID, string LATHE_NAME)
        {
            bool ret = false;
            string sql = "update LATHE_INFO set LATHE_NAME = @LATHE_NAME where LATHE_ID = @LATHE_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@LATHE_NAME", LATHE_NAME));
            paramList.Add(new SqlParameter("@LATHE_ID", LATHE_ID));
            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }
            return ret;
        }

        //保存添加的车型信息     
        public bool Save(string LATHE_NAME)
        {
            bool ret = false;
            string sql = "insert into LATHE_INFO ( LATHE_NAME)"+" values( @LATHE_NAME) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@LATHE_NAME", LATHE_NAME));
            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }
            return ret;
        }

    }
}
