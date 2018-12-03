using DevExpress.XtraGrid;
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
    public partial class FormCarInfo : Form
    {
        public string formName = "FormCarInfo";
        string list1 = "select li.[LATHE_ID] as 车型编号,  li.[LATHE_NAME] as 车型 from LATHE_INFO li ";
        string list2 = "select lc.[COLUMN_ID] as 列编号,   lc.[COLUMN_NAME] as 列号 from LATHE_COLUMN lc ";
        string list3 = "select hi.[EQUIMENT_ID] as 设备编号,  hi.[EQUIMENT_NAME] as 吊挂设备 from HOISTINGEQUIPMENT_INFO hi ";
        string list4 = "select dt.[DetectionTechnology_ID] as 检测技术编号,   dt.[Detection_Technology_NAME] as 检测技术 from DETECTION_TECHNOLOGY dt ";
        string strOperationFlag = string.Empty;  //指示操作是“添加”还是“修改”
        public FormCarInfo()
        {
            InitializeComponent();
            //设置这个窗口可以嵌入到其他窗口里面
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;

            //设置gridcontrol表头提示为空
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;

            //显示所有信息
            FreshForm();


            //行高22
            gridView1.RowHeight = 32;
            //不允许编辑
            gridView1.OptionsBehavior.Editable = false;
            //不允许用户拖动列和
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //不显示右键菜单
            gridView1.OptionsMenu.EnableColumnMenu = false;
            gridView1.Columns[0].Visible = false;

            //行高22
            gridView2.RowHeight = 32;
            //不允许编辑
            gridView2.OptionsBehavior.Editable = false;
            //不允许用户拖动列和
            gridView2.OptionsCustomization.AllowColumnMoving = false;
            //不显示右键菜单
            gridView2.OptionsMenu.EnableColumnMenu = false;
            gridView2.Columns[0].Visible = false;

            //行高22
            gridView3.RowHeight = 32;
            //不允许编辑
            gridView3.OptionsBehavior.Editable = false;
            //不允许用户拖动列和
            gridView3.OptionsCustomization.AllowColumnMoving = false;
            //不显示右键菜单
            gridView3.OptionsMenu.EnableColumnMenu = false;
            gridView3.Columns[0].Visible = false;

            //行高22
            gridView4.RowHeight = 32;
            //不允许编辑
            gridView4.OptionsBehavior.Editable = false;
            //不允许用户拖动列和
            gridView4.OptionsCustomization.AllowColumnMoving = false;
            //不显示右键菜单
            gridView4.OptionsMenu.EnableColumnMenu = false;
            gridView4.Columns[0].Visible = false;


            gridControl1.UseEmbeddedNavigator = true;//设置滑动条
            gridControl2.UseEmbeddedNavigator = true;//设置滑动条
            gridControl3.UseEmbeddedNavigator = true;//设置滑动条
            gridControl4.UseEmbeddedNavigator = true;//设置滑动条
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
        public void FreshForm()
        {
            this.GetAllUserinfo(this.list1, gridControl1);
            this.GetAllUserinfo(this.list2, gridControl2);
            this.GetAllUserinfo(this.list3, gridControl3);
            this.GetAllUserinfo(this.list4, gridControl4);
        }

        //自动适应长宽度
        private void FormCarInfo_SizeChanged(object sender, EventArgs e)
        {
            //this.groupControl4.Width = this.Width;
        }

        private void 添加车型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                strOperationFlag = "add";
                FormLatheInfoEdit frm = new FormLatheInfoEdit(strOperationFlag, null);
                frm.Owner = this;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    FreshForm();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("添加车型信息时发生错误！" + ex.Message, "提示信息");
                return;
            }
        }

        private void 修改车型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.RowCount == 0  || this.gridView1.GetSelectedRows()[0] < 0)
                {
                    MessageBox.Show("请选中要修改的行");
                    return;
                }
                strOperationFlag = "modify";
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("车型编号", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[0]).ToString());
                dic.Add("车型名称", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[1]).ToString());
                FormLatheInfoEdit frm = new FormLatheInfoEdit(strOperationFlag, dic);
                frm.Owner = this;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                    FreshForm();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("修改车型信息时发生错误！" + ex.Message, "提示信息");
                return;
            }
        }

        private void 删除车型ToolStripMenuItem_Click(object sender, EventArgs e)
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
                    if (MessageBox.Show("确认删除车型信息", "确认信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        LatheDao dao = new LatheDao();
                        string LATHE_ID = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[0]).ToString();
                         if (dao.delete(LATHE_ID))
                         {
                               FreshForm();
                         }
                    }
                }
            }
            catch 
            {
                MessageBox.Show("删除失败，这个车型在被使用！\n");
                return;
            }
        }

        private void 添加车列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                strOperationFlag = "add";
                FormLatheColumnEdit frm = new FormLatheColumnEdit(strOperationFlag, null);
                frm.Owner = this;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    FreshForm();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("添加车列信息时发生错误！" + ex.Message, "提示信息");
                return;
            }
        }

        private void 修改车列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView2.RowCount == 0 || this.gridView2.GetSelectedRows()[0] < 0)
                {
                    MessageBox.Show("请选中要修改的行");
                    return;
                }
                strOperationFlag = "modify";
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("列号", this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, this.gridView2.Columns[0]).ToString());
                dic.Add("列名称", this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, this.gridView2.Columns[1]).ToString());
                FormLatheColumnEdit frm = new FormLatheColumnEdit(strOperationFlag, dic);
                frm.Owner = this;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                    FreshForm();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("修改车列信息时发生错误！" + ex.Message, "提示信息");
                return;
            }
        }

        private void 删除车列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView2.RowCount > 0)
                {
                    if (this.gridView2.GetSelectedRows()[0] < 0)
                    {
                        MessageBox.Show("没有选中信息，请选择！", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show("确认删除车列信息", "确认信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            LatheColumnDao dao = new LatheColumnDao();
                            string LATHE_ID = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, this.gridView2.Columns[0]).ToString();
                            if (dao.delete(LATHE_ID))
                            {
                                FreshForm();
                            }
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

        private void 添加吊挂设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                strOperationFlag = "add";
                FormHoistingEquipmentInfoEdit frm = new FormHoistingEquipmentInfoEdit(strOperationFlag, null);
                frm.Owner = this;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    FreshForm();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("添加吊挂设备信息时发生错误！" + ex.Message, "提示信息");
                return;
            }
        }

        private void 修改吊挂设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView3.RowCount == 0 || this.gridView3.GetSelectedRows()[0] < 0)
                {
                    MessageBox.Show("请选中要修改的行");
                    return;
                }
                strOperationFlag = "modify";
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("设备编号", this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, this.gridView3.Columns[0]).ToString());
                dic.Add("设备名称", this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, this.gridView3.Columns[1]).ToString());
                FormHoistingEquipmentInfoEdit frm = new FormHoistingEquipmentInfoEdit(strOperationFlag, dic);
                frm.Owner = this;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                    FreshForm();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("修改吊挂设备信息时发生错误！" + ex.Message, "提示信息");
                return;
            }
        }

        private void 删除吊挂设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView3.RowCount > 0)
                {
                    if (this.gridView3.GetSelectedRows()[0] < 0)
                    {
                        MessageBox.Show("没有选中信息，请选择！", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show("确认吊挂设备信息", "确认信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            HoistingEquipmentInfoDao dao = new HoistingEquipmentInfoDao();
                            string LATHE_ID = this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, this.gridView3.Columns[0]).ToString();
                            if (dao.delete(LATHE_ID))
                            {
                                FreshForm();
                            }
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

        private void 添加检测技术ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                strOperationFlag = "add";
                FormDETECTION_TECHNOLOGYInfoEdit frm = new FormDETECTION_TECHNOLOGYInfoEdit(strOperationFlag, null);
                frm.Owner = this;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    FreshForm();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("添加检测技术信息时发生错误！" + ex.Message, "提示信息");
                return;
            }
        }

        private void 修改检测技术ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView4.RowCount == 0 || this.gridView4.GetSelectedRows()[0] < 0)
                {
                    MessageBox.Show("请选中要修改的行");
                    return;
                }
                strOperationFlag = "modify";
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("检测技术编号", this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, this.gridView4.Columns[0]).ToString());
                dic.Add("检测技术名称", this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, this.gridView4.Columns[1]).ToString());
                FormDETECTION_TECHNOLOGYInfoEdit frm = new FormDETECTION_TECHNOLOGYInfoEdit(strOperationFlag, dic);
                frm.Owner = this;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                    FreshForm();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("修改检测技术信息时发生错误！" + ex.Message, "提示信息");
                return;
            }
        }

        private void 删除检测技术ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView4.RowCount > 0)
                {
                    if (this.gridView4.GetSelectedRows()[0] < 0)
                    {
                        MessageBox.Show("没有选中信息，请选择！", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show("确认删除检测技术信息", "确认信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            DETECTION_TECHNOLOGYInDao dao = new DETECTION_TECHNOLOGYInDao();
                            string LATHE_ID = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, this.gridView4.Columns[0]).ToString();
                            if (dao.delete(LATHE_ID))
                            {
                                FreshForm();
                            }
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
            this.修改车型ToolStripMenuItem.PerformClick();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            this.修改车列ToolStripMenuItem.PerformClick();
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            this.修改吊挂设备ToolStripMenuItem.PerformClick();
        }
        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            this.修改检测技术ToolStripMenuItem.PerformClick();
        }
        //添加车型
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LatheDao dao = new LatheDao();
            string name = textEdit1.Text.Trim();
            //控制参数格式
            if (name == "")
            {
                MessageBox.Show("信息不能为空！");
                return;
            }
                    string sql1 = "select * from LATHE_INFO where LATHE_NAME = '" + name + "'";
                    if (common.SqlHelper.ExcuteSql(sql1) > 0)
                    {
                        MessageBox.Show("该车型已经被使用，请核查！", "信息提示", MessageBoxButtons.OK);
                        return;
                    }
                    dao.Save(this.textEdit1.Text.Trim());
            FreshForm();
        }
        
        //添加车列

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            LatheColumnDao dao = new LatheColumnDao();
            string name = textEdit2.Text.Trim();
            //控制参数格式
            if (name == "")
            {
                MessageBox.Show("信息不能为空！");
                return;
            }
                    string sql1 = "select * from LATHE_COLUMN where COLUMN_NAME = '" + name + "'";
                    if (common.SqlHelper.ExcuteSql(sql1) > 0)
                    {
                        MessageBox.Show("该车列已经被使用，请核查！", "信息提示", MessageBoxButtons.OK);
                        return;
                    }
                    dao.Save(this.textEdit2.Text.Trim());
            FreshForm();
        }
        //添加吊挂设备
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            HoistingEquipmentInfoDao dao = new HoistingEquipmentInfoDao();
            string name = textEdit3.Text.Trim();
            //控制参数格式
            if (name == "")
            {
                MessageBox.Show("信息不能为空！");
                return;
            }
                    string sql1 = "select * from HOISTINGEQUIPMENT_INFO where EQUIMENT_NAME = '" + name + "'";
                    if (common.SqlHelper.ExcuteSql(sql1) > 0)
                    {
                        MessageBox.Show("该吊挂设备已经被添加过了！", "信息提示", MessageBoxButtons.OK);
                        return;
                    }
                    dao.Save(this.textEdit3.Text.Trim());
            FreshForm();
        }
        //添加检测技术
        private void simpleButton2_Click(object sender, EventArgs e)
        {
             DETECTION_TECHNOLOGYInDao dao = new DETECTION_TECHNOLOGYInDao();
            string name = textEdit4.Text.Trim();
            //控制参数格式
            if (name == "")
            {
                MessageBox.Show("信息不能为空！");
                return;
            }
                    string sql1 = "select * from DETECTION_TECHNOLOGY where Detection_Technology_NAME = '" + name + "'";
                    if (common.SqlHelper.ExcuteSql(sql1) > 0)
                    {
                        MessageBox.Show("该检测技术已被添加过！", "信息提示", MessageBoxButtons.OK);
                        return;
                    }
                    dao.Save(this.textEdit4.Text.Trim());
            FreshForm();
        }
    }
}
