using System.Collections.Generic;

namespace Terminal.SoloBattle.Maps
{
    public interface IGraph
    {
        void AddNode(int index, int weight, string locationName);
        void AddEdge(int fromIndex, Node to, int weight);
        Node[] GetAllNodes();
        IEnumerable<string> GetAllLocationNames();
        Node GetNodeByIndex(int index);
        Node GetNodeByWeight(int weight);
        int NumberOfNodes();
        void PrintGraph();
    }
}