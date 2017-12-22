using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EquipmentMS.BaseInfo
{
    public partial class frmBaseSort : Form
    {
        BaseClass.Operation oper = new EquipmentMS.BaseClass.Operation();
        int zclbID = 0;
        public frmBaseSort()
        {
            InitializeComponent();
        }

        private void frmBaseSort_Load(object sender, EventArgs e)
        {
            this.FillTreeView();
        }
        private void FillTreeView()
        {
            trvFile.Nodes.Clear();
            //设置TreeView控件的菜单项
            DataSet ds = null;
            ds = oper.TreeFill();
            TreeNode RootNode = null;
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
            trvFile.ExpandAll();
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

        private void trvFile_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                DataSet ds = oper.GetDataSetBaseZclb(e.Node.Text);
                zclbID = Convert.ToInt16(ds.Tables[0].Rows[0]["ID"].ToString());
            }
            catch
            { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            DataSet ds = oper.GetDataSetBaseZclb(trvFile.SelectedNode.Text);
            if (ds.Tables[0].Rows[0]["firstID"].ToString() != "-1" && ds.Tables[0].Rows[0]["firstID"].ToString() != "0")
            {
                trvFile.LabelEdit = true;　　　//开启标签编辑
                trvFile.SelectedNode.BeginEdit();
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            DataSet ds = oper.GetDataSetBaseZclb(trvFile.SelectedNode.Text);
            if (ds.Tables[0].Rows[0]["firstID"].ToString() != "-1" && ds.Tables[0].Rows[0]["firstID"].ToString() != "0")
            {
                string firstID = ds.Tables[0].Rows[0]["firstID"].ToString();
                int d = oper.insertBaseZclb(firstID, "新建項目", (Convert.ToInt16(firstID) + 1).ToString());
                this.trvFile.SelectedNode.Parent.Nodes.Add("新建項目");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataSet ds = oper.GetDataSetBaseZclb(trvFile.SelectedNode.Text);
            if (ds.Tables[0].Rows[0]["firstID"].ToString() != "-1" && ds.Tables[0].Rows[0]["firstID"].ToString() != "0")
            {
                oper.deleteBaseZclb(Convert.ToInt16(ds.Tables[0].Rows[0]["id"].ToString()));
                MessageBox.Show("刪除成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.FillTreeView();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            oper.UpdateBaseZclb(zclbID, trvFile.SelectedNode.Text);
            this.FillTreeView();
            trvFile.LabelEdit = false;　　//关闭标签编辑
        }
    }
}