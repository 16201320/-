using DevExpress.XtraGrid.Columns;
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
    public partial class FormFaultInfoEdit : Form
    {
        string strOperationFlag = string.Empty;  //指示操作是“添加”还是“修改”
        string FAULT_ID = string.Empty;  //修改时指示具体的行数据
        public FormFaultInfoEdit(string strOperationFlag, Dictionary<string, string> dic)
        {
            InitializeComponent();
            if (strOperationFlag.Equals("modify"))
            {
                this.FAULT_ID = dic["序号"].ToString().Trim();
                this.LATHE_NAME.Text = dic["车型"].ToString().Trim();
                this.COLUMN_NAME.Text = dic["列号"].ToString().Trim();
                this.REPAIR_NAME.Text = dic["修程"].ToString().Trim();
                this.CARNAME.Text = dic["车号"].ToString().Trim();
                this.CHECK_TM.Text = dic["检查时间"].ToString().Trim();
                this.FAULT_BEAMID.Text = dic["故障横梁号"].ToString().Trim();
                this.IF_PENETRATION.Text = dic["是否贯穿"].ToString().Trim();
                this.FAULT_POSITION.Text = dic["缺陷位置"].ToString().Trim();
                this.DISTANCE1.Text = dic["缺陷尖端距一位侧边梁"].ToString().Trim();
                this.DISTANCE2.Text = dic["缺陷尖端距二位侧边梁"].ToString().Trim();
                this.LENGTH.Text = dic["缺陷长度"].ToString().Trim();
                this.DEPTH.Text = dic["缺陷深度"].ToString().Trim();
                this.EQUIMENT_NAME.Text = dic["吊挂设备"].ToString().Trim();
                this.Detection_Technology_NAME.Text = dic["检测技术"].ToString().Trim();
                this.INCREASE.Text = dic["信号幅值"].ToString().Trim();
                this.PHASE.Text = dic["信号相位"].ToString().Trim();
                this.INVESTIGATOR.Text = dic["探伤工"].ToString().Trim();
                this.TEAM_LEADER.Text = dic["班主长"].ToString().Trim();
                this.ENTERING_PERSON.Text = dic["录入人"].ToString().Trim();
            }
        }


                private void labelControl16_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
