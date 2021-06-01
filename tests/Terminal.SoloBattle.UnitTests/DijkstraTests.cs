using System;
using Terminal.SoloBattle.Maps;
using Xunit;

namespace Terminal.SoloBattle.UnitTests
{
    public class DijkstraTests
    {
        [Theory]
        [InlineData(0, 0, 3, 1, 4, 7)]// startingPosition = 0, distance = [0, 3, 1, 4, 7] 
        [InlineData(4, 0, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue)]
        [InlineData(1, 0, Int32.MaxValue, Int32.MaxValue, 1, 4)]
        public void ShouldEvaluateDistanceCorrectly(int startingPositionIndex, params int[] distance)
        {
            // ARRANGE
            IGraph graph = CreateGraph();

            int[] expectedResult = distance;

            var dijkstra = new Dijkstra(graph, startingPositionIndex);

            // ACT
            var result = dijkstra.GetDistance();

            // ASSERT
            Assert.Equal(result.Count, expectedResult.Length);
            Assert.Collection(result,
                nodeDistance => Assert.Equal(nodeDistance.Distance, expectedResult[0]),
                nodeDistance => Assert.Equal(nodeDistance.Distance, expectedResult[1]),
                nodeDistance => Assert.Equal(nodeDistance.Distance, expectedResult[2]),
                nodeDistance => Assert.Equal(nodeDistance.Distance, expectedResult[3]),
                nodeDistance => Assert.Equal(nodeDistance.Distance, expectedResult[4])
            );
        }

        [Fact]
        public void ShouldGetAllOpponentsDistance()
        {
            // ARRANGE
            IGraph graph = CreateGraph();

            int[] expectedResult = { 3, 1, 4, 7 };

            var dijkstra = new Dijkstra(graph, 0);

            // ACT
            var result = dijkstra.GetOpponentsDistance();

            // ASSERT
            Assert.Equal(result.Count, expectedResult.Length);
            Assert.Collection(result,
                nodeDistance => Assert.Equal(nodeDistance.Distance, expectedResult[0]),
                nodeDistance => Assert.Equal(nodeDistance.Distance, expectedResult[1]),
                nodeDistance => Assert.Equal(nodeDistance.Distance, expectedResult[2]),
                nodeDistance => Assert.Equal(nodeDistance.Distance, expectedResult[3])
            );
        }

        private IGraph CreateGraph()
        {
            return GameMaps.InitialMap();
        }
    }
}