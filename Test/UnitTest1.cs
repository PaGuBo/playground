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
            bt.Insert(100);

            bt.Insert(50);
            bt.Insert(150);

            bt.Insert(25);
            bt.Insert(75);
            bt.Insert(125);
            bt.Insert(175);

            bt.Insert(32);
            bt.Insert(18);
            bt.Insert(82);
            bt.Insert(68);
            bt.Insert(132);
            bt.Insert(118);
            bt.Insert(182);
            bt.Insert(168);


            bt.Insert(15);
            bt.Insert(21);
            bt.Insert(29);
            bt.Insert(35);
            bt.Insert(65);
            bt.Insert(71);
            bt.Insert(79);
            bt.Insert(84);
            bt.Insert(115);
            bt.Insert(121);
            bt.Insert(129);
            bt.Insert(135);
            bt.Insert(165);
            bt.Insert(171);
            bt.Insert(179);
            bt.Insert(185);


            var pp = bt.PrettyPrint();

        }
    }
}
