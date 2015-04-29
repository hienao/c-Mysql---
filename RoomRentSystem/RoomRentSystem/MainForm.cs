using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoomRentSystem
{
    public partial class MainForm : Form
    {
        static string usernamestr;
        public MainForm()
        {
            usernamestr = "admin";
            InitializeComponent();
        }

        public MainForm(string user)
        {
            usernamestr = user;
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "房屋租赁管理系统       当前用户：" + usernamestr;
            if (usernamestr.Equals("admin"))
                toolStripButton3.Visible = false;
            else
                toolStripButton2.Visible = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            Roominf roominf = new Roominf();
            roominf.TopLevel = false;
            roominf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            roominf.WindowState = FormWindowState.Normal;
            roominf.Dock = DockStyle.Fill;
            roominf.KeyPreview = true;
            roominf.Parent = splitContainer1.Panel2;     
            roominf.Show();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            Userinf userinf = new Userinf();
            userinf.TopLevel = false;
            userinf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            userinf.WindowState = FormWindowState.Normal;
            userinf.Dock = DockStyle.Fill;
            userinf.KeyPreview = true;
            userinf.Parent = splitContainer1.Panel2;   
            userinf.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Currentuserpwdedit cupe = new Currentuserpwdedit(usernamestr);
            cupe.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Managerinf minf = new Managerinf();
            minf.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            Rentinf rentinf = new Rentinf();
            rentinf.TopLevel = false;
            rentinf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            rentinf.WindowState = FormWindowState.Normal;
            rentinf.Dock = DockStyle.Fill;
            rentinf.KeyPreview = true;
            rentinf.Parent = splitContainer1.Panel2;
            rentinf.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            Billsinf binf = new Billsinf();
            binf.TopLevel = false;
            binf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            binf.WindowState = FormWindowState.Normal;
            binf.Dock = DockStyle.Fill;
            binf.KeyPreview = true;
            binf.Parent = splitContainer1.Panel2;
            binf.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Othersetting oset = new Othersetting();
            oset.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            Financeinf finance = new Financeinf();
            finance.TopLevel = false;
            finance.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            finance.WindowState = FormWindowState.Normal;
            finance.Dock = DockStyle.Fill;
            finance.KeyPreview = true;
            finance.Parent = splitContainer1.Panel2;
            finance.Show();
        }
    }
}
