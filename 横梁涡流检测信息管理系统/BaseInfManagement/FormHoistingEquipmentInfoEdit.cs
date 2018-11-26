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
    public partial class FormHoistingEquipmentInfoEdit : Form
    {
        string strOperationFlag = string.Empty;  //指示操作是“添加”还是“修改”
        string EQUIMENT_ID = string.Empty;//修改时指示具体的行数据
        public FormHoistingEquipmentInfoEdit(string strOperationFlag, Dictionary<string, string> dic)
        {
            InitializeComponent();
            if (strOperationFlag.Equals("modify"))
            {
                this.EQUIMENT_ID = dic["设备编号"];
                this.EQUIMENT_NAME.Text = dic["设备名称"];
            }
            else
            {
                this.EQUIMENT_NAME.Focus();
            }
        }
    }
}
