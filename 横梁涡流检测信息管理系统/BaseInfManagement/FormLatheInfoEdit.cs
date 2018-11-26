using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 横梁涡流检测信息管理系统.BaseInfManagement
{
    public partial class FormLatheInfoEdit : Form
    {
        string strOperationFlag = string.Empty;  //指示操作是“添加”还是“修改”
        string LATHE_ID = string.Empty;  //修改时指示具体的行数据                                                  
        public FormLatheInfoEdit(string strOperationFlag, Dictionary<string, string>  dic)
        {
            InitializeComponent();
            this.strOperationFlag = strOperationFlag;
            if (strOperationFlag.Equals("modify"))
            {
                //设置窗口标题
                this.Text = "修改车型信息";
                //获取需要修改的信息
                this.LATHE_ID = dic["车型编号"];
                this.LATHE_NAME.Text = dic["车型名称"];
            }
            else
            {
                //设置窗口标题
                this.Text = "添加车型信息";
                this.LATHE_NAME.Focus();
            }
        }



        //保存车型信息
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LatheDao dao = new LatheDao();
            string name = LATHE_NAME.Text.Trim();
            //控制参数格式
            if(name == "")
            {
                MessageBox.Show("信息不能为空！");
                return;
            }
            switch (strOperationFlag)
            {
                case "add":
                    string sql1 = "select * from LATHE_INFO where LATHE_NAME = '" + name + "'";
                    if (common.SqlHelper.ExcuteSql(sql1) > 0)
                    {
                        MessageBox.Show("该车型已经被使用，请核查！", "信息提示", MessageBoxButtons.OK);
                        return;
                    }
                    dao.Save(this.LATHE_NAME.Text.Trim());
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case "modify":
                    string sql2 = "select count(*) from LATHE_INFO where LATHE_NAME = '" + name + "' and LATHE_ID <> '" + LATHE_ID + "'";
                    if (common.SqlHelper.ExcuteSql(sql2) > 0)
                    {
                        MessageBox.Show("该车型已经被使用，请核查！", "信息提示", MessageBoxButtons.OK);
                        this.LATHE_NAME.Focus();
                        return;
                    }
                    dao.Modify(LATHE_ID, this.LATHE_NAME.Text.Trim());
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
            }
        }
        //返回按钮
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
