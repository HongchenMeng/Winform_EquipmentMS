using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EquipmentMS.Equipment
{
    public partial class frmEquipmentInsert : Form
    {
        EquipmentMS.BaseClass.Operation oper = new EquipmentMS.BaseClass.Operation();
        public frmEquipmentInsert()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNX.Text == "0" || txtNX.Text == "")
            {
                errText.SetError(txtNX, "使用年限必須大於０");
                return;
            }
            if (cmbZjff.Text == "")
            {
                errText.SetError(cmbZjff, "請選擇資產折舊方法！");
                return;
            }



            EquipmentMS.BaseClass.cZcMain zcMain = new EquipmentMS.BaseClass.cZcMain();
            zcMain.BH = txtBH.Text;
            zcMain.MC = cmbMC.Text;
            zcMain.XH = txtXH.Text;
            zcMain.Zclb = cmbZclb.Text;
            zcMain.Xxpz = txtXxpz.Text;
            zcMain.Gjbh = txtGjbh.Text;
            zcMain.Sccj = txtSccj.Text;
            zcMain.Ccrq = dtpCcrq.Value;
            zcMain.Zjfs = cmbZjfs.Text;
            zcMain.Sybm = cmbSybm.Text;
            zcMain.Syqk = cmbSyqk.Text;
            zcMain.Cfdd = cmbCfdd.Text;
            zcMain.Bgry = cmbBgry.Text;
            zcMain.Rzrq = dtpRzrq.Value;
            zcMain.SL = Convert.ToInt32(txtSL.Text);
            zcMain.DW = cmbDW.Text;
            zcMain.DJ = Convert.ToSingle(txtDJ.Text);
            zcMain.YZ = Convert.ToSingle(txtYZ.Text);
            zcMain.Ljzj = Convert.ToSingle(txtLjzj.Text);
            zcMain.JZ = Convert.ToSingle(txtJZ.Text);
            zcMain.Jczl = Convert.ToSingle(txtJczl.Text);
            zcMain.Zjff = cmbZjff.Text;
            zcMain.Nx = Convert.ToInt32(txtNX.Text);
            zcMain.Login = dtpLogin.Value;
            zcMain.Loginer = txtLoginer.Text;
            zcMain.Gxrq = gxrq.Value;
            zcMain.Tm = textBox1.Text;
            zcMain.Xlh = textBox2.Text;
            zcMain.Brand = cmbBrand.Text;
            int i = oper.InsertZcMain(zcMain);
            this.btnSave.Enabled = false;
            MessageBox.Show("固定資產添加成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.PrintButton.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindComboBox()
        {
            cmbBgry.DataSource = oper.GetDataSetBaseBgry().Tables[0].DefaultView;
            cmbBgry.ValueMember = "bgry";

            cmbCfdd.DataSource = oper.GetDataSetBaseCfdd().Tables[0].DefaultView;
            cmbCfdd.ValueMember = "cfdd";

            cmbMC.DataSource = oper.GetDataSetBaseZcmc().Tables[0].DefaultView;
            cmbMC.ValueMember = "zcmc";

            cmbSybm.DataSource = oper.GetDataSetBaseSybm().Tables[0].DefaultView;
            cmbSybm.ValueMember = "sybm";

            cmbSyqk.DataSource = oper.GetDataSetBaseSyqk().Tables[0].DefaultView;
            cmbSyqk.ValueMember = "syqk";

            cmbZclb.DataSource = oper.GetDataSetBaseZclb().Tables[0].DefaultView;
            cmbZclb.ValueMember = "zclb";

            cmbZjfs.DataSource = oper.GetDataSetBaseZjfs().Tables[0].DefaultView;
            cmbZjfs.ValueMember = "zjfs";

            cmbDW.DataSource = oper.GetDataSetBaseJldw().Tables[0].DefaultView;
            cmbDW.ValueMember = "jldw";

            cmbBrand.DataSource = oper.GetDataSetBaseBrand().Tables[0].DefaultView;
            cmbBrand.ValueMember = "BrandName";
        }

        private void frmEquipmentInsert_Load(object sender, EventArgs e)
        {
            this.BindComboBox();
            DataSet ds = oper.GetDataSetBaseDefaultNO();
            DataSet dsZcmain = oper.GetDataSetZC();
            string firstNO = ds.Tables[0].Rows[0]["firstNO"].ToString();
            int defaultNO = Convert.ToInt32(ds.Tables[0].Rows[0]["defaultNO"].ToString());

            if (dsZcmain.Tables[0].Rows.Count > 0)
            {
                int j = defaultNO + Convert.ToInt32(dsZcmain.Tables[0].Rows[dsZcmain.Tables[0].Rows.Count - 1]["id"]);
                txtBH.Text = firstNO + j;
            }
            else
            {
                txtBH.Text = firstNO + defaultNO.ToString();
            }
            this.PrintButton.Enabled = false;
        }

        private void txtDJ_TextChanged(object sender, EventArgs e)
        {
            if (oper.IsNumeric(txtDJ.Text))
            {
                txtYZ.Text = Convert.ToString(Convert.ToInt32(txtSL.Text) * Convert.ToSingle(txtDJ.Text) - Convert.ToSingle(txtLjzj.Text));
                txtJZ.Text = Convert.ToString(Convert.ToInt32(txtSL.Text) * Convert.ToSingle(txtDJ.Text) - Convert.ToSingle(txtLjzj.Text));
            }
            else
            {
                MessageBox.Show("請輸入數位！！！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDJ.Undo();
                txtDJ.ClearUndo();
            }
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            if (oper.IsNumeric(txtSL.Text))
            {
                txtYZ.Text = Convert.ToString(Convert.ToInt32(txtSL.Text) * Convert.ToSingle(txtDJ.Text) - Convert.ToSingle(txtLjzj.Text));
                txtJZ.Text = Convert.ToString(Convert.ToInt32(txtSL.Text) * Convert.ToSingle(txtDJ.Text) - Convert.ToSingle(txtLjzj.Text));
            }
            else
            {
                MessageBox.Show("請輸入數位！！！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSL.Undo();
                txtSL.ClearUndo();
            }
        }

        private void txtLjzj_TextChanged(object sender, EventArgs e)
        {
            if (oper.IsNumeric(txtLjzj.Text))
            {
                txtJZ.Text = Convert.ToString(Convert.ToInt32(txtSL.Text) * Convert.ToSingle(txtDJ.Text) - Convert.ToSingle(txtLjzj.Text));
            }
            else
            {
                MessageBox.Show("請輸入數位！！！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLjzj.Undo();
                txtLjzj.ClearUndo();
            }
        }

        private void txtNX_TextChanged(object sender, EventArgs e)
        {
            if (!oper.IsNumeric(txtNX.Text))
            {
                MessageBox.Show("請輸入數位！！！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNX.Undo();
                txtNX.ClearUndo();
            }
        }

        private void txtJczl_TextChanged(object sender, EventArgs e)
        {
            if (!oper.IsNumeric(txtJczl.Text))
            {
                MessageBox.Show("請輸入數位！！！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtJczl.Undo();
                txtJczl.ClearUndo();
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            PrintCodeForm pform = new PrintCodeForm(this.txtBH.Text.Trim());
            pform.ShowDialog();
        }

    }
}
