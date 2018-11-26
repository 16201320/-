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
        //查询所有可以吊挂设备
        public DataSet getList()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> paramList = new List<SqlParameter>();
            string sql = "select EQUIMENT_ID, EQUIMENT_NAME from LATHE_INFO ";
            ds = helper.ExecuteDataSet(sql, paramList.ToArray());
            return ds;
        }


        
        // 删除吊挂设备信息
        public bool delete(string id)
        {
            String sql = "delete from HOISTINGEQUIPMENT_INFO  where EQUIMENT_ID = @EQUIMENT_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@EQUIMENT_ID", id));
            int result = helper.ExecuteNonQuery(sql, paramList);
            return (result > 0);
        }

        // 保存修改的吊挂设备信息
        public bool Modify(string EQUIMENT_ID, string EQUIMENT_NAME)
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

        // 保存添加的吊挂设备信息     
        public bool Save(string EQUIMENT_NAME)
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
