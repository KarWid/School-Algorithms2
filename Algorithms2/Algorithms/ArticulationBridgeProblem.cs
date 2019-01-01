using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms2.Forms;
using Algorithms2.Interfaces;
using Algorithms2.Models;

namespace Algorithms2.Algorithms
{
    //http://informatyka.wroc.pl/node/752?page=0,2
    public class ArticulationBridgeProblem : CNF2Problem, IAlgorithm
    {
        private ArticulationResult _result;

        public ArticulationBridgeProblem(List<TreeNodeModel<int, int>> graph) : base(graph) { }

        public override void ShowResult()
        {
            var form = new GraphForm(_result);
            form.Show();
        }

        public override async Task Start()
        {
            await Task.Run(() =>
            {
                _stopwatch.Start();

                // set result
                FindArticulationBridge();

                _stopwatch.Stop();
                LastActionTime = _stopwatch.Elapsed;
            });
        }

        protected void FindArticulationBridge()
        {
            // deep first search
            DFS();

            // create DFS graph
            // dfsVertices containsgraph vertices
            var dfsVertices = new List<Vertex>();
            _vertices.ForEach(v => dfsVertices.Add((Vertex)v.Clone()));

            // dfsEdges contains dfsGraph edges
            var dfsEdges = _edges.Where(x => x.IsVisited).ToList();

            // find bridge
            var bridges = dfsEdges.Where(x => x.IsBridge).ToList();
            var articulationPoints = dfsVertices.Where(x => x.IsArticulationPoint).ToList();

            _result = new ArticulationResult
            {
                ArticulationPoints = articulationPoints,
                Bridges = bridges,
                GraphVertices = _vertices,
                GraphEdges = _edges
            };
        }

        protected void CreateDFSGraph(out List<GraphEdge> dfsGraphEdges, out List<TreeNodeModel<int, int>> dfsGraph)
        {
            dfsGraphEdges = _edges.Where(edge => edge.IsVisited).ToList();

            var graph = new List<TreeNodeModel<int, int>>();

            dfsGraphEdges.ForEach(dfsGraphEdge =>
            {
                var neighbour1 = new TreeNeighbourNode<int, int> { Name = dfsGraphEdge.Node2 };
                var neighbour2 = new TreeNeighbourNode<int, int> { Name = dfsGraphEdge.Node1 };

                var dfsGraphNode = graph.Where(x => x.Name == dfsGraphEdge.Node1).FirstOrDefault();
                if (dfsGraphNode == null)
                {
                    var neighbours = new List<TreeNeighbourNode<int, int>> { neighbour1 };

                    var treeNode = new TreeNodeModel<int, int>(dfsGraphEdge.Node1, neighbours);

                    graph.Add(treeNode);
                }
                else
                {
                    dfsGraphNode.Neighbours.Add(neighbour1);
                }

                dfsGraphNode = graph.Where(x => x.Name == dfsGraphEdge.Node2).FirstOrDefault();
                if (dfsGraphNode == null)
                {
                    var neighbours = new List<TreeNeighbourNode<int, int>> { neighbour2 };

                    var treeNode = new TreeNodeModel<int, int>(dfsGraphEdge.Node2, neighbours);

                    graph.Add(treeNode);
                }
                else
                {
                    dfsGraphNode.Neighbours.Add(neighbour2);
                }
            });

            dfsGraph = graph;
        }
    }
}
