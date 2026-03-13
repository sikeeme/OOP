using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Lab2.Shapes;   // <-- важно!

namespace Lab2
{
    public partial class Form1 : Form
    {
        private List<Shape> shapes = new List<Shape>();
        private Shape? currentCreatingShape = null;
        private Color currentColor = Color.Black;
        private List<Type> availableShapeTypes = new List<Type>();

        public Form1()
        {
            InitializeComponent();
            LoadAvailableShapes();
            SubscribeEvents();
        }

        /// <summary>
        /// Populates ComboBox with all shapes using reflection.
        /// Adding new class requires NO changes here!
        /// </summary>
        private void LoadAvailableShapes()
        {
            availableShapeTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Shape)) && !t.IsAbstract)
                .ToList();

            shapeComboBox.Items.Clear();
            foreach (var type in availableShapeTypes)
            {
                shapeComboBox.Items.Add(type.Name);
            }
            if (shapeComboBox.Items.Count > 0)
                shapeComboBox.SelectedIndex = 0;
        }

        private void SubscribeEvents()
        {
            canvasPanel.Paint += CanvasPanel_Paint;
            canvasPanel.MouseDown += CanvasPanel_MouseDown;
            canvasPanel.MouseMove += CanvasPanel_MouseMove;
            canvasPanel.MouseUp += CanvasPanel_MouseUp;

            colorButton.Click += ColorButton_Click;
            clearButton.Click += ClearButton_Click;
            //deleteButton.Click += DeleteButton_Click;
        }

        private void CanvasPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (shapeComboBox.SelectedIndex < 0) return;

            Type selectedType = availableShapeTypes[shapeComboBox.SelectedIndex];
            currentCreatingShape = (Shape)Activator.CreateInstance(selectedType);
            currentCreatingShape.Color = currentColor;

            currentCreatingShape.StartCreation(e.Location);
            canvasPanel.Invalidate();
        }

        private void CanvasPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentCreatingShape == null) return;

            currentCreatingShape.UpdateCreation(e.Location);
            canvasPanel.Invalidate();
        }

        private void CanvasPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentCreatingShape == null) return;

            currentCreatingShape.FinishCreation(e.Location);
            shapes.Add(currentCreatingShape);

            shapesListBox.Items.Add(currentCreatingShape); // uses ToString()
            currentCreatingShape = null;
            canvasPanel.Invalidate();
        }

        /// <summary>
        /// Drawing logic is here. Only here we use if (because drawing is NOT forbidden to be in one place).
        /// When you add a new shape, you just add one "else if" block here.
        /// </summary>
        private void CanvasPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw finished shapes
            foreach (var shape in shapes)
            {
                DrawSingleShape(g, shape);
            }

            // Draw current creating shape (live preview)
            if (currentCreatingShape != null)
            {
                DrawSingleShape(g, currentCreatingShape);
            }
        }

        private void DrawSingleShape(Graphics g, Shape shape)
        {
            using (Pen pen = new Pen(shape.Color, 2))
            {
                if (shape is Circle circle)
                {
                    g.DrawEllipse(pen,
                        circle.Center.X - circle.Radius,
                        circle.Center.Y - circle.Radius,
                        circle.Radius * 2,
                        circle.Radius * 2);
                }
                else if (shape is RectangleShape rect)
                {
                    g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
                }
                else if (shape is Line line)
                {
                    g.DrawLine(pen, line.Start, line.End);
                }
            }
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    currentColor = cd.Color;
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            shapes.Clear();
            shapesListBox.Items.Clear();
            canvasPanel.Invalidate();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (shapesListBox.SelectedIndex >= 0)
            {
                shapes.RemoveAt(shapesListBox.SelectedIndex);
                shapesListBox.Items.RemoveAt(shapesListBox.SelectedIndex);
                canvasPanel.Invalidate();
            }
        }
    }
}