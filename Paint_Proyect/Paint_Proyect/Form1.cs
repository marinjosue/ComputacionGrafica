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


        private Dibujar classDibujar;
        public Form1()
        {
            InitializeComponent();
            classDibujar = new Dibujar(picCanvasLienzo.CreateGraphics());
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
            classDibujar.IniciarDibujo(e);
            picCanvasLienzo.Cursor = Cursors.Hand;
        }

        private void picCanvasLienzo_MouseMove(object sender, MouseEventArgs e)
        {
            classDibujar.DibujarLinea(e);
        }

        private void picCanvasLienzo_MouseUp(object sender, MouseEventArgs e)
        {
            classDibujar.TerminarDibujo();
            picCanvasLienzo.Cursor = Cursors.Default;
        }

        private void ColorBTN1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            classDibujar.CambiarColor(btn.BackColor);
        }

    }
}
