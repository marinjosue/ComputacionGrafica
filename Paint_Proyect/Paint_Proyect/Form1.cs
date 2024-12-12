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
        private Administrador administrador;

        public Form1()
        {
            InitializeComponent();
            classDibujar = new Dibujar(picCanvasLienzo);
            administrador = new Administrador(picCanvasLienzo, classDibujar);
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
            if (borrarActivo)
            {
                classDibujar.BorrarEnLinea(e);
            }
            else
            {
                classDibujar.IniciarDibujo(e);
                picCanvasLienzo.Cursor = Cursors.Hand;
            }
        }

        private void picCanvasLienzo_MouseMove(object sender, MouseEventArgs e)
        {
            if (borrarActivo)
            {
                classDibujar.BorrarEnLinea(e);
            }
            else
            {
                classDibujar.DibujarLinea(e);
            }
        }

        private void picCanvasLienzo_MouseUp(object sender, MouseEventArgs e)
        {
            classDibujar.TerminarDibujo();
            picCanvasLienzo.Cursor = Cursors.Default;
        }

        private void btnLapiz_Click(object sender, EventArgs e)
        {
            borrarActivo = false;
            classDibujar.ToggleLapiz();
            MessageBox.Show($"Lápiz {(classDibujar.IsActive() ? "Activado" : "Desactivado")}");
        }


        private void ColorBTN1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            classDibujar.CambiarColor(btn.BackColor);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            borrarActivo = true;
            MessageBox.Show("Herramienta Borrar Activada");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            classDibujar.LimpiarLienzo(); // Limpiar Lienzo activo
            MessageBox.Show("Lienzo Limpio");
                    
        }

        private void cargarImagenes_Click(object sender, EventArgs e)
        {
            administrador.CargarImagen();
        }

        private void guardarComo_Click(object sender, EventArgs e)
        {
            administrador.GuardarImagen();
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            classDibujar.LimpiarLienzo();
        }
    }
}
