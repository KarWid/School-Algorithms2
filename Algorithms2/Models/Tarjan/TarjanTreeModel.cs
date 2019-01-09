using System.Collections.Generic;

namespace Algorithms2.Models.Tarjan
{
    public class TarjanTreeModel
    {
        public TarjanNodeModel Root { get; set; }
        public List<TarjanNodeModel> Vertices;

        public TarjanTreeModel()
        {
            Vertices = new List<TarjanNodeModel>();
        }
    }
}