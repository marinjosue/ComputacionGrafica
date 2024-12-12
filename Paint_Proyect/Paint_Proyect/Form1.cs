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
        private bool estadoRellenoActivo = false;
        private Color colorSeleccionado = Color.Black;

        public Form1()
        {
            InitializeComponent();
            classDibujar = new Dibujar(picCanvasLienzo);
            administrador = new Administrador(picCanvasLienzo, classDibujar);
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.vScrollBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vScrollBar1_MouseUp);
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
            if (estadoRellenoActivo)
            {
                classDibujar.RellenarArea(e.Location, colorSeleccionado);
                estadoRellenoActivo = false; // Desactivar el estado de relleno
            }
            else
            {
                classDibujar.IniciarDibujo(e);
                picCanvasLienzo.Cursor = Cursors.Hand;
            }
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
            classDibujar.ActivarLapiz();
            MessageBox.Show("Lápiz activado.");
        }


        private void ColorBTN1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            colorSeleccionado = btn.BackColor; // Seleccionar el color del botón
            classDibujar.CambiarColor(colorSeleccionado); // Actualizar el color del lápiz
            MessageBox.Show($"Color seleccionado: {colorSeleccionado.Name}");
        }


        private void btnBorrar_Click(object sender, EventArgs e)
        {
            classDibujar.ActivarBorrador();
            MessageBox.Show("Borrador activado.");
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

        private void btnRelleno_Click(object sender, EventArgs e)
        {
            estadoRellenoActivo = true;
            MessageBox.Show("Haga clic en el área que desea rellenar.");
        }



        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            classDibujar.Deshacer();
        }

        private void btnRehacer_Click(object sender, EventArgs e)
        {
            classDibujar.Rehacer();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // Actualizar el grosor mientras se desplaza
            float nuevoGrosor = e.NewValue;
            classDibujar.CambiarGrosor(nuevoGrosor);
        }
        private void vScrollBar1_MouseUp(object sender, MouseEventArgs e)
        {
            // Mostrar mensaje cuando se suelta el mouse
            float nuevoGrosor = vScrollBar1.Value;
            MessageBox.Show($"Grosor de línea cambiado a: {nuevoGrosor}");
        }
    }
}