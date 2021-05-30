﻿using System;
using System.Collections.Generic;

namespace Terminal.SelfDuel
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(5);
            graph.AddNode(index: 0, weight: 0);
            graph.AddNode(index: 1, weight: 1);
            graph.AddNode(index: 2, weight: 2);
            graph.AddNode(index: 3, weight: 3);
            graph.AddNode(index: 4, weight: 4);
            graph.AddEdge(index: 0, to: new Node(1), weight: 4);
            graph.AddEdge(index: 0, to: new Node(2), weight: 1);
            graph.AddEdge(index: 1, to: new Node(3), weight: 1);
            graph.AddEdge(index: 2, to: new Node(1), weight: 2);
            graph.AddEdge(index: 2, to: new Node(3), weight: 5);
            graph.AddEdge(index: 3, to: new Node(4), weight: 3);

            Dijkstra dj = new Dijkstra();
            IList<NodeDistance> result = dj.RunImplementation(graph: graph, startingNodeIndex: 0);

            foreach (var r in result)
            {
                Console.WriteLine($" RESULT DISTANCE {r.Distance} NODE {r.Node.Weight}");
            }
        }
    }
}
