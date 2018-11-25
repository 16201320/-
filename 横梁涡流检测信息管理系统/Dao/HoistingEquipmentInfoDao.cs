using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using common;

namespace EddyCurrentTesting
{
    public class HoistingEquipmentInfoDao
    {
        SqlHelper helper = null;
        public HoistingEquipmentInfoDao()
        {
            helper = new SqlHelper();
        }

        

        /// <summary>
        /// 删除吊挂设备信息
        /// </summary>
        /// <param name="id">给定的车辆内码</param>
        /// <returns>true --删除成功,  false--删除失败</returns>
        public bool deleteCar(string id)
        {
            String sql = "delete from HOISTINGEQUIPMENT_INFO  where EQUIMENT_ID = @EQUIMENT_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@EQUIMENT_ID", id));

            int result = helper.ExecuteNonQuery(sql, paramList);

            return (result > 0);
        }

        /// <summary>
        /// 保存修改的吊挂设备信息，用于保存编辑后的吊挂设备信息
        /// </summary>
        public bool ModifyCar(string EQUIMENT_ID, string EQUIMENT_NAME)
        {
            bool ret = false;

            string sql = "update HOISTINGEQUIPMENT_INFO set EQUIMENT_NAME = @EQUIMENT_NAME where EQUIMENT_ID = @EQUIMENT_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@EQUIMENT_NAME", EQUIMENT_NAME));
            paramList.Add(new SqlParameter("@EQUIMENT_ID", EQUIMENT_ID));

            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// 保存添加的吊挂设备信息
        /// </summary>       
        public bool SaveCar(string EQUIMENT_NAME)
        {
            bool ret = false;
            string sql = "insert into HOISTINGEQUIPMENT_INFO (EQUIMENT_NAME)  " +
                                " values(@EQUIMENT_NAME) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@EQUIMENT_NAME", EQUIMENT_NAME));

            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }

            return ret;
        }

    }
}
