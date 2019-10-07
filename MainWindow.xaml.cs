using PhotoRacoon.Popups;
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
            DrawEllipse(40, 25, 300, 100, 4, Color.FromRgb(255, 0, 255), Color.FromRgb(255, 255, 0));
            DrawEllipse(5, 5, 50, 50, 2, Color.FromRgb(255, 0, 255));
            DrawRectangle();
        }

        private void DrawLine(double x, double y, double w, double h, double thickness = 4, Color? strokeColor = null)
        {
            Line line = new Line
            {
                X2 = w,
                Y2 = h,
                StrokeThickness = thickness,
                Stroke = new SolidColorBrush(strokeColor.GetValueOrDefault(Color.FromRgb(0,0,0)))
            };

            Canvas.SetLeft(line, x);
            Canvas.SetTop(line, y);
            
            MainCanvas.Children.Add(line);
        }

        private void DrawEllipse(double x, double y, double w, double h, double thickness = 4, Color? strokeColor = null, Color? FillColor = null)
        {
            Ellipse ellipse = new Ellipse
            {
                Width = w,
                Height = h,
                StrokeThickness = thickness,
                Stroke = new SolidColorBrush(strokeColor.GetValueOrDefault(Color.FromRgb(0, 0, 0))),
                Fill = new SolidColorBrush(FillColor.GetValueOrDefault(Color.FromArgb(0, 0, 0, 0)))
            };
            
            Canvas.SetLeft(ellipse, x);
            Canvas.SetTop(ellipse, y);
            
            MainCanvas.Children.Add(ellipse);
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

        private void LineButton_Click(object sender, RoutedEventArgs e)
        {
            DrawLineWindow window = new DrawLineWindow();
            if ((bool)window.ShowDialog())
            {
                DrawLine(window.X, window.Y, window.L, window.H);
            }
        }
    }
}
