using common;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
    public partial class FormFaultInfoEdit : Form
    {
        string strOperationFlag = string.Empty;  //指示操作是“添加”还是“修改”
        string FAULT_ID = string.Empty;  //修改时指示具体的行数据
        FaultInfoDao dao = new FaultInfoDao();
        public FormFaultInfoEdit(string strOperationFlag, Dictionary<string, string> dic)
        {
            InitializeComponent();
            this.strOperationFlag = strOperationFlag;
            //设置下拉框内容
            setLatheCombo();
            setLatheColummn();
            setEquipment();
            setTechnolog();
            setPenetration();
            //设置输入格式RegEx" UseMaskAsDisplayFormat="True" Mask="[0-9]*"
            CHECK_TM.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            FAULT_BEAMID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            FAULT_BEAMID.Properties.Mask.EditMask = "[0-9]*";
            DISTANCE1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            DISTANCE2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            LENGTH.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            DEPTH.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            INCREASE.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            PHASE.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            
            if (strOperationFlag.Equals("modify"))
            {
                //设置窗口标题
                this.Text = "修改缺陷信息";
                //获取需要修改的信息
                this.FAULT_ID = dic["序号"].ToString().Trim();
                this.LATHE_NAME.EditValue = dic["车型编号"].ToString().Trim();
                this.COLUMN_NAME.EditValue = dic["车列编号"].ToString().Trim();
                this.REPAIR_NAME.Text = dic["修程"].ToString().Trim();
                this.CARNAME.Text = dic["车号"].ToString().Trim();
                this.CHECK_TM.Text = dic["检查时间"].ToString().Trim();
                this.FAULT_BEAMID.Text = dic["故障横梁号"].ToString().Trim();
                this.IF_PENETRATION.Text = dic["是否贯穿"].ToString().Trim();
                this.FAULT_POSITION.Text = dic["缺陷位置"].ToString().Trim();
                this.DISTANCE1.Text = dic["缺陷尖端距一位侧边梁"].ToString().Trim();
                this.DISTANCE2.Text = dic["缺陷尖端距二位侧边梁"].ToString().Trim();
                this.LENGTH.Text = dic["缺陷长度"].ToString().Trim();
                this.DEPTH.Text = dic["缺陷深度"].ToString().Trim();
                this.EQUIMENT_NAME.EditValue = dic["吊挂设备编号"].ToString().Trim();
                this.Detection_Technology_NAME.EditValue = dic["检测技术编号"].ToString().Trim();
                this.INCREASE.Text = dic["信号幅值"].ToString().Trim();
                this.PHASE.Text = dic["信号相位"].ToString().Trim();
                this.INVESTIGATOR.Text = dic["探伤工"].ToString().Trim();
                this.TEAM_LEADER.Text = dic["班主长"].ToString().Trim();
                this.ENTERING_PERSON.Text = dic["录入人"].ToString().Trim();



                this.FAULT_BEAMID.Enabled = false;
            }
            else
            {
                //设置窗口标题
                this.Text = "录入缺陷信息";
                this.CHECK_TM.Text = DateTime.Now.ToString();
                this.ENTERING_PERSON.Text = Frm_main.userName;
            }           
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

        //获取检测技术列表
        private void setTechnolog()
        {
            DataSet ds = new DataSet();
            ds = dao.setTechnologList();
            Detection_Technology_NAME.Properties.NullText = "";
            this.Detection_Technology_NAME.Properties.DataSource = ds.Tables[0];
            this.Detection_Technology_NAME.Properties.ValueMember = "编号";
            this.Detection_Technology_NAME.Properties.DisplayMember = "检测技术";
            //Detection_Technology_NAME.EditValue
        }

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

        private void labelControl16_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        //录入信息
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (checkFaultInfo())//判定参数格式是否正确
            {
                switch (strOperationFlag)
                {
                    case "add":
                        string a = FAULT_BEAMID.Text.Trim();
                        if (a.Length > 0 && a[a.Length - 1] == '_')
                            a = a.Substring(0, a.Length - 1);
                        try
                        {
                            a = int.Parse(a) + "";
                        }
                        catch
                        {
                            a = " ";
                        }
                        string sql0 = "select count(*) from FaultNumber where FAULT_BEAMID = " + a;
                        if (common.SqlHelper.ExcuteSql(sql0) > 0)
                        {
                            string sql = "update FaultNumber set number = number+1 WHERE FAULT_BEAMID = @FAULT_BEAMID";
                            List<SqlParameter> paramList = new List<SqlParameter>();
                            SqlHelper helper = new SqlHelper();
                            paramList.Add(new SqlParameter("@FAULT_BEAMID", a));
                            helper.ExecuteNonQuery(sql, paramList);
                        }
                        else
                        {
                            string sql = "insert into FaultNumber(FAULT_BEAMID,number)values(@FAULT_BEAMID,@number)";
                            List<SqlParameter> paramList = new List<SqlParameter>();
                            SqlHelper helper = new SqlHelper();
                            paramList.Add(new SqlParameter("@FAULT_BEAMID", a));
                            paramList.Add(new SqlParameter("@number", 1));
                            helper.ExecuteNonQuery(sql, paramList);
                        }
                        dao.Save(this.LATHE_NAME.EditValue.ToString().Trim(), this.COLUMN_NAME.EditValue.ToString().Trim(),this.REPAIR_NAME.Text.Trim(),
                                 this.CARNAME.Text.Trim(), this.EQUIMENT_NAME.EditValue.ToString().Trim(), this.CHECK_TM.Text.Trim(),
                                this.Detection_Technology_NAME.EditValue.ToString().Trim(), this.FAULT_BEAMID.Text.Trim(),                                
                                this.DISTANCE1.Text.Trim(), this.DISTANCE2.Text.Trim(), this.FAULT_POSITION.Text.Trim(),
                               this.LENGTH.Text.Trim(),  this.DEPTH.Text.Trim(),
                               this.INCREASE.Text.Trim(),this.PHASE.Text.Trim() ,this.IF_PENETRATION.Text.Trim(),
                               this.INVESTIGATOR.Text.Trim(), this.ENTERING_PERSON.Text.Trim(), this.TEAM_LEADER.Text.Trim());  
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                    case "modify":
                        dao.Modify(this.FAULT_ID,
                               this.LATHE_NAME.EditValue.ToString().Trim(), this.COLUMN_NAME.EditValue.ToString().Trim(), this.REPAIR_NAME.Text.Trim(),
                                 this.CARNAME.Text.Trim(), this.EQUIMENT_NAME.EditValue.ToString().Trim(), this.CHECK_TM.Text.Trim(),
                                this.Detection_Technology_NAME.EditValue.ToString().Trim(), this.FAULT_BEAMID.Text.Trim(),
                                this.DISTANCE1.Text.Trim(), this.DISTANCE2.Text.Trim(), this.FAULT_POSITION.Text.Trim(),
                               this.LENGTH.Text.Trim(), this.DEPTH.Text.Trim(),
                               this.INCREASE.Text.Trim(), this.PHASE.Text.Trim(), this.IF_PENETRATION.Text.Trim(),
                               this.INVESTIGATOR.Text.Trim(), this.ENTERING_PERSON.Text.Trim(), this.TEAM_LEADER.Text.Trim());
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                }
            }

        }

        //返回
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //控制录入的信息
        private bool checkFaultInfo()
        {
            if (LATHE_NAME.Text == "")
            {
                MessageBox.Show("车型不能为空");
                return false;
            }

            if (COLUMN_NAME.Text == "")
            {
                MessageBox.Show("列号不能为空");
                return false;
            }
            string sql1 = "select * from LATHE_COLUMN where COLUMN_NAME = '" + COLUMN_NAME.Text + "'";
            if (common.SqlHelper.ExcuteSql(sql1) == 0)
            {
                MessageBox.Show("该车列不存在数据库中，请先在基础信息中加入该车列！");
                return false;
            }


            //如果修程格式不对，返回



            //控制车号前缀必须是车列号，并且车号不能和列号相同
            string carName = CARNAME.Text.Trim();
            string columnName = COLUMN_NAME.Text.Trim();
            if (carName.Substring(0, columnName.Length)!= columnName || carName == columnName)
            {
                    MessageBox.Show("车号格式不正确！");
                    return false;
            }
       
            if (EQUIMENT_NAME.Text == "")
            {
                MessageBox.Show("吊挂设备不能为空");
                return false;
            }

            if (Detection_Technology_NAME.Text == "")
            {
                MessageBox.Show("检测技术不能为空");
                return false;
            }

            if(FAULT_BEAMID.Text.Trim() == "")
            {
                MessageBox.Show("故障横梁号不能为空！");
                return false;
            }



            //再次验证故障位置是否正确


            if (LENGTH.Text == "")
            {
                MessageBox.Show("长度不能为空！");
                return false;
            }
            if (DEPTH.Text == "")
            {
                MessageBox.Show("深度不能为空！");
                return false;
            }

            if (INCREASE.Text.Trim() == "")
                INCREASE.Text = "/";
            

            if (PHASE.Text.Trim() == "")
                PHASE.Text = "/";
        
            if (IF_PENETRATION.Text == "")
            {
                MessageBox.Show("是否贯穿不能为空");
                return false;
            }

            if (INVESTIGATOR.Text == "")
            {
                MessageBox.Show("探伤员不能为空！");
                return false;
            }
            if (ENTERING_PERSON.Text == "")
            {
                MessageBox.Show("录入人不能为空！");
                return false;
            }
            if (TEAM_LEADER.Text == "")
            {
                MessageBox.Show("班组长不能为空！");
                return false;
            }


            return true;
        }

        private void REPAIR_NAME_TextChanged(object sender, EventArgs e)
        {

        }

        private void REPAIR_NAME_EditValueChanged(object sender, EventArgs e)
        {

        }

        //设置修程格式
        private void REPAIR_NAME_EditValueChanging(object sender, ChangingEventArgs e)
        {
            /*if (REPAIR_NAME.Text.ToString() == "1")
                REPAIR_NAME.Text += "2";*/

           /* // MessageBox.Show(REPAIR_NAME.Text);
            if (REPAIR_NAME.Text == null || REPAIR_NAME.Text=="")
                return;
            string s = REPAIR_NAME.Text.ToString().Trim();
            switch (s.Length)
            {
                 case 0:
                    //REPAIR_NAME.Text = "";//设置前后不能有空格
                    e.NewValue =  "";
                    e.Cancel = false;
                    break;
                case 1:
                    if (s[0] >= '0' && s[0] <= '9')//如果第1个是数字，被允许并且加-,否则被去掉
                    {
                       // REPAIR_NAME.Text = 
                        e.NewValue = s + "-";
                        e.Cancel = false;
                    }
                    else
                    {
                        //REPAIR_NAME.Text = "";
                        e.NewValue = "";
                        e.Cancel = false;
                    }
                    break;
                case 2:
                    if (s[1] != '-')
                    {
                        //REPAIR_NAME.Text = s.Substring(0, 1) + "-";
                        e.NewValue = s.Substring(0, 1) + "-";
                        e.Cancel = false;
                    }
                    break;
                case 3:
                    if ((s[2] >= 'a' && s[2] <= 'z') || (s[2] >= 'A' && s[2] <= 'Z'))//如果第3个是字母,否则被去掉
                    {

                    }
                    else
                    {
                        //REPAIR_NAME.Text = s.Substring(0, 2);
                        e.NewValue = s.Substring(0, 2);
                        e.Cancel = false;
                    }
                    break;
                case 4:
                    if (s[3] >= '0' && s[3] <= '9')//如果第4个是数字，否则被去掉
                    {

                    }
                    else
                    {
                       // REPAIR_NAME.Text = s.Substring(0, 3);
                        e.NewValue = s.Substring(0, 3);
                        e.Cancel = false;
                    }
                    break;
                default:
                   // REPAIR_NAME.Text = s.Substring(0, 4);
                    e.NewValue = s.Substring(0, 4);
                    e.Cancel = false;
                    break;
            }*/

        }
        //车号前缀是车列号
        private void COLUMN_NAME_EditValueChanged(object sender, EventArgs e)
        {
            this.CARNAME.Text = this.COLUMN_NAME.Text;
        }
        //1位测了2位不能测
        private void DISTANCE1_EditValueChanged(object sender, EventArgs e)
        {
            if (DISTANCE1.Text.ToString() == "" || DISTANCE1.Text.ToString() == "/" || DISTANCE1.EditValue.ToString() == "0")
            {
                if (DISTANCE2.Text == "/" || DISTANCE2.Text == "0")
                    DISTANCE2.Text = "";
                DISTANCE2.Enabled = true;
            }
            else
            {
                DISTANCE2.Text = "/";
                DISTANCE2.Enabled = false;
            }
            updateFaultPosiyion();
        }
        //2位测了1位不能测
        private void DISTANCE2_EditValueChanged(object sender, EventArgs e)
        {
            if (DISTANCE2.Text.ToString() == "" || DISTANCE2.Text.ToString() == "/" || DISTANCE2.EditValue.ToString() == "0")
            {
                if (DISTANCE1.Text == "/" || DISTANCE1.Text == "0")
                    DISTANCE1.Text = "";
                DISTANCE1.Enabled = true;
            }
            else
            {
                DISTANCE1.Text = "/";
                DISTANCE1.Enabled = false;
            }
            updateFaultPosiyion();
        }

        private void FAULT_BEAMID_EditValueChanged(object sender, EventArgs e)
        {
            updateFaultPosiyion();
        }

        //自动更新故障位置 a-b-c形式
        private void updateFaultPosiyion()
        {           
            string a = FAULT_BEAMID.Text.Trim();
            string[] x = a.Split('-');
            if (a.Length>0 && a[a.Length - 1] == '_')
                a = a.Substring(0, a.Length -1);
            try
            {
                a = int.Parse(a) + "";
            }
            catch
            {
                a = " ";
            }
            string b;
            if (DISTANCE1.Enabled == true && DISTANCE2.Enabled == false)
                b = "1";
            else if(DISTANCE1.Enabled == false && DISTANCE2.Enabled == true)
                    b = "2";
            else
                b = " ";
            string c = " ";
            string sql;
            try { 
                sql = "select number from FaultNumber where FAULT_BEAMID = " + a ;
                SqlCommand cmd = new SqlCommand(sql, common.SqlHelper.GetConnection());
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                sda.Fill(ds);
                string time = ds.Tables[0].Rows[0]["number"].ToString();;
                c = int.Parse(time) + 1+"";
            }
            catch
            {
                c = "1";
            }
            if (strOperationFlag == "Modify")
            {
                try
                {
                    this.FAULT_POSITION.Text = x[0] + "-" + b + "-" + x[2];
                }
                catch
                {
                    MessageBox.Show("缺陷位置格式不正确，格式为a-b-c");
                }              
            }               
            else
                 this.FAULT_POSITION.Text = a + "-" + b + "-" + c;
        }

        private void INCREASE_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
