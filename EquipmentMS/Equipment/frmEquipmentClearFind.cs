using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EquipmentMS.Equipment
{
    public partial class frmEquipmentClearFind : Form
    {
        EquipmentMS.BaseClass.Operation oper = new EquipmentMS.BaseClass.Operation();
        string P_str_type = "";
        string P_str_BH = "";
        public frmEquipmentClearFind()
        {
            InitializeComponent();
        }

        private void frmEquipmentClearFind_Load(object sender, EventArgs e)
        {
            toolStripButton2_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (tlcmbFind.Text == "")
            {
                MessageBox.Show("請選擇查詢條件！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataSet ds = null;
            ds = oper.GetDataSetzcClear(P_str_type, tltxtContent.Text);
            dgvEquipment.DataSource = ds.Tables[0].DefaultView;
        }

        private void tlcmbFind_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tlcmbFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tlcmbFind.Text)
            {
                case "資產編號":
                    P_str_type = "BH";
                    break;
                case "資產名稱":
                    P_str_type = "MC";
                    break;
                case "使用部門":
                    P_str_type = "SYBM";
                    break;
                case "存放地點":
                    P_str_type = "CFDD";
                    break;
                case "清理人":
                    P_str_type = "QLR";
                    break;
                case "保管人":
                    P_str_type = "BGRY";
                    break;
                case "批准人":
                    P_str_type = "PZR";
                    break;

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            ds = oper.GetDataSetzcClear();
            dgvEquipment.DataSource = ds.Tables[0].DefaultView;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dgvEquipment.SelectedRows.Count > 0)
            {
                if (dgvEquipment.SelectedCells[0].Value.ToString() == "")
                {
                    MessageBox.Show("請選擇將要刪除的資料！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int i = oper.DeletezcClear(dgvEquipment.SelectedCells[0].Value.ToString());
                DataSet ds = null;
                if (tlcmbFind.Text == "")
                {
                    ds = oper.GetDataSetzcClear("BH", tltxtContent.Text);
                }
                else
                {
                    ds = oper.GetDataSetzcClear(P_str_type, tltxtContent.Text);
                }
                dgvEquipment.DataSource = ds.Tables[0].DefaultView;
                MessageBox.Show("資料刪除成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvEquipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            P_str_BH = dgvEquipment[0, e.RowIndex].Value.ToString();
        }
    }
}