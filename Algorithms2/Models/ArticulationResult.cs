using System.Collections.Generic;

namespace Algorithms2.Models
{
    public class ArticulationResult
    {
        public List<GraphEdge> Bridges { get; set; }
        public List<Vertex> ArticulationPoints { get; set; }
        public List<GraphEdge> GraphEdges { get; set; }
        public List<Vertex> GraphVertices { get; set; }
    }
}