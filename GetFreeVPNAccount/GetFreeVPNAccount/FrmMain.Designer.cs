namespace GetFreeVPNAccount
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LabInfo = new System.Windows.Forms.Label();
            this.BtnCopyPassword = new System.Windows.Forms.Button();
            this.BtnCopyAccount = new System.Windows.Forms.Button();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.LabPassword = new System.Windows.Forms.Label();
            this.LabAccount = new System.Windows.Forms.Label();
            this.BtnGetOneKey = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TssInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimeClock = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LabInfo);
            this.groupBox1.Controls.Add(this.BtnCopyPassword);
            this.groupBox1.Controls.Add(this.BtnCopyAccount);
            this.groupBox1.Controls.Add(this.TxtPassword);
            this.groupBox1.Controls.Add(this.TxtAccount);
            this.groupBox1.Controls.Add(this.LabPassword);
            this.groupBox1.Controls.Add(this.LabAccount);
            this.groupBox1.Controls.Add(this.BtnGetOneKey);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作说明：点击【一键获取】就OK！ IP:106.187.93.193";
            // 
            // LabInfo
            // 
            this.LabInfo.AutoSize = true;
            this.LabInfo.ForeColor = System.Drawing.Color.Red;
            this.LabInfo.Location = new System.Drawing.Point(183, 107);
            this.LabInfo.Name = "LabInfo";
            this.LabInfo.Size = new System.Drawing.Size(95, 12);
            this.LabInfo.TabIndex = 5;
            this.LabInfo.Text = "Kvkens 荣誉出品";
            // 
            // BtnCopyPassword
            // 
            this.BtnCopyPassword.Location = new System.Drawing.Point(347, 77);
            this.BtnCopyPassword.Name = "BtnCopyPassword";
            this.BtnCopyPassword.Size = new System.Drawing.Size(37, 23);
            this.BtnCopyPassword.TabIndex = 4;
            this.BtnCopyPassword.Text = "Copy";
            this.BtnCopyPassword.UseVisualStyleBackColor = true;
            this.BtnCopyPassword.Click += new System.EventHandler(this.BtnCopyPassword_Click);
            // 
            // BtnCopyAccount
            // 
            this.BtnCopyAccount.Location = new System.Drawing.Point(347, 38);
            this.BtnCopyAccount.Name = "BtnCopyAccount";
            this.BtnCopyAccount.Size = new System.Drawing.Size(37, 23);
            this.BtnCopyAccount.TabIndex = 3;
            this.BtnCopyAccount.Text = "Copy";
            this.BtnCopyAccount.UseVisualStyleBackColor = true;
            this.BtnCopyAccount.Click += new System.EventHandler(this.BtnCopyAccount_Click);
            // 
            // TxtPassword
            // 
            this.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPassword.Location = new System.Drawing.Point(185, 77);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.ReadOnly = true;
            this.TxtPassword.Size = new System.Drawing.Size(156, 21);
            this.TxtPassword.TabIndex = 2;
            this.TxtPassword.Text = "请点击“一键获取”！";
            this.TxtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtAccount
            // 
            this.TxtAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtAccount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtAccount.Location = new System.Drawing.Point(185, 39);
            this.TxtAccount.Name = "TxtAccount";
            this.TxtAccount.ReadOnly = true;
            this.TxtAccount.Size = new System.Drawing.Size(156, 21);
            this.TxtAccount.TabIndex = 1;
            this.TxtAccount.Text = "请点击“一键获取”！";
            this.TxtAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LabPassword
            // 
            this.LabPassword.AutoSize = true;
            this.LabPassword.Location = new System.Drawing.Point(148, 81);
            this.LabPassword.Name = "LabPassword";
            this.LabPassword.Size = new System.Drawing.Size(41, 12);
            this.LabPassword.TabIndex = 2;
            this.LabPassword.Text = "密码：";
            // 
            // LabAccount
            // 
            this.LabAccount.AutoSize = true;
            this.LabAccount.Location = new System.Drawing.Point(148, 43);
            this.LabAccount.Name = "LabAccount";
            this.LabAccount.Size = new System.Drawing.Size(41, 12);
            this.LabAccount.TabIndex = 1;
            this.LabAccount.Text = "账号：";
            // 
            // BtnGetOneKey
            // 
            this.BtnGetOneKey.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnGetOneKey.ForeColor = System.Drawing.Color.Red;
            this.BtnGetOneKey.Location = new System.Drawing.Point(23, 34);
            this.BtnGetOneKey.Name = "BtnGetOneKey";
            this.BtnGetOneKey.Size = new System.Drawing.Size(106, 63);
            this.BtnGetOneKey.TabIndex = 0;
            this.BtnGetOneKey.Text = "一键获取";
            this.BtnGetOneKey.UseVisualStyleBackColor = true;
            this.BtnGetOneKey.Click += new System.EventHandler(this.BtnGetOneKey_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TssInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 148);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(427, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TssInfo
            // 
            this.TssInfo.Name = "TssInfo";
            this.TssInfo.Size = new System.Drawing.Size(131, 17);
            this.TssInfo.Text = "toolStripStatusLabel1";
            // 
            // TimeClock
            // 
            this.TimeClock.Enabled = true;
            this.TimeClock.Interval = 1000;
            this.TimeClock.Tick += new System.EventHandler(this.TimeClock_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 170);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[远程VPN账号获取] WwW.ImYY.Org 荣誉出品";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Label LabPassword;
        private System.Windows.Forms.Label LabAccount;
        private System.Windows.Forms.Button BtnGetOneKey;
        private System.Windows.Forms.Button BtnCopyPassword;
        private System.Windows.Forms.Button BtnCopyAccount;
        private System.Windows.Forms.Label LabInfo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TssInfo;
        private System.Windows.Forms.Timer TimeClock;
    }
}

