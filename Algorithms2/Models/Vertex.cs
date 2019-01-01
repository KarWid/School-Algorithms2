using System;

namespace Algorithms2.Models
{
    public class Vertex : ICloneable
    {
        public int Name { get; set; }
        public bool Visited { get; set; }
        public int EntryTime { get; set; }
        public int ProcessingTime { get; set; }

        // Articulation point
        public int? ParentName { get; set; } = null;
        public bool IsArticulationPoint { get; set; }
        public int LowTime { get; set; }

        public object Clone()
        {
            return new Vertex
            {
                Name = Name,
                Visited = Visited,
                EntryTime = EntryTime,
                ProcessingTime = ProcessingTime,
                LowTime = LowTime,
                ParentName = ParentName,
                IsArticulationPoint = IsArticulationPoint
            };
        }
    }
}