using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;

namespace ClearCacheIcons.Helpers
{
    public static class ImageUtils
    {
        public static Image? CargarImagenDesdeRecurso(string imageName)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            string resourceName = $"ClearCacheIcons.images.{imageName}"; // Asumiendo que las imágenes están en la carpeta 'images' del proyecto

            using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    Logger.Log($"Error: Embedded resource '{resourceName}' not found.", true);
                    return null;
                }

                try
                {
                    using (Image tempImage = Image.FromStream(stream))
                    {
                        Bitmap bmp = new Bitmap(tempImage.Width, tempImage.Height);
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.DrawImage(tempImage, 0, 0, tempImage.Width, tempImage.Height);
                        }
                        return bmp;
                    }
                }
                catch (OutOfMemoryException ex)
                {
                    Logger.Log($"Error: OutOfMemoryException when loading embedded image '{resourceName}': {ex.Message}", true);
                    return null;
                }
                catch (Exception ex)
                {
                    Logger.Log($"Error loading embedded image '{resourceName}': {ex.Message}", true);
                    return null;
                }
            }
        }

        public static Image EscalarImagenAltaCalidad(Image originalImage, int width, int height)
        {
            if (originalImage == null) return new Bitmap(1, 1); // Return a minimal valid image

            Bitmap newImage = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(originalImage, 0, 0, width, height);
            }
            return newImage;
        }
    }
}