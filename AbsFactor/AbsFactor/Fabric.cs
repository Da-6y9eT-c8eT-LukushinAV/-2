using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AbsFactor
{
    public class RedFactory : IShapeFactory
    {
        public IShape CreateCircle() => new Circle(Brushes.Red);
        public IShape CreateSquare() => new Square(Brushes.Red);
        public IShape CreateTriangle() => new Triangle(Brushes.Red);
    }

    public class BlueFactory : IShapeFactory
    {
        public IShape CreateCircle() => new Circle(Brushes.Blue);
        public IShape CreateSquare() => new Square(Brushes.Blue);
        public IShape CreateTriangle() => new Triangle(Brushes.Blue);
    }

}
