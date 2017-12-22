namespace EquipmentMS.BaseInfo
{
    partial class frmDataGridViewSetVisible
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataGridViewSetVisible));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsvVisible = new System.Windows.Forms.ListView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = null;
            this.groupBox1.AccessibleName = null;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackgroundImage = null;
            this.groupBox1.Controls.Add(this.lsvVisible);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Font = null;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lsvVisible
            // 
            this.lsvVisible.AccessibleDescription = null;
            this.lsvVisible.AccessibleName = null;
            resources.ApplyResources(this.lsvVisible, "lsvVisible");
            this.lsvVisible.BackgroundImage = null;
            this.lsvVisible.CheckBoxes = true;
            this.lsvVisible.Font = null;
            this.lsvVisible.Name = "lsvVisible";
            this.lsvVisible.UseCompatibleStateImageBehavior = false;
            this.lsvVisible.View = System.Windows.Forms.View.List;
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
            // btnSave
            // 
            this.btnSave.AccessibleDescription = null;
            this.btnSave.AccessibleName = null;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackgroundImage = null;
            this.btnSave.Font = null;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmDataGridViewSetVisible
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.groupBox1);
            this.Font = null;
            this.Icon = null;
            this.Name = "frmDataGridViewSetVisible";
            this.Load += new System.EventHandler(this.frmDataGridViewSetVisible_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView lsvVisible;
    }
}