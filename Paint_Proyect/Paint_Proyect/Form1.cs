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
        private bool borrarActivo = false;

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

        private void btnLapiz_Click(object sender, EventArgs e)
        {
            classDibujar.ToggleLapiz(); // Activa la herramienta lápiz

        }

        private void ColorBTN1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            classDibujar.CambiarColor(btn.BackColor);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Obtener las coordenadas del cursor en el momento del clic
            Point puntoClic = this.PointToClient(Cursor.Position);

            // Crear un objeto MouseEventArgs simulado con las coordenadas del clic
            MouseEventArgs mouseEventArgs = new MouseEventArgs(
                MouseButtons.Left, // Simular un clic izquierdo
                1, // Número de clics
                puntoClic.X,
                puntoClic.Y,
                0); // Número de ruedas

            // Llamar a la función BorrarEnLinea con el MouseEventArgs simulado
            classDibujar.BorrarEnLinea(sender, mouseEventArgs);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            classDibujar.LimpiarLienzo(); // Limpiar Lienzo activo
            MessageBox.Show("Lienzo Limpio");
                    
        }
    }
}
