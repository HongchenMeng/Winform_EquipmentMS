using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EquipmentMS.BaseInfo
{
    public partial class frmBaseNumber : Form
    {
        EquipmentMS.BaseClass.Operation oper = new EquipmentMS.BaseClass.Operation();
        DataSet ds = null;

        public frmBaseNumber()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ds = oper.GetDataSetBaseDefaultNO();
            if (ds.Tables[0].Rows.Count ==0)
            {
                int i = oper.InsertBaseDefaultNO(txtFirst.Text, Convert.ToInt32(txtDefault.Text));
            }
            else
            {
                int i = oper.UpdateBaseDefaultNO(txtFirst.Text, Convert.ToInt32(txtDefault.Text));
            }
            MessageBox.Show("設置成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBaseNumber_Load(object sender, EventArgs e)
        {
            ds = oper.GetDataSetBaseDefaultNO();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtFirst.Text = ds.Tables[0].Rows[0]["firstNO"].ToString();
                txtDefault.Text = ds.Tables[0].Rows[0]["defaultNO"].ToString();
            }
        }
    }
}