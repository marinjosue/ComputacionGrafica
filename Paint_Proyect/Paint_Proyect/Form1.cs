using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_Proyect
{
    public partial class Form1 : Form
    {

        Graphics g;
        Pen p = new Pen(Color.Black, 2);
        private Dibujar classDibujar;
        private bool borrarActivo = false;
        private Administrador administrador;
        private bool estadoRellenoActivo = false;
        private Color colorSeleccionado = Color.Black;
        // para dibujar 
        Formas shapeDrawer;
        int index;
        int x, y, sX, sY, cX, cY; // Variables para coordenadas


        public Form1()
        {
            InitializeComponent();
            classDibujar = new Dibujar(picCanvasLienzo);
            administrador = new Administrador(picCanvasLienzo, classDibujar);
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.vScrollBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vScrollBar1_MouseUp);
            shapeDrawer = new Formas(g, p);


        }

        private void btnEstrella_Click(object sender, EventArgs e)
        {
            WidthLineBTN.Enabled = true;
            shapeDrawer = new Formas(g, p);
            index = 8; // Estrella
        }

        private void SquardToolsBTN_Click(object sender, EventArgs e)
        {
            WidthLineBTN.Enabled = true;
            shapeDrawer = new Formas(g, p);
            index = 4;

        }

        private void ElipseToolsBTN_Click(object sender, EventArgs e)
        {
            WidthLineBTN.Enabled = true;
            shapeDrawer = new Formas(g, p);
            index = 3; // Círculo
        }

        private void LineToolsBTN_Click(object sender, EventArgs e)
        {
            WidthLineBTN.Enabled = true;
            shapeDrawer = new Formas(g, p);
            index = 5; // Establecemos el índice para línea
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
            shapeDrawer = new Formas(g, p); // Preparamos el dibujador
            index = 1;
        }


        private void ColorBTN1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            colorSeleccionado = btn.BackColor; // Seleccionar el color del botón
            classDibujar.CambiarColor(colorSeleccionado); // Actualizar el color del lápiz
        }


        private void btnBorrar_Click(object sender, EventArgs e)
        {

            classDibujar.ActivarBorrador();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            classDibujar.LimpiarLienzo(); 
      

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
        }

        private void btnEscribir_Click(object sender, EventArgs e)
        {

        }

        private void ButtonColors_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                
            }
        }
        private void DrawShape()
        {
            if (index == 3) g.DrawEllipse(p, cX, cY, sX, sY);
            if (index == 4) g.DrawRectangle(p, cX, cY, sX, sY);
            if (index == 5) g.DrawLine(p, cX, cY, x, y);

        }

        private void DrawPreview(Graphics g)
        {
            if (index == 3) g.DrawEllipse(p, cX, cY, sX, sY);
            if (index == 4) g.DrawRectangle(p, cX, cY, sX, sY);
            if (index == 5) g.DrawLine(p, cX, cY, x, y);

        }
    }
}