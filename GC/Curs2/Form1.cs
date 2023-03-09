using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CloseAllChildren()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Dispose();
                frm.Close();
            }
        }

        private void ex1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildren();
            Ex1Form frm = new Ex1Form();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void ex2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildren();
            Ex2Form frm = new Ex2Form();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void ex3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildren();
            Ex3Form frm = new Ex3Form();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
    }
}
