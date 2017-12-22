using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EquipmentMS.SystemSet
{
    public partial class frmUnits : Form
    {
        EquipmentMS.BaseClass.Operation oper = new EquipmentMS.BaseClass.Operation();
        public frmUnits()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUnits_Load(object sender, EventArgs e)
        {
            DataSet ds = oper.GetDataSetUnits();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtUnits.Text = ds.Tables[0].Rows[0]["units"].ToString();
                txtUnitsAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
                txtTel.Text = ds.Tables[0].Rows[0]["tel"].ToString();
                txtLinkman.Text = ds.Tables[0].Rows[0]["linkman"].ToString();
                txtMemo.Text = ds.Tables[0].Rows[0]["memo"].ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataSet ds = oper.GetDataSetUnits();
            if (ds.Tables[0].Rows.Count == 0)
            {
                int i = oper.InsertUnits(txtUnits.Text, txtLinkman.Text, txtUnitsAddress.Text, txtTel.Text, txtMemo.Text);
            }
            else
            {
                int i = oper.UpdateUnits(txtUnits.Text, txtLinkman.Text, txtUnitsAddress.Text, txtTel.Text, txtMemo.Text);
            }
            MessageBox.Show("單位資訊--更新成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}