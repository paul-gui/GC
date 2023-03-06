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
    public partial class Ex1Form : Form
    {
        public Ex1Form()
        {
            InitializeComponent();
        }

        private void Ex1Form_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
        }

        private void Operations()
        {
            Random rnd = new Random();
            int n = rnd.Next(50, 100);


        }
    }
}
