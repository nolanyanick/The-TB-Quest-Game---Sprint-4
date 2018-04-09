using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public abstract class GameObject
    {
        public enum ObjectType
        {
            Food,
            Ship,
            Treasure,
            Weapon
        }

        public  int Id { get; set; }
        public  string Name { get; set; }
        public  string Description { get; set; }
        public  int IslandLocationId { get; set; }        
        public bool CanInventory { get; set; }
        public bool IsConsumable { get; set; }
        public bool IsVisible { get; set; }
        public int Value { get; set; }
        public bool HasBeenPickedUp { get; set; }
        public ObjectType Type { get; set; }


    }
}
