using System.Collections.Generic;

namespace Terminal.SelfDuel
{
    public class Node
    {
        public Node(int weight)
        {
            this.Weight = weight;
            this.Edges = new List<Edge>();
        }

        public int Weight { get; set; }
        public IList<Edge> Edges { get; set; }
    }
}
