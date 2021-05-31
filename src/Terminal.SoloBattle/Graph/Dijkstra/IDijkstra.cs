using System.Collections.Generic;
using Terminal.SoloBattle.Models;

namespace Terminal.SoloBattle
{
    public interface IDijkstra
    {
        IList<NodeDistance> GetDistance();
    }

}