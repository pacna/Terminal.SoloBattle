using Xunit;
using Terminal.SoloBattle.Maps;
using System;
using System.Collections.Generic;

namespace Terminal.SoloBattle.UnitTests
{
    public class GraphTests
    {
        [Fact]
        public void CanGetAllNodes()
        {
            // ARRANGE
            uint expectedNumberofNodes = 3;
            var graph = new Graph(expectedNumberofNodes);
            graph.AddNode(0, 2, Guid.NewGuid().ToString());
            graph.AddNode(1, 3, Guid.NewGuid().ToString());
            graph.AddNode(2, 4, Guid.NewGuid().ToString());


            // ACT
            var result = graph.NumberOfNodes();

            // ASSERT
            Assert.Equal(result, (int)expectedNumberofNodes);
        }

        [Fact]
        public void CanGetAllLocationNames()
        {
            // ARRANGE
            uint expectedNumberofNodes = 3;
            var actualResult = new List<string>();
            var graph = new Graph(expectedNumberofNodes);
            graph.AddNode(0, 2, "Google");
            graph.AddNode(1, 3, "Facebook");
            graph.AddNode(2, 4, "Yahoo");


            // ACT
            var result = graph.GetAllLocationNames();
            foreach (var r in result)
            {
                actualResult.Add(r);
            }

            // ASSERT
            Assert.Equal(actualResult.Count, (int)expectedNumberofNodes);
            Assert.Collection(actualResult,
                locationName => Assert.Equal(locationName, "Google"),
                locationName => Assert.Equal(locationName, "Facebook"),
                locationName => Assert.Equal(locationName, "Yahoo")
            );
        }

    }
}