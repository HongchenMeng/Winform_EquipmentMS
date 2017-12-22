using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Win32;
namespace EquipmentMS
{
    public partial class frmMain : Form
    {
        BaseClass.Operation oper = new BaseClass.Operation();
        public frmMain()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            staDataTime.Text = DateTime.Now.ToString();
        }

        private void tlbtnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("請確認退出！", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                Application.Exit();
        }

        private void DataBindGridViewList()
        {
            DataSet P_dsDataGridView = null;
            DataSet P_dsZC = null;

            P_dsDataGridView = oper.GetDataGridViewList();
            P_dsZC = oper.GetDataSetZC();

            dgvEquipmentList.DataSource = P_dsZC.Tables[0].DefaultView;

            for (int j = 0; j < P_dsZC.Tables[0].Columns.Count; j++)
            {
                for (int i = 1; i < P_dsDataGridView.Tables[0].Rows.Count; i++)
                    if (P_dsDataGridView.Tables[0].Rows[i]["filedName"].ToString() == P_dsZC.Tables[0].Columns[j].ColumnName)
                    {
                        dgvEquipmentList.Columns[i].HeaderText = P_dsDataGridView.Tables[0].Rows[i - 1]["title"].ToString();
                        dgvEquipmentList.Columns[i+1].Width = Convert.ToInt16(P_dsDataGridView.Tables[0].Rows[i]["width"].ToString());
                        dgvEquipmentList.Columns[i+1].Visible = Convert.ToBoolean(P_dsDataGridView.Tables[0].Rows[i]["visible"].ToString());
                    }
            }
            dgvEquipmentList.Columns[P_dsZC.Tables[0].Columns.Count - 1].HeaderText = P_dsDataGridView.Tables[0].Rows[P_dsDataGridView.Tables[0].Rows.Count - 1]["title"].ToString();
            dgvEquipmentList.Columns[P_dsZC.Tables[0].Columns.Count - 1].Width = Convert.ToInt16(P_dsDataGridView.Tables[0].Rows[P_dsDataGridView.Tables[0].Rows.Count - 1]["width"].ToString());
            dgvEquipmentList.Columns[P_dsZC.Tables[0].Columns.Count - 1].Visible = Convert.ToBoolean(P_dsDataGridView.Tables[0].Rows[P_dsDataGridView.Tables[0].Rows.Count - 1]["visible"].ToString());
            dgvEquipmentList.Columns[0].Visible = false;
        }
        private void SetUnits()
        {
            DataSet ds = oper.GetDataSetUnits();
            staUnits.Text = ds.Tables[0].Rows[0]["units"].ToString();
            staAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();

        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.SetUnits();

            this.DataBindGridViewList();

            this.SetTreeView();
        }
        private void SetTreeView()
        {
            trvFile.Nodes.Clear();
            //设置TreeView控件的菜单项
            DataSet ds = null;
            ds = oper.TreeFill();
            TreeNode RootNode = null;
            TreeNode chileNode = null;
            DataTable dt = ds.Tables[0].Copy();     //将资产列表另存一份为dt
            DataView dv = new DataView(dt);
            dv.RowFilter = "firstID = -1";
            //将数据集中的所有记录逐个根据他们之间的关系添加到树形表中去
            if (dv.Count > 0)
            {
                foreach (DataRowView myRow in dv)
                {
                    //设置根节点,然后该函数会递归添加所有子节点。
                    trvFile.Nodes.Add(RootNode = new TreeNode(myRow["zclb"].ToString()));
                    childTreeView(myRow["zclb"].ToString(), trvFile.Nodes[0], myRow);
                    trvFile.SelectedNode = trvFile.Nodes[0]; //选中第一个节点 
                }
            }
            //展开节点
            trvFile.ExpandAll();
            //填充－－增加方式
            chileNode = RootNode.Nodes.Add("增加方式", "增加方式", 1);
            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                chileNode.Nodes.Add("", ds.Tables[1].Rows[i]["zjfs"].ToString(), 2);
            }
            //填充－－使用部门
            chileNode = RootNode.Nodes.Add("使用部門", "使用部門", 1);
            for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
            {
                chileNode.Nodes.Add("", ds.Tables[2].Rows[i]["sybm"].ToString(), 2);
            }
            //填充－－使用情况
            chileNode = RootNode.Nodes.Add("使用情況", "使用情況", 1);
            for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
            {
                chileNode.Nodes.Add("", ds.Tables[3].Rows[i]["syqk"].ToString(), 2);
            }
            //填充－－存放地点
            chileNode = RootNode.Nodes.Add("存放地點", "存放地點", 1);
            for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
            {
                chileNode.Nodes.Add("", ds.Tables[4].Rows[i]["cfdd"].ToString(), 2);
            }
            //填充－－保管人员
            chileNode = RootNode.Nodes.Add("保管人員", "保管人員", 1);
            for (int i = 0; i < ds.Tables[5].Rows.Count; i++)
            {
                chileNode.Nodes.Add("", ds.Tables[5].Rows[i]["bgry"].ToString(), 2);
            }
        }
        private void childTreeView(string childPart, TreeNode childNode, DataRowView childRow)
        {
            string strdeptName = "";
            DataSet ds = null;
            ds = oper.TreeFill();
            DataTable dt = ds.Tables[0].Copy();
            DataView dv = new DataView(dt);
            //筛选获得当前传递过来的节点的子项，并将其添加到树形图中
            //判断方法是凡parentIndex等于传递过来的节点的absIndex的，就是该节点的子项
            dv.RowFilter = "firstID = '" + childRow["secondID"].ToString() + "'";
            //递归的添加每一个节点的所有子节点
            foreach (DataRowView myRow in dv)
            {
                strdeptName = myRow["zclb"].ToString();
                TreeNode myNode = new TreeNode(strdeptName);
                childNode.Nodes.Add(myNode);
                //函数递归调用，将所有节点按顺序添加完毕
                childTreeView(strdeptName, myNode, myRow);
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            new EquipmentMS.BaseInfo.frmBaseSort().Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new EquipmentMS.BaseInfo.frmBaseInfo().Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            toolStripMenuItem3_Click(sender, e);
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            toolStripTextBox1_Click(sender, e);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            new EquipmentMS.BaseInfo.frmBaseNumber().Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            new EquipmentMS.Equipment.frmEquipmentInsert().Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem11_Click(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem12_Click(sender, e);
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (dgvEquipmentList.RowCount > 1)
            {
                EquipmentMS.Equipment.frmEquipmentUpdate frmEUpdate = new EquipmentMS.Equipment.frmEquipmentUpdate();
                frmEUpdate.M_frmMain = this;
                frmEUpdate.M_str_BH = dgvEquipmentList.SelectedCells[1].Value.ToString();
                frmEUpdate.Show();
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            this.DataBindGridViewList();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            if (dgvEquipmentList.RowCount > 1)
            {
                if (MessageBox.Show("是否刪除當前行資料!", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int i = oper.DeleteZcMain(dgvEquipmentList.SelectedCells[1].Value.ToString());
                    this.DataBindGridViewList();
                }
            }
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            if (dgvEquipmentList.RowCount > 1)
            {
                DataSet ds = oper.GetDataSetZC(dgvEquipmentList.SelectedCells[1].Value.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    EquipmentMS.Equipment.frmEquipmentClear frmEClear = new EquipmentMS.Equipment.frmEquipmentClear();
                    frmEClear.M_frmMain = this;
                    frmEClear.M_str_BH = dgvEquipmentList.SelectedCells[1].Value.ToString();
                    frmEClear.Show();
                }
                else
                {
                    MessageBox.Show("用戶選擇的資料不存在！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DataBindGridViewList();
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStripMenuItem14_Click(sender, e);
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            new EquipmentMS.DataManage.frmBakDataBase().Show();
        }

        private void toolStripSeparator4_Click(object sender, EventArgs e)
        {
            new EquipmentMS.Equipment.frmEquipmentClearFind().Show();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            new EquipmentMS.Equipment.frmEquimentSum().Show();
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            new EquipmentMS.SystemSet.frmUser().Show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            DataSet P_dsDataGridView = null;
            DataSet P_dsZC = null;

            P_dsDataGridView = oper.GetDataGridViewList();
            P_dsZC = oper.GetDataSetZC();

            for (int j = 0; j < P_dsZC.Tables[0].Columns.Count; j++)
            {
                for (int i = 1; i < P_dsDataGridView.Tables[0].Rows.Count; i++)
                {
                    if (P_dsDataGridView.Tables[0].Rows[i]["filedName"].ToString() == P_dsZC.Tables[0].Columns[j].ColumnName)
                    {
                        int d = oper.DataGridViewSetWidth(dgvEquipmentList.Columns[j].Index, dgvEquipmentList.Columns[j].Width);
                    }
                }
            }
            this.DataBindGridViewList();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            new EquipmentMS.BaseInfo.frmDataGridViewSetVisible().Show();
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            new EquipmentMS.SystemSet.frmUnits().Show();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            new EquipmentMS.DataManage.frmNewSystem().Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.SetTreeView();
        }

        private void trvFile_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            DataSet ds = null;
            if (e.Node.Text == "全部資產")
            {
                ds = oper.GetDataSetZC();
            }
            else
            {
                switch (e.Node.Parent.Text)
                {
                    case "資產類別":
                        ds = oper.GetDataSetBaseZcMain_zclb(e.Node.Text);
                        break;
                    case "增加方式":
                        ds = oper.GetDataSetBaseZcMain_zjfs(e.Node.Text);
                        break;
                    case "使用部門":
                        ds = oper.GetDataSetBaseZcMain_sybm(e.Node.Text);
                        break;
                    case "使用情況":
                        ds = oper.GetDataSetBaseZcMain_syqk(e.Node.Text);
                        break;
                    case "存放地點":
                        ds = oper.GetDataSetBaseZcMain_cfdd(e.Node.Text);
                        break;
                    case "保管人員":
                        ds = oper.GetDataSetBaseZcMain_bgry(e.Node.Text);
                        break;
                    default:
                        return;
                }
            }
            dgvEquipmentList.DataSource = ds.Tables[0].DefaultView;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (tlcmbFind.Text == "")
                return;
            string findTitle = "";
            if (tlcmbFind.Text == "資產編號")
                findTitle = "BH";
            else
                findTitle = "MC";
            dgvEquipmentList.DataSource = oper.GetDataSetZC(findTitle, tltxtFind.Text).Tables[0].DefaultView;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            toolStripMenuItem16_Click(sender, e);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            toolStripMenuItem21_Click(sender, e);
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            Application.Exit();
            System.Diagnostics.Process.Start("EquipmentMS");
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            toolStripMenuItem26_Click(sender, e);
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            tlbtnExit_Click(sender, e);
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dgvEquipmentList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            toolStripMenuItem12_Click(sender, e);
        }

        private void dgvEquipmentList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8 || e.KeyCode == Keys.Delete)
            {
                toolStripMenuItem13_Click(sender, e);
            }
        }

        private void 繁体中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 簡體中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void 繁体中文ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CHT");
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("zh-CHT");
            regKey.GetValue("zh-CHT", "visible");
            regKey.SetValue("zh-CHT", (long)42);
            //System.Diagnostics.Process.Start(Application.ExecutablePath, "");
            //this.Close();


        }

        private void 语言ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CHS");
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("zh-CHS");
            regKey.GetValue("zh-CHS", "visible");
            regKey.SetValue("zh-CHS", (long)42);
           
        }

        private void PrintCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintCodeForm pForm = new PrintCodeForm();
            pForm.ShowDialog();
        }

        private void pDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VitApp.MainForm vmForm = new VitApp.MainForm();
            vmForm.ShowDialog();
        }
    }
}