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
    public class SLine : SShape
    {
        public Point startingPoint;
        public Point relativePoint;

        public SLine(double x1, double y1, double x2, double y2)
        {
            startingPoint = new Point(x1, y1);
            relativePoint = new Point(x2, y2);
        }

        public override void Draw(ref Canvas target)
        {
            DrawLine(ref target, startingPoint.X, startingPoint.Y, relativePoint.X-startingPoint.X, relativePoint.Y-startingPoint.Y, normalColor);
        }

        public override string ToString()
        {
            return $"Line: Starting Point:({startingPoint}), Relative Point:({relativePoint})";
        }

        private void DrawLine(ref Canvas target, double x, double y, double w, double h, Color? strokeColor = null, double thickness = 1)
        {
            Line line = new Line
            {
                X2 = w,
                Y2 = h,
                StrokeThickness = thickness,
                Stroke = new SolidColorBrush(strokeColor.GetValueOrDefault(normalColor))
            };

            Canvas.SetLeft(line, x);
            Canvas.SetTop(line, y);

            element = line;

            element.MouseEnter += OnHover;
            element.MouseLeave += OnHoverLost;

            target.Children.Add(line);
        }

    }
}
