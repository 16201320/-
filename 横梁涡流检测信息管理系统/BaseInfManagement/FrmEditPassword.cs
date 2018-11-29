using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 横梁涡流检测信息管理系统.SystemSetting;

namespace 横梁涡流检测信息管理系统.BaseInfManagement
{
    public partial class FrmEditPassword : Form
    {
        public FrmEditPassword()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string account = Frm_main.account;
            string oldPwd = txtOldPwd.Text.Trim();
            string newPwd = txtNewPwd.Text.Trim();
            string newPwd2 = txtNewPwd2.Text.Trim();

            DLLAdmin dll = new DLLAdmin();


            if (oldPwd == dll.GetPassword(account))
            {
                if (newPwd != newPwd2)
                {
                    MessageBox.Show("两次密码不一致！");
                    txtNewPwd.Focus();
                    return;
                }
                dll.ChangePassword(account, newPwd);
                MessageBox.Show("修改密码成功！");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("原密码错误！");
                txtNewPwd.Focus();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
