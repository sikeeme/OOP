using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Lab2.Shapes;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private List<Shape> shapes = new List<Shape>();
        private Shape? currentCreatingShape = null;
        private Color currentColor = Color.Black;
        private List<Type> availableShapeTypes = new List<Type>();


        // Initializes the form, loads available shapes using reflection, and subscribes to all necessary events.
        public Form1()
        {
            InitializeComponent();
            LoadAvailableShapes();
            SubscribeEvents();
        }

        // Discovers all concrete (non-abstract) classes derived from Shape using reflection 
        // and fills the ComboBox with their names. Adding a new shape requires no changes here.
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
            {
                shapeComboBox.SelectedIndex = 0;
            }
        }

        // Attaches event handlers to the canvas and control buttons.
        private void SubscribeEvents()
        {
            canvasPanel.Paint += CanvasPanel_Paint;
            canvasPanel.MouseDown += CanvasPanel_MouseDown;
            canvasPanel.MouseMove += CanvasPanel_MouseMove;
            canvasPanel.MouseUp += CanvasPanel_MouseUp;

            colorButton.Click += ColorButton_Click;
            clearButton.Click += ClearButton_Click;
            deleteButton.Click += DeleteButton_Click;
        }

        // Initiates creation of a new shape when the user clicks on the canvas.
        private void CanvasPanel_MouseDown(object? sender, MouseEventArgs e)
        {
            if (shapeComboBox.SelectedIndex < 0)
                return;

            Type selectedType = availableShapeTypes[shapeComboBox.SelectedIndex];
            currentCreatingShape = (Shape)Activator.CreateInstance(selectedType);
            currentCreatingShape.Color = currentColor;

            currentCreatingShape.StartCreation(e.Location);
            canvasPanel.Invalidate();
        }

        // Updates the live preview of the shape being created as the mouse moves.
        private void CanvasPanel_MouseMove(object? sender, MouseEventArgs e)
        {
            if (currentCreatingShape == null)
                return;

            currentCreatingShape.UpdateCreation(e.Location);
            canvasPanel.Invalidate();
        }

        // Finalizes shape creation, adds it to the collection and list box, and refreshes the canvas.
        private void CanvasPanel_MouseUp(object? sender, MouseEventArgs e)
        {
            if (currentCreatingShape == null)
                return;

            currentCreatingShape.FinishCreation(e.Location);
            shapes.Add(currentCreatingShape);

            shapesListBox.Items.Add(currentCreatingShape); 
            currentCreatingShape = null;

            canvasPanel.Invalidate();
        }

        // Redraws the entire canvas: all completed shapes + current shape being created (if any).
        private void CanvasPanel_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw all finished shapes
            foreach (var shape in shapes)
            {
                DrawSingleShape(g, shape);
            }

            // Draw preview of shape currently being created
            if (currentCreatingShape != null)
            {
                DrawSingleShape(g, currentCreatingShape);
            }
        }

        // Draws a single shape using its polymorphic Draw method.
        // No if-else chains — drawing logic is delegated to the shape classes themselves.
        private void DrawSingleShape(Graphics g, Shape shape)
        {
            shape.Draw(g);
        }

        // Opens the color selection dialog and updates the current drawing color.
        private void ColorButton_Click(object? sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = currentColor;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    currentColor = colorDialog.Color;
                }
            }
        }

        // Clears all shapes from the canvas and resets the shapes list.
        private void ClearButton_Click(object? sender, EventArgs e)
        {
            shapes.Clear();
            shapesListBox.Items.Clear();
            canvasPanel.Invalidate();
        }

        // Removes the selected shape from both the list and the canvas.
        private void DeleteButton_Click(object? sender, EventArgs e)
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