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
        private CNF2Result _result = new CNF2Result();

        protected Stopwatch _stopwatch = new Stopwatch();
        protected List<Vertex> _vertices = new List<Vertex>();
        protected List<TreeNodeModel<int, int>> _graph = new List<TreeNodeModel<int, int>>();
        protected List<GraphEdge> _edges = new List<GraphEdge>();

        public virtual TimeSpan LastActionTime { get; protected set; }

        public CNF2Problem(List<TreeNodeModel<int, int>> graph)
        {
            graph.ForEach(node =>
            {
                _graph.Add(node.Clone() as TreeNodeModel<int, int>);

                // add vertex
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
                    // add vertex to vertices if no exists
                    if (!_vertices.Any(x => x.Name == neighbour.Name))
                    {
                        _vertices.Add(new Vertex
                        {
                            Name = neighbour.Name,
                            Visited = false
                        });
                    }

                    // add edge
                    _edges.Add(new GraphEdge
                    {
                        Node1 = node.Name,
                        Node2 = neighbour.Name
                    });
                });
            });
        }

        public virtual void ShowResult()
        {
            string messageResult = "1 wiersz - 1 silnie spójna składowa\n";

            if (!_result.IsValidResult)
            {
                messageResult += "Nie znaleziono rozwiązania dla tego równania\n";
                MessageBox.Show(messageResult);
                return;
            }

            _result.StronglyCoherentComponents.ForEach(x =>
            {
                x.Vertices.ForEach(v =>
                {
                    messageResult += v.Name < 0 ? "" : $"Nazwa: {v.Name}, Wartość: {x.LogicValue}\n";
                });
            });

            MessageBox.Show(messageResult);
        }

        public virtual async Task Start()
        {
            await Task.Run(() =>
            {
                _stopwatch.Start();

                _result = StronglyCoherentComponents();

                _stopwatch.Stop();
                LastActionTime = _stopwatch.Elapsed;
            });
        }

        protected CNF2Result StronglyCoherentComponents()
        {
            var result = new CNF2Result();

            // dfs
            DFS();

            // graph transposition
            var transposedGraph = TransposeGraph(_graph);

            // DSF na transponowanym grafie, ale główna pętla DFS analizuje wierzchołki w kolejności
            // wartości czasu przetworzenia, czyli ProcessingTime
            result.StronglyCoherentComponents = CreateStronglyCoherentComponents(transposedGraph);

            // sprawdzenie czy kazda silnie spojna skladowa jest ok, tzn czy nie ma w niej np a i ~a
            for (int i=0; i < result.StronglyCoherentComponents.Count; i++)
            {
                if (!result.StronglyCoherentComponents[i].IsValid())
                {
                    result.IsValidResult = false;
                    return result;
                }
            }

            // utworzenie sąsiadów dla silnie spójnych składowych
            CreateNeighoursInCoherentComponents(result.StronglyCoherentComponents);

            // ustawienie wartości dla silnie spójnych składowych (0,1)
            var stronglyCoherentComponentsTransposed = result.StronglyCoherentComponents.OrderByDescending(x => x.ProcessingTime)
                                                                                        .ToList();

            SetLogicValuesInCoherentComponents(stronglyCoherentComponentsTransposed);

            return result;
        }

        //returns time
        protected void DFS()
        {
            int time = 1;

            for (int i = 0; i < _vertices.Count; i++)
            {
                if (_vertices[i].Visited == false)
                {
                    time = DFSUtil(i, time);
                }
            }
        }

        /// <summary>
        /// Deep first search
        /// </summary>
        /// <param name="vertexIndex"></param>
        /// <param name="time"></param>
        /// <param name="parentTime"></param>
        /// <returns></returns>
        protected int DFSUtil(int vertexIndex, int time)
        {
            int children = 0;

            var vertex = _vertices[vertexIndex];

            vertex.Visited = true;
            vertex.EntryTime = vertex.LowTime = time++;

            var graphVertex = _graph.Where(node => node.Name == vertex.Name).FirstOrDefault();

            if (graphVertex == null)
            {
                return time;
            }

            graphVertex.Neighbours.ForEach(neighbour =>
            {
                var index = _vertices.FindIndex(x => x.Name == neighbour.Name);

                var neighVertex = _vertices[index];

                if (!neighVertex.Visited)
                {
                    neighVertex.ParentName = vertex.Name;
                    _edges.Where(edge => edge.Node1 == vertex.Name && edge.Node2 == neighVertex.Name)
                          .FirstOrDefault()
                          .IsVisited = true;

                    time = DFSUtil(index, time);

                    vertex.LowTime = Math.Min(vertex.LowTime, neighVertex.LowTime);

                    // vertex is root of DFS tree and has two or more children
                    if (vertex.ParentName == null && children > 1)
                    {
                        vertex.IsArticulationPoint = true;
                    }

                    // If vertex is not root and low value of one of its child is more
                    // than entry time value of vertex
                    if (vertex.ParentName != null && vertex.LowTime >= vertex.EntryTime)
                    {
                        vertex.IsArticulationPoint = true;
                    }

                    if (neighVertex.LowTime > vertex.EntryTime)
                    {
                        _edges.Where(x => x.Node2 == neighVertex.Name && x.Node1 == vertex.Name)
                              .FirstOrDefault()
                              .IsBridge = true;
                    }
                }
                // Update low value of neighVertex for parent function calls
                else if (neighVertex.Name != vertex.ParentName)
                {
                    vertex.LowTime = Math.Min(vertex.LowTime, neighVertex.LowTime);
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

            if (vertexGraph == null)
            {
                result.Vertices.Add(vertex);
                return;
            }

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

        protected List<StronglyCoherentComponent<int>> CreateStronglyCoherentComponents(List<TreeNodeModel<int, int>> transposedGraph)
        {
            var result = new List<StronglyCoherentComponent<int>>();

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

            for (int i = 0; i < result.Count; i++)
            {
                result[i].ProcessingTime = i+1;
            }

            return result;
        }

        protected void CreateNeighoursInCoherentComponents(List<StronglyCoherentComponent<int>> stronglyCoherentComponents)
        {
            for (int i=0; i < stronglyCoherentComponents.Count; i++)
            {
                // biore silnie spójną składową
                var stronglyCoherentComponent = stronglyCoherentComponents[i];

                // dla kazdego wierzchołka w tej silnie spójnej składowej weź wszystkich sąsiadów i sprawdź w których składowych są
                stronglyCoherentComponent.Vertices.ForEach(v =>
                {
                    var vertexWithNeighbours = _graph.FirstOrDefault(x => x.Name == v.Name);

                    if (vertexWithNeighbours == null)
                    {
                        return;
                    }

                    var neighbours = vertexWithNeighbours.Neighbours;

                    // sprawdz w których innych silnie spójnych składowych jest ten sąsiad
                    neighbours.ForEach(n =>
                    {
                        for (int j = 0; j < stronglyCoherentComponents.Count; j++)
                        {
                            if (j != i)
                            {
                                // jeśli silnie spójna składowa zawiera tego sąsiada, to dodajemy tą silnie spójną składową
                                // do sąsiadów przeglądanej silnie spójnej składowej
                                if (!stronglyCoherentComponent.Neighbours.Contains(stronglyCoherentComponents[j])
                                    && stronglyCoherentComponents[j].Vertices.Where(vertex => vertex.Name == n.Name).ToList().Count > 0)
                                {
                                    stronglyCoherentComponent.Neighbours.Add(stronglyCoherentComponents[j]);
                                }
                            }
                        }
                    });
                });
            }
        }

        protected void SetLogicValuesInCoherentComponents(List<StronglyCoherentComponent<int>> stronglyCoherentComponentsTransposed)
        {
            // szukam składowej która nie ma wartości
            var stronglyCoherentComponent = stronglyCoherentComponentsTransposed.FirstOrDefault(x => x.LogicValue == -1);

            if (stronglyCoherentComponent == null)
            {
                return;
            }

            stronglyCoherentComponent.LogicValue = 1;
            var stronglyCoherentComponentIndex = stronglyCoherentComponentsTransposed.IndexOf(stronglyCoherentComponent);

            for (int i=0; i < stronglyCoherentComponentsTransposed.Count; i++)
            {
                // wszedzie gdzie występują przeciwności wierzchołków tej silnie spójnej składowej
                // te silnie spójne składowe mają wartość 0

                if (i != stronglyCoherentComponentIndex && stronglyCoherentComponentsTransposed[i].LogicValue == -1)
                {
                    // dla wszystkich wierzchołków w stronglyCoherentComponent, szukam wierzchołków negacji
                    // w i-tym stronglyCoherentComponentsTransposed
                    for (int iVertex = 0; iVertex < stronglyCoherentComponent.Vertices.Count; iVertex++)
                    {
                        var oppositeName = stronglyCoherentComponent.Vertices[iVertex].Name * (-1);
                        var oppositeElement = stronglyCoherentComponentsTransposed[i].Vertices.FirstOrDefault(x => x.Name == oppositeName);

                        if (oppositeElement != null)
                        {
                            stronglyCoherentComponentsTransposed[i].LogicValue = 0;
                            break;
                        }
                    }
                }
            }

            SetLogicValuesInCoherentComponents(stronglyCoherentComponentsTransposed);
        }
    }
}