using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using common;

namespace EddyCurrentTesting
{
    public class UserDao
    {
        SqlHelper helper = null;
        public UserDao()
        {
            helper = new SqlHelper();
        }

        /// <summary>
        /// 查询所有符合条件的用户信息
        /// </summary>
        /// <returns>查询到的用户信息数据集</returns>
        public DataSet ListUser()
        {
            //DataSet ds = new DataSet();
            //List<SqlParameter> paramList = new List<SqlParameter>();
            ////string sql = "select a.*, b.dept_nm, car_info.plate_no  from user_info a, departments b, car_info where 1 = 1 ";
            //string sql = "select a.*, b.dept_nm, car_info.plate_no  from user_info a, departments b, car_info where a.dept_id=b.dept_id  ";

            //ds = helper.ExecuteDataSet(sql, paramList.ToArray());

            //return ds;


            //以下为以前的代码，没有对多个表进行拼接
            DataSet ds = new DataSet();
            List<SqlParameter> paramList = new List<SqlParameter>();
            string sql = "select * from USER_INFO where 1 = 1 ";
            ds = helper.ExecuteDataSet(sql, paramList.ToArray());
            return ds;
        }

        public DataSet ListUserWithDeptCarNO()
        {
            string sql = "select * from vw_user_dept_car ";
            DataSet ds = helper.ExecuteDataSetSql(sql);

            return ds;
        }

        /// <summary>
        /// </summary>
        /// <returns>查询到的用户ID信息数据集</returns>
        public DataSet ListUserId()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> paramList = new List<SqlParameter>();
            string sql = "select USER_ID from USER_INFO where 1 = 1 ";

            ds = helper.ExecuteDataSet(sql, paramList.ToArray());

            return ds;
        }

        /// <summary>
        /// </summary>
        /// <returns>查询到的用户ID信息数据集</returns>
        public DataSet ListUserIdNew()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> paramList = new List<SqlParameter>();
            string sql = "select USER_ID, NAME from USER_INFO where 1 = 1 ";

            ds = helper.ExecuteDataSet(sql, paramList.ToArray());

            return ds;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">给定的用户内码</param>
        /// <returns>true --删除成功,  false--删除失败</returns>
        public bool deleteUser(string id)
        {
            String sql = "delete from USER_INFO  where user_id = @user_id";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@user_id", id));

            int result = helper.ExecuteNonQuery(sql, paramList);

            return (result > 0);
        }

        /// <summary>
        /// 保存修改的用户信息，用于保存编辑后的用户信息
        /// </summary>   
        public bool ModifyUser(string id, string deptId, string cardNumber, string frstCar, string scndCar,
                               string ssn, string name, string sex, string title, string mPhone, string shrtNum,
                               string hmPhone, string hiredDt, string hmAddr, string userTp, string nation,
                               string userStatus)
        {
            bool ret = false;

            string sql = "update USER_INFO set dept_id = @dept_id, card_number = @cardNumber, frst_car = @frst_car," +
                          "scnd_car = @scnd_car, ssn = @ssn, name = @name, sex = @sex, title = @title," +
                          "m_phone = @m_phone, shrt_num = @shrt_num, hm_phone = @hm_phone, hired_dt = @hired_dt," +
                          "hm_addr = @hm_addr, user_tp = @user_tp, nation = @nation, " +  
                          "user_status = @user_status where user_id = @user_id";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@dept_id", deptId));
            paramList.Add(new SqlParameter("@cardNumber", cardNumber));
            paramList.Add(new SqlParameter("@frst_car", frstCar));
            paramList.Add(new SqlParameter("@scnd_car", scndCar));
            paramList.Add(new SqlParameter("@ssn", ssn));
            paramList.Add(new SqlParameter("@name", name));
            paramList.Add(new SqlParameter("@sex", sex));
            paramList.Add(new SqlParameter("@title", title));
            paramList.Add(new SqlParameter("@m_phone", mPhone));
            paramList.Add(new SqlParameter("@shrt_num", shrtNum));
            paramList.Add(new SqlParameter("@hm_phone", hmPhone));
            paramList.Add(new SqlParameter("@hired_dt", DateTime.Parse(hiredDt)));
            paramList.Add(new SqlParameter("@hm_addr", hmAddr));
            paramList.Add(new SqlParameter("@user_tp", userTp));
            paramList.Add(new SqlParameter("@nation", nation));
            paramList.Add(new SqlParameter("@user_status", userStatus));

            paramList.Add(new SqlParameter("@user_id", id));

            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }

            return ret;
        }

        /// <summary>
        /// 保存添加的用户信息
        /// </summary>
        public bool SaveUser(string deptId, string cardNumber, string frstCar, string scndCar,
                               string ssn, string name, string sex, string title, string mPhone, string shrtNum,
                               string hmPhone, string hiredDt, string hmAddr, string userTp, string nation,
                               string userStatus)
        {
            bool ret = false;
            string sql = "insert into USER_INFO (dept_id, card_Number, frst_car, scnd_car, ssn, name, sex, title, m_phone, " + 
                         "shrt_num, hm_phone, hired_dt, hm_addr, user_tp, nation, user_status)  " +
                         " values(@dept_id, @cardNumber, @frst_car, @scnd_car, @ssn, @name, @sex, @title, @m_phone, " +
                         " @shrt_num, @hm_phone, @hired_dt, @hm_addr, @user_tp, @nation, @user_status) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@dept_id", deptId));
            paramList.Add(new SqlParameter("@cardNumber", cardNumber));
            paramList.Add(new SqlParameter("@frst_car", frstCar));
            paramList.Add(new SqlParameter("@scnd_car", scndCar));
            paramList.Add(new SqlParameter("@ssn", ssn));
            paramList.Add(new SqlParameter("@name", name));
            paramList.Add(new SqlParameter("@sex", sex));
            paramList.Add(new SqlParameter("@title", title));
            paramList.Add(new SqlParameter("@m_phone", mPhone));
            paramList.Add(new SqlParameter("@shrt_num", shrtNum));
            paramList.Add(new SqlParameter("@hm_phone", hmPhone));
            paramList.Add(new SqlParameter("@hired_dt", DateTime.Parse(hiredDt)));
            paramList.Add(new SqlParameter("@hm_addr", hmAddr));
            paramList.Add(new SqlParameter("@user_tp", userTp));
            paramList.Add(new SqlParameter("@nation", nation));
            paramList.Add(new SqlParameter("@user_status", userStatus));

            int result = helper.ExecuteNonQuery(sql, paramList);
            if (result >= 1)
            {
                ret = true;
            }

            return ret;
        }

        /// <summary>
        /// 根据用户内码查找用户记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet getUser(string id)
        {
            String sql = "select * from USER_INFO where id = @id";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@id", id));
            DataSet ds = helper.ExecuteDataSet(sql, paramList.ToArray());

            return ds;
        }

        /// <summary>
        /// 重置用户的密码
        /// </summary>
        /// <param name="id">用户内码</param>
        /// <returns>操作成功与否</returns>
        public bool ResetPassword(string id)
        {
            String sql = "update Tuser set password = '000000' where id = @id";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@id", id));

            int result = helper.ExecuteNonQuery(sql, paramList);

            return (result > 0);
        }
    }
}
