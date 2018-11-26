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
    public partial class FormDETECTION_TECHNOLOGYInfoEdit : Form
    {
        //select dt.[DetectionTechnology_ID] as 检测技术编号, dt.[Detection_Technology_NAME] as 检测技术名称
   
        string strOperationFlag = string.Empty;  //指示操作是“添加”还是“修改”
        string DetectionTechnology_ID = string.Empty;//修改时指示具体的行数据
        public FormDETECTION_TECHNOLOGYInfoEdit(string strOperationFlag, Dictionary<string, string> dic)
        {
            InitializeComponent();
            if (strOperationFlag.Equals("modify"))
            {
                this.DetectionTechnology_ID = dic["检测技术编号"];
                this.Detection_Technology_NAME.Text = dic["检测技术名称"];
            }
            else
            {
                this.Detection_Technology_NAME.Focus();
            }
        }
    }
}
