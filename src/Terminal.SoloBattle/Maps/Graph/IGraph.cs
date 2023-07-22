namespace Terminal.SoloBattle.Maps;

public interface IGraph
{
    void AddNode(int index, int weight, string locationName);
    void AddEdge(int fromIndex, Node to, int weight);
    Node[] GetAllNodes();
    Node GetNodeByIndex(int index);
    Node GetNodeByWeight(int weight);
    int NumberOfNodes();

    #region  Solo Battle
    IEnumerable<string> GetAllLocationNames();
    (Node, int) GetNodeByLocationId(int locationId);
    #endregion

    #region DEBUG
    void PrintGraph();
    #endregion
}