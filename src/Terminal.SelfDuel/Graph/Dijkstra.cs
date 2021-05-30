using System;
using System.Collections.Generic;
using System.Linq;
using Priority_Queue;

namespace Terminal.SelfDuel
{
    public class Dijkstra
    {
        public Dijkstra()
        {

        }

        public IList<NodeDistance> RunImplementation(Graph graph, int startingNodeIndex)
        {
            IList<NodeDistance> distance = new List<NodeDistance>();
            distance.Add(new NodeDistance
            {
                Node = graph.Nodes[startingNodeIndex],
                Distance = 0
            });

            SimplePriorityQueue<int> priorityQueue = new SimplePriorityQueue<int>();

            for (var i = 0; i < graph.Nodes.Length; i++)
            {
                if (i != startingNodeIndex)
                {
                    distance.Add(new NodeDistance
                    {
                        Node = graph.Nodes[i],
                        Distance = Int32.MaxValue
                    });
                }

                priorityQueue.Enqueue(i, distance[i].Distance);

            }

            while (priorityQueue.Any())
            {
                int nodePriorityIndex = priorityQueue.Dequeue();
                Node nodeWithHighestPriority = graph.Nodes[nodePriorityIndex];

                foreach (var neighbor in nodeWithHighestPriority.Edges)
                {
                    int newDistance = neighbor.Weight + distance[nodePriorityIndex].Distance;

                    int nodeIndex = this.GetNodeIndex(node: neighbor.To, distance: distance);
                    if (newDistance < distance[nodeIndex].Distance)
                    {
                        distance[nodeIndex].Distance = newDistance;
                        priorityQueue.UpdatePriority(nodeIndex, newDistance);
                    }

                }
            }

            return distance;
        }

        public int GetNodeIndex(Node node, IList<NodeDistance> distance)
        {

            for (var i = 0; i < distance.Count; i++)
            {
                if (distance[i].Node.Weight == node.Weight)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}