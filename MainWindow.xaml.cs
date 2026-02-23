using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FabricAndAbstract
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Figure <Fihures> = new 

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Theme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CircleCreator circleCreator;
            SquareCreator squareCreator;
            TriangleCreator triangleCreator;

            switch (Theme.SelectedItem.ToString())
            {
                case "Light":
                    circleCreator = new LightCircleCreator();
                    squareCreator = new LightSquareCreator();
                    triangleCreator = new LightTriangleCreator();
                    break;
                case "Dark":
                    circleCreator = new DarkCircleCreator();
                    squareCreator = new DarkSquareCreator();
                    triangleCreator = new DarkTriangleCreator();
                    break;
                case "Colorful":
                    circleCreator = new ColorfulCircleCreator();
                    squareCreator = new ColorfulSquareCreator();
                    triangleCreator = new ColorfulTriangleCreator();
                    break;
                default:
                    return;
            }
            Figure figa = circleCreator.CreateCircle();
            UIElement ff = figa.CreateUIElement();
            Fig.Children.Add(ff);
        }
    }

    public abstract class Figure
    {
        public Color Color { get; set; }

        public abstract UIElement CreateUIElement(double size = 50);
    }
    public class Circle : Figure
    {
        public override UIElement CreateUIElement(double size = 50)
        {
            return new Ellipse
            {
                Width = size,
                Height = size,
                Fill = new SolidColorBrush(Color),
                Margin = new Thickness(5)
            };
        }
    }
    public class Square : Figure
    {
        public override UIElement CreateUIElement(double size = 50)
        {
            return new Rectangle
            {
                Width = size,
                Height = size,
                Fill = new SolidColorBrush(Color),
                Margin = new Thickness(5)
            };
        }
    }

    public class Triangle : Figure
    {
        public override UIElement CreateUIElement(double size = 50)
        {
            var polygon = new Polygon
            {
                Points = new PointCollection
                {
                    new Point(size / 2, 0),
                    new Point(0, size),
                    new Point(size, size)
                },
                Fill = new SolidColorBrush(Color),
                Margin = new Thickness(5),
                Width = size,
                Height = size,
                Stretch = Stretch.Fill
            };
            return polygon;
        }
    }

    // ФАБРИЧНЫЕ МЕТОДЫ

    public abstract class CircleCreator { 
        public abstract Circle CreateCircle();
    }
    public abstract class SquareCreator{
        public abstract Square CreateSquare();
    }
    public abstract class TriangleCreator { 
        public abstract Triangle CreateTriangle();
    }
    ///
    /// Круги
    /// 
    public class LightCircleCreator : CircleCreator
    {
        public override Circle CreateCircle() => new Circle { Color = Color.FromRgb(207, 207, 207)};
    }
    public class DarkCircleCreator : CircleCreator
    {
        public override Circle CreateCircle() => new Circle { Color = Color.FromRgb(82, 82, 82) };
    }
    public class ColorfulCircleCreator : CircleCreator
    {
        public override Circle CreateCircle() => new Circle { Color = Color.FromRgb(0, 128, 0) };
    }
    ///
    /// Квадраты
    /// 
    public class LightSquareCreator : SquareCreator
    {
        public override Square CreateSquare() => new Square { Color = Color.FromRgb(207, 207, 207) };
    }
    public class DarkSquareCreator : SquareCreator
    {
        public override Square CreateSquare() => new Square { Color = Color.FromRgb(82, 82, 82) };
    }
    public class ColorfulSquareCreator : SquareCreator
    {
        public override Square CreateSquare() => new Square { Color = Color.FromRgb(0, 128, 0) };
    }
    ///
    /// Треугольники
    /// 
    public class LightTriangleCreator : TriangleCreator
    {
        public override Triangle CreateTriangle() => new Triangle { Color = Color.FromRgb(207, 207, 207) };
    }
    public class DarkTriangleCreator : TriangleCreator
    {
        public override Triangle CreateTriangle() => new Triangle { Color = Color.FromRgb(82, 82, 82) };
    }
    public class ColorfulTriangleCreator : TriangleCreator
    {
        public override Triangle CreateTriangle() => new Triangle { Color = Color.FromRgb(0, 128, 0) };
    }
}