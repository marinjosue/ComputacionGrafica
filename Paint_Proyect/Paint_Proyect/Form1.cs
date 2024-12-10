using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_Proyect
{
    public partial class Form1 : Form
    {

        Graphics g;
        int x = -1;
        int y = -1;
        bool movimiento = false;
        Pen pen;
        public Form1()
        {
            InitializeComponent();
            g = picCanvasLienzo.CreateGraphics();
            pen = new Pen(Color.Black,5);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; 
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void btnEstrella_Click(object sender, EventArgs e)
        {
            WidthLineBTN.Enabled = true;
        }

        private void SquardToolsBTN_Click(object sender, EventArgs e)
        {
            WidthLineBTN.Enabled = true;
        }

        private void ElipseToolsBTN_Click(object sender, EventArgs e)
        {
           WidthLineBTN.Enabled = true;
        }

        private void LineToolsBTN_Click(object sender, EventArgs e)
        {
            WidthLineBTN.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void WidthLineBTN_Click(object sender, EventArgs e)
        {
            groupTamanioOpcion.Visible = !groupTamanioOpcion.Visible;
        }


        private void picCanvasLienzo_MouseDown(object sender, MouseEventArgs e)
        {
            movimiento = true;
            x=e.X;
            y=e.Y;  
            picCanvasLienzo.Cursor= Cursors.Hand;   
        }

        private void picCanvasLienzo_MouseMove(object sender, MouseEventArgs e)
        {
            if(movimiento && x!=-1 && y != -1)
            {
                g.DrawLine(pen, new Point(x,y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void picCanvasLienzo_MouseUp(object sender, MouseEventArgs e)
        {
            movimiento = false;
            x = -1;
            y= -1;
            picCanvasLienzo.Cursor = Cursors.Default;
        }

        private void ColorBTN1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; // Obtener el Button
            pen.Color = btn.BackColor; // Cambiar el color del pen al color de fondo del PictureBox
        }

    }
}
