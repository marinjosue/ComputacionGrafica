using System;
using System.Drawing;

namespace Paint_Proyect
{
    internal class EstrellaCincoPuntas
    {
        private Pen pen = new Pen(Color.Blue, 2);

        public void PlotShape(Graphics g, Rectangle boundingBox)
        {
            // Calcular centro y radios basados en la caja delimitadora
            float centroX = boundingBox.Left + boundingBox.Width / 2f;
            float centroY = boundingBox.Top + boundingBox.Height / 2f;
            float radioExterior = Math.Min(boundingBox.Width, boundingBox.Height) / 2f;
            float radioInterior = radioExterior / 2.5f;

            // Crear puntos para la estrella
            PointF[] puntos = CrearPuntosEstrella(centroX, centroY, radioExterior, radioInterior);

            // Dibujar la estrella
            for (int i = 0; i < puntos.Length; i++)
            {
                int nextIndex = (i + 1) % puntos.Length; // Conectar con el siguiente punto
                g.DrawLine(pen, puntos[i], puntos[nextIndex]);
            }
        }

        private PointF[] CrearPuntosEstrella(float centroX, float centroY, float radioExterior, float radioInterior)
        {
            int numVertices = 10; // Alterna entre puntas grandes y pequeñas
            PointF[] puntos = new PointF[numVertices];

            double anguloInicial = -Math.PI / 2; // Inicia en la parte superior

            for (int i = 0; i < numVertices; i++)
            {
                double angulo = anguloInicial + (Math.PI * i) / 5; // Incrementa ángulo en divisiones de 36°
                float radio = (i % 2 == 0) ? radioExterior : radioInterior; // Alterna radios
                puntos[i] = new PointF(
                    (float)(centroX + radio * Math.Cos(angulo)),
                    (float)(centroY + radio * Math.Sin(angulo))
                );
            }

            return puntos;
        }
    }
}
