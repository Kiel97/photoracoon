using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PhotoRacoon.Shapes
{
    public abstract class SShape
    {
        public Color normalColor = Color.FromArgb(255, 0, 0, 0);
        public Color highlightedColor = Color.FromArgb(127, 116, 41, 255);

        public abstract void Draw(ref Canvas target);
        public override abstract String ToString();
    }
}
