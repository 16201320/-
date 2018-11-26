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
    public partial class FormLatheColumnEdit : Form
    {
        string strOperationFlag = string.Empty;  //指示操作是“添加”还是“修改”                                              
        string COLUMN_ID = string.Empty; //修改时指示具体的行数据
        public FormLatheColumnEdit(string strOperationFlag, Dictionary<string, string> dic)
        {
            InitializeComponent();
            if (strOperationFlag.Equals("modify"))
            {
                //设置窗口标题
                this.Text = "修改车列信息";
                //获取需要修改的信息
                this.COLUMN_ID = dic["列号"];
                this.COLUMN_NAME.Text = dic["列名称"];
            }

            else
            {
                //设置窗口标题
                this.Text = "添加车列信息";
                this.COLUMN_NAME.Focus();
            }
        }
    }
}
