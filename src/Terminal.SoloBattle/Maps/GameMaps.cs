namespace Terminal.SoloBattle.Maps
{
    public static class GameMaps
    {
        public static IGraph InitialMap()
        {
            IGraph initialMap = new Graph(5);

            initialMap.AddNode(index: 0, weight: 0);
            initialMap.AddNode(index: 1, weight: 1);
            initialMap.AddNode(index: 2, weight: 2);
            initialMap.AddNode(index: 3, weight: 3);
            initialMap.AddNode(index: 4, weight: 4);

            initialMap.AddEdge(fromIndex: 0, to: new Node(1), weight: 4);
            initialMap.AddEdge(fromIndex: 0, to: new Node(2), weight: 1);
            initialMap.AddEdge(fromIndex: 1, to: new Node(3), weight: 1);
            initialMap.AddEdge(fromIndex: 2, to: new Node(1), weight: 2);
            initialMap.AddEdge(fromIndex: 2, to: new Node(3), weight: 5);
            initialMap.AddEdge(fromIndex: 3, to: new Node(4), weight: 3);

            return initialMap;
        }
    }
}