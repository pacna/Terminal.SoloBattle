using System;
using System.Collections.Generic;
using Terminal.SoloBattle.Maps;

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

            DislayLocations();

            Console.WriteLine();

            while (input != "q")
            {
                input = Console.ReadLine();
                (Node location, int positionIndex) location = gameMap.GetNodeByLocationId(input.GetHashCode());
                if (location.location != null)
                {
                    Console.Clear();
                    Console.WriteLine($"You are now in {location.location.LocationName}");
                    Console.WriteLine($"You have {playerDistance} distance");

                    Console.WriteLine("Do you want to attack? (yes or no)");
                    string battleInput = "";

                    while (battleInput != "q")
                    {
                        battleInput = Console.ReadLine();
                        if (battleInput == "yes")
                        {
                            Console.WriteLine(battleInput);
                        }
                    }


                    // Console.WriteLine("something happen");
                    // IDijkstra opponentsDistance = new Dijkstra(graph: gameMap, location.positionIndex);
                    // RunGame(startingPositionIndex: location.positionIndex);
                }
                else if (input == "q")
                {
                    Console.WriteLine("Bye | (• ◡•)| (❍ᴥ❍ʋ)");
                    return;
                }
                else
                {
                    Console.WriteLine();
                    DislayLocations();
                    Console.WriteLine();
                }
            }
        }

        public static void MenuInfo()
        {
            string introHeader = SoloBattleTextArt.IntroHeader();
            Console.WriteLine(introHeader);

            Console.WriteLine();
            Console.WriteLine("Please select a location to start");
            Console.WriteLine();

            gameMap = GameMaps.InitialMap();
            locationNames = gameMap.GetAllLocationNames();
        }

        public static void DislayLocations()
        {
            foreach (var locationName in locationNames)
            {
                Console.WriteLine(locationName);
            }
        }

        public static void RunGame(int startingPositionIndex)
        {
        }
    }
}