using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms2.Algorithms;

namespace AlgorithmsTest
{
    /// <summary>
    /// Summary description for HashFunction
    /// </summary>
    [TestClass]
    public class HashFunctionTest
    {
        // sprawdzenie podstawowych funkcjonalnosci
        [TestMethod]
        public void Scenario1()
        {
            int testValue = 1;

            var function = new HashFunction(5);

            var addingResult = function.Insert(testValue);

            Assert.IsTrue(addingResult);

            var memberResult = function.Member(testValue);

            Assert.IsTrue(memberResult);

            var removeResult = function.Delete(testValue);

            Assert.IsTrue(memberResult);

            var memberResult2 = function.Member(testValue);

            Assert.IsFalse(memberResult2);
        }

        // sprawdzenie czy tablica zmienia swoja wielkosc
        [TestMethod]
        public void Scenario2()
        {
            var rand = new Random();
            var startTableSize = 4;

            var function = new HashFunction(startTableSize);

            Assert.AreEqual(startTableSize, function.TableCount);

            for (int i = 0; i < 100; i++)
            {
                function.Insert(rand.Next(0, 200));
            }

            Assert.AreNotEqual(startTableSize, function.TableCount, "Wielkosc tablicy nie ulegla zmianie");
        }
    }
}
