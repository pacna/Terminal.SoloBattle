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
            IList<NodeDistance> distance = new List<NodeDistance>();
            distance.Add(new NodeDistance
            {
                Node = graph.GetNode(startingNodeIndex),
                Distance = 0
            });

            SimplePriorityQueue<int> priorityQueue = new SimplePriorityQueue<int>();

            for (var i = 0; i < graph.GetAllNodes().Length; i++)
            {
                if (i != startingNodeIndex)
                {
                    distance.Add(new NodeDistance
                    {
                        Node = graph.GetNode(i),
                        Distance = Int32.MaxValue
                    });
                }

                priorityQueue.Enqueue(i, distance[i].Distance);

            }

            while (priorityQueue.Any())
            {
                int nodePriorityIndex = priorityQueue.Dequeue();
                Node nodeWithHighestPriority = graph.GetNode(nodePriorityIndex);

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

            this._distance = distance;
        }

        public IList<NodeDistance> GetDistance()
        {
            return this._distance;
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