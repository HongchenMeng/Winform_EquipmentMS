using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EquipmentMS.Equipment
{
    public partial class frmEquipmentClear : Form
    {
        EquipmentMS.BaseClass.Operation oper = new EquipmentMS.BaseClass.Operation();
        public EquipmentMS.frmMain M_frmMain = null;
        public string M_str_BH = "";
        public frmEquipmentClear()
        {
            InitializeComponent();
        }

        private void frmEquipmentClear_Load(object sender, EventArgs e)
        {
            DataSet ds = oper.GetDataSetZC(M_str_BH);
            txtBH.Text = ds.Tables[0].Rows[0]["BH"].ToString();
            txtMC.Text = ds.Tables[0].Rows[0]["MC"].ToString();
            txtXH.Text = ds.Tables[0].Rows[0]["XH"].ToString();
            txtXxpz.Text = ds.Tables[0].Rows[0]["Xxpz"].ToString();
            txtSybm.Text = ds.Tables[0].Rows[0]["Sybm"].ToString();
            txtSyqk.Text = ds.Tables[0].Rows[0]["Syqk"].ToString();
            txtCfdd.Text = ds.Tables[0].Rows[0]["Cfdd"].ToString();
            txtBgry.Text = ds.Tables[0].Rows[0]["Bgry"].ToString();

            cmbQlfs.DataSource = oper.GetDataSetBaseQlfs().Tables[0].DefaultView;
            cmbQlfs.ValueMember = "qlfs";


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            EquipmentMS.BaseClass.cZcMain zcMain = new EquipmentMS.BaseClass.cZcMain();
            zcMain.BH = txtBH.Text;
            zcMain.MC = txtMC.Text;
            zcMain.XH = txtXH.Text;
            zcMain.Xxpz = txtXxpz.Text;
            zcMain.Sybm = txtSybm.Text;
            zcMain.Syqk = txtSyqk.Text;
            zcMain.Cfdd = txtCfdd.Text;
            zcMain.Bgry = txtBgry.Text;
            zcMain.Qlr = txtQlr.Text;
            zcMain.Qlfs = cmbQlfs.Text;
            zcMain.Qlrq = dtpQlrq.Value;
            zcMain.Pzr = txtPzr.Text;
            zcMain.Memo = txtMemo.Text;
            int i = oper.ClearZcMain(zcMain);
            MessageBox.Show("固定資產清理成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnClear.Enabled = false;
            int j = oper.DeleteZcMain(txtBH.Text);
        }
    }
}