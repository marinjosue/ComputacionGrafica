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

        private bool isDrawing = false; // Flag para verificar si está dibujando
        private bool isTransforming = false; // Flag para verificar si está transformando
        private Point startPoint; // Punto inicial del clic
        private Point currentPoint; // Punto actual del mouse
        private Rectangle boundingBox; // Caja delimitadora de la estrella
        private EstrellaCincoPuntas estrellaSeleccionada; // Instancia actual de la estrella
        private Cursor originalCursor; // Cursor original para restaurar después
        private Dibujar classDibujar;
<<<<<<< HEAD
        // Define los diferentes modos del programa
        private int puntoTransformacionIndex = -1; // Índice del punto seleccionado (-1 significa ninguno)
        private bool isMoving = false; // Indica si estamos moviendo la figura
        private Point offset = Point.Empty; // Offset entre el clic inicial y el origen de la figura
        private Cuadrado cuadradoSeleccionado;

        private enum FiguraActual { Ninguna, Estrella, Cuadrado }
        private FiguraActual figuraSeleccionada = FiguraActual.Ninguna;

        enum Modo { Ninguno, Dibujo, Transformacion }

        private Modo modoActual = Modo.Ninguno; // Estado inicial del programa

        public Form1()
        {
            InitializeComponent();
            originalCursor = picCanvasLienzo.Cursor;
            classDibujar = new Dibujar(); // Asegúrate de inicializar aquí o en algún momento previo.
=======
        private bool borrarActivo = false;
        private Administrador administrador;
        private bool estadoRellenoActivo = false;
        private Color colorSeleccionado = Color.Black;
        public Form1()
        {
            InitializeComponent();
            classDibujar = new Dibujar(picCanvasLienzo);
            administrador = new Administrador(picCanvasLienzo, classDibujar);
>>>>>>> 7b1a32e1a280fc9aaaf52ac3033f804405bb8f0b
        }

        private void btnEstrella_Click(object sender, EventArgs e)
        {
            // Cambiar al modo estrella
            figuraSeleccionada = FiguraActual.Estrella;
            picCanvasLienzo.Cursor = Cursors.Cross; // Cursor para indicar que está en modo dibujo
            isDrawing = true;
        }

        private void SquardToolsBTN_Click(object sender, EventArgs e)
        {
            figuraSeleccionada = FiguraActual.Cuadrado;
            isDrawing = true;
            cuadradoSeleccionado = new Cuadrado();
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
<<<<<<< HEAD
            if (isDrawing && e.Button == MouseButtons.Left)
            {
                // Iniciar el dibujo
                startPoint = e.Location;
                currentPoint = e.Location;
                estrellaSeleccionada = new EstrellaCincoPuntas();
            }
            else if (isTransforming && e.Button == MouseButtons.Left)
            {
                // Verificar si se ha hecho clic en un punto de transformación
                var puntos = CalcularPuntosTransformacion(boundingBox);
                for (int i = 0; i < puntos.Length; i++)
                {
                    if (Math.Abs(e.X - puntos[i].X) <= 5 && Math.Abs(e.Y - puntos[i].Y) <= 5)
                    {
                        puntoTransformacionIndex = i;
                        break;
                    }
                }
            }

            if (boundingBox.Contains(e.Location) && !isDrawing)
            {
                isMoving = true;
                offset = new Point(e.X - boundingBox.X, e.Y - boundingBox.Y); // Calcular el desplazamiento
            }
            else if (isDrawing && e.Button == MouseButtons.Left)
            {
                // Código existente para iniciar el dibujo
                startPoint = e.Location;
                currentPoint = e.Location;
                estrellaSeleccionada = new EstrellaCincoPuntas();
            }
=======
            if (estadoRellenoActivo)
            {
                // Obtener las coordenadas del clic en el lienzo
                Point puntoInicio = e.Location;

                // Llamar al método de relleno
                classDibujar.RellenarArea(puntoInicio, colorSeleccionado);

                // Desactivar el estado de relleno después de usarlo
                estadoRellenoActivo = false;
            }
            else
            {
                // Si no estamos en modo de relleno, manejamos otras acciones (lapiz, borrador, etc.)
                if (borrarActivo)
                {
                    classDibujar.BorrarEnLinea(e);
                }
                else
                {
                    classDibujar.IniciarDibujo(e);
                }
            }
>>>>>>> 7b1a32e1a280fc9aaaf52ac3033f804405bb8f0b
        }

        private void picCanvasLienzo_MouseMove(object sender, MouseEventArgs e)
        {
<<<<<<< HEAD
            if (isDrawing)
            {
                // Actualizar el bounding box
                currentPoint = e.Location;
                boundingBox = CalcularBoundingBox(startPoint, currentPoint);
                RedibujarLienzo(preview: true);
            }
            else if (isTransforming && puntoTransformacionIndex != -1)
            {
                // Actualizar el bounding box en función del punto de transformación
                boundingBox = ActualizarBoundingBox(boundingBox, puntoTransformacionIndex, e.Location);
                RedibujarLienzo(preview: false);
            }

            if (isMoving && e.Button == MouseButtons.Left)
            {
                // Actualizar la posición de la caja delimitadora
                boundingBox = new Rectangle(
                    e.X - offset.X,
                    e.Y - offset.Y,
                    boundingBox.Width,
                    boundingBox.Height
                );
                RedibujarLienzo(preview: false); // Dibujar en la nueva posición
            }
            else if (isDrawing && e.Button == MouseButtons.Left)
            {
                // Código existente para vista previa de dibujo
                currentPoint = e.Location;
                RedibujarLienzo(preview: true);
=======
            if (borrarActivo)
            {
                classDibujar.BorrarEnLinea(e);
            }
            else
            {
                classDibujar.DibujarLinea(e);
>>>>>>> 7b1a32e1a280fc9aaaf52ac3033f804405bb8f0b
            }
        }

        private void picCanvasLienzo_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing && e.Button == MouseButtons.Left)
            {
                isDrawing = false;
                boundingBox = CalcularBoundingBox(startPoint, currentPoint);
                RedibujarLienzo(preview: false);
                isTransforming = true;
                picCanvasLienzo.Cursor = originalCursor;
            }
            else if (isTransforming && e.Button == MouseButtons.Left)
            {
                puntoTransformacionIndex = -1; // Finalizar transformación
            }

            if (isMoving)
            {
                isMoving = false;
            }
            else if (isDrawing && e.Button == MouseButtons.Left)
            {
                // Código existente para finalizar el dibujo
                isDrawing = false;
                boundingBox = CalcularBoundingBox(startPoint, currentPoint);
                RedibujarLienzo(preview: false);
                isTransforming = true;
                picCanvasLienzo.Cursor = originalCursor;
            }

            if (isDrawing && e.Button == MouseButtons.Left)
    {
        isDrawing = false;
        boundingBox = CalcularBoundingBox(startPoint, currentPoint);

        if (cuadradoSeleccionado != null)
        {
            using (Graphics g = picCanvasLienzo.CreateGraphics())
            {
                cuadradoSeleccionado.PlotShape(g, boundingBox);
            }

            cuadradoSeleccionado = null; // Reiniciar el cuadrado seleccionado
        }

        picCanvasLienzo.Cursor = originalCursor;
    }
        }


        private void RedibujarLienzo(bool preview)
        {
            Graphics g = picCanvasLienzo.CreateGraphics();
            g.Clear(picCanvasLienzo.BackColor);

            if (boundingBox != Rectangle.Empty && estrellaSeleccionada != null)
            {
                // Dibujar la estrella usando la caja delimitadora
                estrellaSeleccionada.PlotShape(g, boundingBox);

                if (!preview)
                {
                    // Dibujar la caja delimitadora
                    using (Pen pen = new Pen(Color.Gray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
                    {
                        g.DrawRectangle(pen, boundingBox);

                        // Dibujar puntos de transformación
                        foreach (var punto in CalcularPuntosTransformacion(boundingBox))
                        {
                            g.FillEllipse(Brushes.Blue, punto.X - 3, punto.Y - 3, 6, 6);
                        }
                    }
                }
            }
        }


        private Rectangle CalcularBoundingBox(Point start, Point end)
        {
            int x = Math.Min(start.X, end.X);
            int y = Math.Min(start.Y, end.Y);
            int width = Math.Abs(end.X - start.X);
            int height = Math.Abs(end.Y - start.Y);

            return new Rectangle(x, y, width, height);
        }

        private Point[] CalcularPuntosTransformacion(Rectangle rect)
        {
            // Devuelve los puntos para modificar la figura
            return new Point[]
            {
                new Point(rect.Left, rect.Top), // Esquina superior izquierda
                new Point(rect.Right, rect.Top), // Esquina superior derecha
                new Point(rect.Left, rect.Bottom), // Esquina inferior izquierda
                new Point(rect.Right, rect.Bottom), // Esquina inferior derecha
                new Point(rect.Left + rect.Width / 2, rect.Top), // Punto superior medio
                new Point(rect.Left + rect.Width / 2, rect.Bottom) // Punto inferior medio
            };
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
<<<<<<< HEAD

            if (classDibujar == null)
            {
                MessageBox.Show("Error: La herramienta de dibujo no está inicializada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            classDibujar.CambiarColor(btn.BackColor);
=======
            colorSeleccionado = btn.BackColor;
            MessageBox.Show($"Color seleccionado: {colorSeleccionado.Name}");

            // Verificar si ya estamos en el estado de relleno
            if (estadoRellenoActivo)
            {
                MessageBox.Show("Ahora, haga clic en el área que desea rellenar.");
            }
>>>>>>> 7b1a32e1a280fc9aaaf52ac3033f804405bb8f0b
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

<<<<<<< HEAD
        private Rectangle ActualizarBoundingBox(Rectangle rect, int puntoIndex, Point nuevoPunto)
        {
            int left = rect.Left;
            int top = rect.Top;
            int right = rect.Right;
            int bottom = rect.Bottom;

            switch (puntoIndex)
            {
                case 0: // Esquina superior izquierda
                    left = nuevoPunto.X;
                    top = nuevoPunto.Y;
                    break;
                case 1: // Esquina superior derecha
                    right = nuevoPunto.X;
                    top = nuevoPunto.Y;
                    break;
                case 2: // Esquina inferior izquierda
                    left = nuevoPunto.X;
                    bottom = nuevoPunto.Y;
                    break;
                case 3: // Esquina inferior derecha
                    right = nuevoPunto.X;
                    bottom = nuevoPunto.Y;
                    break;
                case 4: // Punto superior medio
                    top = nuevoPunto.Y;
                    break;
                case 5: // Punto inferior medio
                    bottom = nuevoPunto.Y;
                    break;
            }

            return new Rectangle(
                Math.Min(left, right),
                Math.Min(top, bottom),
                Math.Abs(right - left),
                Math.Abs(bottom - top)
            );
        }


=======
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
            MessageBox.Show("Por favor, elige un color y luego haz clic en el área que deseas rellenar.");
        }
>>>>>>> 7b1a32e1a280fc9aaaf52ac3033f804405bb8f0b
    }
}
