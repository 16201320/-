using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using common;

namespace EddyCurrentTesting
{
    public class CarNoDao
    {
        SqlHelper helper = null;
        public CarNoDao()
        {
            helper = new SqlHelper();
        }

        /// <summary>
        /// 查询所有符合条件的可用车号信息
        /// </summary>
        /// <returns>查询到车列号信息数据集</returns>
        public DataSet ListCarId3()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> paramList = new List<SqlParameter>();
            string sql = "select COLUMN_ID, COLUMN_NAME from LATHE_COLUMN ";

            ds = helper.ExecuteDataSet(sql, paramList.ToArray());

            return ds;
        }


        /// <summary>
        /// 删除车号
        /// </summary>
        /// <param name="id">给定的车辆内码</param>
        /// <returns>true --删除成功,  false--删除失败</returns>
        public bool deleteCar(string id)
        {
            String sql = "delete from CARNO_INFO  where CARID = @CARID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CARID", id));

            int result = helper.ExecuteNonQuery(sql, paramList);

            return (result > 0);
        }

        /// <summary>
        /// 保存修改的车号信息，用于保存编辑后的车列号信息
        /// </summary>
        public bool ModifyCar(string CARID, string COLUMN_ID, string CARNAME)
        {
            bool ret = false;

            string sql = "update CARNO_INFO set COLUMN_ID = @COLUMN_ID, CARNAME = @CARNAME " +
                               "  where CARID = @CARID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@COLUMN_ID", COLUMN_ID));
            paramList.Add(new SqlParameter("@CARNAME", CARNAME));
            paramList.Add(new SqlParameter("@CARID", CARID));

            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// 保存添加的车号信息
        /// </summary>       
        public bool SaveCar(string COLUMN_ID, string CARNAME)
        {
            bool ret = false;
            string sql = "insert into CARNO_INFO (COLUMN_ID, CARNAME)  " +
                                " values(@COLUMN_ID, @CARNAME) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@COLUMN_ID", COLUMN_ID));
            paramList.Add(new SqlParameter("@CARNAME", CARNAME));

            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }

            return ret;
        }
 
    }
}
