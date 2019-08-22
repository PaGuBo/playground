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
            for (var i = 0; i < 16; i++)
            {
                var v = rand.Next(1, 99);
                Console.WriteLine($"Inserting {v}");
                bt.Insert(v);
            }
            Console.Write(bt.PrettyPrint());
        }
    }
}
