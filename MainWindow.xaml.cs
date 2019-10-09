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
                SCircle circle = new SCircle(window.X, window.Y, window.R);
                circle.Draw(ref MainCanvas);
                shapesOnCanvas.Add(circle);
            }
        }
        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            DrawRectangleWindow window = new DrawRectangleWindow();
            if ((bool)window.ShowDialog())
            {
                SRectangle rectangle = new SRectangle(window.X, window.Y, window.W, window.H);
                rectangle.Draw(ref MainCanvas);
                shapesOnCanvas.Add(rectangle);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Figury na płótnie: ");
            foreach (SShape shape in shapesOnCanvas)
            {
                Console.WriteLine(shape);
                Console.WriteLine(shape.element);
            }
        }
    }
}
