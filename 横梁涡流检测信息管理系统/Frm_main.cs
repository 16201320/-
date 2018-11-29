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
using DevExpress.XtraBars.Navigation;
using System.Threading;

namespace 横梁涡流检测信息管理系统
{
    public partial class Frm_main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected SqlConnection conn;

        public static string account = "";//登陆者账号名称
        public static string userName = "";//登陆者真实姓名
        public static string userType = "";//登陆者权限状态
        public FrmLogin frmLogin = null;
        FormFaultInfo f11 = new FormFaultInfo();//故障信息

        FormCarInfo f21 = new FormCarInfo();//基础信息面板

        FormFaultInfoSearch f31 = new FormFaultInfoSearch();//查询故障信息

        FoemFaultStatistics f41 = new FoemFaultStatistics();//统计故障信息
        public Frm_main(FrmLogin frm, string name)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            frmLogin = frm;
            this.Name = name;
            officeNavigationBar.CustomizationButtonVisibility = CustomizationButtonVisibility.Hidden; ;         
        }

        //下方导航栏绑定面板
        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
        }

        //上方导航栏绑定面板
        void barButtonNavigation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int barItemIndex = Navigation.ItemLinks.IndexOf(e.Link);
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
            if (Frm_main.userType == "管理员")
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
            f11.openAdd(sender, e);
        }
        //切换为基础信息
        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.panelControl2.Controls.Clear();
            this.panelControl2.Controls.Add(f21);
            f21.Height = this.panelControl2.Height;
            f21.Width = this.panelControl2.Width;
            f21.Show();
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
            f11.openAdd(sender,e);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            f11.openModify(sender, e);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            f11.openDelete(sender, e);
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            f11.FreshForm();
            f21.FreshForm();
            f31.FreshForm();
        }
    }
}