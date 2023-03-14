using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomDrawMethods;

namespace Curs3
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pcbDisplay.Width, pcbDisplay.Height);
            g = Graphics.FromImage(bmp);
        }

        private void btnEx1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);

            Random rnd = new Random();
            int n = rnd.Next(25, 50);
            Pen pointsPen = new Pen(Color.Black, 2);

            Point[] points = CustomGraphics.DrawRandomPoints(g, pointsPen, 2 * n, 0, 0, pcbDisplay.Width, pcbDisplay.Height);


            RefreshImage();
        }

        private void RefreshImage()
        {
            pcbDisplay.Image = bmp;
        }
    }
}
