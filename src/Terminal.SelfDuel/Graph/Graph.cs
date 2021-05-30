using System;

namespace Terminal.SelfDuel
{
    public class Graph
    {
        public Graph(uint numberOfNodes)
        {
            Nodes = new Node[numberOfNodes];
        }

        public Node[] Nodes { get; set; }

        public void AddNode(int index, int weight)
        {
            this.Nodes[index] = new Node(weight: weight);
        }

        public void AddEdge(int index, Node to, int weight)
        {
            this.Nodes[index].Edges.Add(new Edge(to: to, weight: weight));
        }

        public void PrintGraph()
        {
            foreach (var node in Nodes)
            {
                Console.Write($"Node {node.Weight}");

                foreach (var edge in node.Edges)
                {
                    Console.Write($"--> Node {edge.To.Weight} w/ Edge {edge.Weight}");
                }

                Console.WriteLine();
            }
        }
    }
}