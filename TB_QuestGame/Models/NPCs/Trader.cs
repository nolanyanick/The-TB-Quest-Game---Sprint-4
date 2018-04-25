using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Trader : Npc, ITrade
    {
        public override int Id { get; set; }
        public override string Description { get; set; }    
        public List<GameObject> Inventory { get; set; }
        public override int ExperiencePoints { get; set; }
        public override int HealthPoints { get; set; }

        /// <summary>
        /// determines which NPC is trading then determines whoch objects are to be traded
        /// and removes traded objects from game
        /// </summary>
        public void Trade(int objectIdInNpcInventory, int objectIdInPlayerInventory, Player prisoner)
        {
            if (this.Name == "Silas")
            {
                GameObject objectInPlayersInventory = null;
                GameObject objectInNpcInventory = null;

                //
                // get the correct object for NPC
                //
                foreach (var gameObject in this.Inventory)
                {
                    if (gameObject.Id == objectIdInNpcInventory)
                    {
                        objectInNpcInventory = gameObject;
                    }
                }

                //
                // get the correct object for Player
                //
                foreach (var gameObject in prisoner.TreasureInventory)
                {
                    if (gameObject.Id == objectIdInPlayerInventory)
                    {
                        objectInPlayersInventory = gameObject;
                    }
                }

                if (objectInNpcInventory.Id == 14)
                {
                    if (prisoner.TreasureInventory.Contains(objectInPlayersInventory))
                    {
                        prisoner.TreasureInventory.Add((Treasure)objectInNpcInventory);
                        prisoner.TreasureInventory.Remove((Treasure)objectInPlayersInventory);
                        this.Inventory.Remove(objectInNpcInventory);
                        this.InventoryIds.Remove(objectInNpcInventory.Id);

                        // remove object from game
                        objectInPlayersInventory.IslandLocationId = -1;
                    }
                }

                if (objectInNpcInventory.Id == 15 && prisoner.TreasureInventory.Contains(objectInPlayersInventory))
                {
                    prisoner.TreasureInventory.Add((Treasure)objectInNpcInventory);
                    prisoner.TreasureInventory.Remove((Treasure)objectInPlayersInventory);
                    this.Inventory.Remove(objectInNpcInventory);
                    this.InventoryIds.Remove(objectInNpcInventory.Id);

                    objectInPlayersInventory.IslandLocationId = -1;
                }
            }
        }

        public List<string> Messages { get; set; }

        public List<int> InventoryIds { get; set; }



    }
}
