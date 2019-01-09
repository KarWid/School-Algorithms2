using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithms2.Interfaces;
using Algorithms2.Models.Tarjan;

namespace Algorithms2.Algorithms
{
    public class TarjanProblem : IAlgorithm
    {
        private string _result;
        private Stopwatch _stopwatch;
        private TarjanTreeModel _tree;
        private List<TarjanVertexPairTarget> _target;

        public TimeSpan LastActionTime { get; private set; }

        public TarjanProblem(TarjanModel model)
        {
            _stopwatch = new Stopwatch();
            _tree = model.Tree;
            _target = model.Target;
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

                _result = "";
                Tarjan(_tree.Root);

                _stopwatch.Stop();
                LastActionTime = _stopwatch.Elapsed;
            });
        }

        private void MakeSet(TarjanNodeModel vertex)
        {
            vertex.Father = null;
            vertex.Count = 1;
        }

        private void Union(TarjanNodeModel vertex1, TarjanNodeModel vertex2)
        {
            TarjanNodeModel largeRoot, smallRoot, vertexSmall, vertexLarge;

            if (vertex1.Root.Count > vertex2.Root.Count)
            {
                largeRoot = vertex1.Root;
                vertexLarge = vertex1;

                smallRoot = vertex2.Root;
                vertexSmall = vertex2;
            }
            else
            {
                largeRoot = vertex2.Root;
                vertexLarge = vertex2;

                smallRoot = vertex1.Root;
                vertexSmall = vertex1;
            }

            smallRoot.Father = largeRoot;
            largeRoot.Count = largeRoot.Count + smallRoot.Count;
            smallRoot = largeRoot;
        }

        // return ancestor
        private TarjanNodeModel Find(TarjanNodeModel vertex)
        {
            var list = new List<TarjanNodeModel>();
            var currentVertex = vertex;

            while (currentVertex.Father != null)
            {
                list.Add(currentVertex);
                currentVertex = currentVertex.Father;
            }

            list.ForEach(v => v.Father = currentVertex);

            return currentVertex;
        }

        private void Tarjan(TarjanNodeModel vertex)
        { 
            MakeSet(vertex);

            vertex.Ancestor = vertex;

            foreach (var child in vertex.Children)
            {
                Tarjan(child);
                Union(vertex, child);
                Find(vertex).Ancestor = vertex;
            }

            vertex.Color = Color.Black;

            var targetPairs = _target.Where(x => x.Vertex1.Name == vertex.Name || x.Vertex2.Name == vertex.Name).ToList();
            
            foreach (var pair in targetPairs)
            {
                var v = pair.Vertex1 == vertex ? pair.Vertex2 : pair.Vertex1;

                if (v.Color == Color.Black)
                {
                    var ancestor = Find(v).Ancestor.Name;
                    _result += $"({vertex.Name},{v.Name}) -> {ancestor}\n";
                }
            }
        }
    }
}