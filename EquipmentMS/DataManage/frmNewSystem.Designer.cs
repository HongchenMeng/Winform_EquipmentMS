namespace EquipmentMS.DataManage
{
    partial class frmNewSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewSystem));
            this.label1 = new System.Windows.Forms.Label();
            this.chkBase = new System.Windows.Forms.CheckBox();
            this.chkOperation = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = null;
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // chkBase
            // 
            this.chkBase.AccessibleDescription = null;
            this.chkBase.AccessibleName = null;
            resources.ApplyResources(this.chkBase, "chkBase");
            this.chkBase.BackgroundImage = null;
            this.chkBase.Font = null;
            this.chkBase.ForeColor = System.Drawing.Color.Blue;
            this.chkBase.Name = "chkBase";
            this.chkBase.UseVisualStyleBackColor = true;
            // 
            // chkOperation
            // 
            this.chkOperation.AccessibleDescription = null;
            this.chkOperation.AccessibleName = null;
            resources.ApplyResources(this.chkOperation, "chkOperation");
            this.chkOperation.BackgroundImage = null;
            this.chkOperation.Font = null;
            this.chkOperation.ForeColor = System.Drawing.Color.Blue;
            this.chkOperation.Name = "chkOperation";
            this.chkOperation.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.AccessibleDescription = null;
            this.btnClear.AccessibleName = null;
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.BackgroundImage = null;
            this.btnClear.Font = null;
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleDescription = null;
            this.btnExit.AccessibleName = null;
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.BackgroundImage = null;
            this.btnExit.Font = null;
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmNewSystem
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.chkOperation);
            this.Controls.Add(this.chkBase);
            this.Controls.Add(this.label1);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.Name = "frmNewSystem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkBase;
        private System.Windows.Forms.CheckBox chkOperation;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
    }
}