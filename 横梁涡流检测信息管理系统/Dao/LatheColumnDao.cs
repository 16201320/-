using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using common;

namespace EddyCurrentTesting
{
    public class LatheColumnDao
    {
        SqlHelper helper = null;
        public LatheColumnDao()
        {
            helper = new SqlHelper();
        }

        //查询所有可以车列
        public DataSet getList()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> paramList = new List<SqlParameter>();
            string sql = "select COLUMN_ID, COLUMN_NAME from LATHE_INFO ";
            ds = helper.ExecuteDataSet(sql, paramList.ToArray());
            return ds;
        }


        
        // 删除车列号
        public bool delete(string id)
        {
            String sql = "delete from LATHE_COLUMN  where COLUMN_ID = @COLUMN_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@COLUMN_ID", id));
            int result = helper.ExecuteNonQuery(sql, paramList);
            return (result > 0);
        }

        //保存修改的车列号信息
        public bool Modify(string COLUMN_ID, string COLUMN_NAME)
        {
            bool ret = false;
            string sql = "update LATHE_COLUMN set COLUMN_NAME = @COLUMN_NAME " +
                               "  where COLUMN_ID = @COLUMN_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@COLUMN_NAME", COLUMN_NAME));
            paramList.Add(new SqlParameter("@COLUMN_ID", COLUMN_ID));
            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }
            return ret;
        }

        // 保存添加的车辆信息       
        public bool Save(string COLUMN_NAME)
        {
            bool ret = false;
            string sql = "insert into LATHE_COLUMN (COLUMN_NAME)  " +
                                " values(@COLUMN_NAME) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@COLUMN_NAME", COLUMN_NAME));
            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }
            return ret;
        }
 
    }
}
