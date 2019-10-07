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
    /// Logika interakcji dla klasy DrawLineWindow.xaml
    /// </summary>
    public partial class DrawLineWindow : Window
    {
        public double X;
        public double Y;
        public double L;
        public double H;

        public DrawLineWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            X = double.Parse(TextBoxX.Text);
            Y = double.Parse(TextBoxY.Text);
            L = double.Parse(TextBoxL.Text);
            H = double.Parse(TextBoxH.Text);

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }
    }
}
