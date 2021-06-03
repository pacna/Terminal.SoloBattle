using System.Collections.Generic;
using Terminal.SoloBattle.Maps.Models;

namespace Terminal.SoloBattle.Maps
{
    public interface IDijkstra
    {
        IList<NodeDistance> GetDistance();

        #region Solo Battle
        IList<NodeDistance> GetMonstersDistance();
        #endregion
    }

}