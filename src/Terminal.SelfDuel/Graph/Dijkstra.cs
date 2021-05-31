using System;
using System.Collections.Generic;
using System.Linq;
using Priority_Queue;

namespace Terminal.SelfDuel
{
    public class Dijkstra
    {
        private IList<NodeDistance> _distance;

        public Dijkstra(Graph graph, int startingNodeIndex)
        {
            this.RunImplementation(graph: graph, startingNodeIndex: startingNodeIndex);
        }

        public void RunImplementation(Graph graph, int startingNodeIndex)
        {
            this.RunImplementation(graph: graph, numberOfNodes: graph.NumberOfNodes(), startingNodeIndex: startingNodeIndex);
        }

        public void RunImplementation(Graph graph, int numberOfNodes, int startingNodeIndex)
        {
            NodeDistance[] distance = new NodeDistance[numberOfNodes];
            distance[0] = new NodeDistance
            {
                Node = graph.GetNode(startingNodeIndex),
                Distance = 0
            };

            SimplePriorityQueue<int> priorityQueue = new SimplePriorityQueue<int>();

            for (var i = 0; i < graph.GetAllNodes().Length; i++)
            {
                if (i != startingNodeIndex)
                {
                    distance[i] = new NodeDistance
                    {
                        Node = graph.GetNode(i),
                        Distance = Int32.MaxValue
                    };
                }

                priorityQueue.Enqueue(i, distance[i].Distance);

            }

            while (priorityQueue.Any())
            {
                int nodeWithHighestPriorityIndex = priorityQueue.Dequeue();
                Node nodeWithHighestPriority = graph.GetNode(nodeWithHighestPriorityIndex);

                foreach (var neighbor in nodeWithHighestPriority.Edges)
                {
                    int newDistance = neighbor.Weight + distance[nodeWithHighestPriorityIndex].Distance;

                    int neighborIndex = this.GetNeighborNodeIndex(node: neighbor.To, distance: distance);
                    if (newDistance < distance[neighborIndex].Distance)
                    {
                        distance[neighborIndex].Distance = newDistance;
                        priorityQueue.UpdatePriority(neighborIndex, newDistance);
                    }

                }
            }

            this._distance = distance;
        }

        public IList<NodeDistance> GetDistance()
        {
            return this._distance;
        }

        private int GetNeighborNodeIndex(Node node, NodeDistance[] distance)
        {
            return Array.FindIndex(distance, (NodeDistance nodeDistance) =>
            {
                if (nodeDistance.Node.Weight == node.Weight)
                {
                    return true;
                }

                return false;
            });
        }
    }
}