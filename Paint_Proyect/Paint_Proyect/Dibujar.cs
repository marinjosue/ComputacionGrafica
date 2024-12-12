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
        private bool borradorActivo = false;
        private PictureBox pictureBox;

        private Stack<Bitmap> undoStack = new Stack<Bitmap>(); // Historial para deshacer
        private Stack<Bitmap> redoStack = new Stack<Bitmap>(); // Historial para rehacer

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

        public void GuardarEstado()
        {
            // Guarda el estado actual en la pila de deshacer
            undoStack.Push((Bitmap)bitmap.Clone());
            redoStack.Clear(); // Limpiar el historial de rehacer
        }

        public void Deshacer()
        {
            if (undoStack.Count > 0)
            {
                // Guarda el estado actual en la pila de rehacer
                redoStack.Push((Bitmap)bitmap.Clone());
                // Restaura el último estado de la pila de deshacer
                bitmap = undoStack.Pop();
                g = Graphics.FromImage(bitmap);
                RefreshPictureBox();
            }
        }

        public void Rehacer()
        {
            if (redoStack.Count > 0)
            {
                // Guarda el estado actual en la pila de deshacer
                undoStack.Push((Bitmap)bitmap.Clone());
                // Restaura el último estado de la pila de rehacer
                bitmap = redoStack.Pop();
                g = Graphics.FromImage(bitmap);
                RefreshPictureBox();
            }
        }

        public void ActivarLapiz()
        {
            lapizActivo = true;
            borradorActivo = false;
        }

        public void ActivarBorrador()
        {
            borradorActivo = true;
            lapizActivo = false;
        }

        public void IniciarDibujo(MouseEventArgs e)
        {
            if (!lapizActivo && !borradorActivo) return;
            GuardarEstado(); // Guarda el estado antes de comenzar a dibujar
            movimiento = true;
            x = e.X;
            y = e.Y;
        }

        public void DibujarLinea(MouseEventArgs e)
        {


            if (!movimiento || (x == -1 || y == -1)) return;

            if (borradorActivo)
            {
                var originalColor = pen.Color;
                pen.Color = Color.White;
                g.DrawLine(pen, new Point(x, y), e.Location);
                pen.Color = originalColor;
            }
            else
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
            }

            x = e.X;
            y = e.Y;
            RefreshPictureBox();
        }

        public void TerminarDibujo()
        {
            movimiento = false;
            x = -1;
            y = -1;
        }

        public void CambiarColor(Color color)
        {
            if (!borradorActivo)
            {
                pen.Color = color;
            }
        }

        public void CambiarGrosor(float grosor) => pen.Width = grosor;

        public void LimpiarLienzo()
        {
            GuardarEstado(); // Guarda el estado antes de limpiar
            g.Clear(Color.White);
            RefreshPictureBox();
        }

        private void RefreshPictureBox()
        {
            pictureBox.Image = bitmap;
            pictureBox.Invalidate();
        }

        public Bitmap GetBitmap() => bitmap;

        public void AsignarBitmap(Bitmap nuevoBitmap)
        {
            if (nuevoBitmap == null) return;

            GuardarEstado(); // Guarda el estado antes de asignar un nuevo bitmap
            bitmap = nuevoBitmap;
            g = Graphics.FromImage(bitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            RefreshPictureBox();
        }

        public void RellenarArea(Point puntoInicio, Color colorRelleno)
        {
            GuardarEstado(); // Guarda el estado antes de rellenar
            if (puntoInicio.X < 0 || puntoInicio.Y < 0 ||
                puntoInicio.X >= bitmap.Width || puntoInicio.Y >= bitmap.Height)
            {
                return;
            }

            Color colorOriginal = bitmap.GetPixel(puntoInicio.X, puntoInicio.Y);
            if (colorOriginal.ToArgb() == colorRelleno.ToArgb()) return;

            Queue<Point> puntos = new Queue<Point>();
            puntos.Enqueue(puntoInicio);

            while (puntos.Count > 0)
            {
                Point punto = puntos.Dequeue();
                if (punto.X < 0 || punto.Y < 0 ||
                    punto.X >= bitmap.Width || punto.Y >= bitmap.Height)
                {
                    continue;
                }

                if (bitmap.GetPixel(punto.X, punto.Y).ToArgb() == colorOriginal.ToArgb())
                {
                    bitmap.SetPixel(punto.X, punto.Y, colorRelleno);
                    puntos.Enqueue(new Point(punto.X + 1, punto.Y));
                    puntos.Enqueue(new Point(punto.X - 1, punto.Y));
                    puntos.Enqueue(new Point(punto.X, punto.Y + 1));
                    puntos.Enqueue(new Point(punto.X, punto.Y - 1));
                }
            }

            RefreshPictureBox();
        }
    }
}
