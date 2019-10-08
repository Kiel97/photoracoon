using PhotoRacoon.Popups;
using PhotoRacoon.Shapes;
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
        public List<SShape> shapesOnCanvas;

        public MainWindow()
        {
            InitializeComponent();
            shapesOnCanvas = new List<SShape>();
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

        private void DrawEllipse(double x, double y, double w, double h, double thickness = 4, Color? strokeColor = null, Color? fillColor = null)
        {
            Ellipse ellipse = new Ellipse
            {
                Width = w,
                Height = h,
                StrokeThickness = thickness,
                Stroke = new SolidColorBrush(strokeColor.GetValueOrDefault(Color.FromRgb(0, 0, 0))),
                Fill = new SolidColorBrush(fillColor.GetValueOrDefault(Color.FromArgb(0, 0, 0, 0)))
            };
            
            Canvas.SetLeft(ellipse, x);
            Canvas.SetTop(ellipse, y);
            
            MainCanvas.Children.Add(ellipse);
        }

        private void DrawRectangle(double x, double y, double w, double h, double thickness = 4, Color? strokeColor = null, Color? fillColor = null)
        {
            Rectangle rectangle = new Rectangle
            {
                Width = w,
                Height = h,
                StrokeThickness = thickness,
                Stroke = new SolidColorBrush(strokeColor.GetValueOrDefault(Color.FromRgb(0, 0, 0))),
                Fill = new SolidColorBrush(fillColor.GetValueOrDefault(Color.FromArgb(0, 0, 0, 0)))
            };

            Canvas.SetLeft(rectangle, x);
            Canvas.SetTop(rectangle, y);
            
            MainCanvas.Children.Add(rectangle);
        }

        private void LineButton_Click(object sender, RoutedEventArgs e)
        {
            DrawLineWindow window = new DrawLineWindow();
            if ((bool)window.ShowDialog())
            {
                SLine line = new SLine(window.X1, window.Y1, window.X2, window.Y2);
                line.Draw(ref MainCanvas);
                shapesOnCanvas.Add(line);
            }
        }
        private void CircleButton_Click(object sender, RoutedEventArgs e)
        {
            DrawCircleWindow window = new DrawCircleWindow();
            if ((bool)window.ShowDialog())
            {
                Console.WriteLine($"Rysujemy koło {window.X}, {window.Y}, {window.R}");
            }
        }
        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            DrawRectangleWindow window = new DrawRectangleWindow();
            if ((bool)window.ShowDialog())
            {
                Console.WriteLine($"Rysujemy prostokąt {window.X1},{window.Y1} {window.X2},{window.Y2} ");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Figury na płótnie: ");
            foreach (SShape shape in shapesOnCanvas)
            {
                Console.WriteLine(shape);
            }
        }
    }
}
