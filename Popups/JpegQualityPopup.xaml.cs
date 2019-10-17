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
    /// Logika interakcji dla klasy JpegQualityPopup.xaml
    /// </summary>
    public partial class JpegQualityPopup : Window
    {
        public int Quality;

        public JpegQualityPopup()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Quality = (int)slider.Value;

            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }
    }
}
