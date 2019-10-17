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
            SliderR.ValueChanged += SliderR_ValueChanged;
            SliderG.ValueChanged += SliderG_ValueChanged;
            SliderB.ValueChanged += SliderB_ValueChanged;
            SliderC.ValueChanged += SliderC_ValueChanged;
            SliderM.ValueChanged += SliderM_ValueChanged;
            SliderY.ValueChanged += SliderY_ValueChanged;
            SliderK.ValueChanged += SliderK_ValueChanged;
        }

        private void CalculateCMYKtoRGB()
        {
            byte R = (byte)(255 * (1 - SliderC.Value) * (1 - SliderK.Value));
            byte G = (byte)(255 * (1 - SliderM.Value) * (1 - SliderK.Value));
            byte B = (byte)(255 * (1 - SliderY.Value) * (1 - SliderK.Value));

            fillSample(R, G, B);

            SliderR.Value = R;
            SliderG.Value = G;
            SliderB.Value = B;
        }

        private void CalculateRGBtoCMYK()
        {
            double C, M, Y;
            double K = 1 - Math.Max(SliderR.Value/255, Math.Max(SliderG.Value/255, SliderB.Value/255));
            if (K == 1)
            {
                C = (1 - SliderR.Value / 255);
                M = (1 - SliderG.Value / 255);
                Y = (1 - SliderB.Value / 255);
            }
            else
            {
                C = (1 - SliderR.Value / 255 - K) / (1 - K);
                M = (1 - SliderG.Value / 255 - K) / (1 - K);
                Y = (1 - SliderB.Value / 255 - K) / (1 - K);
            }

            SliderC.Value = Math.Round(C, 2);
            SliderM.Value = Math.Round(M, 2);
            SliderY.Value = Math.Round(Y, 2);
            SliderK.Value = Math.Round(K, 2);
        }

        private void fillSample(byte r, byte g, byte b)
        {
            ColorSample.Fill = new SolidColorBrush(Color.FromRgb(r, g, b));
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

        private void SliderR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            fillSample((byte)SliderR.Value, (byte)SliderG.Value, (byte)SliderB.Value);
            CalculateRGBtoCMYK();
        }

        private void SliderG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            fillSample((byte)SliderR.Value, (byte)SliderG.Value, (byte)SliderB.Value);
            CalculateRGBtoCMYK();
        }
        private void SliderB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            fillSample((byte)SliderR.Value, (byte)SliderG.Value, (byte)SliderB.Value);
            CalculateRGBtoCMYK();
        }
    }
}
