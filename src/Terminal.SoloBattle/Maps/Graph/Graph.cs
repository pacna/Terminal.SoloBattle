using System;
using System.Collections.Generic;
using System.Linq;

namespace Terminal.SoloBattle.Maps
{
    public class Graph : IGraph
    {
        private Node[] _nodes;

        public Graph(uint numberOfNodes)
        {
            this._nodes = new Node[numberOfNodes];
        }

        public void AddNode(int index, int weight, string locationName)
        {
            this._nodes[index] = new Node(weight: weight, locationName: locationName);
        }

        public void AddEdge(int fromIndex, Node to, int weight)
        {
            this._nodes[fromIndex].Edges.Add(new Edge(to: to, weight: weight));
        }

        public Node[] GetAllNodes()
        {
            return this._nodes;
        }

        public Node GetNodeByIndex(int index)
        {
            return this._nodes[index];
        }

        public Node GetNodeByWeight(int weight)
        {
            return Array.Find(this._nodes, (Node node) =>
            {
                if (node.Weight == weight)
                {
                    return true;
                }

                return false;
            });
        }

        public int NumberOfNodes()
        {
            return this._nodes.Length;
        }

        #region Solo Battle
        public (Node, int) GetNodeByLocationId(int locationId)
        {
            for (int i = 0; i < this._nodes.Length; i++)
            {
                if (this._nodes[i].LocationId == locationId)
                {
                    return (this._nodes[i], i);
                }
            }

            return (null, -1);
        }

        public IEnumerable<string> GetAllLocationNames()
        {
            return this._nodes.Select(x => x.LocationName);
        }
        #endregion

        #region DEBUG
        public void PrintGraph()
        {
            foreach (Node node in this._nodes)
            {
                Console.Write($"Node {node.Weight}");

                foreach (Edge edge in node.Edges)
                {
                    Console.Write($" --> Node {edge.To.Weight} ({node.Weight} {edge.To.Weight}) Edge {edge.Weight}");
                }

                Console.WriteLine();
            }
        }
        #endregion
    }
}