using System;
using Lib;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var bt = new BinaryTree<int>();
            var rand = new Random();
            for (var i = 0; i < 32; i++)
            {
                var v = rand.Next(1, 32);
                bt.Insert(v);
            }
            Console.Write(bt.PrettyPrint());
        }
    }
}
