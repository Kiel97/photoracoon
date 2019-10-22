using Microsoft.Win32;
using PhotoRacoon.Popups;
using PhotoRacoon.Readers;
using PhotoRacoon.Shapes;
using PhotoRacoon.Windows;
using PhotoRacoon.Writers;
using PhotoRacoon.Converters;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
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

        public enum DrawingMode
        {
            NOTHING, LINE, CIRCLE, RECTANGLE
        }
        public static DrawingMode currentMode;

        public Point mainPointCaptured;
        public Point otherPointCaptured;

        public bool pressed = false;

        public MainWindow()
        {
            InitializeComponent();
            lateInitEvents();
            shapesOnCanvas = new List<SShape>();
        }

        private void lateInitEvents()
        {
            DrawNothingRadioButton.Checked += DrawModeSelectionChanged;
            DrawLineRadioButton.Checked += DrawModeSelectionChanged;
            DrawCircleRadioButton.Checked += DrawModeSelectionChanged;
            DrawRectangleRadioButton.Checked += DrawModeSelectionChanged;
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
                // TODO: Refactor
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
                // TODO: Refactor
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
                // TODO: Refactor
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

        private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePosition = Mouse.GetPosition(MainCanvas);
            MousePosStatusBar.Content = $"X: {(int)mousePosition.X}, Y: {(int)mousePosition.Y}";

            if (pressed)
            {
                Console.WriteLine($"Pressed LMB: {mousePosition}");
            }
        }

        private void NewCanvasButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy chcesz wyczyścić płótno ze wszystkich figur?", "Nowe płótno", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                ClearAllShapes();
        }

        private void ClearAllShapes()
        {
            shapesOnCanvas.Clear();
            MainCanvas.Children.Clear();
        }

        private void DrawModeSelectionChanged(object sender, RoutedEventArgs e)
        {
            RadioButton radiobutton = sender as RadioButton;
            switch (radiobutton.Name)
            {
                case "DrawNothingRadioButton":
                    currentMode = DrawingMode.NOTHING;
                    break;
                case "DrawLineRadioButton":
                    currentMode = DrawingMode.LINE;
                    break;
                case "DrawCircleRadioButton":
                    currentMode = DrawingMode.CIRCLE;
                    break;
                case "DrawRectangleRadioButton":
                    currentMode = DrawingMode.RECTANGLE;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown RadioButton name");
            }
            PaintModeStatusBar.Content = currentMode.ToString();
        }

        private void MainCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(currentMode == DrawingMode.NOTHING)
            {
                return;
            }

            // TODO: Refactor
            switch (currentMode)
            {
                case DrawingMode.NOTHING:
                    return;
                case DrawingMode.LINE:
                    break;
                case DrawingMode.CIRCLE:
                    break;
                case DrawingMode.RECTANGLE:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown drawing mode!");
            }

            pressed = true;
            PressedStateStatusBar.Content = "DRAWING";

            mainPointCaptured = Mouse.GetPosition(MainCanvas);
            Console.WriteLine($" Main point {mainPointCaptured}");
        }

        private void MainCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (currentMode == DrawingMode.NOTHING)
            {
                return;
            }

            pressed = false;
            PressedStateStatusBar.Content = String.Empty;

            otherPointCaptured = Mouse.GetPosition(MainCanvas);
            Console.WriteLine($" Other point {otherPointCaptured}");

            // TODO: Refactor
            switch (currentMode)
            {
                case DrawingMode.LINE:
                    SLine line = new SLine(mainPointCaptured.X, mainPointCaptured.Y, otherPointCaptured.X, otherPointCaptured.Y);
                    line.Draw(ref MainCanvas);
                    shapesOnCanvas.Add(line);
                    break;
                case DrawingMode.CIRCLE:
                    double radius = Point.Subtract(otherPointCaptured, mainPointCaptured).Length;
                    SCircle circle = new SCircle(mainPointCaptured.X, mainPointCaptured.Y, radius);
                    circle.Draw(ref MainCanvas);
                    shapesOnCanvas.Add(circle);
                    break;
                case DrawingMode.RECTANGLE:
                    double startX = Math.Min(mainPointCaptured.X, otherPointCaptured.X);
                    double startY = Math.Min(mainPointCaptured.Y, otherPointCaptured.Y);

                    double width = Math.Abs(otherPointCaptured.X - mainPointCaptured.X);
                    double height = Math.Abs(otherPointCaptured.Y - mainPointCaptured.Y);

                    SRectangle rectangle = new SRectangle(startX, startY, width, height);
                    rectangle.Draw(ref MainCanvas);
                    shapesOnCanvas.Add(rectangle);
                    break;
                default:
                    return;
            }

            mainPointCaptured = new Point();
            otherPointCaptured = new Point();
        }

        private void OpenPPMButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Pliki PPM (*.ppm)|*.ppm|Wszystkie pliki (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if ((bool)openFileDialog.ShowDialog())
            {
                LoadPPMImageAsBitmap(openFileDialog.FileName);
            }
        }

        private void LoadPPMImageAsBitmap(string filepath)
        {
            try
            {
                System.Drawing.Bitmap bitmap = PPMReader.ReadBitmapFromPPM(filepath);

                Image image = new Image
                {
                    Source = Converters.Converters.BitmapToImageSource(bitmap)
                };

                Window window = new Window
                {
                    Title = $"PPM Viewer Pro - {filepath}",
                    MinWidth = 5,
                    MinHeight = 5,
                    Width = bitmap.Width,
                    Height = bitmap.Height,
                    Content = image
                };

                window.Show();

            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.ToString(), ex.ParamName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.ToString(), ex.ParamName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void OpenJPGButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Pliki JPG (*.jpg, *.jpeg)|*.jpg;*.jpeg"
            };

            if ((bool)openFileDialog.ShowDialog())
            {
                ClearAllShapes();
                DrawNothingRadioButton.IsChecked = true;

                Image image = new Image
                {
                    Source = new BitmapImage(new Uri(openFileDialog.FileName))
                };

                MainCanvas.Children.Add(image);
            }
        }

        private void SaveCanvasButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Plik JPG (*.jpg)|*.jpg"
            };

            if ((bool)saveFileDialog.ShowDialog())
            {
                JpegQualityPopup popup = new JpegQualityPopup();

                if ((bool)popup.ShowDialog())
                {
                    JpegWriter.SaveImage(MainCanvas, (int)MainCanvas.ActualWidth, (int)MainCanvas.ActualHeight, saveFileDialog.FileName, popup.Quality);
                }
            }
        }

        private void RGB_CMYK_Button_Click(object sender, RoutedEventArgs e)
        {
            RGBandCMYKconverterWindow window = new RGBandCMYKconverterWindow();
            window.ShowDialog();
        }

        private void RGBcubeButton_Click(object sender, RoutedEventArgs e)
        {
            Show3DCubeWindow window = new Show3DCubeWindow();
            window.ShowDialog();
        }
    }
}
