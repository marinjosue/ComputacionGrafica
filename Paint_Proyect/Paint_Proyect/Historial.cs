using System.Collections.Generic;
using System.Drawing;

namespace Paint_Proyect
{
    internal class Historial
    {
        private Stack<Bitmap> estadosAnteriores;
        private Stack<Bitmap> estadosSiguientes;

        public Historial()
        {
            estadosAnteriores = new Stack<Bitmap>();
            estadosSiguientes = new Stack<Bitmap>();
        }

        public void GuardarEstado(Bitmap estadoActual)
        {
            estadosAnteriores.Push(new Bitmap(estadoActual)); // Copia profunda
            estadosSiguientes.Clear(); // Limpiar estados siguientes
        }

        public Bitmap Deshacer(Bitmap estadoActual)
        {
            if (estadosAnteriores.Count > 0)
            {
                estadosSiguientes.Push(new Bitmap(estadoActual)); // Guardar el estado actual
                return estadosAnteriores.Pop(); // Recuperar el último estado anterior
            }
            return null; // No hay nada que deshacer
        }

        public Bitmap Rehacer()
        {
            if (estadosSiguientes.Count > 0)
            {
                Bitmap estado = estadosSiguientes.Pop(); // Recuperar el estado siguiente
                estadosAnteriores.Push(new Bitmap(estado)); // Guardarlo en estados anteriores
                return estado;
            }
            return null; // No hay nada que rehacer
        }
    }
}
