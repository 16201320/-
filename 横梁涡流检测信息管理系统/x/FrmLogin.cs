using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EddyCurrentTesting.SystemSetting;
using System.Data.SqlClient;
using System.Data.Common;

namespace EddyCurrentTesting
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string account = txtAccount.Text.Trim();
            string password = txtPassword.Text.Trim();

            DLLAdmin dll = new DLLAdmin();

            if (dll.Login(account, password))
            {
                Frm_main frm = new Frm_main(this,getAdminName(account));
                frm.Show();
                Frm_main.admin = account;             
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
