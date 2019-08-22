using System;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DoesEmptyTreeReturnSizeZero()
        {
            var bt = new BinaryTree<int>();
            Assert.AreEqual(0, bt.Size);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(10)]
        [DataRow(100)]
        [DataRow(1000)]
        [DataRow(10000)]
        [DataRow(100000)]
        public void IsTreeSizeCorrect(int size)
        {
            var bt = new BinaryTree<int>();
            var rand = new Random();
            for (var i = 0; i < size; i++)
            {
                var v = rand.Next(1, 1000000);
                Console.WriteLine($"Inserting {v}");
                bt.Insert(v);
            }

            Assert.AreEqual(size, bt.Size);
        }
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(10)]
        [DataRow(100)]
        public void IsTreeDepthCorrect(int size)
        {
            var bt = new BinaryTree<int>();
            for (var i = 0; i < size; i++)
            {
                var v = i;
                bt.Insert(v);
            }

            Assert.AreEqual(size, bt.Depth);
        }

        [TestMethod]
        public void IsBreadthFirstTraversalCorrect()
        {
            var bt = new BinaryTree<int>();
            bt.Insert(10);

            bt.Insert(20);

            bt.Insert(5);

            bt.Insert(15);
            bt.Insert(25);
            bt.Insert(8);
            bt.Insert(3);

            var x = bt.BreadthFirstList();
            Assert.AreEqual(x[0], 10);
        }

        [TestMethod]
        public void CanPrettyPrettyPrint()
        {
            var bt = new BinaryTree<int>();
            bt.Insert(10);

            bt.Insert(20);

            bt.Insert(5);

            bt.Insert(15);
            bt.Insert(25);
            bt.Insert(8);
            bt.Insert(3);

            bt.Insert(1);
            bt.Insert(4);
            bt.Insert(50);
            bt.Insert(100);

            var pp = bt.PrettyPrint();
        }
    }
}
