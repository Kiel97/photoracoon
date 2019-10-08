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
        public double X1;
        public double Y1;
        public double X2;
        public double Y2;

        public DrawLineWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            X1 = double.Parse(TextBoxX1.Text);
            Y1 = double.Parse(TextBoxY1.Text);
            X2 = double.Parse(TextBoxX2.Text);
            Y2 = double.Parse(TextBoxY2.Text);

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }
    }
}
