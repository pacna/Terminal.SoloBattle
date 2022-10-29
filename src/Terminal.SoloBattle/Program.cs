using System;
using Terminal.SoloBattle.Maps;
using Terminal.SoloBattle.Maps.Models;
using Terminal.SoloBattle.Utils;

namespace Terminal.SoloBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            SoloBattleProgram.InitiateGame();
        }

        static void DebugProgram()
        {
            IGraph initialMap = GameMaps.InitialMap();

            IDijkstra dj = new Dijkstra(graph: initialMap, startingNodeIndex: 0);

            foreach (NodeDistance r in dj.GetDistance())
            {
                Console.WriteLine($"NODE {r.Node.Weight} \t LOCATION NAME {r.Node.LocationName} \t DISTANCE {r.Distance} ");
            }
        }
    }
}
