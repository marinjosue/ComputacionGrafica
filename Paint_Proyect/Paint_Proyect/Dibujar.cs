using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_Proyect
{
    internal class Dibujar
    {
        private Graphics g;
        private Pen pen;
        private int x = -1;
        private int y = -1;
        private bool movimiento = false;
        private bool lapizActivo = false;

        public Dibujar(Graphics graphics)
        {
            g = graphics;
            pen = new Pen(Color.Black, 5)
            {
                StartCap = System.Drawing.Drawing2D.LineCap.Round,
                EndCap = System.Drawing.Drawing2D.LineCap.Round
            };
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        public void ActivarLapiz()
        {
            lapizActivo = true;
        }

        public void DesactivarLapiz()
        {
            lapizActivo = false;
        }
        public void ToggleLapiz()
        {
            lapizActivo = !lapizActivo;
        }
        public void IniciarDibujo(MouseEventArgs e)
        {
            if (lapizActivo)
            {
                movimiento = true;
                x = e.X;
                y = e.Y;
            }
        }

        public void DibujarLinea(MouseEventArgs e)
        {
            if (movimiento && lapizActivo && x != -1 && y != -1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }



        public void BorrarEnLinea(object sender, MouseEventArgs e)
        {
            pen.Color= Color.White;
        }

        public void TerminarDibujo()
        {
            if (lapizActivo)
            {
                movimiento = false;
                x = -1;
                y = -1;
            }
        }

        public void CambiarColor(Color color)
        {
            pen.Color = color;
        }

        public void LimpiarLienzo()
        {
            g.Clear(Color.White); // Limpia todo el lienzo
        }
    }
}
