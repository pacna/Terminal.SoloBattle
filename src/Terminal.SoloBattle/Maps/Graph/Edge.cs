namespace Terminal.SoloBattle.Maps
{
    public class Edge
    {
        public Edge(Node to, int weight)
        {
            this.To = to;
            this.Weight = weight;
        }

        public Node To { get; set; }
        public int Weight { get; set; }

    }

}