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
    public partial class frmLogin : Form
    {
        EquipmentMS.BaseClass.Operation oper = new EquipmentMS.BaseClass.Operation();
        public frmLogin()
        {
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CHT");
            //RegistryKey regKey = Registry.CurrentUser.CreateSubKey("zh-CHT");
            //regKey.GetValue("zh-CHT", "visible");
            //regKey.SetValue("zh-CHT", (long)42);
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (oper.LoginSystem(txtUserName.Text, txtPWD.Text).Tables[0].Rows.Count > 0)
            {
                new frmMain().Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("操作員用戶名稱或密碼錯誤,請重新輸入！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtUserName.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                txtPWD.Focus();
        }

        private void txtPWD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnOK.Focus();
        }
    }
}