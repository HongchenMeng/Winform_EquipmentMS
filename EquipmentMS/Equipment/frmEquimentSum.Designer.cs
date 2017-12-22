namespace EquipmentMS.Equipment
{
    partial class frmEquimentSum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEquimentSum));
            this.dtpZjrq = new System.Windows.Forms.DateTimePicker();
            this.btnSum = new System.Windows.Forms.Button();
            this.dgvEquiment = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquiment)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpZjrq
            // 
            this.dtpZjrq.AccessibleDescription = null;
            this.dtpZjrq.AccessibleName = null;
            resources.ApplyResources(this.dtpZjrq, "dtpZjrq");
            this.dtpZjrq.BackgroundImage = null;
            this.dtpZjrq.CalendarFont = null;
            this.dtpZjrq.CustomFormat = null;
            this.dtpZjrq.Font = null;
            this.dtpZjrq.Name = "dtpZjrq";
            // 
            // btnSum
            // 
            this.btnSum.AccessibleDescription = null;
            this.btnSum.AccessibleName = null;
            resources.ApplyResources(this.btnSum, "btnSum");
            this.btnSum.BackgroundImage = null;
            this.btnSum.Font = null;
            this.btnSum.Name = "btnSum";
            this.btnSum.UseVisualStyleBackColor = true;
            this.btnSum.Click += new System.EventHandler(this.btnSum_Click);
            // 
            // dgvEquiment
            // 
            this.dgvEquiment.AccessibleDescription = null;
            this.dgvEquiment.AccessibleName = null;
            resources.ApplyResources(this.dgvEquiment, "dgvEquiment");
            this.dgvEquiment.BackgroundImage = null;
            this.dgvEquiment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquiment.Font = null;
            this.dgvEquiment.Name = "dgvEquiment";
            this.dgvEquiment.RowTemplate.Height = 23;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // btnExcel
            // 
            this.btnExcel.AccessibleDescription = null;
            this.btnExcel.AccessibleName = null;
            resources.ApplyResources(this.btnExcel, "btnExcel");
            this.btnExcel.BackgroundImage = null;
            this.btnExcel.Font = null;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.AccessibleDescription = null;
            this.btnCalc.AccessibleName = null;
            resources.ApplyResources(this.btnCalc, "btnCalc");
            this.btnCalc.BackgroundImage = null;
            this.btnCalc.Font = null;
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
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
            // frmEquimentSum
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEquiment);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnSum);
            this.Controls.Add(this.dtpZjrq);
            this.Font = null;
            this.Icon = null;
            this.Name = "frmEquimentSum";
            this.Resize += new System.EventHandler(this.frmEquimentSum_Resize);
            this.Load += new System.EventHandler(this.frmEquimentSum_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquiment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpZjrq;
        private System.Windows.Forms.Button btnSum;
        private System.Windows.Forms.DataGridView dgvEquiment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button btnExit;

    }
}