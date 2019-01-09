using System;
using System.Collections.Generic;
using System.Drawing;
using Algorithms2.Models;

namespace Algorithms2.Algorithms.BaseClasses
{
    public class UnionFindBase
    {
        protected List<TreeNodeModel<int, int>> tree { get; set; }

        protected int verticesCount;
        protected Dictionary<int,int> count;
        protected Dictionary<int, int> name;
        protected Dictionary<int, int> father;
        protected Dictionary<int, int> root;

        public UnionFindBase(List<TreeNodeModel<int, int>> tree)
        {
            if (tree == null)
            {
                throw new Exception("Drzewo nie istnieje");
            }

            verticesCount = tree.Count;

            count = new Dictionary<int, int>();
            name = new Dictionary<int, int>();
            father = new Dictionary<int, int>();
            root = new Dictionary<int, int>();

            tree.ForEach(node =>
            {
                count.Add(node.Name, 1);
                name.Add(node.Name, node.Name);
                father.Add(node.Name, 0);
                root.Add(node.Name, node.Name);
            });

            this.tree = new List<TreeNodeModel<int, int>>();

            tree.ForEach(node => this.tree.Add(node.Clone() as TreeNodeModel<int, int>));
        }

        protected int Find(int node)
        {
            var list = new List<int>();
            var v = node;

            while (father[v] != 0)
            {
                list.Add(v);
                v = father[v];
            }

            list.ForEach(w => father[w] = v);

            return name[v];
        }

        protected void Union(int node1, int node2)
        {
            if (count[root[node1]] > count[root[node2]])
            {
                var tempNode = node1;
                node1 = node2;
                node2 = tempNode;
            }

            var large = root[node2];
            var small = root[node1];

            father[small] = large;
            count[large] = count[large] + count[small];
            name[large] = node1;
            root[node1] = large;
        }

        protected void Union(int node1, int node2, int nodeName)
        {
            if (count[root[node1]] > count[root[node2]])
            {
                var tempNode = node1;
                node1 = node2;
                node2 = tempNode;
            }

            var large = root[node2];
            var small = root[node1];

            father[small] = large;
            count[large] = count[large] + count[small];
            name[large] = nodeName;
            root[nodeName] = large;
        }

        protected void MakeSet(int vertexName)
        {
            father[vertexName] = 0;
            count[vertexName] = 1;
        }
    }
}