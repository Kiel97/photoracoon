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

namespace PhotoRacoon.Popups
{
    /// <summary>
    /// Logika interakcji dla klasy DrawRectangleWindow.xaml
    /// </summary>
    public partial class DrawRectangleWindow : Window
    {
        public double X;
        public double Y;
        public double W;
        public double H;

        public DrawRectangleWindow()
        {
            InitializeComponent();
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            X = double.Parse(TextBoxX.Text);
            Y = double.Parse(TextBoxY.Text);
            W = double.Parse(TextBoxW.Text);
            H = double.Parse(TextBoxH.Text);

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }
    }
}
