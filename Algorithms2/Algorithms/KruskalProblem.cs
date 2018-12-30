using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Algorithms2.Algorithms.BaseClasses;
using Algorithms2.Forms;
using Algorithms2.Interfaces;
using Algorithms2.Models;

namespace Algorithms2.Algorithms
{
    public class KruskalProblem : UnionFindBase, IAlgorithm
    {
        protected Stopwatch stopwatch;
        protected int[] vertexNames;
        protected List<GraphEdge> edges;
        protected List<GraphEdge> result;

        public virtual TimeSpan LastActionTime { get; protected set; }

        public KruskalProblem(List<TreeNodeModel<int, int>> tree) : base(tree)
        {
            int i = 0;
            edges = new List<GraphEdge>();
            vertexNames = new int[tree.Count];

            foreach (var treeNode in tree)
            {
                foreach (var neighbour in treeNode.Neighbours)
                {
                    edges.Add(new GraphEdge
                    {

                        Node1 = treeNode.Name,
                        Node2 = neighbour.Name,
                        Weight = neighbour.Weight
                    });
                }

                vertexNames[i++] = treeNode.Name;
            }

            edges = edges.OrderBy(edge => edge.Weight).ToList();

            stopwatch = new Stopwatch();
        }

        public virtual void ShowResult()
        {
            var form = new GraphForm(vertexNames, edges, result);
            form.Show();
        }

        public virtual async Task Start()
        {
            await Task.Run(() =>
            {
                stopwatch.Start();

                result = MinimumSpanningTree();

                stopwatch.Stop();
                LastActionTime = stopwatch.Elapsed;
            });
        }

        protected List<GraphEdge> MinimumSpanningTree()
        {
            var result = new List<GraphEdge>();

            int edgeUnionCount = 0;
            int edgeCounter = 0;

            while (edgeUnionCount < verticesCount - 1)
            {
                var edge = edges[edgeCounter];

                var father1 = Find(edge.Node1);
                var father2 = Find(edge.Node2);

                if (father1 != father2)
                {
                    result.Add(edge.Clone() as GraphEdge);
                    edgeUnionCount++;
                    Union(edge.Node1, edge.Node2);
                }

                edgeCounter++;
            }

            return result;
        }
    }
}
