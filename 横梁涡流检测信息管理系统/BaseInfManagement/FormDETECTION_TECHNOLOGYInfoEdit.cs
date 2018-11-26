using EddyCurrentTesting;
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
    public partial class FormDETECTION_TECHNOLOGYInfoEdit : Form
    { 
        string strOperationFlag = string.Empty;  //指示操作是“添加”还是“修改”
        string DetectionTechnology_ID = string.Empty;//修改时指示具体的行数据
        public FormDETECTION_TECHNOLOGYInfoEdit(string strOperationFlag, Dictionary<string, string> dic)
        {
            InitializeComponent();
            this.strOperationFlag = strOperationFlag;
            if (strOperationFlag.Equals("modify"))
            {
                //设置窗口标题
                this.Text = "添加检测技术信息";
                //获取需要修改的信息
                this.DetectionTechnology_ID = dic["检测技术编号"];
                this.Detection_Technology_NAME.Text = dic["检测技术名称"];
            }
            else
            {
                //设置窗口标题
                this.Text = "添加检测技术信息";

                this.Detection_Technology_NAME.Focus();
            }
        }
        //保存检测技术信息
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DETECTION_TECHNOLOGYInDao dao = new DETECTION_TECHNOLOGYInDao();
            string name = Detection_Technology_NAME.Text.Trim();
            //控制参数格式
            if (name == "")
            {
                MessageBox.Show("信息不能为空！");
                return;
            }
            switch (strOperationFlag)
            {
                case "add":
                    string sql1 = "select * from DETECTION_TECHNOLOGY where Detection_Technology_NAME = '" + name + "'";
                    if (common.SqlHelper.ExcuteSql(sql1) > 0)
                    {
                        MessageBox.Show("该检测技术已被添加过！", "信息提示", MessageBoxButtons.OK);
                        return;
                    }
                    dao.Save(this.Detection_Technology_NAME.Text.Trim());
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case "modify":
                    string sql2 = "select count(*) from DETECTION_TECHNOLOGY where Detection_Technology_NAME = '" + name + "' and DetectionTechnology_ID <> '" + DetectionTechnology_ID + "'";
                    if (common.SqlHelper.ExcuteSql(sql2) > 0)
                    {
                        MessageBox.Show("该检测技术已被添加过！", "信息提示", MessageBoxButtons.OK);
                        this.Detection_Technology_NAME.Focus();
                        return;
                    }
                    dao.Modify(DetectionTechnology_ID, this.Detection_Technology_NAME.Text.Trim());
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
            }
        }
        //返回
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
