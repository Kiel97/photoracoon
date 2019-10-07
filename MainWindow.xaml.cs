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
            DrawLine(110, 100, 200, 400, 4, Color.FromRgb(0, 0, 255));
            DrawLine(0, 0, 15, 5, strokeColor: Color.FromRgb(255, 0, 0));
            DrawEllipse();
            DrawRectangle();
        }

        private void DrawLine(double startPosX, double startPosY, double lengthX, double lengthY, double thickness = 4, Color? strokeColor = null)
        {
            Line line = new Line
            {
                X2 = lengthX,
                Y2 = lengthY,
                StrokeThickness = thickness,
                Stroke = new SolidColorBrush(strokeColor.GetValueOrDefault(Color.FromRgb(0,0,0)))
            };

            Canvas.SetLeft(line, startPosX);
            Canvas.SetTop(line, startPosY);
            
            MainCanvas.Children.Add(line);
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
