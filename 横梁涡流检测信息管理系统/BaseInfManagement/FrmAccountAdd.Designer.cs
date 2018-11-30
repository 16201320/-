namespace 横梁涡流检测信息管理系统.BaseInfManagement
{
    partial class FrmAccountAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.ACCOUNT_TYPE = new DevExpress.XtraEditors.ComboBoxEdit();
            this.PASSWORD = new DevExpress.XtraEditors.TextEdit();
            this.NAME = new DevExpress.XtraEditors.TextEdit();
            this.ACCOUNT = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ACCOUNT_TYPE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PASSWORD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ACCOUNT.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.ACCOUNT_TYPE);
            this.panelControl1.Controls.Add(this.PASSWORD);
            this.panelControl1.Controls.Add(this.NAME);
            this.panelControl1.Controls.Add(this.ACCOUNT);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(678, 226);
            this.panelControl1.TabIndex = 1;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(404, 172);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 10;
            this.simpleButton2.Text = "退出";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // ACCOUNT_TYPE
            // 
            this.ACCOUNT_TYPE.Location = new System.Drawing.Point(455, 16);
            this.ACCOUNT_TYPE.Name = "ACCOUNT_TYPE";
            this.ACCOUNT_TYPE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ACCOUNT_TYPE.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.ACCOUNT_TYPE.Size = new System.Drawing.Size(157, 24);
            this.ACCOUNT_TYPE.TabIndex = 9;
            // 
            // PASSWORD
            // 
            this.PASSWORD.Location = new System.Drawing.Point(455, 101);
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.Size = new System.Drawing.Size(157, 24);
            this.PASSWORD.TabIndex = 8;
            // 
            // NAME
            // 
            this.NAME.Location = new System.Drawing.Point(143, 104);
            this.NAME.Name = "NAME";
            this.NAME.Size = new System.Drawing.Size(157, 24);
            this.NAME.TabIndex = 7;
            // 
            // ACCOUNT
            // 
            this.ACCOUNT.Location = new System.Drawing.Point(143, 13);
            this.ACCOUNT.Name = "ACCOUNT";
            this.ACCOUNT.Size = new System.Drawing.Size(157, 24);
            this.ACCOUNT.TabIndex = 6;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(178, 172);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "确定添加";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(348, 107);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(75, 18);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "密      码：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(35, 110);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 18);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "真实姓名：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(348, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 18);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "账号类型：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(35, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "账      号：";
            // 
            // FrmAccountAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 226);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmAccountAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAccountAdd";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ACCOUNT_TYPE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PASSWORD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ACCOUNT.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit ACCOUNT_TYPE;
        private DevExpress.XtraEditors.TextEdit PASSWORD;
        private DevExpress.XtraEditors.TextEdit NAME;
        private DevExpress.XtraEditors.TextEdit ACCOUNT;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}