using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using EddyCurrentTesting;
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
    public partial class FoemFaultStatistics : Form
    {
        public string formName = "FoemFaultStatistics";
        FaultInfoDao dao = new FaultInfoDao();
        public FoemFaultStatistics()
        {
            InitializeComponent();
            GetLATHE_NAME();
            GetLATHE_NAME1();
            GetLATHE_NAME2();
            GetLATHE_NAME3();
            this.FormBorderStyle = FormBorderStyle.None;
             this.TopLevel = false;
            comboBoxEdit1.Properties.TextEditStyle = TextEditStyles.Standard;
            comboBoxEdit1.Properties.AutoComplete = true;
            comboBoxEdit1.Properties.CycleOnDblClick = true;
            ComboBoxItemCollection coll = comboBoxEdit1.Properties.Items;
            coll.BeginUpdate();
            try
            {
                coll.Add(new PersonInfo("Sven", "Petersen"));
                coll.Add(new PersonInfo("Cheryl", "Saylor"));
                coll.Add(new PersonInfo("Dirk1", "Luchte"));
                coll.Add(new PersonInfo("Dirk2", "Luchte"));
                coll.Add(new PersonInfo("Dirk3", "Luchte"));
                coll.Add(new PersonInfo("Dirk4", "Luchte"));
            }
            finally
            {
                coll.EndUpdate();
            }
            comboBoxEdit1.SelectedIndex = -1;
            /*DataSet ds = new DataSet();
            ds = dao.List1();
            // riLookup.Columns [“Description”]。Visible = false;
            comboBoxEdit1.Properties.NullText = "";
            this.comboBoxEdit1.Properties.Items.d = ds.Tables[0];*/
            // Controls.Add(comboBoxEdit1);

            //lookUpEdit1.Properties.DataSource
        }


        private void GetLATHE_NAME()
        {
            //lookUpEdit1.Properties.TextEditStyle = TextEditStyles.Standard;
            lookUpEdit1.Properties.PopupFilterMode = PopupFilterMode.Contains;
            DataSet ds = new DataSet();
            ds = dao.getLatheList();
            // riLookup.Columns [“Description”]。Visible = false;
            lookUpEdit1.Properties.NullText = "lookUpEdit1";
            this.lookUpEdit1.Properties.DataSource = ds.Tables[0];
            this.lookUpEdit1.Properties.ValueMember = "LATHE_ID";
            this.lookUpEdit1.Properties.DisplayMember = "LATHE_NAME";
            this.lookUpEdit1.ItemIndex = 2;
            lookUpEdit1.EditValue = 3;
            // lookUpEdit1.Properties.Columns.Add(new LookUpColumnInfo("LATHE_NAME"));

            // this.lookUpEdit1.Properties.PopulateColumns();
            // this.lookUpEdit1.Properties.Columns["LATHE_ID"].Visible = false;
        }

        private void GetLATHE_NAME1()
        {
            gridLookUpEdit1.Properties.TextEditStyle = TextEditStyles.Standard;
            DataSet ds = new DataSet();
            ds = dao.getLatheList();
            gridLookUpEdit1.Properties.NullText = "gridLookUpEdit1";
            this.gridLookUpEdit1.Properties.DataSource = ds.Tables[0];
            this.gridLookUpEdit1.Properties.ValueMember = "LATHE_ID";
            this.gridLookUpEdit1.Properties.DisplayMember = "LATHE_NAME";

            //lookUpEdit1.Properties.Columns.Add(new LookUpColumnInfo("LATHE_NAME"));

            // this.lookUpEdit1.Properties.PopulateColumns();
            // this.lookUpEdit1.Properties.Columns["LATHE_ID"].Visible = false;
        }

        private void GetLATHE_NAME2()
        {
            searchLookUpEdit1.Properties.TextEditStyle = TextEditStyles.Standard;
            DataSet ds = new DataSet();
            ds = dao.getLatheList();
            searchLookUpEdit1.Properties.NullText = "searchLookUpEdit1";
            this.searchLookUpEdit1.Properties.DataSource = ds.Tables[0];
            this.searchLookUpEdit1.Properties.ValueMember = "LATHE_ID";
            this.lookUpEdit1.Properties.DisplayMember = "LATHE_NAME";

           // searchLookUpEdit1.Properties.Columns.Add(new LookUpColumnInfo("LATHE_NAME"));

            // this.lookUpEdit1.Properties.PopulateColumns();
            // this.lookUpEdit1.Properties.Columns["LATHE_ID"].Visible = false;
        }

        private void GetLATHE_NAME3()
        {
            treeListLookUpEdit1.Properties.TextEditStyle = TextEditStyles.Standard;
            DataSet ds = new DataSet();
            ds = dao.getLatheList();
            treeListLookUpEdit1.Properties.NullText = "treeListLookUpEdit1";
            this.treeListLookUpEdit1.Properties.DataSource = ds.Tables[0];
            this.treeListLookUpEdit1.Properties.ValueMember = "LATHE_ID";
            this.treeListLookUpEdit1.Properties.DisplayMember = "LATHE_NAME";

           // treeListLookUpEdit1.Properties.Columns.Add(new LookUpColumnInfo("LATHE_NAME"));

            // this.lookUpEdit1.Properties.PopulateColumns();
            // this.lookUpEdit1.Properties.Columns["LATHE_ID"].Visible = false;
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }





    public class PersonInfo
    {
        private string _firstName;
        private string _lastName;

        public PersonInfo(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public override string ToString()
        {
            return _firstName + " " + _lastName;
        }
    }
}
