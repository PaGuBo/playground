using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Lib
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        private TreeNode<T> Root { get; set; }

        public int Size => GetSize(Root, 0);
        public int Depth => GetDepth(Root, 0);

        public void Insert(T value)
        {
            if (Root == null)
            {
                Root = new TreeNode<T>(value);
            }
            else
            {
                Insert(value, Root);
            }
        }

        public List<T> BreadthFirstList()
        {
            var breadthFirstList = new List<T>();

            var queue = new Queue<TreeNode<T>>();
            if (Root != null)
            {
                queue.Enqueue(Root);
            }

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                breadthFirstList.Add(node.Value);
                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
            return breadthFirstList;
        }

        public string PrettyPrint()
        {
            var dict = new Dictionary<int, List<string>>();

            var queue = new Queue<Tuple<int, TreeNode<T>>>();
            if (Root != null)
            {
                queue.Enqueue(Tuple.Create(0, Root));
                dict.Add(0, new List<string>());
                dict[0].Add(Root.Value.ToString());
            }

            var treeDepth = Depth;
            while (queue.Count > 0)
            {
                var (level, node) = queue.Dequeue();

                var nextLevel = level + 1;
                if (nextLevel > treeDepth)
                {
                    break;
                }
                //make sure that a string list exists at this level
                if (!dict.ContainsKey(nextLevel))
                {
                    dict.Add(nextLevel, new List<string>());
                }

                if (node.Left != null)
                {
                    queue.Enqueue(Tuple.Create(level + 1, node.Left));
                    dict[nextLevel].Add(node.Left.Value.ToString());
                }
                else
                {
                    queue.Enqueue(Tuple.Create(level + 1, new TreeNode<T>()));
                    dict[nextLevel].Add(null);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(Tuple.Create(level + 1, node.Right));
                    dict[nextLevel].Add(node.Right.Value.ToString());
                }
                else
                {
                    queue.Enqueue(Tuple.Create(level + 1, new TreeNode<T>()));
                    dict[nextLevel].Add(null);
                }
            }
            //final level will always be full of nulls, so let's remove it, and set the real last level
            var lastLevel = dict.Keys.Max();
            dict.Remove(lastLevel);
            lastLevel--;

            const string elementPrefix = "  [";
            const string elementSuffix = "]  ";
            const int elementWidth = 6;  //keep this an even number
            var totalElementWidth = elementPrefix.Length + elementSuffix.Length + elementWidth;

            var sb = new StringBuilder();
            var emptyStr = new string(' ', totalElementWidth);
            var arrowPadding = new string(' ', (totalElementWidth - 2) / 2);
            var leftNodeArrow = $"{arrowPadding}//{arrowPadding}";
            var rightNodeArrow = $"{arrowPadding}\\\\{arrowPadding}";
            foreach (var treeLevel in dict.Keys)
            {
                var treeLevelVals = dict[treeLevel];

                //figure out how much padding is needed around the element for proper alignment
                var levelsBelow = lastLevel - treeLevel;
                var elementsAtLowestLevel = Math.Pow(2, levelsBelow);
                var stringLengthOfAllLowestElements = elementsAtLowestLevel * totalElementWidth; 
                var paddingLength = (stringLengthOfAllLowestElements - totalElementWidth) / 2;
                var padding = new string(' ', Convert.ToInt32(paddingLength));

                var elementsString = new StringBuilder();
                var branchesString = new StringBuilder();
                for (var i = 0; i < treeLevelVals.Count; i++)
                {
                    var val = treeLevelVals[i];
                    string valueString, arrowString;
                    if (val != null)
                    {
                        valueString = $"{elementPrefix}{val,elementWidth}{elementSuffix}";
                        arrowString = i % 2 != 0 ? rightNodeArrow : leftNodeArrow;
                    }
                    else
                    {
                        valueString = emptyStr;
                        arrowString = emptyStr;
                    }

                    branchesString.Append($"{padding}{arrowString}{padding}");
                    elementsString.Append($"{padding}{valueString}{padding}");
                }

                if (treeLevel != 0)
                {
                    sb.AppendLine(branchesString.ToString());
                }
                sb.AppendLine(elementsString.ToString());
            }
            return sb.ToString();
        }

        private static void Insert(T value, TreeNode<T> currentNode)
        {
            while (true)
            {
                if (currentNode == null)
                {
                    throw new Exception("Trying to insert into a null node. Should never happen");
                }

                if (currentNode.Value.CompareTo(value) >= 0)
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = new TreeNode<T>(value);
                    }
                    else
                    {
                        currentNode = currentNode.Left;
                        continue;
                    }
                }
                else
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = new TreeNode<T>(value);
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                        continue;
                    }
                }

                break;
            }
        }

        private static int GetSize(TreeNode<T> currentNode, int currentLength)
        {
            return currentNode == null ?
                currentLength :
                1 + GetSize(currentNode.Left, currentLength) + GetSize(currentNode.Right, currentLength);
        }

        private static int GetDepth(TreeNode<T> currentNode, int currentDepth)
        {
            return currentNode == null ?
                currentDepth :
                Math.Max(GetDepth(currentNode.Left, currentDepth + 1), GetDepth(currentNode.Right, currentDepth + 1));
        }
    }
}
