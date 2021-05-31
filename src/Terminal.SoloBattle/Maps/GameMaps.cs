namespace Terminal.SoloBattle.Maps
{
    public static class GameMaps
    {
        public static IGraph InitialMap()
        {
            IGraph initialMap = new Graph(numberOfNodes: 5);

            initialMap.AddNode(index: 0, weight: 0, locationName: "Metal City");
            initialMap.AddNode(index: 1, weight: 1, locationName: "Sky Road");
            initialMap.AddNode(index: 2, weight: 2, locationName: "Splash Canyon");
            initialMap.AddNode(index: 3, weight: 3, locationName: "Ice Factory");
            initialMap.AddNode(index: 4, weight: 4, locationName: "Babylon Garden");

            initialMap.AddEdge(fromIndex: 0, to: new Node(weight: 1, locationName: "Sky Road"), weight: 4);
            initialMap.AddEdge(fromIndex: 0, to: new Node(weight: 2, locationName: "Splash Canyon"), weight: 1);
            initialMap.AddEdge(fromIndex: 1, to: new Node(weight: 3, locationName: "Ice Factory"), weight: 1);
            initialMap.AddEdge(fromIndex: 2, to: new Node(weight: 1, locationName: "Sky Road"), weight: 2);
            initialMap.AddEdge(fromIndex: 2, to: new Node(weight: 3, locationName: "Ice Factory"), weight: 5);
            initialMap.AddEdge(fromIndex: 3, to: new Node(weight: 4, locationName: "Babylon Garden"), weight: 3);

            return initialMap;
        }
    }
}