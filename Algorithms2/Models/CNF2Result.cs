using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms2.Models
{
    public class CNF2Result
    {
        public List<StronglyCoherentComponent<int>> StronglyCoherentComponents { get; set; } = new List<StronglyCoherentComponent<int>>();
        public bool IsValidResult { get; set; } = true;
    }
}