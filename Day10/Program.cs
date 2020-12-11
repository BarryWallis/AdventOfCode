using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Day10
{
    class Program
    {
        private class Node : IEquatable<Node>
        {
            public int Value { get; }
            public LinkedList<Node> Nodes { get; set; } = new();

            private Node(int value, LinkedList<Node> nodes)
            {
                Value = value;
                Nodes = nodes;
                NodeSet.Add(this);
            }

            private Node(int value) : this(value, new())
            {
                Value = value;
            }

            public static Node Create(int value) => NodeSet.Contains(new Node(value))
                                                    ? NodeSet.First(n => n.Value == value)
                                                    : new Node(value);

            public bool Equals(Node other) => other is not null && Value == other.Value;

            public override bool Equals(object obj)
            {
                return Equals(obj as Node);
            }

            public override int GetHashCode() => Value.GetHashCode();
        }

        private static readonly ISet<Node> NodeSet = new HashSet<Node>();
        private static readonly List<int> adapters = new();

        static void Main(string[] args)
        {
            adapters.Add(0);
            adapters.InsertRange(1, new StreamReader(args[0]).ReadToEnd()
                                                      .Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries)
                                                      .Select(s => int.Parse(s)));
            adapters.Sort();
            adapters.Add(adapters[^1] + 3);
            BuildGraph();
            long solutions = WalkGraph();
            Console.WriteLine(solutions);
        }



        private static long WalkGraph()
        {
            int[] tribonacci = { 0, 1, 1, 2, 4, 7, 13, 24, 44 };
            long result = 1L;
            int currentJoltage = 0;
            int count = 1;
            foreach (Node node in NodeSet)
            {
                int nextJoltage = node.Value;
                if (currentJoltage + 1 == nextJoltage)
                {
                    count += 1;
                }
                else
                {
                    result *= tribonacci[count];
                    count = 1;
                }
                currentJoltage = nextJoltage;
            }

            return result;
        }

        private static void BuildGraph()
        {
            for (int i = 0; i < adapters.Count; i++)
            {
                Node node = Node.Create(adapters[i]);
                for (int j = i + 1; j < adapters.Count && adapters[j] - adapters[i] <= 3; j++)
                {
                    node.Nodes.AddLast(Node.Create(adapters[j]));
                }
            }
        }

        private static void CountOfOnesAndThrees(List<int> adapters, out int ones, out int threes)
        {
            ones = 0;
            threes = 0;
            int other = 0;
            for (int i = 1; i < adapters.Count; i++)
            {
                switch (adapters[i] - adapters[i - 1])
                {
                    case 1:
                        ones += 1;
                        break;
                    case 3:
                        threes += 1;
                        break;
                    default:
                        Debug.Fail($"Found {other} joltage differences of other.");
                        break;
                }
            }
        }
    }
}
