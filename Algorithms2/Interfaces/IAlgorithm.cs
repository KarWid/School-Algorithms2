using System;
using System.Threading.Tasks;

namespace Algorithms2.Interfaces
{
    public interface IAlgorithm
    {
        Task Start();
        void ShowResult();
        TimeSpan LastActionTime { get; }
    }
}
