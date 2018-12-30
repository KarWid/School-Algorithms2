using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithms2.Interfaces;
using Algorithms2.Models;

namespace Algorithms2.Algorithms
{
    // slajd 64
    public class CNF2Problem : IAlgorithm
    {
        protected Stopwatch _stopwatch = new Stopwatch();

        protected List<StronglyCoherentComponent<int>> _result = new List<StronglyCoherentComponent<int>>();
        protected List<Vertex> _vertices = new List<Vertex>();
        protected List<TreeNodeModel<int, int>> _graph = new List<TreeNodeModel<int, int>>();

        public TimeSpan LastActionTime { get; private set; }

        public CNF2Problem(List<TreeNodeModel<int, int>> graph)
        {
            graph.ForEach(node =>
            {
                _graph.Add(node.Clone() as TreeNodeModel<int, int>);

                var y = _vertices.Any(x => x.Name == node.Name);
                if (!_vertices.Any(x => x.Name == node.Name))
                {
                    _vertices.Add(new Vertex
                    {
                        Name = node.Name,
                        Visited = false
                    });
                }

                node.Neighbours.ForEach(neighbour =>
                {
                    if (!_vertices.Any(x => x.Name == neighbour.Name))
                    {
                        _vertices.Add(new Vertex
                        {
                            Name = neighbour.Name,
                            Visited = false
                        });
                    }
                });
            });
        }

        public void ShowResult()
        {
            string messageResult = "1 wiersz - 1 silnie spójna składowa\n";

            _result.ForEach(x =>
            {
                for (int i=0; i < x.Vertices.Count; i++)
                {
                    messageResult += x.Vertices[i].Name + " ";
                    if (i < x.Vertices.Count - 1)
                    {
                        messageResult += ": ";
                    }
                }
                messageResult += "\n";
            });

            MessageBox.Show(messageResult);
        }

        public async Task Start()
        {
            await Task.Run(() =>
            {
                _stopwatch.Start();

                _result = StronglyCoherentComponents();

                _stopwatch.Stop();
                LastActionTime = _stopwatch.Elapsed;
            });
        }

        protected List<StronglyCoherentComponent<int>> StronglyCoherentComponents()
        {
            var result = new List<StronglyCoherentComponent<int>>();

            // dfs
            int time = 1;
            for (int i=0; i < _vertices.Count; i++)
            {
                if (_vertices[i].Visited == false)
                {
                    DFSUtil(i, time);
                }
            }

            // graph transposition
            var transposedGraph = TransposeGraph(_graph);

            // DSF na transponowanym grafie, ale główna pętla DFS analizuje wierzchołki w kolejności
            // wartości czasu przetworzenia, czyli ProcessingTime
            _vertices.ForEach(v => v.Visited = false);
            _vertices = _vertices.OrderByDescending(x => x.ProcessingTime).ToList();

            _vertices.ForEach(v =>
            {
                if (!v.Visited)
                {
                    var localResult = new StronglyCoherentComponent<int>();

                    DFSBasedOnProcessingTime(transposedGraph, v, localResult);

                    result.Add(localResult);
                }
            });

            return result;
        }

        //returns time
        protected int DFSUtil(int vertexIndex, int time)
        {
            var vertex = _vertices[vertexIndex];

            vertex.Visited = true;
            vertex.EntryTime = time++;

            var graphVertex = _graph.Where(node => node.Name == vertex.Name).FirstOrDefault();

            graphVertex.Neighbours.ForEach(neighbour =>
            {
                var index = _vertices.FindIndex(x => x.Name == neighbour.Name);
                var isVisited = _vertices[index].Visited;

                if (!isVisited)
                {
                    time = DFSUtil(index, time);
                }
            });

            vertex.ProcessingTime = time++;

            return time;
        }

        // graph transposition
        protected List<TreeNodeModel<int, int>> TransposeGraph(List<TreeNodeModel<int, int>> graph)
        {
            var result = new List<TreeNodeModel<int, int>>();

            graph.ForEach(treeNode =>
            {
                treeNode.Neighbours.ForEach(neighbour =>
                {
                    var newElement = new TreeNeighbourNode<int, int> { Name = treeNode.Name };

                    if (!result.Any(x => x.Name == neighbour.Name))
                    {
                        var neighbourList = new List<TreeNeighbourNode<int, int>>() { newElement };
                        result.Add(new TreeNodeModel<int, int>(neighbour.Name, neighbourList));
                    }
                    else
                    {
                        result.Where(x => x.Name == neighbour.Name).FirstOrDefault()
                                                                   .Neighbours
                                                                   .Add(newElement);
                    }
                });
            });

            return result;
        }

        protected void DFSBasedOnProcessingTime(List<TreeNodeModel<int, int>> graph, Vertex vertex, StronglyCoherentComponent<int> result)
        {
            vertex.Visited = true;

            var vertexGraph = graph.Where(x => x.Name == vertex.Name).FirstOrDefault();

            vertexGraph.Neighbours.ForEach(neighbour =>
            {
                var neighVertex = _vertices.Where(x => x.Name == neighbour.Name).FirstOrDefault();
                if (!neighVertex.Visited)
                {
                    DFSBasedOnProcessingTime(graph, neighVertex, result);
                }
            });

            result.Vertices.Add(vertex);
        }
    }
}