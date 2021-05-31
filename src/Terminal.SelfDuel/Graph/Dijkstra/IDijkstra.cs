using System.Collections.Generic;
using Terminal.SelfDuel.Models;

namespace Terminal.SelfDuel
{
    public interface IDijkstra
    {
        IList<NodeDistance> GetDistance();
    }

}