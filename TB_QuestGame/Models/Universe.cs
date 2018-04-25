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
        
        private List<IslandLocation> _islandLocations;
        private List<GameObject> _gameObjects;
        private List<Npc> _npcs;

        #endregion

        #region properties of lists

        public List<IslandLocation> IslandLocations
        {
            get { return _islandLocations; }
            set { _islandLocations = value; }
        }

        public List<GameObject> GameObjects
        {
            get { return _gameObjects; }
            set { _gameObjects = value; }
        }

        public List<Npc> Npcs
        {
            get { return _npcs; }
            set { _npcs = value; }
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
            _gameObjects = UniverseObjects.GameObjects;
            _npcs = UniverseObjects.Npcs;
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
        /// determines if the object in question is valid
        /// </summary>        
        public bool IsValidGameObjectByLocaitonId(int gameObjectId, int currentIslandLocation)
        {
            List<int> gameObjectIds = new List<int>();

            //
            // creates a list of game object ids in current location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.IslandLocationId == currentIslandLocation)
                {
                    gameObjectIds.Add(gameObject.Id);
                }
            }

            //
            // determines if the game object id is valid and returns the result
            //
            if (gameObjectIds.Contains(gameObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// determines if the selected object is in the NPC's inventory
        /// </summary>
        public bool IsValidObjectByNpcInventoryId(int gameObjectId, ITrade trader)
        {        
            //
            // determines if the game object id is valid and returns the result
            //
            if ( trader.InventoryIds.Contains(gameObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }







        /// <summary>
        /// determines if npc in question is valid
        /// </summary>
        public bool IsValidNpcByLocationId(int npcId, int currentSpacetiemLocation)
        {
            List<int> npcIds = new List<int>();

            //
            // create a list of npcs in the current location
            //
            foreach (var npc in _npcs)
            {
                if (npc.IslandLocationId == currentSpacetiemLocation)
                {
                    npcIds.Add(npc.Id);
                }
            }

            //
            // determine if the game object id is a valid id and return the reslult
            //
            if (npcIds.Contains(npcId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// gets an NPC via their Id
        /// </summary>
        public Npc GetNpcById(int Id)
        {
            Npc npcToReturn = null;

            //
            // run through the NPC object list and grab the correct one
            //
            foreach (var npc in _npcs)
            {
                if (npc.Id == Id)
                {
                    npcToReturn = npc;
                }
            }

            //
            // the specified Id was notfound in the universe
            // thow an exception
            //
            if (npcToReturn == null)
            {
                string feedbackMessage = $"The NPC ID {Id} does not exsist in the current universe.";
                throw new ArgumentException(feedbackMessage, Id.ToString());
            }

            return npcToReturn;
        }

        /// <summary>
        /// gets a list of NPCs in the current location
        /// </summary>
        public List<Npc> GetNpcsByIslandLocation(int isandLocationId)
        {
            List<Npc> npcs = new List<Npc>();

            //
            // run through the NPC object list and grab all that are in the current location
            //
            foreach (var npc in _npcs)
            {
                if (npc.IslandLocationId == isandLocationId)
                {
                    npcs.Add(npc);
                }
            }

            return npcs;
        }











        public List<Trader> GetTraderNpcsByIslandLocation(int isandLocationId)
        {
            List<Trader> npcs = new List<Trader>();

            //
            // run through the NPC object list and grab all Traders that are in the current location
            //
            foreach (Npc npc in _npcs)
            {
                if (npc.IslandLocationId == isandLocationId && npc is Trader)
                {
                    npcs.Add((Trader)npc);
                }
            }

            return npcs;
        }

















        /// <summary>
        /// gets an object via its id
        /// </summary>
        public GameObject GetObjectById(int id)
        {
            GameObject gameObjectToReturn = null;

            //
            // run through the game object list and grab the correct one
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.Id == id)
                {
                    gameObjectToReturn = gameObject;
                }
            }

            //
            // if the specified id was not found in the universe
            // throw an exception
            //
            if (gameObjectToReturn == null)
            {
                string feedbackMessage = $"The Game Object ID, {id}, does not exsist in the ucrrent universe.";
                throw new ArgumentException(feedbackMessage, id.ToString());
            }

            return gameObjectToReturn;
        }

        /// <summary>
        /// gets all game objects in the current location
        /// </summary>
        public List<GameObject> GetGameObjectsByIslandLocaitonId(int islandLocationId)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            //
            // shift throught the game object list
            // and grab all that are in the current island location
            //
            foreach (GameObject gameObject in _gameObjects)            
            {
                if (gameObject.IslandLocationId == islandLocationId)
                {
                    gameObjects.Add(gameObject);
                }
            }

            return gameObjects;
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

