namespace Terminal.SelfDuel
{
    public class Graph
    {
        public Graph(uint numberOfNodes)
        {
            Nodes = new Node[numberOfNodes];
        }

        public Node[] Nodes { get; set; }
    }
}