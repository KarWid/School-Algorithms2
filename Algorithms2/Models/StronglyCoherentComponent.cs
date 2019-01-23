using System.Collections.Generic;

namespace Algorithms2.Models
{
    public class StronglyCoherentComponent<T>
    {
        public List<Vertex> Vertices { get; set; } = new List<Vertex>();
        public List<StronglyCoherentComponent<T>> Neighbours { get; set; } = new List<StronglyCoherentComponent<T>>();
        public int ProcessingTime { get; set; }
        public int LogicValue { get; set; } = -1;

        public bool IsValid()
        {
            int oppositeName = 0; 

            for (int i=0; i < Vertices.Count; i++)
            {
                oppositeName = Vertices[i].Name * (-1);

                for (int j=i + 1; j < Vertices.Count; j++)
                {
                    if (oppositeName == Vertices[j].Name)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override string ToString()
        {
            var result = "Silnie spójna składowa:\n";
            
            for (int i = 0; i < Vertices.Count; i++)
            {
                result += Vertices[i].Name + " ";
                if (i < Vertices.Count - 1)
                {
                    result += ": ";
                }
            }

            result += "\nSąsiedzi:\n";

            Neighbours.ForEach(n => result += n.ToString());

            return result;
        }
    }
}