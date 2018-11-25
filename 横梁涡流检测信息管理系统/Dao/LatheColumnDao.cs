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

        /// <summary>
        /// 查询所有符合条件的可用车辆信息
        /// </summary>
        /// <returns>查询到车列号信息数据集</returns>
        public DataSet ListCarId3()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> paramList = new List<SqlParameter>();
            string sql = "select LATHE_ID, LATHE_NAME from LATHE_INFO ";

            ds = helper.ExecuteDataSet(sql, paramList.ToArray());

            return ds;
        }


        /// <summary>
        /// 删除车列号
        /// </summary>
        /// <param name="id">给定的车辆内码</param>
        /// <returns>true --删除成功,  false--删除失败</returns>
        public bool deleteCar(string id)
        {
            String sql = "delete from LATHE_COLUMN  where COLUMN_ID = @COLUMN_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@COLUMN_ID", id));

            int result = helper.ExecuteNonQuery(sql, paramList);

            return (result > 0);
        }

        /// <summary>
        /// 保存修改的车列号信息，用于保存编辑后的车列号信息
        /// </summary>
        public bool ModifyCar(string COLUMN_ID, string LATHE_ID, string COLUMN_NAME)
        {
            bool ret = false;

            string sql = "update LATHE_COLUMN set LATHE_ID = @LATHE_ID, COLUMN_NAME = @COLUMN_NAME " +
                               "  where COLUMN_ID = @COLUMN_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@LATHE_ID", LATHE_ID));
            paramList.Add(new SqlParameter("@COLUMN_NAME", COLUMN_NAME));
            paramList.Add(new SqlParameter("@COLUMN_ID", COLUMN_ID));

            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// 保存添加的车辆信息
        /// </summary>       
        public bool SaveCar(string LATHE_ID, string COLUMN_NAME)
        {
            bool ret = false;
            string sql = "insert into LATHE_COLUMN (LATHE_ID, COLUMN_NAME)  " +
                                " values(@LATHE_ID, @COLUMN_NAME) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@LATHE_ID", LATHE_ID));
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
