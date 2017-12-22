using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EquipmentMS.BaseInfo
{
    public partial class frmDataGridViewSetVisible : Form
    {
        EquipmentMS.BaseClass.Operation oper = new EquipmentMS.BaseClass.Operation();
        public frmDataGridViewSetVisible()
        {
            InitializeComponent();
        }

        private void frmDataGridViewSetVisible_Load(object sender, EventArgs e)
        {
            DataSet ds = oper.GetDataGridViewList();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lsvVisible.Items.Add(ds.Tables[0].Rows[i]["title"].ToString());
                lsvVisible.Items[i].Checked = Convert.ToBoolean(ds.Tables[0].Rows[i]["visible"]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvVisible.Items.Count; i++)
            {
                int d = oper.DataGridViewSetVisible(lsvVisible.Items[i].Index + 1, lsvVisible.Items[i].Checked);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDataGridViewSetVisible_Load_1(object sender, EventArgs e)
        {

        }
    }
}