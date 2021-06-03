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
                Console.WriteLine("Press q to quit");
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
            IList<NodeDistance> monstersDistance = dijkstra.GetMonstersDistance();

            Console.WriteLine($"You are now in {location.LocationName}");
            Console.WriteLine($"You have {playerDistance} distance");
            Console.WriteLine("Press e to exit the game");

            string battleInput = "";

            while (battleInput != "e")
            {
                Console.WriteLine("Do you want to attack? (yes or no)");
                battleInput = Console.ReadLine();

                if (battleInput == "yes")
                {
                    SoloBattleTextArt.DisplayAttack();
                    NodeDistance defeatedMonster = monstersDistance[0];
                    monstersDistance.RemoveAt(0);

                    playerDistance -= defeatedMonster.Distance;

                    if (playerDistance < 0)
                    {
                        SoloBattleTextArt.GameOverText();
                        return;
                    }

                    if (!monstersDistance.Any())
                    {
                        playerDistance = 100;
                        SoloBattleTextArt.YouveWonText();
                        return;
                    }

                    Console.WriteLine($"You've defeated the monster in {defeatedMonster.Node.LocationName}");
                    Console.WriteLine($"You now have {playerDistance}");


                }
                else if (battleInput == "e")
                {
                    Console.WriteLine("Returning back to menu");
                    return;
                }
                else
                {
                    playerDistance = 100;
                    Console.WriteLine();
                    SoloBattleTextArt.GameOverText();
                    Console.WriteLine();
                    return;
                }
            }
        }
    }
}