using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhotoRacoon.Writers
{
    class JpegWriter
    {
        public static void SaveImage(Canvas canvas, int width, int height, string filePath, int quality = 90)
        {
            Rect bounds = VisualTreeHelper.GetDescendantBounds(canvas);
            double dpi = 96d;
            RenderTargetBitmap rtb = new RenderTargetBitmap(width, height, dpi, dpi, System.Windows.Media.PixelFormats.Default);

            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(canvas);
                dc.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
            }

            rtb.Render(dv);

            JpegBitmapEncoder image = new JpegBitmapEncoder
            {
                QualityLevel = quality
            };

            image.Frames.Add(BitmapFrame.Create(rtb));

            using (Stream fs = File.Create(filePath))
            {
                image.Save(fs);
                fs.Close();
            }
        }
    }
}
