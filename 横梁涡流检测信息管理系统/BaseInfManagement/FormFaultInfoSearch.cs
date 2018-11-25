using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 横梁涡流检测信息管理系统.BaseInfManagement
{
    public partial class FormFaultInfoSearch : Form
    {
        public string formName = "FormFaultInfoSearch";
        string gs_carlist = "select fi.[FAULT_ID] as 序号,  li.[LATHE_NAME] as 车型,lc.[COLUMN_NAME] as 列号,ri.[REPAIR_NAME] as 修程,ci.[CARNAME] as 车号,fi.[CHECK_TM] as 检查时间,fi.[FAULT_BEAMID] as 故障横梁号, fi.[IF_PENETRATION] as 是否贯穿,fi.[FAULT_POSITION] as 缺陷位置, fi.[DISTANCE1] as 缺陷尖端距一位侧边梁,fi.[DISTANCE2] as 缺陷尖端距二位侧边梁,fi.[LENGTH] as 缺陷长度,hi.[EQUIMENT_NAME] as 吊挂设备,fi.[DEPTH] as 缺陷深度,fi.[PIC] as 缺陷图片,fi.[MEMO] as 备注" +
            ",dt.[Detection_Technology_NAME] as 检测技术,fi.[INCREASE] as 增加幅度,fi.[PHASE] as 相位,fi.[FREQUENCY] as 频率,fi.[FRONT] as 前置,fi.[GAIN] as 增益,fi.[GAIN_RATIO] as 增益比,fi.[LOWPASS] as 低通, " +
            " fi.[HIGHPASS] as 高通, fi.[DIGITAL_FILTERING] as 数字滤波, fi.[ARTIFICIAL_DEFECT_LENGTH] as 人工缺陷长度, fi.[ARTIFICIAL_DEFECT_WIDTH] as 人工缺陷宽度, fi.[ARTIFICIAL_DEFECT_HEIGHT] as 人工缺陷高度, fi.[INVESTIGATOR] as 探伤工, fi.[TEAM_LEADER] as 班主长, fi.[ENTERING_PERSON] as 录入人" +
            " from FAULT_INFO fi " +
            "inner join LATHE_INFO li on fi.LATHE_ID = li.LATHE_ID " +
             "inner join LATHE_COLUMN lc on fi.COLUMN_ID = lc.COLUMN_ID " +
             "inner join REPAIRPROCESS_INFO ri on fi.REPAIR_ID = ri.REPAIR_ID " +
             "inner join HOISTINGEQUIPMENT_INFO hi on fi.EQUIMENT_ID = hi.EQUIMENT_ID " +
           "inner join CARNO_INFO ci on fi.CARID = ci.CARID " +
            "inner join DETECTION_TECHNOLOGY dt on fi.DetectionTechnology_ID = dt.DetectionTechnology_ID"
           ;
        // RepairPRocessDao dao = new RepairPRocessDao();
        DataSet ds = new DataSet();
        string strOperationFlag = string.Empty;  //指示操作是“添加”还是“修改”
        DataGridViewCellCollection oneLineCarInfo = null;  //传递要要修改的单行数据
        public FormFaultInfoSearch()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            FreshForm();
            //行高22
            gridView1.RowHeight = 32;
            //不允许编辑
            gridView1.OptionsBehavior.Editable = false;
            //不允许用户拖动列和
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //不显示右键菜单
            gridView1.OptionsMenu.EnableColumnMenu = false;
            //隐藏细节信息
            for(int i=6;i< gridView1.Columns.Count;i++)
            {
                gridView1.Columns[i].Visible = false;
            }

        }

        /// <summary>
        /// 主要是刷新DataGridView控件中的数据
        /// </summary>
        private void GetAllUserinfo(string strsql, GridControl gridControl1)
        {
            SqlCommand cmd = new SqlCommand(strsql, common.SqlHelper.GetConnection());
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        /// <summary>
        /// “添加”、“删除”和“修改”操作后刷新窗体，
        /// 主要是刷新DataGridView控件中的数据
        /// </summary>
        private void FreshForm()
        {
            this.GetAllUserinfo(gs_carlist, gridControl1);
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                strOperationFlag = "add";
                FormFaultInfoEdit frm = new FormFaultInfoEdit(strOperationFlag, oneLineCarInfo);
                frm.Owner = this;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    FreshForm();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("添加故障信息时发生错误！" + ex.Message, "提示信息");
                return;
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.RowCount == 0)
                {
                    MessageBox.Show("请选中要修改的行行");
                    return;
                }
                int selectedIndex = this.gridView1.GetSelectedRows()[0];
                if (selectedIndex < 0)
                {
                    MessageBox.Show("请选中要修改的行行");
                    return;
                }
                else
                {
                    strOperationFlag = "modify";
                    /*int a = gridView1.row
                    oneLineCarInfo = this.gridView1.rows.GetRowCellValue(selectedIndex);*/
                    GridColumnCollection x = gridView1.Columns;
                    FormFaultInfoEdit frm = new FormFaultInfoEdit(strOperationFlag, oneLineCarInfo, x);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        FreshForm();
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("修改故障信息时发生错误！" + ex.Message, "提示信息");
                return;
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.修改ToolStripMenuItem.PerformClick();
        }

        private void 详细信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 6; i < 14; i++)
            {
                gridView1.Columns[i].Visible = true;
            }
        }

        private void 缩略信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 6; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Visible = false;
            }
        }
    }
}
