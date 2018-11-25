using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Configuration;
using 横梁涡流检测信息管理系统;
using 横梁涡流检测信息管理系统.BaseInfManagement;
using 横梁涡流检测信息管理系统.SystemSetting;

namespace 横梁涡流检测信息管理系统
{
    public partial class Frm_main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected SqlConnection conn;

        public static string account = "";//登陆者账号名称
        public static string name = "";//登陆者真实姓名
        public string userType = "";//登陆者权限状态
        public FrmLogin frmLogin = null;
        FormFaultInfo f11 = new FormFaultInfo();//故障信息

        FormCarInfo f21 = new FormCarInfo();//列车信息面板
        FormHoistingEquipmentInfo f22 = new FormHoistingEquipmentInfo();//吊挂设备信息面板
        FormDETECTION_TECHNOLOGYInfo f23 = new FormDETECTION_TECHNOLOGYInfo();//检测技术信息面板
        FormRepairPRocessInfo f24 = new FormRepairPRocessInfo();//修程信息

        FormFaultInfoSearch f31 = new FormFaultInfoSearch();//查询故障信息

        FoemFaultStatistics f41 = new FoemFaultStatistics();//统计故障信息
        public Frm_main(FrmLogin frm, string name)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            frmLogin = frm;
            this.Name = name;
        }

        //下方导航栏绑定面板
        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
        }

        //上方导航栏绑定面板
        void barButtonNavigation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        }

        private void Frm_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin.Dispose();
            DLLAdmin dll = new DLLAdmin();
            dll.QuitLogin(account);
        }

        private void Frm_main_Load(object sender, EventArgs e)
        {
            //根据管理员和员工，赋予不同权限
            if (this.userType == "管理员")
            {
                this.ribbonPageGroup3.Visible = true;
             }
            else
            {

            }
            //初始化面板
            this.panelControl1.Controls.Add(f11);
            f11.Height = this.panelControl1.Height;
            f11.Width = this.panelControl1.Width;
            f11.Show();
            this.panelControl2.Controls.Add(f21);
            f21.Height = this.panelControl2.Height;
            f21.Width = this.panelControl2.Width;
            f21.Show();
            this.panelControl3.Controls.Add(f31);
            f31.Height = this.panelControl3.Height;
            f31.Width = this.panelControl3.Width;
            f31.Show();
            this.panelControl4.Controls.Add(f41);
            f41.Height = this.panelControl4.Height;
            f41.Width = this.panelControl4.Width;
            f41.Show();
            //添加回车键快捷菜单
            Button btn = new Button();
            btn.Click += new System.EventHandler(this.btn_Click);
            this.AcceptButton = btn;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            FormFaultInfoEdit form = new FormFaultInfoEdit("add", null);
            form.ShowDialog();
        }
        //切换为列车信息
        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.panelControl2.Controls.Clear();
            this.panelControl2.Controls.Add(f21);
            f21.Height = this.panelControl2.Height;
            f21.Width = this.panelControl2.Width;
            f21.Show();
        }
        //切换为吊挂设备信息
        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.panelControl2.Controls.Clear();
            this.panelControl2.Controls.Add(f22);
            f22.Height = this.panelControl2.Height;
            f22.Width = this.panelControl2.Width;
            f22.Show();
        }
        //切换为检测技术信息
        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.panelControl2.Controls.Clear();
            this.panelControl2.Controls.Add(f23);
            f23.Height = this.panelControl2.Height;
            f23.Width = this.panelControl2.Width;
            f23.Show();
        }
        //切换为修程信息
        private void navBarItem7_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.panelControl2.Controls.Clear();
            this.panelControl2.Controls.Add(f24);
            f24.Height = this.panelControl2.Height;
            f24.Width = this.panelControl2.Width;
            f24.Show();
        }
        //故障信息
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.panelControl1.Controls.Clear();
            this.panelControl1.Controls.Add(f11);
            f11.Height = this.panelControl1.Height;
            f11.Width = this.panelControl1.Width;
            f11.Show();
        }
        //故障信息查询
        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.panelControl3.Controls.Clear();
            this.panelControl3.Controls.Add(f31);
            f31.Height = this.panelControl3.Height;
            f31.Width = this.panelControl3.Width;
            f31.Show();
        }
        //故障信息统计
        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.panelControl4.Controls.Clear();
            this.panelControl4.Controls.Add(f41);
            f41.Height = this.panelControl4.Height;
            f41.Width = this.panelControl4.Width;
            f41.Show();
        }
        //自动调节窗口大小
        private void panelControl1_SizeChanged(object sender, EventArgs e)
        {
            int pane1Height = this.panelControl1.Height;
            int pane1Width = this.panelControl1.Width;
            if(this.panelControl1.Controls.Count > 0)
            {
                this.panelControl1.Controls[0].Height = pane1Height;
                this.panelControl1.Controls[0].Width = pane1Width;
            }
        }

        private void panelControl2_SizeChanged(object sender, EventArgs e)
        {
            int pane1Height = this.panelControl2.Height;
            int pane1Width = this.panelControl2.Width;
            if (this.panelControl2.Controls.Count > 0)
            {
                this.panelControl2.Controls[0].Height = pane1Height;
                this.panelControl2.Controls[0].Width = pane1Width;
            }
        }

        private void panelControl3_SizeChanged(object sender, EventArgs e)
        {
            int pane1Height = this.panelControl3.Height;
            int pane1Width = this.panelControl3.Width;
            if (this.panelControl3.Controls.Count > 0)
            {
                this.panelControl3.Controls[0].Height = pane1Height;
                this.panelControl3.Controls[0].Width = pane1Width;
            }
        }

        private void panelControl4_SizeChanged(object sender, EventArgs e)
        {
            int pane1Height = this.panelControl4.Height;
            int pane1Width = this.panelControl1.Width;
            if (this.panelControl4.Controls.Count > 0)
            {
                this.panelControl4.Controls[0].Height = pane1Height;
                this.panelControl4.Controls[0].Width = pane1Width;
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormFaultInfoEdit form = new FormFaultInfoEdit("1",null);
            form.ShowDialog();
        }
    }
}