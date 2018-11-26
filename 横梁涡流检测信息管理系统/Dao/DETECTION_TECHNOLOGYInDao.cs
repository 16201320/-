using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using common;

namespace EddyCurrentTesting
{
    public class DETECTION_TECHNOLOGYInDao
    {
        SqlHelper helper = null;
        public DETECTION_TECHNOLOGYInDao()
        {
            helper = new SqlHelper();
        }
        //查询所有可用检测技术
        public DataSet getList()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> paramList = new List<SqlParameter>();
            string sql = "select DetectionTechnology_ID, Detection_Technology_NAME from DETECTION_TECHNOLOGY ";
            ds = helper.ExecuteDataSet(sql, paramList.ToArray());
            return ds;
        }



        // 删除检测技术信息
        public bool delete(string id)
        {
            String sql = "delete from DETECTION_TECHNOLOGY  where DetectionTechnology_ID = @DetectionTechnology_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DetectionTechnology_ID", id));
            int result = helper.ExecuteNonQuery(sql, paramList);
            return (result > 0);
        }

        // 保存修改的检测技术信息
        public bool Modify(string DetectionTechnology_ID, string Detection_Technology_NAME)
        {
            bool ret = false;
            string sql = "update DETECTION_TECHNOLOGY set Detection_Technology_NAME = @Detection_Technology_NAME where DetectionTechnology_ID = @DetectionTechnology_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Detection_Technology_NAME", Detection_Technology_NAME));
            paramList.Add(new SqlParameter("@DetectionTechnology_ID", DetectionTechnology_ID));
            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }
            return ret;
        }

        // 保存添加的检测技术信息     
        public bool Save(string Detection_Technology_NAME)
        {
            bool ret = false;
            string sql = "insert into DETECTION_TECHNOLOGY (Detection_Technology_NAME)  " +
                                " values(@Detection_Technology_NAME) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Detection_Technology_NAME", Detection_Technology_NAME));

            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }
            return ret;
        }



    }
}
