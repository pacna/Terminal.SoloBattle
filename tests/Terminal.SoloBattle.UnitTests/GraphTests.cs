using Xunit;
using Terminal.SoloBattle.Maps;

namespace Terminal.SoloBattle.UnitTests;

public class GraphTests
{
    [Fact]
    public void CanGetAllNodes()
    {
        // ARRANGE
        uint expectedNumberofNodes = 3;
        IGraph graph = new Graph(expectedNumberofNodes);
        graph.AddNode(0, 2, Guid.NewGuid().ToString());
        graph.AddNode(1, 3, Guid.NewGuid().ToString());
        graph.AddNode(2, 4, Guid.NewGuid().ToString());


        // ACT
        int result = graph.NumberOfNodes();

        // ASSERT
        Assert.Equal(result, (int)expectedNumberofNodes);
    }

    [Fact]
    public void CanGetAllLocationNames()
    {
        // ARRANGE
        uint expectedNumberofNodes = 3;
        List<string> actualResult = new();
        IGraph graph = new Graph(expectedNumberofNodes);
        graph.AddNode(0, 2, "Google");
        graph.AddNode(1, 3, "Facebook");
        graph.AddNode(2, 4, "Yahoo");


        // ACT
        IEnumerable<string> result = graph.GetAllLocationNames();
        foreach (string r in result)
        {
            actualResult.Add(r);
        }

        // ASSERT
        Assert.Equal(actualResult.Count, (int)expectedNumberofNodes);
        Assert.Collection(actualResult,
            locationName => Assert.Equal("Google", locationName),
            locationName => Assert.Equal("Facebook", locationName),
            locationName => Assert.Equal("Yahoo", locationName)
        );
    }

}