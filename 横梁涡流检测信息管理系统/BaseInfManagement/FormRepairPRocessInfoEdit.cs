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
    public partial class FormRepairPRocessInfoEdit : Form
    {
        string strOperationFlag = string.Empty;  //指示操作是“添加”还是“修改”
                                                 //string strUserId = string.Empty;  //修改时指示具体的行数据
                                                 //bool strFlag = true; //用于判断控件是否填写了信息
                                                 // FaultInfoDao dao = new FaultInfoDao();
        string REPAIR_ID = "";
        public FormRepairPRocessInfoEdit(string strOperationFlag, DataGridViewCellCollection oneLineCarInf)
        {
            InitializeComponent();
            if (strOperationFlag.Equals("modify"))
            {
               /* this.REPAIR_ID = oneLineCarInf["修程编号"].Value.ToString().Trim();
                this.REPAIR_NAME.Text = oneLineCarInf["修程名称"].Value.ToString().Trim();     */       
            }
}
    }
}
