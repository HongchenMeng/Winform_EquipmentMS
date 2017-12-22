using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.IO;

namespace EquipmentMS.DataManage
{
    public partial class frmBakDataBase : Form
    {
        EquipmentMS.BaseClass.Operation oper = new EquipmentMS.BaseClass.Operation();
        private int P_int_checkListItem = 0;
        public frmBakDataBase()
        {
            InitializeComponent();
        }

        private void BindListView()
        {
            listView1.Clear();
            string strPath = GetBakUpPath() + @"\\bakDataBase\\db_EquipmentMS.bak";
            DataSet ds = oper.GetBakUp(strPath);
            DataRow[] row = ds.Tables[0].Select();
            int i=0;
            foreach (DataRow fileName in row)
            {
                listView1.Items.Add(fileName[5].ToString(), fileName[18].ToString(), 0);
                listView1.Items[i++].ToolTipText = fileName[5].ToString();
            }
        }
        private string GetBakUpPath()
        { 
            string path=Application.StartupPath;
            return path.Substring(0, path.LastIndexOf("bin\\Debug"));
        }

        private void frmBakDataBase_Load(object sender, EventArgs e)
        {
            this.BindListView();
        }

        private void btnBak_Click(object sender, EventArgs e)
        {
            if (chkBak.Checked)
                oper.BackUp(GetBakUpPath() + @"\\bakDataBase\\db_EquipmentMS.bak", true);
            else
                oper.BackUp(GetBakUpPath() + @"\\bakDataBase\\db_EquipmentMS.bak", false);
            this.BindListView();
            MessageBox.Show("系統資料備份成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            if (P_int_checkListItem > 0)
            {
                oper.ReStore(GetBakUpPath() + @"\\bakDataBase\\db_EquipmentMS.bak", P_int_checkListItem);
                MessageBox.Show("系統資料恢復成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("請選擇恢復到資料的備份日期！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item.ToolTipText == "")
                P_int_checkListItem = 0;
            else
                P_int_checkListItem = Convert.ToInt32(e.Item.ToolTipText);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}