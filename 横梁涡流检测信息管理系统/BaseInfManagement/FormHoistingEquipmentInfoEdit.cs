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
    public partial class FormHoistingEquipmentInfoEdit : Form
    {
        string strOperationFlag = string.Empty;  //指示操作是“添加”还是“修改”
        string EQUIMENT_ID = string.Empty;//修改时指示具体的行数据
        public FormHoistingEquipmentInfoEdit(string strOperationFlag, Dictionary<string, string> dic)
        {
            InitializeComponent();
            this.strOperationFlag = strOperationFlag;
            if (strOperationFlag.Equals("modify"))
            {
                //设置窗口标题
                this.Text = "添加吊挂设备信息";
                //获取需要修改的信息
                this.EQUIMENT_ID = dic["设备编号"];
                this.EQUIMENT_NAME.Text = dic["设备名称"];
            }
            else
            {
                //设置窗口标题
                this.Text = "添加吊挂设备信息";
                this.EQUIMENT_NAME.Focus();
            }
        }
        //保存吊挂设备信息
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            HoistingEquipmentInfoDao dao = new HoistingEquipmentInfoDao();
            string name = EQUIMENT_NAME.Text.Trim();
            //控制参数格式
            if (name == "")
            {
                MessageBox.Show("信息不能为空！");
                return;
            }
            switch (strOperationFlag)
            {
                case "add":
                    string sql1 = "select * from HOISTINGEQUIPMENT_INFO where EQUIMENT_NAME = '" + name + "'";
                    if (common.SqlHelper.ExcuteSql(sql1) > 0)
                    {
                        MessageBox.Show("该吊挂设备已经被添加过了！", "信息提示", MessageBoxButtons.OK);
                        return;
                    }
                    dao.Save(this.EQUIMENT_NAME.Text.Trim());
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case "modify":
                    string sql2 = "select count(*) from HOISTINGEQUIPMENT_INFO where EQUIMENT_NAME = '" + name + "' and EQUIMENT_ID <> '" + EQUIMENT_ID + "'";
                    if (common.SqlHelper.ExcuteSql(sql2) > 0)
                    {
                        MessageBox.Show("该吊挂设备已经被添加过了！", "信息提示", MessageBoxButtons.OK);
                        this.EQUIMENT_NAME.Focus();
                        return;
                    }
                    dao.Modify(EQUIMENT_ID, this.EQUIMENT_NAME.Text.Trim());
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

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {


        }
    }
}
