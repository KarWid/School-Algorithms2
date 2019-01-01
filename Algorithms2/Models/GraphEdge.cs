using System;

namespace Algorithms2.Models
{
    public class GraphEdge : ICloneable
    {
        public int Node1 { get; set; }
        public int Node2 { get; set; }
        public int Weight { get; set; }
        public bool IsVisited { get; set; }
        public bool IsBridge { get; set; }

        public object Clone()
        {
            return new GraphEdge
            {
                Node1 = Node1,
                Node2 = Node2,
                Weight = Weight,
                IsVisited = IsVisited,
                IsBridge = IsBridge
            };
        }
    }
}