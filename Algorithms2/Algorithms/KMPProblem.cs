using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Algorithms2.Forms;
using Algorithms2.Interfaces;

namespace Algorithms2.Algorithms
{
    public class KMPProblem : IAlgorithm
    {
        private Stopwatch _stopwatch;

        public TimeSpan LastActionTime { get; set; }

        public KMPProblem()
        {
            _stopwatch = new Stopwatch();
        }

        public void ShowResult()
        {
            var form = new KMPForm(this);
            form.Show();
        }

        public async Task Start()
        {
            await Task.Run(() =>
            {
                LastActionTime = TimeSpan.FromMilliseconds(0);
            });
        }

        public List<int> LookForPattern(string pattern, string mainText)
        {
            var result = new List<int>();

            var computedPrefixes = ComputePrefix(pattern);
            int k = 0;

            for (int i = 0; i < mainText.Length; i++)
            {
                while (k > 0 && pattern[k] != mainText[i])
                {
                    k = computedPrefixes[k];
                }

                if (pattern[k] == mainText[i])
                {
                    k = k + 1;
                }

                if (k == pattern.Length)
                {
                    result.Add(i - pattern.Length + 1);
                    k = computedPrefixes[k];
                }
            }

            return result;
        }

        private int[] ComputePrefix(string pattern)
        {
            int[] result = new int[pattern.Length + 1];
            result[0] = 0;

            int k = 0;

            for (int q = 1; q < pattern.Length; q++)
            {
                while (k > 0 && pattern[k] != pattern[q])
                {
                    k = result[k];
                }

                if (pattern[k] == pattern[q])
                {
                    k++;
                }

                result[q] = k;
            }

            return result;
        }
    }
}