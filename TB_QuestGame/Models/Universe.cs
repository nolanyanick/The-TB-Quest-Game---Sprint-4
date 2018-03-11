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

        #endregion

        #region properties of lists

        public List<IslandLocation> IslandLocations
        {
            get { return _islandLocations; }
            set { _islandLocations = value; }
        }

        #endregion

        #region CONSTRUCTORS
        //
        // default Universe constructor
        //
        public Universe()
        {
            //
            // add all of the universe objects to the game
            // 
            InitializeUniverse();
        }
        #endregion

        #region METHODS

        /// <summary>
        /// initialize the universe with all of the island locations
        /// </summary>
        private void InitializeUniverse()
        {
            _islandLocations = UniverseObjects.IslandLocations;
        }

        /// <summary>
        /// determines if the user selected a valid island location ID
        /// </summary>
        public bool IsValidIslandLocationId(int islandLocationId)
        {
            List<int> islandLocationIds = new List<int>();

            //
            // create a list of island ids
            // 
            foreach (IslandLocation island in _islandLocations)
            {
                islandLocationIds.Add(island.IslandLocationID);
            }

            //
            // determine if the island id is valid and return that value
            //
            if (islandLocationIds.Contains(islandLocationId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// gets an island location ID choosen from the user
        /// </summary>
        public IslandLocation GetIslandLocationById(int id)
        {
            IslandLocation islandLocation = null;

            //
            // shift through islandLocation list and select correct one
            //
            foreach (IslandLocation location in _islandLocations)
            {
                if (location.IslandLocationID == id)
                {
                    islandLocation = location;
                }
            }

            //
            // if the ID is not found wihtin the universe,
            // throw an exception
            //
            if (islandLocation == null)
            {
                string feedbackMessage = $"The Island Location ID, {id}, does not exist on the current Map.";
                throw new ArgumentException(id.ToString(), feedbackMessage);
            }

            return islandLocation;
        }

        /// <summary>
        /// determines if the choosen island location is accessible or not
        /// </summary>
        public bool IsAccessibleLocation(int islandLocationId)
        {
            IslandLocation islandLocation = GetIslandLocationById(islandLocationId);

            if (islandLocation.Accessible == true)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        /// <summary>
        /// gets the maximum island location ID
        /// </summary>
        public int GetMaxIslandLocationId()
        {
            int MaxId = 0;

            foreach (IslandLocation islandLocation in IslandLocations)
            {
                if (islandLocation.IslandLocationID > MaxId)
                {
                    MaxId = islandLocation.IslandLocationID;
                }
            }

            return MaxId;
        }
        
        #endregion
    }
}

