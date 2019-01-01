using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Algorithms2.Models;

namespace Algorithms2.Forms
{
    /// <summary>
    /// Functionality in this class should be better implemented
    /// but because of too many tasks related to university i used enum
    /// </summary>
    public partial class GraphForm : Form
    {
        private enum GraphType
        {
            Kruskal,
            ArticulationEdge,
        }

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

        private List<VertexViewData> _rectangleVertices;
        private Font _font = new Font("Arial", 16);

        private GraphType _graphType;
        private int[] _vertices;
        private List<GraphEdge> _edges;
        private List<GraphEdge> _result;
        private ArticulationResult _articulationResult;

        public GraphForm()
        {
            InitializeComponent();
        }

        public GraphForm(int[] vertices, List<GraphEdge> edges, List<GraphEdge> result)
        {
            InitializeComponent();

            this.Size = new Size(HEIGHT, WIDTH);

            _rectangleVertices = new List<VertexViewData>();

            _vertices = vertices;
            _edges = edges;
            _result = result;
            _graphType = GraphType.Kruskal;
        }

        public GraphForm(ArticulationResult result)
        {
            InitializeComponent();

            Size = new Size(HEIGHT, WIDTH);

            _rectangleVertices = new List<VertexViewData>();
            _graphType = GraphType.ArticulationEdge;

            _articulationResult = result;
        }

        private void GraphForm_Paint(object sender, PaintEventArgs e)
        {
            switch (_graphType)
            {
                case GraphType.Kruskal:
                    DrawVerticesKruskal(e.Graphics);
                    break;
                case GraphType.ArticulationEdge:
                    DrawVerticesArticulation(e.Graphics);
                    break;
            }

            DrawAllEdges(e.Graphics);
            DrawResult(e.Graphics);
        }

        private void DrawVerticesKruskal(Graphics graphics)
        {
            var vertexBackgroundColor = new SolidBrush(Color.Black);
            var vertexForGroundColor = new SolidBrush(Color.White);
            var partEllipseSize = ELLIPSE_SIZE / 4;

            for (int i = 0; i < _vertices.Length; i++)
            {
                var row = i / VERTICES_IN_ROW;
                var column = i - row * VERTICES_IN_ROW;

                var y = CellSize * row + (ELLIPSE_SIZE * (column % 2));
                var x = CellSize * column;

                var rectangle = new Rectangle(x, y, ELLIPSE_SIZE, ELLIPSE_SIZE);

                _rectangleVertices.Add(new VertexViewData { Rectangle = rectangle, Name = _vertices[i] });

                graphics.FillEllipse(vertexBackgroundColor, rectangle);

                graphics.DrawString(_vertices[i].ToString(),
                                    _font, 
                                    vertexForGroundColor, 
                                    new PointF(x + partEllipseSize, y + partEllipseSize));
            }
        }

        private void DrawVerticesArticulation(Graphics graphics)
        {
            var vertexBackgroundColor = new SolidBrush(Color.Black);
            var vertexForGroundColor = new SolidBrush(Color.White);
            var partEllipseSize = ELLIPSE_SIZE / 4;

            for (int i = 0; i < _articulationResult.GraphVertices.Count; i++)
            {
                var vertex = _articulationResult.GraphVertices[i];

                vertexBackgroundColor = vertex.IsArticulationPoint ? new SolidBrush(Color.Red) : new SolidBrush(Color.Black); 

                var row = i / VERTICES_IN_ROW;
                var column = i - row * VERTICES_IN_ROW;

                var y = CellSize * row + (ELLIPSE_SIZE * (column % 2));
                var x = CellSize * column;

                var rectangle = new Rectangle(x, y, ELLIPSE_SIZE, ELLIPSE_SIZE);

                _rectangleVertices.Add(new VertexViewData
                {
                    Rectangle = rectangle,
                    Name = vertex.Name
                });

                graphics.FillEllipse(vertexBackgroundColor, rectangle);

                graphics.DrawString(vertex.Name.ToString(),
                                    _font,
                                    vertexForGroundColor,
                                    new PointF(x + partEllipseSize, y + partEllipseSize));
            }
        }

        private void DrawAllEdges(Graphics graphics)
        {
            var color = Color.Black;
            var pen = new Pen(color);
            var brush = new SolidBrush(color);
            pen.Width = 1;

            var halfEllipseSize = ELLIPSE_SIZE / 2;

            _articulationResult.GraphEdges.ForEach(edge =>
            {
                pen = edge.IsVisited ? new Pen(Color.Blue) : new Pen(Color.Black);
                pen.Width = edge.IsVisited ? 3 : 1;

                var point1 = _rectangleVertices.FirstOrDefault(x => x.Name == edge.Node1).Rectangle.Location;
                var point2 = _rectangleVertices.FirstOrDefault(x => x.Name == edge.Node2).Rectangle.Location;

                var x1 = point1.X + halfEllipseSize;
                var y1 = point1.Y + halfEllipseSize;
                var x2 = point2.X + halfEllipseSize;
                var y2 = point2.Y + halfEllipseSize;

                var textPosX = (x1 + x2) / 2;
                var textPosY = (y1 + y2) / 2;

                graphics.DrawLine(pen, x1, y1, x2, y2);

                if (edge.Weight != 0)
                {
                    graphics.DrawString(edge.Weight.ToString(),
                                        _font,
                                        brush,
                                        new PointF(textPosX, textPosY));
                }
            });
        }

        private void DrawResult(Graphics graphics)
        {
            var pen = new Pen(Color.Green);
            pen.Width = 5;

            var partEllipseSize = ELLIPSE_SIZE / 2;

            _articulationResult.Bridges.ForEach(edge =>
            {
                var point1 = _rectangleVertices.FirstOrDefault(x => x.Name == edge.Node1).Rectangle.Location;
                var point2 = _rectangleVertices.FirstOrDefault(x => x.Name == edge.Node2).Rectangle.Location;

                graphics.DrawLine(pen,
                                  point1.X + partEllipseSize,
                                  point1.Y + partEllipseSize,
                                  point2.X + partEllipseSize,
                                  point2.Y + partEllipseSize);
            });
        }
    }
}