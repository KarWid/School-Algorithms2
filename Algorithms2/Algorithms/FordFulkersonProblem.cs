using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithms2.Interfaces;

namespace Algorithms2.Algorithms
{
    //https://www.geeksforgeeks.org/ford-fulkerson-algorithm-for-maximum-flow-problem/
    public class FordFulkersonProblem : IAlgorithm
    {
        private Stopwatch _stopwatch;
        private string _result;
        private int[,] _graph { get; set; }
        private int _begin { get; set; }
        private int _end { get; set; }

        public TimeSpan LastActionTime { get; set; }

        public FordFulkersonProblem(int[,] graph, int begin, int end)
        {
            _graph = graph;
            _begin = begin;
            _end = end;

            _stopwatch = new Stopwatch();
        }

        public void ShowResult()
        {
            MessageBox.Show(_result);
        }

        public async Task Start()
        {
            await Task.Run(() =>
            {
                _stopwatch.Start();

                _result = FordFulkerson(_graph, _begin, _end);

                _stopwatch.Stop();
                LastActionTime = _stopwatch.Elapsed;
            });
        }

        private bool BFS(int[,] tab, int begin, int end, int[] parent, int V)
        {
            var visited = new bool[V];
            var queue = new Queue<int>();

            queue.Enqueue(begin);
            visited[begin] = true;
            parent[begin] = -1;

            while (queue.Count != 0)
            {
                var u = queue.Dequeue();

                for (int v = 0; v < V; v++)
                {
                    if (!visited[v] && tab[u, v] > 0)
                    {
                        queue.Enqueue(v);
                        parent[v] = u;
                        visited[v] = true;
                    }
                }
            }
            return visited[end] == true;
        }

        private string FordFulkerson(int[,] tab, int begin, int end)
        {
            var result = "";

            var maxFlow = 0;
            var V = tab.GetLength(0);

            int[,] residualGraph = (int[,])tab.Clone();

            var parent = new int[V];

            // przechodzenie grafu
            while (BFS(residualGraph, begin, end, parent, V))
            {
                var pathFlow = int.MaxValue;

                // znajdowanie minimalnej pojemności rezydualnej
                for (int v = end; v != begin; v = parent[v])
                {
                    pathFlow = Math.Min(pathFlow, residualGraph[parent[v], v]);
                    result += parent[v] + "--->" + v + "  przepływ = " + pathFlow + "\n";
                }

                for (int v = end; v != begin; v = parent[v])
                {
                    if (pathFlow == residualGraph[parent[v], v])
                    {
                        result += parent[v] + "--->" + v + "  przepływ = " + pathFlow + "\t[ SUMOWANY ]\n";
                    }
                }

                // aktualizacja pojemności rezydualnej
                for (int v = end; v != begin; v = parent[v])
                {
                    residualGraph[parent[v], v] -= pathFlow;
                    residualGraph[v, parent[v]] += pathFlow;
                }

                maxFlow += pathFlow;
            }

            result += $"Max flow: {maxFlow}";

            return result;
        }
    }
}