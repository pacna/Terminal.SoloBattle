namespace Terminal.SoloBattle
{
    public interface IGraph
    {
        void AddNode(int index, int weight);
        void AddEdge(int fromIndex, Node to, int weight);
        Node[] GetAllNodes();
        Node GetNodeByIndex(int index);
        Node GetNodeByWeight(int weight);
        int NumberOfNodes();
        void PrintGraph();
    }
}