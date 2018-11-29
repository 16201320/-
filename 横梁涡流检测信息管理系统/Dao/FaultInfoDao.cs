using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using common;
using System.IO;
using System.Drawing;

namespace EddyCurrentTesting
{
    public class FaultInfoDao
    {
        SqlHelper helper = null;
        public FaultInfoDao()
        {
            helper = new SqlHelper();
        }


        //获取所有车型
        public DataSet getLatheList()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> paramList = new List<SqlParameter>();
            string sql = "select LATHE_ID as 编号,LATHE_NAME  as 车型 from LATHE_INFO ";
            ds = helper.ExecuteDataSet(sql, paramList.ToArray());
            return ds;
        }
        //获取所有车列
        public DataSet getLatheColummnList()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> paramList = new List<SqlParameter>();
            string sql = "select COLUMN_ID as 编号, COLUMN_NAME as 车列 from LATHE_COLUMN ";
            ds = helper.ExecuteDataSet(sql, paramList.ToArray());
            return ds;
        }


        //获取所有吊挂设备
        public DataSet setEquipmentList()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> paramList = new List<SqlParameter>();
            string sql = "select EQUIMENT_ID as 编号,EQUIMENT_NAME as 吊挂设备 from HOISTINGEQUIPMENT_INFO ";
            ds = helper.ExecuteDataSet(sql, paramList.ToArray());
            return ds;
        }
        
        //获取所有检测技术
        public DataSet setTechnologList()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> paramList = new List<SqlParameter>();
            string sql = "select DetectionTechnology_ID as 编号,Detection_Technology_NAME as 检测技术 from DETECTION_TECHNOLOGY ";
            ds = helper.ExecuteDataSet(sql, paramList.ToArray());
            return ds;
        }



        // 删除故障
        public bool delete(string id)
        {
            String sql = "delete from FAULT_INFO  where FAULT_ID = @FAULT_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@FAULT_ID", id));

            int result = helper.ExecuteNonQuery(sql, paramList);

            return (result > 0);
        }

        // 保存修改的故障信息
        public bool Modify(string FAULT_ID,
            string LATHE_NAME, string COLUMN_NAME, string REPAIR_NAME,
            string CARNAME, string EQUIMENT_NAME, string CHECK_TM,
            string Detection_Technology_NAME, string FAULT_BEAMID,
             string DISTANCE1, string DISTANCE2, string FAULT_POSITION,
              string LENGTH, string DEPTH,
               string INCREASE, string PHASE, string IF_PENETRATION,
               string INVESTIGATOR, string ENTERING_PERSON, string TEAM_LEADER)
        {
            bool ret = false;
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@FAULT_ID", FAULT_ID));

            paramList.Add(new SqlParameter("@LATHE_NAME", LATHE_NAME));
            paramList.Add(new SqlParameter("@COLUMN_NAME", COLUMN_NAME));
            paramList.Add(new SqlParameter("@REPAIR_NAME", REPAIR_NAME));

            paramList.Add(new SqlParameter("@CARNAME", CARNAME));
            paramList.Add(new SqlParameter("@EQUIMENT_NAME", EQUIMENT_NAME));
            paramList.Add(new SqlParameter("@CHECK_TM", DateTime.Parse(CHECK_TM)));

            paramList.Add(new SqlParameter("@Detection_Technology_NAME", Detection_Technology_NAME));
            paramList.Add(new SqlParameter("@FAULT_BEAMID", FAULT_BEAMID));

            paramList.Add(new SqlParameter("@DISTANCE1", DISTANCE1));
            paramList.Add(new SqlParameter("@DISTANCE2", DISTANCE2));
            paramList.Add(new SqlParameter("@FAULT_POSITION", FAULT_POSITION));

            paramList.Add(new SqlParameter("@LENGTH", LENGTH));
            paramList.Add(new SqlParameter("@DEPTH", DEPTH));

            paramList.Add(new SqlParameter("@INCREASE", INCREASE));
            paramList.Add(new SqlParameter("@PHASE", PHASE));
            paramList.Add(new SqlParameter("@IF_PENETRATION", IF_PENETRATION));

            paramList.Add(new SqlParameter("@INVESTIGATOR", INVESTIGATOR));
            paramList.Add(new SqlParameter("@ENTERING_PERSON", ENTERING_PERSON));
            paramList.Add(new SqlParameter("@TEAM_LEADER", TEAM_LEADER));

            string sql = "update FAULT_INFO set " + 
                                 " LATHE_ID = @LATHE_NAME, COLUMN_ID = @COLUMN_NAME, REPAIR_NAME = @REPAIR_NAME, " +
                                " CARNAME = @CARNAME, EQUIMENT_ID = @EQUIMENT_NAME,  CHECK_TM = @CHECK_TM, " +
                                " DetectionTechnology_ID = @Detection_Technology_NAME, FAULT_BEAMID = @FAULT_BEAMID," +
                                " DISTANCE1 = @DISTANCE1,  DISTANCE2 = @DISTANCE2,  FAULT_POSITION= @FAULT_POSITION," +
                                 "   LENGTH = @LENGTH,  DEPTH = @DEPTH," +
                                  " INCREASE = @INCREASE,  PHASE = PHASE,IF_PENETRATION = @IF_PENETRATION," +
                                  " INVESTIGATOR = @INVESTIGATOR,  ENTERING_PERSON = ENTERING_PERSON,TEAM_LEADER = @TEAM_LEADER" +
                                " where FAULT_ID = @FAULT_ID ";


            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }
            return ret;
        }

        //保存故障信息
        public bool Save(string LATHE_NAME, string COLUMN_NAME, string REPAIR_NAME, 
            string CARNAME, string EQUIMENT_NAME, string CHECK_TM,
            string Detection_Technology_NAME, string FAULT_BEAMID,
             string DISTANCE1, string DISTANCE2, string FAULT_POSITION,                           
              string LENGTH,  string DEPTH,
               string INCREASE, string PHASE, string IF_PENETRATION ,
               string INVESTIGATOR, string ENTERING_PERSON, string TEAM_LEADER)
        {
            
            bool ret = false; 
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@LATHE_NAME", LATHE_NAME));
            paramList.Add(new SqlParameter("@COLUMN_NAME", COLUMN_NAME));
            paramList.Add(new SqlParameter("@REPAIR_NAME", REPAIR_NAME));

            paramList.Add(new SqlParameter("@CARNAME", CARNAME));
            paramList.Add(new SqlParameter("@EQUIMENT_NAME", EQUIMENT_NAME));
            paramList.Add(new SqlParameter("@CHECK_TM", DateTime.Parse(CHECK_TM)));

            paramList.Add(new SqlParameter("@Detection_Technology_NAME", Detection_Technology_NAME));
            paramList.Add(new SqlParameter("@FAULT_BEAMID", FAULT_BEAMID));

            paramList.Add(new SqlParameter("@DISTANCE1", DISTANCE1));
            paramList.Add(new SqlParameter("@DISTANCE2", DISTANCE2));
            paramList.Add(new SqlParameter("@FAULT_POSITION", FAULT_POSITION));

            paramList.Add(new SqlParameter("@LENGTH", LENGTH));
            paramList.Add(new SqlParameter("@DEPTH", DEPTH));

            paramList.Add(new SqlParameter("@INCREASE", INCREASE));
            paramList.Add(new SqlParameter("@PHASE", PHASE));
            paramList.Add(new SqlParameter("@IF_PENETRATION", IF_PENETRATION));

            paramList.Add(new SqlParameter("@INVESTIGATOR", INVESTIGATOR));
            paramList.Add(new SqlParameter("@ENTERING_PERSON", ENTERING_PERSON));
            paramList.Add(new SqlParameter("@TEAM_LEADER", TEAM_LEADER));

            string sql = "insert into FAULT_INFO ( LATHE_ID,  COLUMN_ID,  REPAIR_NAME, CARNAME,  EQUIMENT_ID, CHECK_TM,DetectionTechnology_ID,  FAULT_BEAMID,DISTANCE1,  DISTANCE2,  FAULT_POSITION,LENGTH,   DEPTH,INCREASE,  PHASE,  IF_PENETRATION,INVESTIGATOR,  ENTERING_PERSON,  TEAM_LEADER)  " +
                  " values(@LATHE_NAME,  @COLUMN_NAME,  @REPAIR_NAME, @CARNAME,  @EQUIMENT_NAME, @CHECK_TM,@Detection_Technology_NAME,  @FAULT_BEAMID,@DISTANCE1,  @DISTANCE2,  @FAULT_POSITION,@LENGTH,   @DEPTH,@INCREASE,  @PHASE,  @IF_PENETRATION,@INVESTIGATOR,  @ENTERING_PERSON,  @TEAM_LEADER)  ";
            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }
            return ret;
        }

    }
}
