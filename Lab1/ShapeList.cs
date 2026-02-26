using System.Collections.Generic;
using Lab1.Shapes;
using System.Drawing;

namespace Lab1
{
    public class ShapeList
    {
        private List<IShape> _shapes = new List<IShape>();

        public void Add(IShape shape) => _shapes.Add(shape);

        public void DrawAll(Graphics g)
        {
            foreach (var shape in _shapes)
            {
                shape.Draw(g); 
            }
        }
    }
}