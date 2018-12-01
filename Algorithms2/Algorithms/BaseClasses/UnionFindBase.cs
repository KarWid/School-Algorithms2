using System;
using System.Collections.Generic;
using Algorithms2.Models;

namespace Algorithms2.Algorithms.BaseClasses
{
    public class UnionFindBase
    {
        protected List<TreeNodeModel<int, int>> tree { get; set; }

        protected int verticesCount;
        protected int[] count;
        protected int[] name;
        protected int[] father;
        protected int[] root;

        public UnionFindBase(List<TreeNodeModel<int, int>> tree)
        {
            if (tree == null)
            {
                throw new Exception("Drzewo nie istnieje");
            }

            verticesCount = tree.Count;

            count = new int[verticesCount];
            name = new int[verticesCount];
            father = new int[verticesCount];
            root = new int[verticesCount];

            for (int i=0; i < verticesCount; i++)
            {
                count[i] = 1;
                name[i] = tree[i].Name;
                father[i] = 0;
                root[i] = i;
            }

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
    }
}