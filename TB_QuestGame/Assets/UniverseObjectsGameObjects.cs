using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to hold all objects in the game universe; locations, game objects, npc's, etc.
    /// </summary>
    public static partial class UniverseObjects
    {
        /// <summary>
        /// list of all game objects
        /// </summary>
        public static List<GameObject> gameObjects = new List<GameObject>()
        {
            #region ***SHIPS***

            //new Ship
            //{
            //    Id = 20,
            //    Name = "British Man-O-War",
            //    IslandLocationId = 4,
            //    Description = "Devastating warship, feared by many.",
            //    Type = Ship.ShipType.BritishManOWar,
            //    Value = 15000,
            //    CanInventory = false,
            //    IsConsumable = false,
            //    IsVisible = true
            //},

            new Ship
            {
                Id = 21,
                Name = "Frigate",
                IslandLocationId = 1,
                Description = "Standard ship.",
                Type = Ship.ShipType.Frigate,
                Value = 8000,
                CanInventory = false,
                IsConsumable = false,
                IsVisible = true
            },

            //new Ship
            //{
            //    Id = 22,
            //    Name = "Galleon",
            //    IslandLocationId = 1,
            //    Description = "Standard ship.",
            //    Type = Ship.ShipType.Galleon,
            //    Value = 8000,
            //    CanInventory = false,
            //    IsConsumable = false,
            //    IsVisible = true
            //},

            //new Ship
            //{
            //    Id = 23,
            //    Name = "Merchant Ship",
            //    IslandLocationId = 3,
            //    Description = "Merchant ship.",
            //    Type = Ship.ShipType.Merchant,
            //    Value = 5000,
            //    CanInventory = false,
            //    IsConsumable = false,
            //    IsVisible = true
            //},

            new Ship
            {
                Id = 24,
                Name = "Sloop",
                IslandLocationId = 2,
                Description = "Standard ship.",
                Type = Ship.ShipType.Sloop,
                Value = 1000,
                CanInventory = false,
                IsConsumable = false,
                IsVisible = true
            },

            //new Ship
            //{
            //    Id = 25,
            //    Name = "Spanish Galleon",
            //    IslandLocationId = 4,
            //    Description = "Luxorious warship, lots of cargo space.",
            //    Type = Ship.ShipType.SpanishGalleon,
            //    Value = 12000,
            //    CanInventory = false,
            //    IsConsumable = false,
            //    IsVisible = true
            //},

            #endregion

            #region ***TREASURES***

            new Treasure()
            {
                Id = 10,
                Name = "Gold Coin",
                Type = GameObject.ObjectType.Treasure,
                IslandLocationId = 0,
                Description = "Gold coin, used as common currency.",
                Quantity = 100,
                Value = 100,
                Rarity = Treasure.RarityLevel.Common,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new Treasure()
            {
                Id = 11,
                Name = "Ruby",
                Type = GameObject.ObjectType.Treasure,
                IslandLocationId = 2,
                Description = "Flawless ruby.",
                Quantity = 1,
                Value = 400,
                Rarity = Treasure.RarityLevel.Rare,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new Treasure()
            {
                Id = 12,
                Name = "Sapphire",
                Type = GameObject.ObjectType.Treasure,
                IslandLocationId = 3,
                Description = "Flawless sapphire.",
                Quantity = 1,
                Value = 300,
                Rarity = Treasure.RarityLevel.Unique,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new Treasure()
            {
                Id = 13,
                Name = "Emerald",
                Type = GameObject.ObjectType.Treasure,
                IslandLocationId = 1,
                Description = "Flawless emerald shines bright green in the light.",
                Quantity = 1,
                Value = 200,
                Rarity = Treasure.RarityLevel.Unique,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new Treasure()
            {
                Id = 14,
                Name = "Diamond",
                Type = GameObject.ObjectType.Treasure,
                IslandLocationId = 4,
                Description = "Flawless diamond.",
                Quantity = 1,
                Value = 500,
                Rarity = Treasure.RarityLevel.Rare,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new Treasure()
            {
                Id = 15,
                Name = "Royal Necklace",
                Type = GameObject.ObjectType.Treasure,
                IslandLocationId = 2,
                Description = "Ornate necklace won by royalty.",
                Quantity = 1,
                Value = 75,
                Rarity = Treasure.RarityLevel.Unique,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new Treasure()
            {
                Id = 16,
                Name = "Jewel Studded Rings",
                Type = GameObject.ObjectType.Treasure,
                IslandLocationId = 3,
                Description = "Gold rings decorated with numerous gems.",
                Quantity = 1,
                Value = 100,
                Rarity = Treasure.RarityLevel.Unique,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            #endregion

            #region ***FOOD***

            new Food
            {
                Id = 1,
                Name = "Fish",
                Type = GameObject.ObjectType.Food,
                IslandLocationId = 1,
                Description = "Tasty fish, packed with nutrients.",
                Value = 5,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new Food
            {
                Id = 2,
                Name = "Crackers",
                Type = GameObject.ObjectType.Food,
                IslandLocationId = 2,
                Description = "Yummy crackers. Extra salty.",
                Value = 1,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new Food
            {
                Id = 3,
                Name = "Moldy Bread",
                Type = GameObject.ObjectType.Food,
                IslandLocationId = 7,
                Description = "Bread covered in repulsive mold.",
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new Food
            {
                Id = 4,
                Name = "Rum",
                Type = GameObject.ObjectType.Food,
                IslandLocationId = 1,
                Description = "Rum, every pirates favorite beverage.",
                Value = 25,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            //new Food
            //{
            //    Id = 5,
            //    Name = "Crab Legs",
            //    Type = GameObject.ObjectType.Food,
            //    IslandLocationId = 3,
            //    Description = "Juicy crab legs that taste better than they look.",
            //    Value = 30,
            //    CanInventory = true,               
            //    IsConsumable = true,
            //    IsVisible = true
            //},

            new Food
            {
                Id = 6,
                Name = "Red Wine",
                Type = GameObject.ObjectType.Food,
                IslandLocationId = 3,
                Description = "Delicous red wine.",
                Value = 35,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            //new Food
            //{
            //    Id = 7,
            //    Name = "Bread",
            //    Type = GameObject.ObjectType.Food,
            //    IslandLocationId = 1,
            //    Description = "Standard bread, looks safe to eat.",
            //    Value = 2,
            //    CanInventory = true,
            //    IsConsumable = true,
            //    IsVisible = true
            //},

            #endregion

            #region ***WEAPONS***
            
            new Weapon
            {
                Id = 30,
                Name = "Cutlass",
                Type = GameObject.ObjectType.Weapon,
                IslandLocationId = 1,
                Description = "Standard sword prefered by many who sail the seas.",
                Value = 100,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            //new Weapon
            //{
            //    Id = 31,
            //    Name = "Flintlock Pistol",
            //    Type = GameObject.ObjectType.Weapon,
            //    IslandLocationId = 3,
            //    Description = "A pistol that is in pretty bad shape.",
            //    Value = 250,
            //    CanInventory = true,
            //    IsConsumable = false,
            //    IsVisible = true
            //},

            new Weapon
            {
                Id = 32,
                Name = "Musket",
                Type = GameObject.ObjectType.Weapon,
                IslandLocationId = 4,
                Description = "A nice looking muskiet, capable dealing lots of damage.",
                Value = 500,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new Weapon
            {
                Id = 33,
                Name = "Hand Cannon",
                Type = GameObject.ObjectType.Weapon,
                IslandLocationId = 7,
                Description = "A mysterious looking gun.",
                Value = 1000,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },


	        #endregion           
        };
    }
}
