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

        /// <summary>
        /// 删除车型信息
        /// </summary>
        /// <param name="id">给定的车辆内码</param>
        /// <returns>true --删除成功,  false--删除失败</returns>
        public bool deleteCar(string LATHE_ID)
        {
            String sql = "delete from LATHE_INFO  where LATHE_ID = @LATHE_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@LATHE_ID", LATHE_ID));

            int result = helper.ExecuteNonQuery(sql, paramList);

            return (result > 0);
        }

        /// <summary>
        /// 保存修改的车型信息，用于保存编辑后的车型信息
        /// </summary>
        public bool ModifyCar(string LATHE_ID, string LATHE_NAME)
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

        /// <summary>
        /// 保存添加的车型信息  
        /// </summary>       
        public bool SaveCar(string LATHE_NAME)
        {
            bool ret = false;
            string sql = "insert into LATHE_INFO ( LATHE_NAME)  " +
                                " values( @LATHE_NAME) ";
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
