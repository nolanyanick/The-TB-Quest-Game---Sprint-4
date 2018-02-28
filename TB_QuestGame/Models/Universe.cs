using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// class of the game map
    /// </summary>
    public class Universe
    {
        #region lists to be maintianed by the Universe Class

        //
        // list of all island locations
        //
        private List<IslandLocation> _islandLocations;

        public List<IslandLocation> IslandLocations
        {
            get { return _islandLocations; }
            set { _islandLocations = value; }
        }

        #endregion

        #region methods to initialize all game elements

        /// <summary>
        /// initialize the universe with all of the island locations
        /// </summary>
        private void InitializeUniverse()
        {
            _islandLocations = UniverseObjects.IslandLocations;
        }

        #endregion
    }
}

