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
    public partial class FormLatheInfoEdit : Form
    {
        //list1 = "select li.[LATHE_ID] as 车型编号,  li.[LATHE_NAME] as 车型名称 from LATHE_INFO li ";

        string strOperationFlag = string.Empty;  //指示操作是“添加”还是“修改”
                                                 //string strUserId = string.Empty;  //修改时指示具体的行数据
                                                 //bool strFlag = true; //用于判断控件是否填写了信息
                                                 // FaultInfoDao dao = new FaultInfoDao();
        string LATHE_ID = "";
        public FormLatheInfoEdit(string strOperationFlag, DataGridViewCellCollection oneLineCarInfo)
        {
            InitializeComponent();
            if (strOperationFlag.Equals("modify"))
            {
                 /*this.LATHE_ID = oneLineCarInfo["车型编号"].Value.ToString().Trim();
                 this.LATHE_NAME.Text = oneLineCarInfo["车型名称"].Value.ToString().Trim();*/
            }
        }
    }
}
