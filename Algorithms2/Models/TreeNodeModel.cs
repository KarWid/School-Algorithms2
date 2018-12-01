using System;
using System.Collections.Generic;

namespace Algorithms2.Models
{
    public class TreeNodeModel<NameType, WeightType> : ICloneable
    {
        public NameType Name { get; }
        public List<TreeNeighbourNode<NameType, WeightType>> Neighbours { get; set; }

        public TreeNodeModel(NameType name, List<TreeNeighbourNode<NameType, WeightType>> neighbours)
        {
            Name = name;
            Neighbours = neighbours != null ? neighbours : new List<TreeNeighbourNode<NameType, WeightType>>();
        }

        public object Clone()
        {
            List<TreeNeighbourNode<NameType, WeightType>> newNeigbours = new List<TreeNeighbourNode<NameType, WeightType>>();

            Neighbours.ForEach(neighbour => newNeigbours.Add(neighbour.Clone() as TreeNeighbourNode<NameType, WeightType>));

            return new TreeNodeModel<NameType, WeightType>(Name, newNeigbours);
        }
    }

    public class TreeNeighbourNode<NameType, WeightType> : ICloneable
    {
        public NameType Name { get; set; }
        public WeightType Weight { get; set; }

        public object Clone()
        {
            return new TreeNeighbourNode<NameType, WeightType> { Name = Name, Weight = Weight };
        }
    }

}