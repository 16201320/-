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


        /// <summary>
        /// 查询所有符合条件的可用故障信息
        /// </summary>
        /// <returns>查询到的车辆ID信息数据集</returns>
        public DataSet List1()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> paramList = new List<SqlParameter>();
            string sql = "select LATHE_ID, LATHE_NAME from LATHE_INFO ";

            ds = helper.ExecuteDataSet(sql, paramList.ToArray());

            return ds;
        }

        public DataSet List2()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> paramList = new List<SqlParameter>();
            string sql = "select COLUMN_ID, COLUMN_NAME from LATHE_COLUMN ";

            ds = helper.ExecuteDataSet(sql, paramList.ToArray());

            return ds;
        }

        public DataSet List3()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> paramList = new List<SqlParameter>();
            string sql = "select REPAIR_ID, REPAIR_NAME from REPAIRPROCESS_INFO ";

            ds = helper.ExecuteDataSet(sql, paramList.ToArray());

            return ds;
        }

        public DataSet List4()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> paramList = new List<SqlParameter>();
            string sql = "select CARID, CARNAME from CARNO_INFO ";

            ds = helper.ExecuteDataSet(sql, paramList.ToArray());

            return ds;
        }

        public DataSet List5()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> paramList = new List<SqlParameter>();
            string sql = "select EQUIMENT_ID, EQUIMENT_NAME from HOISTINGEQUIPMENT_INFO ";

            ds = helper.ExecuteDataSet(sql, paramList.ToArray());

            return ds;
        }


        /// <summary>
        /// 删除故障
        /// </summary>
        /// <param name="id">给定的故障内码</param>
        /// <returns>true --删除成功,  false--删除失败</returns>
        public bool deleteCar(string id)
        {
            String sql = "delete from FAULT_INFO  where FAULT_ID = @FAULT_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@FAULT_ID", id));

            int result = helper.ExecuteNonQuery(sql, paramList);

            return (result > 0);
        }

        /// <summary>
        /// 保存修改的故障信息，用于保存编辑后的故障信息
        /// </summary>
        public bool ModifyCar(string FAULT_ID, string LATHE_ID, string COLUMN_ID, string REPAIR_ID, string CARID,
                            string CHECK_TM, string FAULT_BEAMID, string IF_PENETRATION, string FAULT_POSITION,
                            string DISTANCE1, string DISTANCE2, string LENGTH, string EQUIMENT_ID, string DEPTH,
                            Image PIC, string MEMO)
        {
            bool ret = false;
            string sql = "";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@LATHE_ID", LATHE_ID));
            paramList.Add(new SqlParameter("@COLUMN_ID", COLUMN_ID));
            paramList.Add(new SqlParameter("@REPAIR_ID", REPAIR_ID));
            paramList.Add(new SqlParameter("@CARID", CARID));
            paramList.Add(new SqlParameter("@CHECK_TM", DateTime.Parse(CHECK_TM)));
            paramList.Add(new SqlParameter("@FAULT_BEAMID", FAULT_BEAMID));
            paramList.Add(new SqlParameter("@IF_PENETRATION", IF_PENETRATION));
            paramList.Add(new SqlParameter("@FAULT_POSITION", FAULT_POSITION));
            paramList.Add(new SqlParameter("@DISTANCE1", DISTANCE1));
            paramList.Add(new SqlParameter("@DISTANCE2", DISTANCE2));
            paramList.Add(new SqlParameter("@LENGTH", LENGTH));
            paramList.Add(new SqlParameter("@EQUIMENT_ID", EQUIMENT_ID));
            paramList.Add(new SqlParameter("@DEPTH", DEPTH));
            paramList.Add(new SqlParameter("@MEMO", MEMO));
            paramList.Add(new SqlParameter("@FAULT_ID", FAULT_ID));
            if (PIC != null)
            {

                byte[] by = ImageHelper.ImageToBytes(PIC);
                paramList.Add(new SqlParameter("@PIC", by));
                sql = "update FAULT_INFO set " +
                                " LATHE_ID = @LATHE_ID, COLUMN_ID = @COLUMN_ID, " +
                               " REPAIR_ID = @REPAIR_ID, CARID = @CARID,  CHECK_TM = @CHECK_TM, " +
                               " FAULT_BEAMID = @FAULT_BEAMID, IF_PENETRATION = @IF_PENETRATION, FAULT_POSITION = @FAULT_POSITION,  " +
                                " DISTANCE1 = @DISTANCE1, DISTANCE2 = @DISTANCE2,  LENGTH = @LENGTH, " +
                                 " EQUIMENT_ID = @EQUIMENT_ID, DEPTH = @DEPTH, PIC = @PIC, MEMO = @MEMO " +
                               " where FAULT_ID = @FAULT_ID ";
            }
            else
            {
                sql = "update FAULT_INFO set " +
                                 " LATHE_ID = @LATHE_ID, COLUMN_ID = @COLUMN_ID, " +
                                " REPAIR_ID = @REPAIR_ID, CARID = @CARID,  CHECK_TM = @CHECK_TM, " +
                                " FAULT_BEAMID = @FAULT_BEAMID, IF_PENETRATION = @IF_PENETRATION, FAULT_POSITION = @FAULT_POSITION,  " +
                                 " DISTANCE1 = @DISTANCE1, DISTANCE2 = @DISTANCE2,  LENGTH = @LENGTH, " +
                                  " EQUIMENT_ID = @EQUIMENT_ID, DEPTH = @DEPTH,  PIC = null,MEMO = @MEMO " +
                                " where FAULT_ID = @FAULT_ID ";
            }
            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }
            return ret;
        }

        /*public bool ModifyCar(string FAULT_ID, string LATHE_ID, string COLUMN_ID, string REPAIR_ID, string CARID,
                            string CHECK_TM, string FAULT_BEAMID, string IF_PENETRATION, string FAULT_POSITION,
                            string DISTANCE1, string DISTANCE2, string LENGTH, string EQUIMENT_ID, string DEPTH,
                             string MEMO)
        {
            bool ret = false;

            string sql = "update FAULT_INFO set " +
                                 " LATHE_ID = @LATHE_ID, COLUMN_ID = @COLUMN_ID, " +
                                " REPAIR_ID = @REPAIR_ID, CARID = @CARID,  CHECK_TM = @CHECK_TM, " +
                                " FAULT_BEAMID = @FAULT_BEAMID, IF_PENETRATION = @IF_PENETRATION, FAULT_POSITION = @FAULT_POSITION,  " +
                                 " DISTANCE1 = @DISTANCE1, DISTANCE2 = @DISTANCE2,  LENGTH = @LENGTH, " +
                                  " EQUIMENT_ID = @EQUIMENT_ID, DEPTH = @DEPTH,  PIC = null,MEMO = @MEMO " +
                                " where FAULT_ID = @FAULT_ID ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@LATHE_ID", LATHE_ID));
            paramList.Add(new SqlParameter("@COLUMN_ID", COLUMN_ID));
            paramList.Add(new SqlParameter("@REPAIR_ID", REPAIR_ID));
            paramList.Add(new SqlParameter("@CARID", CARID));
            paramList.Add(new SqlParameter("@CHECK_TM", DateTime.Parse(CHECK_TM)));
            paramList.Add(new SqlParameter("@FAULT_BEAMID", FAULT_BEAMID));
            paramList.Add(new SqlParameter("@IF_PENETRATION", IF_PENETRATION));
            paramList.Add(new SqlParameter("@FAULT_POSITION", FAULT_POSITION));
            paramList.Add(new SqlParameter("@DISTANCE1", DISTANCE1));
            paramList.Add(new SqlParameter("@DISTANCE2", DISTANCE2));
            paramList.Add(new SqlParameter("@LENGTH", LENGTH));
            paramList.Add(new SqlParameter("@EQUIMENT_ID", EQUIMENT_ID));
            paramList.Add(new SqlParameter("@DEPTH", DEPTH));
            paramList.Add(new SqlParameter("@MEMO", MEMO));
            paramList.Add(new SqlParameter("@FAULT_ID", FAULT_ID));

            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }
            return ret;
        }
        */
        /// <summary>
        /// 保存故障信息
        /// </summary>       
        /// (this.LATHE_NAME.SelectedValue.ToString().Trim(), this.COLUMN_NAME.SelectedValue.ToString().Trim(),

        public bool SaveCar(Image a,string LATHE_ID, string COLUMN_ID, string REPAIR_ID, string CARID,
                            string CHECK_TM, string FAULT_BEAMID, string IF_PENETRATION, string FAULT_POSITION,
                            string DISTANCE1, string DISTANCE2, string LENGTH, string EQUIMENT_ID, string DEPTH,
                            string MEMO)
        {
            bool ret = false;
            string sql = ""; 
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@LATHE_ID", LATHE_ID));
            paramList.Add(new SqlParameter("@COLUMN_ID", COLUMN_ID));
            paramList.Add(new SqlParameter("@REPAIR_ID", REPAIR_ID));
            paramList.Add(new SqlParameter("@CARID", CARID));
            paramList.Add(new SqlParameter("@CHECK_TM", DateTime.Parse(CHECK_TM)));
            paramList.Add(new SqlParameter("@FAULT_BEAMID", FAULT_BEAMID));
            paramList.Add(new SqlParameter("@IF_PENETRATION", IF_PENETRATION));
            paramList.Add(new SqlParameter("@FAULT_POSITION", FAULT_POSITION));
            paramList.Add(new SqlParameter("@DISTANCE1", DISTANCE1));
            paramList.Add(new SqlParameter("@DISTANCE2", DISTANCE2));
            paramList.Add(new SqlParameter("@LENGTH", LENGTH));
            paramList.Add(new SqlParameter("@EQUIMENT_ID", EQUIMENT_ID));
            paramList.Add(new SqlParameter("@DEPTH", DEPTH));
            paramList.Add(new SqlParameter("@MEMO", MEMO));
            if (a != null)
            {

                byte[] by = ImageHelper.ImageToBytes(a);
                paramList.Add(new SqlParameter("@PIC", by));
                sql = "insert into FAULT_INFO (LATHE_ID, COLUMN_ID, REPAIR_ID, CARID, CHECK_TM, FAULT_BEAMID, IF_PENETRATION, FAULT_POSITION,DISTANCE1,DISTANCE2,LENGTH,EQUIMENT_ID,DEPTH,PIC,MEMO)  " +
                                " values(@LATHE_ID, @COLUMN_ID, @REPAIR_ID, @CARID, @CHECK_TM, @FAULT_BEAMID, @IF_PENETRATION, @FAULT_POSITION,@DISTANCE1,@DISTANCE2,@LENGTH,@EQUIMENT_ID,@DEPTH,@PIC,@MEMO) ";
            }
            else
            {
                sql = "insert into FAULT_INFO (LATHE_ID, COLUMN_ID, REPAIR_ID, CARID, CHECK_TM, FAULT_BEAMID, IF_PENETRATION, FAULT_POSITION,DISTANCE1,DISTANCE2,LENGTH,EQUIMENT_ID,DEPTH,MEMO)  " +
                                " values(@LATHE_ID, @COLUMN_ID, @REPAIR_ID, @CARID, @CHECK_TM, @FAULT_BEAMID, @IF_PENETRATION, @FAULT_POSITION,@DISTANCE1,@DISTANCE2,@LENGTH,@EQUIMENT_ID,@DEPTH,@MEMO) ";
            } 
            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }

            return ret;
        }

    }
}
