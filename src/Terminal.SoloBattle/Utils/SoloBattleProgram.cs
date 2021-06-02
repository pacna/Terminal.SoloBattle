using System;
using System.Collections.Generic;
using System.Linq;
using Terminal.SoloBattle.Maps;
using Terminal.SoloBattle.Maps.Models;

namespace Terminal.SoloBattle.Utils
{
    public static class SoloBattleProgram
    {
        static int playerDistance = 100;
        static IGraph gameMap;
        static IEnumerable<string> locationNames;

        public static void InitiateGame()
        {
            MenuInfo();

            string input = "";

            while (input != "q")
            {
                DislayLocations();
                Console.WriteLine();
                input = Console.ReadLine();

                (Node location, int positionIndex) location = gameMap.GetNodeByLocationId(input.GetHashCode());
                if (location.location != null)
                {
                    Console.Clear();
                    RunGame(location: location.location, startingPositionIndex: location.positionIndex);

                }
                else if (input == "q")
                {
                    Console.WriteLine("Bye | (• ◡•)| (❍ᴥ❍ʋ)");
                    return;
                }
            }
        }

        public static void MenuInfo()
        {
            SoloBattleTextArt.IntroHeader();

            gameMap = GameMaps.InitialMap();
            locationNames = gameMap.GetAllLocationNames();

            Console.WriteLine();

        }

        public static void DislayLocations()
        {
            Console.WriteLine("Please select a location to start");
            Console.WriteLine();

            foreach (var locationName in locationNames)
            {
                Console.WriteLine(locationName);
            }
        }

        public static void RunGame(Node location, int startingPositionIndex)
        {
            IDijkstra dijkstra = new Dijkstra(graph: gameMap, startingPositionIndex);
            IList<NodeDistance> opponentsDistance = dijkstra.GetOpponentsDistance();

            Console.WriteLine($"You are now in {location.LocationName}");
            Console.WriteLine($"You have {playerDistance} distance");

            string battleInput = "";

            while (battleInput != "exit")
            {
                Console.WriteLine("Do you want to attack? (yes or no)");
                battleInput = Console.ReadLine();

                if (battleInput == "yes")
                {
                    SoloBattleTextArt.DisplayAttack();
                    NodeDistance defeatedOpponent = opponentsDistance[0];
                    opponentsDistance.RemoveAt(0);

                    playerDistance -= defeatedOpponent.Distance;

                    if (playerDistance < 0)
                    {
                        SoloBattleTextArt.GameOverText();
                        return;
                    }

                    if (!opponentsDistance.Any())
                    {
                        SoloBattleTextArt.YouveWonText();
                        return;
                    }

                    Console.WriteLine($"You defeated the opponent in {defeatedOpponent.Node.LocationName}");
                    Console.WriteLine($"You now have {playerDistance}");


                }
                else if (battleInput == "exit")
                {
                    Console.WriteLine("Returning back to menu");
                    return;
                }
                else
                {
                    Console.WriteLine();
                    SoloBattleTextArt.GameOverText();
                    Console.WriteLine();
                    return;
                }
            }
        }
    }
}