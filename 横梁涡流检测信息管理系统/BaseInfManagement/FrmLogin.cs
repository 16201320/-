using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using 横梁涡流检测信息管理系统.SystemSetting;
using 横梁涡流检测信息管理系统.BaseInfManagement;
using System.Threading;

namespace 横梁涡流检测信息管理系统
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            Thread oth = new Thread(new ThreadStart(work.DoMoreWork));
            oth.Start();
            InitializeComponent();         
        }

        // 预先载入缺陷消息窗口，防止卡顿
        class work
        {
            [STAThread]
            public static void DoMoreWork()
            {
                FormFaultInfoEdit f = new FormFaultInfoEdit("add", null);
                f.Size = new Size(-1, -1);
                f.FormBorderStyle = FormBorderStyle.None;
                f.Visible = false;
                f.Show();
                f.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string account = txtAccount.Text.Trim();
            string password = txtPassword.Text.Trim();

            DLLAdmin dll = new DLLAdmin();

            if (dll.Login(account, password))
            {
                Frm_main frm = new Frm_main(this, getAdminName(account));
                Frm_main.account = account;
                Frm_main.userType = getAccountType(account);
                Frm_main.userName = getAccountName(account);
                frm.Show();
                txtAccount.Text = "";
                txtPassword.Text = "";
                this.Hide();
            }
            else
            {
                MessageBox.Show("用户名或密码不正确，请重试！");
            }
        }

        public string getAdminName(string account)
        {
            String sql = "select * from ADMIN_INFO where account = '" + account + "'";
            SqlCommand sqlCommand = new SqlCommand(sql, common.SqlHelper.GetConnection());

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "admin_info");
            string name = dataSet.Tables["admin_info"].Rows[0]["Name"].ToString();
            return name;
        }

        public string getAccountType(string account)
        {
            String sql = "select * from ADMIN_INFO where account = '" + account + "'";
            SqlCommand sqlCommand = new SqlCommand(sql, common.SqlHelper.GetConnection());

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "admin_info");
            string name = dataSet.Tables["admin_info"].Rows[0]["ACCOUNT_TYPE"].ToString();
            return name;
        }

        public string getAccountName(string account)
        {
            String sql = "select * from ADMIN_INFO where account = '" + account + "'";
            SqlCommand sqlCommand = new SqlCommand(sql, common.SqlHelper.GetConnection());

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "admin_info");
            string name = dataSet.Tables["admin_info"].Rows[0]["NAME"].ToString();
            return name;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }
    }
}
