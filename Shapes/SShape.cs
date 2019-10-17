using System;
using System.Collections;
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
    public abstract class SShape
    {
        public Shape element;

        public Color normalColor = Color.FromArgb(255, 0, 0, 0);
        public Color highlightedColor = Color.FromArgb(127, 116, 41, 255);

        public abstract void Draw(ref Canvas target);
        public override abstract String ToString();

        public void OnHover(object sender, MouseEventArgs e)
        {
            element.Stroke = new SolidColorBrush(highlightedColor);
        }

        public void OnHoverLost(object sender, MouseEventArgs e)
        {
            element.Stroke = new SolidColorBrush(normalColor);
        }
    }
}
