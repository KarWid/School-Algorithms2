using System.Collections.Generic;

namespace Algorithms2.Models
{
    public class StronglyCoherentComponent<T>
    {
        public List<Vertex> Vertices { get; set; } = new List<Vertex>();

        public StronglyCoherentComponent()
        {
            Vertices = new List<Vertex>();
        }
    }
}