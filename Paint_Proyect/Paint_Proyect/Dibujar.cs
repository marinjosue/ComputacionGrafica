using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Paint_Proyect
{
    internal class Dibujar
    {
        private Bitmap bitmap;
        private Graphics g;
        private Pen pen;
        private int x = -1;
        private int y = -1;
        private bool movimiento = false;
        private bool lapizActivo = false;
        private PictureBox pictureBox;

        public Dibujar(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            g = Graphics.FromImage(bitmap);
            pen = new Pen(Color.Black, 5)
            {
                StartCap = System.Drawing.Drawing2D.LineCap.Round,
                EndCap = System.Drawing.Drawing2D.LineCap.Round
            };
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            LimpiarLienzo();
            pictureBox.Image = bitmap;
        }

<<<<<<< HEAD
        public Dibujar()
        {
        }

        public void ActivarLapiz()
        {
            lapizActivo = true;
        }
=======
        public void ActivarLapiz() => lapizActivo = true;
        public void DesactivarLapiz() => lapizActivo = false;
        public void ToggleLapiz() => lapizActivo = !lapizActivo;
        public bool IsActive() => lapizActivo;
>>>>>>> 7b1a32e1a280fc9aaaf52ac3033f804405bb8f0b

        public void IniciarDibujo(MouseEventArgs e)
        {
            if (!lapizActivo) return;
            movimiento = true;
            x = e.X;
            y = e.Y;
        }

        public void DibujarLinea(MouseEventArgs e)
        {
            if (!movimiento || !lapizActivo || x == -1 || y == -1) return;

            g.DrawLine(pen, new Point(x, y), e.Location);
            x = e.X;
            y = e.Y;
            RefreshPictureBox();
        }

        public void BorrarEnLinea(MouseEventArgs e)
        {
            if (!movimiento) return;

            var originalColor = pen.Color;
            pen.Color = Color.White; // Cambiar color temporalmente para borrar
            DibujarLinea(e); // Reutilizar lógica
            pen.Color = originalColor; // Restaurar color original
        }

        public void TerminarDibujo()
        {
            movimiento = false;
            x = -1;
            y = -1;
        }

        public void CambiarColor(Color color) => pen.Color = color;
        public void CambiarGrosor(float grosor) => pen.Width = grosor;

        public void LimpiarLienzo()
        {
            g.Clear(Color.White);
            RefreshPictureBox();
        }

        private void RefreshPictureBox()
        {
            pictureBox.Invalidate();
            pictureBox.Image = bitmap;
        }

        public Bitmap GetBitmap() => bitmap;
        public void AsignarBitmap(Bitmap nuevoBitmap)
        {
            if (nuevoBitmap == null) return;

            bitmap = nuevoBitmap;
            g = Graphics.FromImage(bitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            RefreshPictureBox();
        }
        public Color GetColor()
        {
            return pen.Color; // Aquí devolvemos el color actual del lápiz
        }



        // Función de relleno (Balde de pintura)
        public void RellenarArea(Point puntoInicio, Color colorRelleno)
        {
            // Asegurémonos de que el clic esté dentro de los límites del lienzo
            if (puntoInicio.X < 0 || puntoInicio.Y < 0 || puntoInicio.X >= bitmap.Width || puntoInicio.Y >= bitmap.Height)
            {
                MessageBox.Show("El clic está fuera del área del lienzo.");
                return;
            }

            // Obtener el color original del punto de inicio
            Color colorOriginal = bitmap.GetPixel(puntoInicio.X, puntoInicio.Y);

            // Si el color de la zona es igual al color de relleno, no hacemos nada
            if (colorOriginal == colorRelleno)
            {
                MessageBox.Show("El color de inicio ya es el mismo que el color de relleno.");
                return;
            }

            // Cola para rellenar los puntos
            Queue<Point> puntosPorRellenar = new Queue<Point>();
            puntosPorRellenar.Enqueue(puntoInicio);

            // Rellenamos el área cerrada
            while (puntosPorRellenar.Count > 0)
            {
                Point punto = puntosPorRellenar.Dequeue();

                if (bitmap.GetPixel(punto.X, punto.Y) == colorOriginal)
                {
                    bitmap.SetPixel(punto.X, punto.Y, colorRelleno); // Rellenamos el punto

                    // Añadir puntos adyacentes
                    if (punto.X > 0) puntosPorRellenar.Enqueue(new Point(punto.X - 1, punto.Y)); // Izquierda
                    if (punto.X < bitmap.Width - 1) puntosPorRellenar.Enqueue(new Point(punto.X + 1, punto.Y)); // Derecha
                    if (punto.Y > 0) puntosPorRellenar.Enqueue(new Point(punto.X, punto.Y - 1)); // Arriba
                    if (punto.Y < bitmap.Height - 1) puntosPorRellenar.Enqueue(new Point(punto.X, punto.Y + 1)); // Abajo
                }
            }

            // Actualizamos la imagen en el PictureBox
            RefreshPictureBox();
            MessageBox.Show("Relleno completado.");
        }






    }
}