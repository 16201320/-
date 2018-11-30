using DevExpress.XtraEditors.Controls;
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
    public partial class FrmAccountAdd : Form
    {
        string strOperationFlag = string.Empty;  //指示操作是“添加”还是“修改”
        string ADMIN_ID = string.Empty;  //修改时指示具体的行数据                     
        public FrmAccountAdd(string strOperationFlag, Dictionary<string, string> dic)
        {
            InitializeComponent();
            //设置账号类型下拉框
            ACCOUNT_TYPE.Properties.AutoComplete = true;
            ACCOUNT_TYPE.Properties.CycleOnDblClick = true;
            ComboBoxItemCollection coll = ACCOUNT_TYPE.Properties.Items;
            coll.Add("员工");
            coll.Add("管理员");


            this.strOperationFlag = strOperationFlag;
            if (strOperationFlag.Equals("modify"))
            {
                //设置窗口标题
                this.Text = "修改账号信息";
                //获取需要修改的信息
                this.ADMIN_ID = dic["账号编号"];
                this.ACCOUNT.Text = dic["账号"];
                this.ACCOUNT_TYPE.Text = dic["账号类型"];
                this.NAME.Text = dic["真实姓名"];
                this.PASSWORD.Text = dic["密码"];
            }
            else
            {
                //设置窗口标题
                this.Text = "添加账号信息";
                this.ACCOUNT.Focus();
            }
        }
        //保存账号信息
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DLLAdmin dao = new DLLAdmin();
            string name = ACCOUNT.Text.Trim();
            //控制参数格式
            if (name == "")
            {
                MessageBox.Show("信息不能为空！");
                return;
            }
            switch (strOperationFlag)
            {
                case "add":
                    string sql1 = "select * from ADMIN_INFO where ACCOUNT = '" + name + "'";
                    if (common.SqlHelper.ExcuteSql(sql1) > 0)
                    {
                        MessageBox.Show("该账号已经被使用！", "信息提示", MessageBoxButtons.OK);
                        return;
                    }
                    dao.add(this.ACCOUNT.Text.Trim(), this.ACCOUNT_TYPE.Text.Trim(),this.NAME.Text.Trim(),this.PASSWORD.Text.Trim());
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case "modify":
                    string sql2 = "select count(*) from ADMIN_INFO where ACCOUNT = '" + name + "' and ADMIN_ID <> '" + ADMIN_ID + "'";
                    if (common.SqlHelper.ExcuteSql(sql2) > 0)
                    {
                        MessageBox.Show("该账号已经被使用！", "信息提示", MessageBoxButtons.OK);
                        this.ACCOUNT.Focus();
                        return;
                    }
                    dao.Modify(this.ADMIN_ID, ACCOUNT.Text.Trim(), this.ACCOUNT_TYPE.Text.Trim(), this.NAME.Text.Trim(), this.PASSWORD.Text.Trim());
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
            }
        }
        
        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        //退出
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
