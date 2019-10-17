using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PhotoRacoon.Shapes
{
    public class SRectangle : SShape
    {
        public Point TopLeftCorner;
        public double Width;
        public double Height;

        public SRectangle(double x, double y, double w, double h)
        {
            TopLeftCorner = new Point(x, y);
            Width = w;
            Height = h;
        }

        public override void Draw(ref Canvas target)
        {
            DrawRectangle(ref target, TopLeftCorner.X, TopLeftCorner.Y, Width, Height, normalColor);
        }

        public override string ToString()
        {
            return $"Rectangle: TL({TopLeftCorner}) Width({Width}) Height({Height})";
        }

        private void DrawRectangle(ref Canvas target, double x, double y, double w, double h, Color? strokeColor = null, double thickness = 1)
        {
            Rectangle rectangle = new Rectangle
            {
                Width = w,
                Height = h,
                StrokeThickness = thickness,
                Stroke = new SolidColorBrush(strokeColor.GetValueOrDefault(normalColor))
            };

            Canvas.SetLeft(rectangle, x);
            Canvas.SetTop(rectangle, y);

            element = rectangle;

            element.MouseEnter += OnHover;
            element.MouseLeave += OnHoverLost;

            target.Children.Add(rectangle);
        }
    }
}
