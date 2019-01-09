using System.Collections.Generic;
using System.Drawing;

namespace Algorithms2.Models.Tarjan
{
    public class TarjanNodeModel
    {
        public int Name { get; set; }
        public int Count { get; set; }

        public Color Color { get; set; }

        public TarjanNodeModel Root { get; set; }
        public TarjanNodeModel Father { get; set; } = null;
        public TarjanNodeModel Ancestor { get; set; }
        public List<TarjanNodeModel> Children { get; set; }

        public TarjanNodeModel()
        {
            Children = new List<TarjanNodeModel>();
            Root = this;
        }
    }
}