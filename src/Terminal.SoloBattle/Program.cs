using System;
using System.Collections.Generic;
using Terminal.SoloBattle.Maps;

namespace Terminal.SoloBattle
{
    class Program
    {
        static void Main(string[] args)
        {

            IGraph initialMap = GameMaps.InitialMap();

            IDijkstra dj = new Dijkstra(graph: initialMap, startingNodeIndex: 0);

            // graph.PrintGraph();
            foreach (var r in dj.GetDistance())
            {
                Console.WriteLine($" RESULT DISTANCE {r.Distance} NODE {r.Node.Weight}");
            }
        }
    }
}
