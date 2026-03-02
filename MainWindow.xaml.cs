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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private IFigureFactory currentFactory;


        private void Theme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string value = Theme.SelectedValue.ToString();
            value = value.Substring(value.LastIndexOf(' ') + 1);

            switch (value)
            {
                case "Light":
                    currentFactory = new LightFactory();
                    break;
                case "Dark":
                    currentFactory = new DarkFactory();
                    break;
                case "Colorful":
                    currentFactory = new ColorfulFactory();
                    break;
                default:
                    return;
            }
            Figure figaC = currentFactory.CreateCircle();
            Figure figaS = currentFactory.CreateSquare();
            Figure figaT = currentFactory.CreateTriangle();

            UIElement ffC = figaC.CreateUIElement();
            UIElement ffS = figaS.CreateUIElement();
            UIElement ffT = figaT.CreateUIElement();

            if (Fig != null)
            {
                Fig.Children.Clear();
                Fig.Children.Add(ffC);
                Fig.Children.Add(ffS);
                Fig.Children.Add(ffT);
            }
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

    // АБСТРАКТНЫЕ ФАБРИКИ

    public interface IFigureFactory
    {

        Circle CreateCircle();
        Square CreateSquare();
        Triangle CreateTriangle();
    }

    public class LightFactory : IFigureFactory
    {
        public Circle CreateCircle() => new Circle { Color = Color.FromRgb(207, 207, 207) };

        public Square CreateSquare() => new Square { Color = Color.FromRgb(207, 207, 207) };

        public Triangle CreateTriangle() => new Triangle { Color = Color.FromRgb(207, 207, 207) };
    }
    public class DarkFactory : IFigureFactory
    {
        public Circle CreateCircle() => new Circle { Color = Color.FromRgb(82, 82, 82) };

        public Square CreateSquare() => new Square { Color = Color.FromRgb(82, 82, 82) };

        public Triangle CreateTriangle() => new Triangle { Color = Color.FromRgb(82, 82, 82) };
    }
    public class ColorfulFactory : IFigureFactory
    {
        public Circle CreateCircle() => new Circle { Color = Color.FromRgb(0, 128, 0) };

        public Square CreateSquare() => new Square { Color = Color.FromRgb(0, 128, 0) };

        public Triangle CreateTriangle() => new Triangle { Color = Color.FromRgb(0, 128, 0) };
    }
}

