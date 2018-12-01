using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Algorithms2.Models;

namespace Algorithms2.Forms
{
    public partial class GraphForm : Form
    {
        private const int ELLIPSE_SIZE = 50;
        private const int VERTICES_IN_ROW = 2;
        private const int VERTICES_IN_COLUMN = 2;
        private const int HEIGHT = 600;
        private const int WIDTH = 800;

        private int CellSize
        {
            get
            {
                return 4 * ELLIPSE_SIZE;
            }
        }

        private List<VertexViewData> rectangleVertices;
        private Font font = new Font("Arial", 16);

        private int[] vertices;
        private List<GraphEdge> edges;
        private List<GraphEdge> result;

        public GraphForm()
        {
            InitializeComponent();
        }

        public GraphForm(int[] vertices, List<GraphEdge> edges, List<GraphEdge> result)
        {
            InitializeComponent();

            this.Size = new Size(HEIGHT, WIDTH);

            rectangleVertices = new List<VertexViewData>();

            this.vertices = vertices;
            this.edges = edges;
            this.result = result;
        }

        private void GraphForm_Paint(object sender, PaintEventArgs e)
        {
            DrawVertices(e.Graphics);
            DrawAllEdges(e.Graphics);
            DrawResult(e.Graphics);
        }

        private void DrawVertices(Graphics graphics)
        {
            var vertexBackgroundColor = new SolidBrush(Color.Black);
            var vertexForGroundColor = new SolidBrush(Color.White);
            var partEllipseSize = ELLIPSE_SIZE / 4;

            for (int i = 0; i < vertices.Length; i++)
            {
                var row = i / VERTICES_IN_ROW;
                var column = i - row * VERTICES_IN_ROW;

                var y = CellSize * row + (ELLIPSE_SIZE * (column % 2));
                var x = CellSize * column;

                var rectangle = new Rectangle(x, y, ELLIPSE_SIZE, ELLIPSE_SIZE);
                rectangleVertices.Add(new VertexViewData { Rectangle = rectangle, Name = vertices[i] });
                graphics.FillEllipse(vertexBackgroundColor, rectangle);
                graphics.DrawString(vertices[i].ToString(), 
                                    font, 
                                    vertexForGroundColor, 
                                    new PointF(x + partEllipseSize, y + partEllipseSize));
            }
        }

        private void DrawAllEdges(Graphics graphics)
        {
            var color = Color.Black;
            var pen = new Pen(color);
            var brush = new SolidBrush(color);

            var halfEllipseSize = ELLIPSE_SIZE / 2;

            edges.ForEach(edge =>
            {
                var point1 = rectangleVertices.FirstOrDefault(x => x.Name == edge.Node1).Rectangle.Location;
                var point2 = rectangleVertices.FirstOrDefault(x => x.Name == edge.Node2).Rectangle.Location;

                var x1 = point1.X + halfEllipseSize;
                var y1 = point1.Y + halfEllipseSize;
                var x2 = point2.X + halfEllipseSize;
                var y2 = point2.Y + halfEllipseSize;

                var textPosX = (x1 + x2) / 2;
                var textPosY = (y1 + y2) / 2;

                graphics.DrawLine(pen, x1, y1, x2, y2); 

                graphics.DrawString(edge.Weight.ToString(),
                                    font,
                                    brush,
                                    new PointF(textPosX, textPosY));
            });
        }

        private void DrawResult(Graphics graphics)
        {
            var pen = new Pen(Color.Green);
            pen.Width = 5;

            var partEllipseSize = ELLIPSE_SIZE / 2;

            result.ForEach(edge =>
            {
                var point1 = rectangleVertices.FirstOrDefault(x => x.Name == edge.Node1).Rectangle.Location;
                var point2 = rectangleVertices.FirstOrDefault(x => x.Name == edge.Node2).Rectangle.Location;

                graphics.DrawLine(pen,
                                  point1.X + partEllipseSize,
                                  point1.Y + partEllipseSize,
                                  point2.X + partEllipseSize,
                                  point2.Y + partEllipseSize);
            });
        }
    }
}