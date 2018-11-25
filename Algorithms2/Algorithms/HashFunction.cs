using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Algorithms2.Forms;
using Algorithms2.Interfaces;

namespace Algorithms2.Algorithms
{
    public class HashFunction : IAlgorithm
    {
        private Stopwatch stopwatch;
        private List<List<int>> table;
        private int tableCounter;
        private int tableSize;
        private double alfa; // wspolczynnik ktory brany jest pod uwage, gdy tablica powinna byc zwiekszona/zmniejszona

        public TimeSpan LastActionTime { get; private set; }

        public int TableCount
        {
            get
            {
                return table.Count;
            }
            private set { }
        }

        public HashFunction(int tableSize, double alfa)
        {
            if (alfa < 0 || alfa > 1)
            {
                throw new Exception("Nieprawidlowy wspolczynnik");
            }

            this.alfa = alfa;

            stopwatch = new Stopwatch();

            table = new List<List<int>>();

            for (int i=0; i < tableSize; i++)
            {
                var list = new List<int>();
                table.Add(list);
            }

            tableCounter = 0;

            this.tableSize = tableSize;
        }

        public async Task Start()
        {
            await Task.Run(() =>
            {
                LastActionTime = TimeSpan.FromMilliseconds(0);
            });
        }

        public void ShowResult()
        {
            var form = new HashFunctionForm(this);
            form.Show();
        }

        public bool Member(int value)
        {
            var index = Function(value, tableSize);

            if (index >= table.Count)
            {
                return false;
            }

            return this.table[index].Contains(value);
        }

        public bool Insert(int value)
        {
            // dodac powiekszanie tablicy

            var index = Function(value, tableSize);

            if (index >= table.Count)
            {
                return false;
            }

            if (table[index].Contains(value))
            {
                return false;
            }

            table[index].Add(value);
            tableCounter++;

            if (tableCounter >= (1 + alfa) * tableSize)
            {
                RebuildTable(true);
            }

            return true;
        }

        public bool Delete(int value)
        {
            // dodac zmniejszanie tablicy

            var index = Function(value, tableSize);

            if (index >= table.Count)
            {
                return false;
            }

            if (!table[index].Contains(value))
            {
                return false;
            }

            table[index].Remove(value);
            tableCounter--;

            if (tableCounter <= ((1 + alfa) * tableSize / 2))
            {
                RebuildTable(false);
            }

            return true;
        }

        // funkcja zwracająca indeks w tablicy, gdzie znajduje sie element podany w argumencie
        private int Function(int value, int tableSize)
        {
            int result = 0;

            result = value % tableSize;

            return result;
        }

        private void RebuildTable(bool increase)
        {
            var newTable = new List<List<int>>();

            var oldTable = this.table;
            var oldTableSize = this.tableSize;

            var newTableSize = increase ? 2 * oldTableSize : oldTableSize / 2;
            
            for(int i=0; i < newTableSize; i++)
            {
                newTable.Add(new List<int>());
            }
            
            foreach (var list in oldTable)
            {
                foreach (var element in list)
                {
                    var newIndex = Function(element, newTableSize);
                    newTable[newIndex].Add(element);
                }
            }

            this.table = newTable;
            this.tableSize = newTableSize;
        }
    }
}
