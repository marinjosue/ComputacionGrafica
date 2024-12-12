using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paint_Proyect
{
    internal class Cuadrado
    {
        private Pen pen = new Pen(Color.Blue, 2);

        public void PlotShape(Graphics g, Rectangle boundingBox)
        {
            // Dibuja el cuadrado ajustándose a la caja delimitadora
            g.DrawRectangle(pen, boundingBox);
        }
    }
}
