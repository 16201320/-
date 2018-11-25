using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using common;

namespace EddyCurrentTesting
{
    public class RepairPRocessDao
    {
        SqlHelper helper = null;
        public RepairPRocessDao()
        {
            helper = new SqlHelper();
        }

        /// <summary>
        /// 查询所有符合条件的可用车辆信息
        /// </summary>
        /// <returns>查询到的车辆ID信息数据集</returns>
        public DataSet ListCarId3()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> paramList = new List<SqlParameter>();
            string sql = "select COLUMN_ID, COLUMN_NAME from LATHE_COLUMN ";

            ds = helper.ExecuteDataSet(sql, paramList.ToArray());

            return ds;
        }


        /// <summary>
        /// 删除车辆
        /// </summary>
        /// <param name="id">给定的车辆内码</param>
        /// <returns>true --删除成功,  false--删除失败</returns>
        public bool deleteCar(string id)
        {
            String sql = "delete from REPAIRPROCESS_INFO  where REPAIR_ID = @REPAIR_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@REPAIR_ID", id));

            int result = helper.ExecuteNonQuery(sql, paramList);

            return (result > 0);
        }

        /// <summary>
        /// 保存修改的车辆信息，用于保存编辑后的车辆信息
        /// </summary>
        public bool ModifyCar(string REPAIR_ID, string COLUMN_ID, string REPAIR_NAME)
        {
            bool ret = false;

            string sql = "update REPAIRPROCESS_INFO set COLUMN_ID = @COLUMN_ID, REPAIR_NAME = @REPAIR_NAME " +
                                " where REPAIR_ID = @REPAIR_ID ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@COLUMN_ID", COLUMN_ID));
            paramList.Add(new SqlParameter("@REPAIR_NAME", REPAIR_NAME));
            paramList.Add(new SqlParameter("@REPAIR_ID", REPAIR_ID));

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
        public bool SaveCar(string COLUMN_ID, string REPAIR_NAME)
        {
            bool ret = false;
            string sql = "insert into REPAIRPROCESS_INFO (COLUMN_ID, REPAIR_NAME)  " +
                                " values(@COLUMN_ID, @REPAIR_NAME) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@COLUMN_ID", COLUMN_ID));
            paramList.Add(new SqlParameter("@REPAIR_NAME", REPAIR_NAME));


            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }

            return ret;
        }

    }
}
