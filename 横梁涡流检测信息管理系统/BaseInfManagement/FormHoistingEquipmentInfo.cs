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
using 横梁涡流检测信息管理系统.BaseInfManagement;

namespace 横梁涡流检测信息管理系统
{
    public partial class FormHoistingEquipmentInfo : Form
    {
        public string formName = "FormHoistingEquipmentInfo";
        string gs_carlist = "select hi.[EQUIMENT_ID] as 设备编号,  hi.[EQUIMENT_NAME] as 设备名称 from HOISTINGEQUIPMENT_INFO hi ";
        HoistingEquipmentInfoDao dao = new HoistingEquipmentInfoDao();
        string strOperationFlag = string.Empty;  //指示操作是“添加”还是“修改”
        DataGridViewCellCollection oneLineCarInfo = null;  //传递要要修改的单行数据
        public FormHoistingEquipmentInfo()
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
            gridView1.Columns[0].Visible = false;
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

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                strOperationFlag = "add";
                FormHoistingEquipmentInfoEdit frm = new FormHoistingEquipmentInfoEdit(strOperationFlag, oneLineCarInfo);
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
                    FormHoistingEquipmentInfoEdit frm = new FormHoistingEquipmentInfoEdit(strOperationFlag, oneLineCarInfo);
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
                MessageBox.Show("修改吊挂设备信息时发生错误！" + ex.Message, "提示信息");
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
                        if (MessageBox.Show("确认吊挂设备信息", "确认信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
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
    }
}
