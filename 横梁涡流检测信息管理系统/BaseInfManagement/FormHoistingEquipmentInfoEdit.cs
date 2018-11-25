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
        //[EQUIMENT_ID] as 设备编号,  hi.[EQUIMENT_NAME] as 设备名称

        string strOperationFlag = string.Empty;  //指示操作是“添加”还是“修改”
                                                 //string strUserId = string.Empty;  //修改时指示具体的行数据
                                                 //bool strFlag = true; //用于判断控件是否填写了信息
                                                 // FaultInfoDao dao = new FaultInfoDao();
        string EQUIMENT_ID = "";
        public FormHoistingEquipmentInfoEdit(string strOperationFlag, DataGridViewCellCollection oneLineCarInfo)
        {
            InitializeComponent();
            if (strOperationFlag.Equals("modify"))
            {
                /*this.EQUIMENT_ID = oneLineCarInfo["设备编号"].Value.ToString().Trim();
                this.EQUIMENT_NAME.Text = oneLineCarInfo["设备名称"].Value.ToString().Trim();*/
            }
        }
    }
}
