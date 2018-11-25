using System;
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

            var function = new HashFunction(5, 0.05);

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
            var alfa = 0.05;

            var function = new HashFunction(startTableSize, alfa);

            Assert.AreEqual(startTableSize, function.TableCount);

            for (int i = 0; i < 50; i++)
            {
                function.Insert(i);
                function.Insert(rand.Next(50, 200));
            }

            Assert.AreNotEqual(startTableSize, function.TableCount, "Wielkosc tablicy nie ulegla zmianie");
            Assert.AreEqual(128, function.TableCount, "Wielkosc tablicy jest nieodpowiednia z oczekiwaną po dodawaniu elementów");

            for (int i=0; i < 35; i++)
            {
                function.Delete(i);
            }

            Assert.AreEqual(64, function.TableCount, "Wielkosc tablicy jest zla po odejmowaniu elementow");
        }
    }
}