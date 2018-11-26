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
        string strOperationFlag = string.Empty;  //指示操作是“添加”还是“修改”
        string LATHE_ID = string.Empty;  //修改时指示具体的行数据                                                  
        public FormLatheInfoEdit(string strOperationFlag, Dictionary<string, string>  dic)
        {
            InitializeComponent();
            if (strOperationFlag.Equals("modify"))
            {
                this.LATHE_ID = dic["车型编号"];
                this.LATHE_NAME.Text = dic["车型名称"];
            }
            else
            {
                this.LATHE_NAME.Focus();
            }
        }
    }
}
