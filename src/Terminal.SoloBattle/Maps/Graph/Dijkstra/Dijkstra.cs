using System;
using System.Collections.Generic;
using System.Linq;
using Priority_Queue;
using Terminal.SoloBattle.Maps.Models;

namespace Terminal.SoloBattle.Maps
{
    public class Dijkstra : IDijkstra
    {
        private IList<NodeDistance> _distance;

        public Dijkstra(IGraph graph, int startingNodeIndex)
        {
            this.RunImplementation(graph: graph, startingNodeIndex: startingNodeIndex);
        }

        private void RunImplementation(IGraph graph, int startingNodeIndex)
        {
            this.RunImplementation(graph: graph, numberOfNodes: graph.NumberOfNodes(), startingNodeIndex: startingNodeIndex);
        }

        private void RunImplementation(IGraph graph, int numberOfNodes, int startingNodeIndex)
        {
            List<NodeDistance> distance = new List<NodeDistance>();
            distance.Add(new NodeDistance
            {
                Node = graph.GetNodeByIndex(index: startingNodeIndex),
                Distance = 0
            });

            SimplePriorityQueue<int> priorityQueue = new SimplePriorityQueue<int>();

            for (var i = 0; i < graph.GetAllNodes().Length; i++)
            {
                if (graph.GetNodeByIndex(index: i).Weight != graph.GetNodeByIndex(index: startingNodeIndex).Weight)
                {
                    distance.Add(new NodeDistance
                    {
                        Node = graph.GetNodeByIndex(index: i),
                        Distance = Int32.MaxValue
                    });
                }

                priorityQueue.Enqueue(i, distance[i].Distance);
            }

            while (priorityQueue.Any())
            {
                int nodeWithHighestPriorityIndex = priorityQueue.Dequeue();
                Node nodeWithHighestPriority = graph.GetNodeByWeight(distance[nodeWithHighestPriorityIndex].Node.Weight);

                foreach (var neighbor in nodeWithHighestPriority.Edges)
                {
                    int newDistance = distance[nodeWithHighestPriorityIndex].Distance + neighbor.Weight;

                    // since the implementation does not end early when finding the shortest distance for each node
                    // we need to skip the nodes that are unreachable.
                    // newDistance will be neg (overflow) if the node is unreachable
                    if (newDistance >= 0)
                    {
                        int neighborIndex = this.GetNeighborNodeIndex(node: neighbor.To, distance: distance);
                        if (newDistance < distance[neighborIndex].Distance)
                        {
                            distance[neighborIndex].Distance = newDistance;
                            priorityQueue.TryUpdatePriority(neighborIndex, newDistance);
                        }
                    }

                }
            }

            this._distance = distance;
        }

        public IList<NodeDistance> GetDistance()
        {
            return this._distance;
        }

        private int GetNeighborNodeIndex(Node node, List<NodeDistance> distance)
        {
            return distance.FindIndex((NodeDistance nodeDistance) =>
            {
                if (nodeDistance.Node.Weight == node.Weight)
                {
                    return true;
                }

                return false;
            });
        }

        #region Solo Battle
        public IList<NodeDistance> GetMonstersDistance()
        {
            return this._distance.Skip(1).ToList();
        }
        #endregion
    }
}