using System;
using Lib;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var bt = new BinaryTree<char>();
            var rand = new Random();
            for (var i = 0; i < 20; i++)
            {
                var v = (char)('a' + rand.Next(0, 10));
                bt.Insert(v);
            }
            const int elementWidth = 2;
            Console.Write(bt.PrettyPrint("", "", elementWidth));
        }
        
    }
}
