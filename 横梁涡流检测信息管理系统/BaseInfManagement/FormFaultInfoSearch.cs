using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using EddyCurrentTesting;
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
        string gs_carlist = "select fi.[FAULT_ID] as 序号,  li.[LATHE_NAME] as 车型,lc.[COLUMN_NAME] as 列号,fi.[REPAIR_NAME] as 修程,fi.[CARNAME] as 车号,hi.[EQUIMENT_NAME] as 吊挂设备,fi.[CHECK_TM] as 检查时间,fi.[FAULT_BEAMID] as 故障横梁, fi.[DISTANCE1] as 一位侧距,fi.[DISTANCE2] as 二位侧距,fi.[FAULT_POSITION] as 缺陷位置, fi.[LENGTH] as 缺陷长度,fi.[DEPTH] as 缺陷深度,fi.[IF_PENETRATION] as 是否贯穿 " +
            ",dt.[Detection_Technology_NAME] as 检测技术 " +
            " ,fi.[INCREASE] as 信号幅值, fi.[PHASE] as 信号相位, " +
            " fi.[INVESTIGATOR] as 探伤工, fi.[TEAM_LEADER] as 班组长, fi.[ENTERING_PERSON] as 录入人" +
            " from FAULT_INFO fi " +
            "inner join LATHE_INFO li on fi.LATHE_ID = li.LATHE_ID " +
             "inner join LATHE_COLUMN lc on fi.COLUMN_ID = lc.COLUMN_ID " +
             "inner join HOISTINGEQUIPMENT_INFO hi on fi.EQUIMENT_ID = hi.EQUIMENT_ID " +
            "inner join DETECTION_TECHNOLOGY dt on fi.DetectionTechnology_ID = dt.DetectionTechnology_ID " +
            "order by FAULT_ID desc"
           ;
        FaultInfoDao dao = new FaultInfoDao();
        string strOperationFlag = string.Empty;  //指示操作是“添加”还是“修改”
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
            gridControl1.UseEmbeddedNavigator = true;//设置滑动条


            //设置下拉框内容
            setLatheCombo();
            setLatheColummn();
            setEquipment();
            //setTechnolog();
            setPenetration();
        }

        //获取车型列表
        private void setLatheCombo()
        {
            DataSet ds = new DataSet();
            ds = dao.getLatheList();
            LATHE_NAME.Properties.NullText = "";
            this.LATHE_NAME.Properties.DataSource = ds.Tables[0];
            this.LATHE_NAME.Properties.ValueMember = "编号";
            this.LATHE_NAME.Properties.DisplayMember = "车型";

        }

        //获取车列列表
        private void setLatheColummn()
        {
            COLUMN_NAME.Properties.TextEditStyle = TextEditStyles.Standard;//设置可以编辑
            COLUMN_NAME.Properties.PopupFilterMode = PopupFilterMode.Contains;//设置查找模式为包含
            COLUMN_NAME.Properties.ImmediatePopup = true;
            DataSet ds = new DataSet();
            ds = dao.getLatheColummnList();
            COLUMN_NAME.Properties.NullText = "";
            this.COLUMN_NAME.Properties.DataSource = ds.Tables[0];
            this.COLUMN_NAME.Properties.ValueMember = "编号";
            this.COLUMN_NAME.Properties.DisplayMember = "车列";
        }

        //获取吊挂设备列表
        private void setEquipment()
        {
            DataSet ds = new DataSet();
            ds = dao.setEquipmentList();
            EQUIMENT_NAME.Properties.NullText = "";
            this.EQUIMENT_NAME.Properties.DataSource = ds.Tables[0];
            this.EQUIMENT_NAME.Properties.ValueMember = "编号";
            this.EQUIMENT_NAME.Properties.DisplayMember = "吊挂设备";
        }

       /* //获取检测技术列表
        private void setTechnolog()
        {
            DataSet ds = new DataSet();
            ds = dao.setTechnologList();
            Detection_Technology_NAME.Properties.NullText = "";
            this.Detection_Technology_NAME.Properties.DataSource = ds.Tables[0];
            this.Detection_Technology_NAME.Properties.ValueMember = "编号";
            this.Detection_Technology_NAME.Properties.DisplayMember = "检测技术";
            //Detection_Technology_NAME.EditValue
        }*/

        //获取是否贯穿列表
        private void setPenetration()
        {
            // IF_PENETRATION.Properties.TextEditStyle = TextEditStyles.Standard;
            IF_PENETRATION.Properties.AutoComplete = true;
            IF_PENETRATION.Properties.CycleOnDblClick = true;
            ComboBoxItemCollection coll = IF_PENETRATION.Properties.Items;
            coll.Add("是");
            coll.Add("否");
        }



        //设置面板信息
        private void GetAllUserinfo(string strsql, GridControl gridControl1)
        {
            SqlCommand cmd = new SqlCommand(strsql, common.SqlHelper.GetConnection());
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        //刷新面板显示所有信息
        public  void FreshForm()
        {
            this.GetAllUserinfo(gs_carlist, gridControl1);
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                strOperationFlag = "add";
                FormFaultInfoEdit frm = new FormFaultInfoEdit(strOperationFlag, null);
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
                if (this.gridView1.RowCount == 0 || this.gridView1.GetSelectedRows()[0] < 0)
                {
                    MessageBox.Show("请选中要修改的行行");
                    return;
                }
                strOperationFlag = "modify";
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("序号", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[0]).ToString());
                dic.Add("车型", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[1]).ToString());
                dic.Add("列号", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[2]).ToString());
                dic.Add("修程", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[3]).ToString());
                dic.Add("车号", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[4]).ToString());
                dic.Add("吊挂设备", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[5]).ToString());
                dic.Add("检查时间", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[6]).ToString());
                dic.Add("故障横梁号", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[7]).ToString());
                dic.Add("缺陷尖端距一位侧边梁", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[8]).ToString());
                dic.Add("缺陷尖端距二位侧边梁", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[9]).ToString());
                dic.Add("缺陷位置", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[10]).ToString());
                dic.Add("缺陷长度", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[11]).ToString());
                dic.Add("缺陷深度", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[12]).ToString());
                dic.Add("是否贯穿", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[13]).ToString());
                dic.Add("检测技术", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[14]).ToString());
                dic.Add("信号幅值", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[15]).ToString());
                dic.Add("信号相位", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[16]).ToString());
                dic.Add("探伤工", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[17]).ToString());
                dic.Add("班主长", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[18]).ToString());
                dic.Add("录入人", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[19]).ToString());

                FormFaultInfoEdit frm = new FormFaultInfoEdit(strOperationFlag, dic);
                frm.Owner = this;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    FreshForm();
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
            try
            {
                if (this.gridView1.RowCount > 0)
                {
                    if (this.gridView1.GetSelectedRows()[0] < 0)
                    {
                        MessageBox.Show("没有选中信息，请选择！", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show("确认删除故障信息", "确认信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            /*tring strCarId = this.dgv_carlist.Rows[this.dgv_carlist.SelectedCells[0].RowIndex].Cells["车号编号"].Value.ToString().Trim();
                            if (dao.deleteCar(strCarId))
                            {
                                MessageBox.Show("成功删除");
                                FreshForm();
                            }*/
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("删除失败，这条数据被其他数据所引用，请先删除使用了该数据的子信息！\n\n详细信息：\n" + ex.Message, "提示信息");
                return;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.修改ToolStripMenuItem.PerformClick();
        }

        private void 详细信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Visible = true;
            }
            FreshForm();
            for (int i = 7; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Visible = true;
            }          
        }

        private void 缩略信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Visible = true;
            }
            FreshForm();
            for (int i = 7; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Visible = false;
            }           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            /*string newFilter = string.Empty;
            string filter = gridView1.ActiveFilterString;
            newFilter = filter.Replace("StartsWith", "Contains");
            gridView1.ActiveFilterString = newFilter;*/
        }
    }
}
