namespace EquipmentMS.DataManage
{
    partial class frmBakDataBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBakDataBase));
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnBak = new System.Windows.Forms.Button();
            this.btnRes = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.chkBak = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.AccessibleDescription = null;
            this.listView1.AccessibleName = null;
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.BackgroundImage = null;
            this.listView1.Font = null;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bakup.ico");
            // 
            // btnBak
            // 
            this.btnBak.AccessibleDescription = null;
            this.btnBak.AccessibleName = null;
            resources.ApplyResources(this.btnBak, "btnBak");
            this.btnBak.BackgroundImage = null;
            this.btnBak.Font = null;
            this.btnBak.Name = "btnBak";
            this.btnBak.UseVisualStyleBackColor = true;
            this.btnBak.Click += new System.EventHandler(this.btnBak_Click);
            // 
            // btnRes
            // 
            this.btnRes.AccessibleDescription = null;
            this.btnRes.AccessibleName = null;
            resources.ApplyResources(this.btnRes, "btnRes");
            this.btnRes.BackgroundImage = null;
            this.btnRes.Font = null;
            this.btnRes.Name = "btnRes";
            this.btnRes.UseVisualStyleBackColor = true;
            this.btnRes.Click += new System.EventHandler(this.btnRes_Click);
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
            // chkBak
            // 
            this.chkBak.AccessibleDescription = null;
            this.chkBak.AccessibleName = null;
            resources.ApplyResources(this.chkBak, "chkBak");
            this.chkBak.BackgroundImage = null;
            this.chkBak.Font = null;
            this.chkBak.ForeColor = System.Drawing.Color.Blue;
            this.chkBak.Name = "chkBak";
            this.chkBak.UseVisualStyleBackColor = true;
            // 
            // frmBakDataBase
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.chkBak);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRes);
            this.Controls.Add(this.btnBak);
            this.Controls.Add(this.listView1);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.Name = "frmBakDataBase";
            this.Load += new System.EventHandler(this.frmBakDataBase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnBak;
        private System.Windows.Forms.Button btnRes;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chkBak;
    }
}