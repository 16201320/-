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
        string gs_carlist = "select fi.[FAULT_ID] as 序号,  li.[LATHE_NAME] as 车型,lc.[COLUMN_NAME] as 列号,fi.[REPAIR_NAME] as 修程,fi.[CARNAME] as 车号,hi.[EQUIMENT_NAME] as 吊挂设备,fi.[CHECK_TM] as 检查时间,fi.[FAULT_BEAMID] as 故障横梁, fi.[DISTANCE1] as 一位测距,fi.[DISTANCE2] as 二位测距,fi.[FAULT_POSITION] as 缺陷位置, fi.[LENGTH] as 缺陷长度,fi.[DEPTH] as 缺陷深度,fi.[IF_PENETRATION] as 是否贯穿 " +
            ",dt.[Detection_Technology_NAME] as 检测技术 " +
            " ,fi.[INCREASE] as 信号幅值, fi.[PHASE] as 信号相位, " +
            " fi.[INVESTIGATOR] as 探伤工, fi.[TEAM_LEADER] as 班组长, fi.[ENTERING_PERSON] as 录入人 " +
            ",fi.[LATHE_ID] as 车型编号,fi.[COLUMN_ID] as 车列编号,fi.[EQUIMENT_ID] as 吊挂设备编号,fi.[DetectionTechnology_ID] as 检测技术编号" +
            " from FAULT_INFO fi " +
            "inner join LATHE_INFO li on fi.LATHE_ID = li.LATHE_ID " +
             "inner join LATHE_COLUMN lc on fi.COLUMN_ID = lc.COLUMN_ID " +
             "inner join HOISTINGEQUIPMENT_INFO hi on fi.EQUIMENT_ID = hi.EQUIMENT_ID " +
            "inner join DETECTION_TECHNOLOGY dt on fi.DetectionTechnology_ID = dt.DetectionTechnology_ID " +
            ""//"order by FAULT_ID desc"
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
            setcomboBoxEdit();


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
            //IF_PENETRATION.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            IF_PENETRATION.Properties.AutoComplete = true;
            IF_PENETRATION.Properties.CycleOnDblClick = true;
            ComboBoxItemCollection coll = IF_PENETRATION.Properties.Items;
            coll.Add("是");
            coll.Add("否");
        }

        private void setcomboBoxEdit()
        {
            comboBoxEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            comboBoxEdit1.Properties.AutoComplete = true;
            comboBoxEdit1.Properties.CycleOnDblClick = true;
            ComboBoxItemCollection coll1 = comboBoxEdit1.Properties.Items;
            coll1.Add("<");
            coll1.Add("=");
            coll1.Add(">");
            comboBoxEdit2.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            comboBoxEdit2.Properties.AutoComplete = true;
            comboBoxEdit2.Properties.CycleOnDblClick = true;
            ComboBoxItemCollection coll2 = comboBoxEdit2.Properties.Items;
            coll2.Add("<");
            coll2.Add("=");
            coll2.Add(">");
            comboBoxEdit3.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            comboBoxEdit3.Properties.AutoComplete = true;
            comboBoxEdit3.Properties.CycleOnDblClick = true;
            ComboBoxItemCollection coll3 = comboBoxEdit3.Properties.Items;
            coll3.Add("<");
            coll3.Add("=");
            coll3.Add(">");
            comboBoxEdit4.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            comboBoxEdit4.Properties.AutoComplete = true;
            comboBoxEdit4.Properties.CycleOnDblClick = true;
            ComboBoxItemCollection coll4 = comboBoxEdit4.Properties.Items;
            coll4.Add("<");
            coll4.Add("=");
            coll4.Add(">");
            comboBoxEdit5.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            comboBoxEdit5.Properties.AutoComplete = true;
            comboBoxEdit5.Properties.CycleOnDblClick = true;
            ComboBoxItemCollection coll5 = comboBoxEdit5.Properties.Items;
            coll5.Add("<");
            coll5.Add("=");
            coll5.Add(">");
            comboBoxEdit6.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            comboBoxEdit6.Properties.AutoComplete = true;
            comboBoxEdit6.Properties.CycleOnDblClick = true;
            ComboBoxItemCollection coll6 = comboBoxEdit6.Properties.Items;
            coll6.Add("<");
            coll6.Add("=");
            coll6.Add(">");
            comboBoxEdit7.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            comboBoxEdit7.Properties.AutoComplete = true;
            comboBoxEdit7.Properties.CycleOnDblClick = true;
            ComboBoxItemCollection coll7 = comboBoxEdit7.Properties.Items;
            coll7.Add("一天");
            coll7.Add("一段");
            

            comboBoxEdit1.SelectedIndex = 1;
            comboBoxEdit2.SelectedIndex = 1;
            comboBoxEdit3.SelectedIndex = 1;
            comboBoxEdit4.SelectedIndex = 1;
            comboBoxEdit5.SelectedIndex = 1;
            comboBoxEdit6.SelectedIndex = 1;
            comboBoxEdit6.SelectedIndex = 1;
            comboBoxEdit7.SelectedIndex = 0;
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


                dic.Add("车型编号", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[20]).ToString());
                dic.Add("车列编号", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[21]).ToString());
                dic.Add("吊挂设备编号", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[22]).ToString());
                dic.Add("检测技术编号", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[23]).ToString());

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
                            FaultInfoDao dao = new FaultInfoDao();
                            string Fault_ID = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[0]).ToString();
                            if (dao.delete(Fault_ID))
                            {
                                FreshForm();
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("删除失败，详细信息：\n" + ex.Message, "提示信息");
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
            string sqlfind = "where ";
            //车型
            if (checkEdit1.Checked == true && this.LATHE_NAME.Text != "")
            {
                if (!sqlfind.Equals("where "))
                    sqlfind = sqlfind + " and ";
                sqlfind = sqlfind + "li.LATHE_NAME like '%" + LATHE_NAME.Text + "%'";
            }
            //车列
            if (checkEdit2.Checked == true && this.COLUMN_NAME.Text != "")
            {
                if (!sqlfind.Equals("where "))
                    sqlfind = sqlfind + " and ";
                sqlfind = sqlfind + "lc.COLUMN_NAME like '%" + COLUMN_NAME.Text + "%'";
            }
            //修程
            if (checkEdit3.Checked == true && this.REPAIR_NAME.Text != "")
            {
                if (!sqlfind.Equals("where "))
                    sqlfind = sqlfind + " and ";
                sqlfind = sqlfind + "fi.REPAIR_NAME like '%" + REPAIR_NAME.Text + "%'";
            }
            //车号
            if (checkEdit4.Checked == true && this.CARNAME.Text != "")
            {
                if (!sqlfind.Equals("where "))
                    sqlfind = sqlfind + " and ";
                sqlfind = sqlfind + "fi.CARNAME like '%" + this.CARNAME.Text + "%'";
            }
            //吊挂设备
            if (checkEdit5.Checked == true && this.EQUIMENT_NAME.Text != "")
            {
                if (!sqlfind.Equals("where "))
                    sqlfind = sqlfind + " and ";
                sqlfind = sqlfind + "hi.EQUIMENT_NAME like '%" + this.EQUIMENT_NAME.Text + "%'";
            }



            //时间CHECK_TM
            if (checkEdit6.Checked == true && this.CHECK_TM.Text != "")
            {
                if (!sqlfind.Equals("where "))
                    sqlfind = sqlfind + " and ";
                sqlfind = sqlfind + "fi.CHECK_TM like '%" + this.CHECK_TM.Text + "%'";
            }
            //故障横梁号
            if (checkEdit7.Checked == true && this.FAULT_BEAMID.Text != "")
            {
                if (!sqlfind.Equals("where "))
                    sqlfind = sqlfind + " and ";
                sqlfind = sqlfind + "fi.FAULT_BEAMID like '%" + this.FAULT_BEAMID.Text + "%'";
            }
            //距1
            if (checkEdit9.Checked == true && this.DISTANCE1.Text != "" && this.DISTANCE1.Text!="/")
            {
                if (!sqlfind.Equals("where "))
                    sqlfind = sqlfind + " and ";
                string c = comboBoxEdit1.Text;
                sqlfind = sqlfind + " CAST(fi.DISTANCE1 AS numeric(10, 0)) " + c  +" "+ this.DISTANCE1.Text ;
                //sqlfind = sqlfind + "fi.DISTANCE1 like '%" + this.DISTANCE1.Text + "%'";
            }
            //距2
            if (checkEdit10.Checked == true && this.DISTANCE2.Text != "" && this.DISTANCE2.Text != "/")
            {
                if (!sqlfind.Equals("where "))
                    sqlfind = sqlfind + " and ";
                string c = comboBoxEdit2.Text;
                sqlfind = sqlfind + " CAST(fi.DISTANCE2 AS numeric(10, 0)) " + c + " " + this.DISTANCE2.Text;
                //sqlfind = sqlfind + "fi.DISTANCE2 like '%" + this.DISTANCE2.Text + "%'";
            }


            //故障位置
            if (checkEdit11.Checked == true && this.FAULT_POSITION.Text != "")
            {
                if (!sqlfind.Equals("where "))
                    sqlfind = sqlfind + " and ";
                sqlfind = sqlfind + "fi.FAULT_POSITION like '%" + this.FAULT_POSITION.Text + "%'";
            }
            //长度
            if (checkEdit12.Checked == true && this.LENGTH.Text != "" && this.LENGTH.Text != "/")
            {
                if (!sqlfind.Equals("where "))
                    sqlfind = sqlfind + " and ";
                string c = comboBoxEdit3.Text;
                sqlfind = sqlfind + " CAST(fi.LENGTH AS numeric(10, 0)) " + c + " " + this.LENGTH.Text;
               // sqlfind = sqlfind + "fi.LENGTH like '%" + this.LENGTH.Text + "%'";
            }
            //深度
            if (checkEdit13.Checked == true && this.DEPTH.Text != "" && this.DEPTH.Text != "/")
            {
                if (!sqlfind.Equals("where "))
                    sqlfind = sqlfind + " and ";
                string c = comboBoxEdit4.Text;
                sqlfind = sqlfind + " CAST(fi.DEPTH AS numeric(10, 0)) " + c + " " + this.DEPTH.Text;
                //sqlfind = sqlfind + "fi.DEPTH like '%" + this.DEPTH.Text + "%'";
            }
            //幅值
            if (checkEdit14.Checked == true && this.INCREASE.Text != "" && this.INCREASE.Text != "/")
            {
                if (!sqlfind.Equals("where "))
                    sqlfind = sqlfind + " and ";
                string c = comboBoxEdit5.Text;
                sqlfind = sqlfind + " CAST(fi.INCREASE AS numeric(10, 0)) " + c + " " + this.INCREASE.Text;
                //sqlfind = sqlfind + "fi.INCREASE like '%" + this.INCREASE.Text + "%'";
            }
            //相位
            if (checkEdit15.Checked == true && this.PHASE.Text != "" && this.PHASE.Text != "/")
            {
                if (!sqlfind.Equals("where "))
                    sqlfind = sqlfind + " and ";
                string c = comboBoxEdit6.Text;
                sqlfind = sqlfind + " CAST(fi.PHASE AS numeric(10, 0)) " + c + " " + this.PHASE.Text;
               // sqlfind = sqlfind + "fi.PHASE like '%" + this.PHASE.Text + "%'";
            }
            //是否贯穿
            if (checkEdit8.Checked == true && this.IF_PENETRATION.Text != "")
            {
                if (!sqlfind.Equals("where "))
                    sqlfind = sqlfind + " and ";
                sqlfind = sqlfind + "fi.IF_PENETRATION like '%" + this.IF_PENETRATION.Text + "%'";
            }






            if (!sqlfind.Equals("where "))
                GetAllUserinfo(gs_carlist + sqlfind + " order by fi.[FAULT_ID] desc", gridControl1);
            else
                GetAllUserinfo(gs_carlist + " order by fi.[FAULT_ID] desc", gridControl1);






        }

        private void comboBoxEdit7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxEdit7.SelectedIndex == 0)
            {
                this.labelControl1.Visible = false;
                this.CHECK_TM2.Visible = false;
            }
            else if(comboBoxEdit7.SelectedIndex == 1)
            {
                this.labelControl1.Visible = true;
                this.CHECK_TM2.Visible = true;
            }
                
        }
    }
}
