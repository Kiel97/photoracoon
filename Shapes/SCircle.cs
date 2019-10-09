using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PhotoRacoon.Shapes
{
    public class SCircle : SShape
    {
        public Point point;
        public double radius;

        public SCircle(double x, double y, double r)
        {
            point = new Point(x, y);
            radius = r;
        }

        public override void Draw(ref Canvas target)
        {
            DrawCircle(ref target, point.X, point.Y, radius, normalColor);
        }

        public override string ToString()
        {
            return $"Circle Point({point}) Radius({radius})";
        }

        private void DrawCircle(ref Canvas target, double x, double y, double r, Color? strokeColor = null, double thickness = 1)
        {
            double X = x - r;
            double Y = y - r;

            double w = 2*r;
            double h = 2*r;

            Ellipse ellipse = new Ellipse
            {
                Width = w,
                Height = h,
                StrokeThickness = thickness,
                Stroke = new SolidColorBrush(strokeColor.GetValueOrDefault(Color.FromRgb(0, 0, 0)))
            };

            Canvas.SetLeft(ellipse, X);
            Canvas.SetTop(ellipse, Y);

            target.Children.Add(ellipse);

            element = ellipse;
        }
    }
}
