using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EquipmentMS.Equipment
{
    public partial class frmEquipmentUpdate : Form
    {
        EquipmentMS.BaseClass.Operation oper = new EquipmentMS.BaseClass.Operation();
        public EquipmentMS.frmMain M_frmMain = null;
        public string M_str_BH = "";
        public frmEquipmentUpdate()
        {
            InitializeComponent();
        }

        private void frmEquipmentUpdate_Load(object sender, EventArgs e)
        {
            this.BindComboBox();
            txtBH.Text = M_str_BH;
            //根據編號查詢原有資料
            DataSet ds = oper.GetDataSetZC(txtBH.Text);
            cmbMC.Text = ds.Tables[0].Rows[0]["MC"].ToString();
            txtXH.Text = ds.Tables[0].Rows[0]["xh"].ToString();
            cmbZclb.Text = ds.Tables[0].Rows[0]["zclb"].ToString();
            txtXxpz.Text = ds.Tables[0].Rows[0]["xxpz"].ToString();
            txtGjbh.Text = ds.Tables[0].Rows[0]["gbbh"].ToString();
            txtSccj.Text = ds.Tables[0].Rows[0]["sccj"].ToString();
            dtpCcrq.Text = ds.Tables[0].Rows[0]["ccrq"].ToString();
            cmbZjfs.Text = ds.Tables[0].Rows[0]["zjfs"].ToString();
            cmbSybm.Text = ds.Tables[0].Rows[0]["sybm"].ToString();
            cmbSyqk.Text = ds.Tables[0].Rows[0]["syqk"].ToString();
            cmbCfdd.Text = ds.Tables[0].Rows[0]["cfdd"].ToString();
            cmbBgry.Text = ds.Tables[0].Rows[0]["bgry"].ToString();
            dtpRzrq.Text = ds.Tables[0].Rows[0]["rzrq"].ToString();
            txtSL.Text = ds.Tables[0].Rows[0]["sl"].ToString();
            cmbDW.Text = ds.Tables[0].Rows[0]["dw"].ToString();
            txtDJ.Text = ds.Tables[0].Rows[0]["DJ"].ToString();
            txtYZ.Text = ds.Tables[0].Rows[0]["zcYZ"].ToString();
            txtLjzj.Text = ds.Tables[0].Rows[0]["ljzj"].ToString();
            txtJZ.Text = ds.Tables[0].Rows[0]["zcJZ"].ToString();
            txtJczl.Text = ds.Tables[0].Rows[0]["jczl"].ToString();
            cmbZjff.Text = ds.Tables[0].Rows[0]["zjff"].ToString();
            txtNX.Text = ds.Tables[0].Rows[0]["nx"].ToString();
            dtpLogin.Text = ds.Tables[0].Rows[0]["djrq"].ToString();
            txtLoginer.Text = ds.Tables[0].Rows[0]["djr"].ToString();
            textBox1.Text = ds.Tables[0].Rows[0]["tm"].ToString();
            textBox2.Text = ds.Tables[0].Rows[0]["xlh"].ToString();
            BrandcomboBox.Text = ds.Tables[0].Rows[0]["Brand"].ToString();
            this.button1.Enabled = false;
            //ben added


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
            zcMain.Gxrq = UpdateDateTimePicker.Value;
            zcMain.Tm = this.textBox1.Text;
            zcMain.Xlh = this.textBox2.Text;
            zcMain.Brand = this.BrandcomboBox.Text;
            int i = oper.UpdateZcMain(zcMain);

            MessageBox.Show("固定資產更新成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.button1.Enabled = true;
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

            BrandcomboBox.DataSource = oper.GetDataSetBaseBrand().Tables[0].DefaultView;
            BrandcomboBox.ValueMember = "BrandName";

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            PrintCodeForm form = new PrintCodeForm(this.txtBH.Text.Trim());
            form.ShowDialog();
        }
    }
}
