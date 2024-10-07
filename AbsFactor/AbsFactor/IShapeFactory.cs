using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace AbsFactor
{
    public interface IShapeFactory
    {
        IShape CreateCircle();
        IShape CreateSquare();
        IShape CreateTriangle();
    }
}
