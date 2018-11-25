using DevExpress.XtraGrid;
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
        string list1 = "select li.[LATHE_ID] as 车型编号,  li.[LATHE_NAME] as 车型名称 from LATHE_INFO li ";
        string list2 = "select lc.[COLUMN_ID] as 列号,  li.[LATHE_NAME] as 车型名称, lc.[COLUMN_NAME] as 列名称 from LATHE_COLUMN lc " +
             "inner join LATHE_INFO li on lc.LATHE_ID = li.LATHE_ID ";
        string list3 = "select ci.[CARID] as 车号编号,  lc.[COLUMN_NAME] as 列名称, ci.[CARNAME] as 车号名称 from CARNO_INFO ci " +
             "inner join LATHE_COLUMN lc on lc.COLUMN_ID = ci.COLUMN_ID ";
        // RepairPRocessDao dao = new RepairPRocessDao();
        DataSet ds = new DataSet();
        string strOperationFlag = string.Empty;  //指示操作是“添加”还是“修改”
        DataGridViewCellCollection oneLineCarInfo = null;  //传递要要修改的单行数据
        public FormCarInfo()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
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
            gridView2.Columns[1].Visible = false;

            //行高22
            gridView3.RowHeight = 32;
            //不允许编辑
            gridView3.OptionsBehavior.Editable = false;
            //不允许用户拖动列和
            gridView3.OptionsCustomization.AllowColumnMoving = false;
            //不显示右键菜单
            gridView3.OptionsMenu.EnableColumnMenu = false;
            gridView3.Columns[0].Visible = false;
            gridView3.Columns[1].Visible = false;
        
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
            this.GetAllUserinfo(this.list1, gridControl1);
            this.GetAllUserinfo(this.list2, gridControl2);
            this.GetAllUserinfo(this.list3, gridControl3);
        }

        private void FormCarInfo_SizeChanged(object sender, EventArgs e)
        {
            //this.groupControl4.Width = this.Width;
        }

        private void 添加车型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                strOperationFlag = "add";
                FormLatheInfoEdit frm = new FormLatheInfoEdit(strOperationFlag, oneLineCarInfo);
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
                if (this.gridView1.RowCount == 0)
                {
                    MessageBox.Show("请选中要修改的行");
                    return;
                }
                int selectedIndex = this.gridView1.GetSelectedRows()[0];
                if (selectedIndex < 0)
                {
                    MessageBox.Show("请选中要修改的行");
                    return;
                }
                else
                {
                    strOperationFlag = "modify";
                    /*int a = gridView1.row
                    oneLineCarInfo = this.gridView1.rows.GetRowCellValue(selectedIndex);*/
                    FormLatheInfoEdit frm = new FormLatheInfoEdit(strOperationFlag, oneLineCarInfo);
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
                    else
                    {
                        if (MessageBox.Show("确认删除车型信息", "确认信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
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

        private void 添加车列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                strOperationFlag = "add";
                FormLatheColumnEdit frm = new FormLatheColumnEdit(strOperationFlag, oneLineCarInfo);
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
                if (this.gridView1.RowCount == 0)
                {
                    MessageBox.Show("请选中要修改的行");
                    return;
                }
                int selectedIndex = this.gridView1.GetSelectedRows()[0];
                if (selectedIndex < 0)
                {
                    MessageBox.Show("请选中要修改的行");
                    return;
                }
                else
                {
                    strOperationFlag = "modify";
                    /*int a = gridView1.row
                    oneLineCarInfo = this.gridView1.rows.GetRowCellValue(selectedIndex);*/
                    FormLatheColumnEdit frm = new FormLatheColumnEdit(strOperationFlag, oneLineCarInfo);
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
                MessageBox.Show("修改车列信息时发生错误！" + ex.Message, "提示信息");
                return;
            }
        }

        private void 删除车列ToolStripMenuItem_Click(object sender, EventArgs e)
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
                        if (MessageBox.Show("确认删除车列信息", "确认信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
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

        private void 添加车号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                strOperationFlag = "add";
                FormCarNoEdit frm = new FormCarNoEdit(strOperationFlag, oneLineCarInfo);
                frm.Owner = this;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    FreshForm();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("添加车号信息时发生错误！" + ex.Message, "提示信息");
                return;
            }
        }

        private void 修改车号ToolStripMenuItem_Click(object sender, EventArgs e)
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
                    FormCarNoEdit frm = new FormCarNoEdit(strOperationFlag, oneLineCarInfo);
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
                MessageBox.Show("修改车号信息时发生错误！" + ex.Message, "提示信息");
                return;
            }
        }

        private void 删除车号ToolStripMenuItem_Click(object sender, EventArgs e)
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
                        if (MessageBox.Show("确认删除车号信息", "确认信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
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
            this.修改车型ToolStripMenuItem.PerformClick();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            this.修改车列ToolStripMenuItem.PerformClick();
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            this.修改车号ToolStripMenuItem.PerformClick();
        }
    }
}
