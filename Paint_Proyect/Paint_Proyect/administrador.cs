using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paint_Proyect
{
    internal class Administrador
    {
        private Dibujar dibujar;
        private PictureBox pbx;


        public Administrador(PictureBox pictureBox, Dibujar dibujar)
        {
            pbx = pictureBox;
            this.dibujar = dibujar;
        }

        public void CargarImagen()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imágenes|*.png;*.bmp;*.jpg;*.jpeg|Todos los archivos|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image imagen = Image.FromFile(openFileDialog.FileName);
                        Bitmap bitmap = new Bitmap(pbx.Width, pbx.Height);
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            g.Clear(Color.White);
                            g.DrawImage(imagen, 0, 0, pbx.Width, pbx.Height);
                        }

                        // Asignar el nuevo bitmap al lienzo de Dibujar
                        dibujar.AsignarBitmap(bitmap);
                        pbx.Image = bitmap;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                    }
                }
            }
        }

        public void GuardarImagen()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG|*.png|JPEG|*.jpg;*.jpeg|BMP|*.bmp|Todos los archivos|*.*";
                saveFileDialog.Title = "Guardar Imagen";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Obtener el formato de imagen basado en la extensión del archivo
                        string extension = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();
                        System.Drawing.Imaging.ImageFormat formato;

                        switch (extension)
                        {
                            case ".png":
                                formato = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                            case ".jpg":
                            case ".jpeg":
                                formato = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case ".bmp":
                                formato = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            default:
                                MessageBox.Show("Formato no soportado.");
                                return;
                        }

                        // Guardar la imagen
                        pbx.Image.Save(saveFileDialog.FileName, formato);

                        // Mostrar ventana con la ruta donde se guardó la imagen
                        MessageBox.Show($"Imagen guardada exitosamente en:\n{saveFileDialog.FileName}",
                                        "Guardado Exitoso",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar la imagen: " + ex.Message);
                    }
                }
            }
        }

    }
}
