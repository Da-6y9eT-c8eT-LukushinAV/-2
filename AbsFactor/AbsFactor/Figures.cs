using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AbsFactor
{
    public class Circle : IShape
    {
        private readonly Brush _color;

        public Circle(Brush color)
        {
            _color = color;
        }

        public void Draw(Canvas canvas)
        {
            Ellipse ellipse = new Ellipse
            {
                Width = 100,
                Height = 100,
                Fill = _color
            };
            // Центрируем фигуру на холсте
            Canvas.SetLeft(ellipse, (canvas.Width - ellipse.Width) / 2);
            Canvas.SetTop(ellipse, (canvas.Height - ellipse.Height) / 2);
            canvas.Children.Add(ellipse);  // Добавляем круг на холст
        }
    }

    public class Square : IShape
    {
        private readonly Brush _color;

        public Square(Brush color)
        {
            _color = color;
        }

        public void Draw(Canvas canvas)
        {
            Rectangle rectangle = new Rectangle
            {
                Width = 100,
                Height = 100,
                Fill = _color
            };
            // Центрируем фигуру на холсте
            Canvas.SetLeft(rectangle, (canvas.Width - rectangle.Width) / 2);
            Canvas.SetTop(rectangle, (canvas.Height - rectangle.Height) / 2);
            canvas.Children.Add(rectangle);  // Добавляем квадрат на холст
        }
    }

    public class Triangle : IShape
    {
        private readonly Brush _color;

        public Triangle(Brush color)
        {
            _color = color;
        }

        public void Draw(Canvas canvas)
        {
            Polygon triangle = new Polygon
            {
                Points = new PointCollection(new List<Point>
            {
                new Point(50, 0),    // Вершина треугольника
                new Point(0, 100),   // Левый нижний угол
                new Point(100, 100)  // Правый нижний угол
            }),
                Fill = _color
            };
            // Центрируем треугольник на холсте
            double offsetX = (canvas.Width - 100) / 2;
            double offsetY = (canvas.Height - 100) / 2;
            Canvas.SetLeft(triangle, offsetX);
            Canvas.SetTop(triangle, offsetY);
            canvas.Children.Add(triangle);  // Добавляем треугольник на холст
        }
    }


}
