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

        public void ActivarLapiz() => lapizActivo = true;

        public void DesactivarLapiz() => lapizActivo = false;

        public void ToggleLapiz() => lapizActivo = !lapizActivo;

        public bool IsActive() => lapizActivo;

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

    }

}
