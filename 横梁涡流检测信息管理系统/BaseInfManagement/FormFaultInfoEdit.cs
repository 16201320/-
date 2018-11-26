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
        //string strUserId = string.Empty;  //修改时指示具体的行数据
        //bool strFlag = true; //用于判断控件是否填写了信息
       // FaultInfoDao dao = new FaultInfoDao();
        string FAULT_ID = "";
        public FormFaultInfoEdit(string strOperationFlag, DataGridViewCellCollection oneLineCarInfo)
        {
            InitializeComponent();
            if (strOperationFlag.Equals("modify"))
            {
               
                /*this.FAULT_ID = oneLineCarInfo["序号"].Value.ToString().Trim();
                this.LATHE_NAME.Text = oneLineCarInfo["车型"].Value.ToString().Trim();
                this.COLUMN_NAME.Text = oneLineCarInfo["列号"].Value.ToString().Trim();
                this.REPAIR_NAME.Text = oneLineCarInfo["修程"].Value.ToString().Trim();
                this.CARNAME.Text = oneLineCarInfo["车号"].Value.ToString().Trim();
                this.CHECK_TM.Text = oneLineCarInfo["检查时间"].Value.ToString().Trim();
                this.FAULT_BEAMID.Text = oneLineCarInfo["故障横梁号"].Value.ToString().Trim();
                this.IF_PENETRATION.Text = oneLineCarInfo["是否贯穿"].Value.ToString().Trim();
                this.FAULT_POSITION.Text = oneLineCarInfo["缺陷位置"].Value.ToString().Trim();
                this.DISTANCE1.Text = oneLineCarInfo["缺陷尖端距一位侧边梁"].Value.ToString().Trim();
                this.DISTANCE2.Text = oneLineCarInfo["缺陷尖端距二位侧边梁"].Value.ToString().Trim();
                this.LENGTH.Text = oneLineCarInfo["缺陷长度"].Value.ToString().Trim();
                this.DEPTH.Text = oneLineCarInfo["缺陷深度"].Value.ToString().Trim();
                this.EQUIMENT_NAME.Text = oneLineCarInfo["吊挂设备"].Value.ToString().Trim();
                this.PIC.Text = oneLineCarInfo["缺陷图片"].Value.ToString().Trim();
                this.MEMO.Text = oneLineCarInfo["备注"].Value.ToString().Trim();
                this.Detection_Technology_NAME.Text = oneLineCarInfo["检测技术"].Value.ToString().Trim();
                this.INCREASE.Text = oneLineCarInfo["增加幅度"].Value.ToString().Trim();
                this.PHASE.Text = oneLineCarInfo["相位"].Value.ToString().Trim();
                this.FREQUENCY.Text = oneLineCarInfo["频率"].Value.ToString().Trim();
                this.FRONT.Text = oneLineCarInfo["前置"].Value.ToString().Trim();
                this.GAIN.Text = oneLineCarInfo["增益"].Value.ToString().Trim();
                this.GAIN_RATIO.Text = oneLineCarInfo["增益比"].Value.ToString().Trim();
                this.LOWPASS.Text = oneLineCarInfo["低通"].Value.ToString().Trim();
                this.HIGHPASS.Text = oneLineCarInfo["高通"].Value.ToString().Trim();
                this.DIGITAL_FILTERING.Text = oneLineCarInfo["数字滤波"].Value.ToString().Trim();
                this.ARTIFICIAL_DEFECT_WIDTH.Text = oneLineCarInfo["人工缺陷长度"].Value.ToString().Trim();
                this.ARTIFICIAL_DEFECT_WIDTH.Text = oneLineCarInfo["人工缺陷宽度"].Value.ToString().Trim();
                this.ARTIFICIAL_DEFECT_HEIGHT.Text = oneLineCarInfo["人工缺陷高度"].Value.ToString().Trim();
                this.INVESTIGATOR.Text = oneLineCarInfo["探伤工"].Value.ToString().Trim();
                this.TEAM_LEADER.Text = oneLineCarInfo["班主长"].Value.ToString().Trim();
                this.ENTERING_PERSON.Text = oneLineCarInfo["录入人"].Value.ToString().Trim();*/
            }
        }

        public FormFaultInfoEdit(string strOperationFlag, DataGridViewCellCollection x, GridColumnCollection oneLineCarInfo)
        {
            InitializeComponent(); 
            if (strOperationFlag.Equals("modify"))
            {
                this.FAULT_ID = oneLineCarInfo[0].ToString().Trim();
                this.LATHE_NAME.Text = oneLineCarInfo[1].ToString().Trim();
                this.COLUMN_NAME.Text = oneLineCarInfo[2].ToString().Trim();
                this.REPAIR_NAME.Text = oneLineCarInfo[3].ToString().Trim();
                this.CARNAME.Text = oneLineCarInfo[4].ToString().Trim();
                this.CHECK_TM.Text = oneLineCarInfo[5].ToString().Trim();
                this.FAULT_BEAMID.Text = oneLineCarInfo[6].ToString().Trim();
                this.IF_PENETRATION.Text = oneLineCarInfo[7].ToString().Trim();
                this.FAULT_POSITION.Text = oneLineCarInfo[8].ToString().Trim();
                this.DISTANCE1.Text = oneLineCarInfo[9].ToString().Trim();
                this.DISTANCE2.Text = oneLineCarInfo[10].ToString().Trim();
                this.LENGTH.Text = oneLineCarInfo[11].ToString().Trim();
                this.DEPTH.Text = oneLineCarInfo[13].ToString().Trim();
                this.EQUIMENT_NAME.Text = oneLineCarInfo[12].ToString().Trim();
                //this.PIC.Text = oneLineCarInfo[14].ToString().Trim();
               // this.MEMO.Text = oneLineCarInfo[15].ToString().Trim();
                this.Detection_Technology_NAME.Text = oneLineCarInfo[16].ToString().Trim();
                this.INCREASE.Text = oneLineCarInfo[17].ToString().Trim();
                this.PHASE.Text = oneLineCarInfo[18].ToString().Trim();
                /*this.FREQUENCY.Text = oneLineCarInfo[19].ToString().Trim();
                this.FRONT.Text = oneLineCarInfo[20].ToString().Trim();
                this.GAIN.Text = oneLineCarInfo[21].ToString().Trim();
                this.GAIN_RATIO.Text = oneLineCarInfo[22].ToString().Trim();
                this.LOWPASS.Text = oneLineCarInfo[23].ToString().Trim();
                this.HIGHPASS.Text = oneLineCarInfo[24].ToString().Trim();
                this.DIGITAL_FILTERING.Text = oneLineCarInfo[25].ToString().Trim();
                this.ARTIFICIAL_DEFECT_LENGTH.Text = oneLineCarInfo[26].ToString().Trim();
                this.ARTIFICIAL_DEFECT_WIDTH.Text = oneLineCarInfo[27].ToString().Trim();
                this.ARTIFICIAL_DEFECT_HEIGHT.Text = oneLineCarInfo[28].ToString().Trim();*/
               // this.INVESTIGATOR.Text = oneLineCarInfo[29].ToString().Trim();
                //this.TEAM_LEADER.Text = oneLineCarInfo[30].ToString().Trim();
                //this.ENTERING_PERSON.Text = oneLineCarInfo[31].ToString().Trim();
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

        private void labelControl22_Click(object sender, EventArgs e)
        {

        }

        private void CARNAME_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void LATHE_NAME_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
