using System;
using System.Collections.Generic;
using System.Linq;
using Priority_Queue;

namespace Terminal.SelfDuel
{
    public class Dijkstra
    {
        public Dijkstra(Graph graph, int startingNodeIndex)
        {
            this.RunImplementation(graph: graph, startingNodeIndex: startingNodeIndex);
        }

        public IList<NodeDistance> RunImplementation(Graph graph, int startingNodeIndex)
        {
            IList<NodeDistance> distance = new List<NodeDistance>();
            distance[0].Node = graph.Nodes[startingNodeIndex];
            distance[0].Distance = 0;

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

                    if (newDistance < distance[nodePriorityIndex].Distance)
                    {
                        distance[nodePriorityIndex].Distance = newDistance;
                        priorityQueue.UpdatePriority(nodePriorityIndex, newDistance);
                    }

                }
            }

            return distance;
        }
    }
}