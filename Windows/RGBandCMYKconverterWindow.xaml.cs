using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PhotoRacoon.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy RGBandCMYKconverterWindow.xaml
    /// </summary>
    public partial class RGBandCMYKconverterWindow : Window
    {
        public RGBandCMYKconverterWindow()
        {
            InitializeComponent();
        }

        private void CalculateCMYKtoRGB()
        {
            byte R = (byte)(255 * (1 - SliderC.Value) * (1 - SliderK.Value));
            byte G = (byte)(255 * (1 - SliderM.Value) * (1 - SliderK.Value));
            byte B = (byte)(255 * (1 - SliderY.Value) * (1 - SliderK.Value));

            ColorSample.Fill = new SolidColorBrush(Color.FromRgb(R, G, B));
        }

        private void SliderC_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CalculateCMYKtoRGB();
        }

        private void SliderM_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CalculateCMYKtoRGB();
        }

        private void SliderY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CalculateCMYKtoRGB();
        }

        private void SliderK_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CalculateCMYKtoRGB();
        }
    }
}
