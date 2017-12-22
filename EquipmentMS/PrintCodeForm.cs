using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace EquipmentMS
{
    public partial class PrintCodeForm : Form
    {
        Bitmap memoryImage;
        [DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int NXDestt, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, System.Int32 dwRop);
        BaseClass.Operation oper = new EquipmentMS.BaseClass.Operation();
        DataSet ds = null;
        private string codeNo = "";
        public PrintCodeForm()
        {
            InitializeComponent();
        }
        public PrintCodeForm(string codeNo)
        {
            InitializeComponent();
            this.codeNo = codeNo;
        }
        private void PrintCodeForm_Load(object sender, EventArgs e)
        {
            //this.axBarCodeCtrl1.Style="6--code-39 7--code-128";
            //this.axBarCodeCtrl1.Value="123456 CODE-39";
            this.comboBox1.SelectedIndex = 7;
            this.comboBox2.SelectedIndex = 0;
            this.comboBox3.SelectedIndex = 3;
            this.comboBox4.SelectedIndex = 0;
            this.textBox2.Text ="234";
            this.textBox1.Text ="128";
           
            if (this.codeNo == "")
            {
                this.radioButton1.Checked = true;
            }
            else
            {
                this.radioButton1.Checked = true;
                this.radioButton1.Enabled = false;
                this.radioButton2.Enabled = false;
                this.textBox3.ReadOnly = true;
                this.textBox4.Text = this.codeNo;
                this.axBarCodeCtrl1.Value = this.codeNo;
            }
            
        }
        private void CaptureScreen()
        {
            Graphics mygraphics = axBarCodeCtrl1.CreateGraphics();
            this.memoryImage = new Bitmap(axBarCodeCtrl1.Width, axBarCodeCtrl1.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1, dc2;
            dc1 = mygraphics.GetHdc();
            dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, axBarCodeCtrl1.Width, axBarCodeCtrl1.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
          

        }
        private void PrintButton_Click(object sender, EventArgs e)
        {
            //if (this.radioButton2.Checked == true)
            //{
            //    if (this.textBox3.Text == "")
            //    {
            //        MessageBox.Show("請輸入批量列印的終止號碼!", "提示");
            //        return;
            //    }
            //    else
            //    {
            //        this.ds = oper.GetDataSetZC();

            //        DataRow[] info = this.ds.Tables[0].Select("bh >=" + "'" + this.textBox4.Text.Trim() + "'" + "  and bh <= " + "'" + this.textBox3.Text.Trim() + "'", "bh asc");


            //        if (info.Length < 1)
            //        {
            //            MessageBox.Show("沒有符合條件的條碼存在,請重新輸入", "提示");
            //            return;
            //        }
            //        else
            //        {
            //            for (int i = 0; i < info.Length; i++)
            //            {
            //                this.axBarCodeCtrl1.Value = info[i][1];
            //                this.CaptureScreen();
            //                printDocument1.Print();
            //            }

            //        }
            //    }
            //}
            //if (this.radioButton1.Checked == true && this.radioButton2.Checked == false)
            //{
            //    if (this.textBox4.Text == "")
            //    {
            //        MessageBox.Show("請輸入列印的標簽號碼!", "提示");
            //        return;
            //    }
            //    else 
            //    {
            //        this.axBarCodeCtrl1.Value = this.textBox4.Text.Trim();
            //        this.CaptureScreen();
            //        printDocument1.Print();
            //    }
            //}
            this.CaptureScreen();
            printDocument1.Print();
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;
            short ii = short.Parse(i.ToString());
            axBarCodeCtrl1.Style = ii;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox2.SelectedIndex;
            short ii = short.Parse(i.ToString());
            axBarCodeCtrl1.SubStyle = ii;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox3.SelectedIndex;
            short ii = short.Parse(i.ToString());
            axBarCodeCtrl1.LineWeight = ii;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox4.SelectedIndex;
            short ii = short.Parse(i.ToString());
            axBarCodeCtrl1.Direction = ii;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox2.Text != "")
            {
                axBarCodeCtrl1.Width = int.Parse(this.textBox2.Text.Trim());

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox2.Text != "")
            {
                axBarCodeCtrl1.Height = int.Parse(this.textBox1.Text.Trim());
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true)
            {
                this.textBox3.ReadOnly = true;
                this.textBox3.Text = this.textBox4.Text;
            }
            this.axBarCodeCtrl1.Value = this.textBox4.Text.Trim();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true)
            {
                this.textBox3.ReadOnly = true;
                this.textBox3.Text = this.textBox4.Text;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked == true)
            {
                this.textBox3.ReadOnly = false;
                this.textBox3.Text = "";
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Point ulCorner = new Point(100, 100);
            e.Graphics.DrawImage(memoryImage, ulCorner);
		
        }
    }
}