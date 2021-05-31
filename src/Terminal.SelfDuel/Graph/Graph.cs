using System;

namespace Terminal.SelfDuel
{
    public class Graph
    {
        private Node[] _nodes;

        public Graph(uint numberOfNodes)
        {
            this._nodes = new Node[numberOfNodes];
        }

        public void AddNode(int index, int weight)
        {
            this._nodes[index] = new Node(weight: weight);
        }

        public void AddEdge(int from, Node to, int weight)
        {
            this._nodes[from].Edges.Add(new Edge(to: to, weight: weight));
        }

        public Node[] GetAllNodes()
        {
            return this._nodes;
        }

        public Node GetNode(int index)
        {
            return this._nodes[index];
        }

        public int NumberOfNodes()
        {
            return this._nodes.Length;
        }

        public void PrintGraph()
        {
            foreach (var node in this._nodes)
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