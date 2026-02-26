using System.Windows.Forms;
using Lab1.Shapes;
using System.Drawing;

namespace Lab1
{
    public partial class Form1 : Form
    {
        private ShapeList shapeList;

        public Form1()
        {
            InitializeComponent();
            InitializeShapes();

            this.Paint += Form1_Paint;
        }

        private void InitializeShapes()
        {
            shapeList = new ShapeList();
            
            shapeList.Add(new Line(25, 10, 115, 100));
            shapeList.Add(new RectangleShape(135, 20, 80, 50));
            shapeList.Add(new Ellipse(265, 20, 100, 60));
            shapeList.Add(new Circle(315, 150, 40));      
            shapeList.Add(new Square(190, 150, 60));    
            shapeList.Add(new Triangle(75, 125, 50));  
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            shapeList.DrawAll(e.Graphics);
        }
    }
}