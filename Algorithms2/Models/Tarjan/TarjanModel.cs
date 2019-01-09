using System.Collections.Generic;

namespace Algorithms2.Models.Tarjan
{
    public class TarjanModel
    {
        public TarjanTreeModel Tree { get; set; }
        public List<TarjanVertexPairTarget> Target { get; set; }
    }

    public class TarjanVertexPairTarget
    {
        public TarjanNodeModel Vertex1 { get; set; }
        public TarjanNodeModel Vertex2 { get; set; }
    }
}