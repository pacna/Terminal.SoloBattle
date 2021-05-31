using System.Collections.Generic;

namespace Terminal.SoloBattle.Maps
{
    public class Node
    {
        public Node(int weight, string locationName)
        {
            this.Weight = weight;
            this.LocationName = locationName;
            this.Edges = new List<Edge>();
        }

        public int Weight { get; set; }
        public string LocationName { get; set; }
        public IList<Edge> Edges { get; set; }
    }
}
