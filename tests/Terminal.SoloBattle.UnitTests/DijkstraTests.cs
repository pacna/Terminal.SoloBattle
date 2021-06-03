using System;
using Terminal.SoloBattle.Maps;
using Xunit;

namespace Terminal.SoloBattle.UnitTests
{
    public class DijkstraTests
    {
        [Theory]
        [InlineData(0, new[] { 0, 3, 1, 4, 7 }, new[] { "Metal City", "Sky Road", "Splash Canyon", "Ice Factory", "Babylon Garden" })]
        [InlineData(4, new[] { 0, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue }, new[] { "Babylon Garden", "Metal City", "Sky Road", "Splash Canyon", "Ice Factory" })]
        [InlineData(1, new[] { 0, Int32.MaxValue, Int32.MaxValue, 1, 4 }, new[] { "Sky Road", "Metal City", "Splash Canyon", "Ice Factory", "Babylon Garden" })]
        public void ShouldEvaluateDistanceCorrectly(int startingPositionIndex, int[] distance, string[] locationNames)
        {
            // ARRANGE
            IGraph graph = CreateGraph();
            var dijkstra = new Dijkstra(graph, startingPositionIndex);

            // ACT
            var result = dijkstra.GetDistance();

            // ASSERT
            Assert.Equal(result.Count, distance.Length);
            Assert.Equal(result.Count, locationNames.Length);
            Assert.Collection(result,
                nodeDistance =>
                {
                    Assert.Equal(nodeDistance.Distance, distance[0]);
                    Assert.Equal(nodeDistance.Node.LocationName, locationNames[0]);
                },
                nodeDistance =>
                {
                    Assert.Equal(nodeDistance.Distance, distance[1]);
                    Assert.Equal(nodeDistance.Node.LocationName, locationNames[1]);
                },
                nodeDistance =>
                {
                    Assert.Equal(nodeDistance.Distance, distance[2]);
                    Assert.Equal(nodeDistance.Node.LocationName, locationNames[2]);
                },
                nodeDistance =>
                {
                    Assert.Equal(nodeDistance.Distance, distance[3]);
                    Assert.Equal(nodeDistance.Node.LocationName, locationNames[3]);
                },
                nodeDistance =>
                {
                    Assert.Equal(nodeDistance.Distance, distance[4]);
                    Assert.Equal(nodeDistance.Node.LocationName, locationNames[4]);
                }
            );
        }

        [Fact]
        public void ShouldGetAllMonstersDistance()
        {
            // ARRANGE
            IGraph graph = CreateGraph();
            int[] expectedDistance = { 3, 1, 4, 7 };
            string[] expectedLocationNames = { "Sky Road", "Splash Canyon", "Ice Factory", "Babylon Garden" };

            var dijkstra = new Dijkstra(graph, 0);

            // ACT
            var result = dijkstra.GetMonstersDistance();

            // ASSERT
            Assert.Equal(result.Count, expectedDistance.Length);
            Assert.Equal(result.Count, expectedLocationNames.Length);
            Assert.Collection(result,
                nodeDistance =>
                {
                    Assert.Equal(nodeDistance.Distance, expectedDistance[0]);
                    Assert.Equal(nodeDistance.Node.LocationName, expectedLocationNames[0]);
                },
                nodeDistance =>
                {
                    Assert.Equal(nodeDistance.Distance, expectedDistance[1]);
                    Assert.Equal(nodeDistance.Node.LocationName, expectedLocationNames[1]);
                },
                nodeDistance =>
                {
                    Assert.Equal(nodeDistance.Distance, expectedDistance[2]);
                    Assert.Equal(nodeDistance.Node.LocationName, expectedLocationNames[2]);
                },
                nodeDistance =>
                {
                    Assert.Equal(nodeDistance.Distance, expectedDistance[3]);
                    Assert.Equal(nodeDistance.Node.LocationName, expectedLocationNames[3]);
                }
            );
        }

        private IGraph CreateGraph()
        {
            return GameMaps.InitialMap();
        }
    }
}