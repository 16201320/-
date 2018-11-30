using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 横梁涡流检测信息管理系统.SystemSetting;

namespace 横梁涡流检测信息管理系统.BaseInfManagement
{
    
    public partial class FrmAccountEdit : Form
    {
        string strOperationFlag = "";
        public FrmAccountEdit()
        {
            InitializeComponent();

            //设置账号类型下拉框
            comboBoxEdit1.Properties.AutoComplete = true;
            comboBoxEdit1.Properties.CycleOnDblClick = true;
            ComboBoxItemCollection coll = comboBoxEdit1.Properties.Items;
            coll.Add("员工");
            coll.Add("管理员");

            //设置gridcontrol
            //行高22
            gridView1.RowHeight = 40;
            //不允许编辑
            gridView1.OptionsBehavior.Editable = false;
            //不允许用户拖动列和
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //不显示右键菜单
            gridView1.OptionsMenu.EnableColumnMenu = false;
            gridControl1.UseEmbeddedNavigator = true;//设置滑动条
            gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            //gridControl1.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.End;
            gridControl1.EmbeddedNavigator.Dock = DockStyle.Bottom;

            //绑定数据
            BindGridView();
        }

        private void BindGridView()
        {
            DLLAdmin dll = new DLLAdmin();
            DataSet ds = dll.ListAdmin();

            gridControl1.DataSource = ds.Tables[0];
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                strOperationFlag = "add";
                FrmAccountAdd frm = new FrmAccountAdd(strOperationFlag, null);
                frm.Owner = this;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    BindGridView();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("添加车型信息时发生错误！" + ex.Message, "提示信息");
                return;
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.RowCount == 0 || this.gridView1.GetSelectedRows()[0] < 0)
                {
                    MessageBox.Show("请选中要修改的行");
                    return;
                }
                strOperationFlag = "modify";
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("账号编号", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[0]).ToString());
                dic.Add("账号", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[2]).ToString());
                dic.Add("账号类型", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[1]).ToString());
                dic.Add("真实姓名", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[3]).ToString());
                dic.Add("密码", this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[4]).ToString());
                FrmAccountAdd frm = new FrmAccountAdd(strOperationFlag, dic);
                frm.Owner = this;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                     BindGridView();
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("修改车型信息时发生错误！" + ex.Message, "提示信息");
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
                    if (MessageBox.Show("确认删除账号信息", "确认信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        DLLAdmin dao = new DLLAdmin();
                        string ADMIN_ID = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[0]).ToString();
                        if (dao.delete(ADMIN_ID))
                        {
                            BindGridView();
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
    }
}
