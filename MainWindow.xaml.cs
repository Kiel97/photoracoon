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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhotoRacoon
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UIElement selectedElement = null;

        public MainWindow()
        {
            InitializeComponent();
            DrawPrimitivesTest();
        }

        private void OnWindowClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy chcesz zakończyć pracę z aplikacją?", "Zakończ", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DrawPrimitivesTest()
        {
            DrawLine();
            DrawEllipse();
            DrawRectangle();
        }

        private void DrawLine()
        {
            Line line = new Line
            {
                X2 = 200,
                Y2 = 400,
                StrokeThickness = 4,
                Stroke = new SolidColorBrush(Color.FromRgb(0, 255, 0))
            };
            MainCanvas.Children.Add(line);
            Canvas.SetLeft(line, 110);
            Canvas.SetTop(line, 100);
        }

        private void DrawEllipse()
        {
            Ellipse ellipse = new Ellipse
            {
                Width = 300,
                Height = 100,
                StrokeThickness = 4,
                Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 255)),
                Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0))
            };
            MainCanvas.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, 40);
            Canvas.SetTop(ellipse, 25);
        }

        private void DrawRectangle()
        {
            Rectangle rectangle = new Rectangle
            {
                Width = 100,
                Height = 200,
                StrokeThickness = 4,
                Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 0)),
                Fill = new SolidColorBrush(Color.FromRgb(0, 0, 255))
            };
            MainCanvas.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, 0);
            Canvas.SetTop(rectangle, 100);
        }
    }
}
