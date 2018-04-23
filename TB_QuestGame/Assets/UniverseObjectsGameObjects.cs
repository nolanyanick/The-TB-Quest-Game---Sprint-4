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
        public static List<GameObject> GameObjects = new List<GameObject>()
        {         
            #region ***TREASURES***

            new Treasure()
            {
                Id = 10,
                Name = "Gold Coin",
                Type = GameObject.ObjectType.Treasure,
                IslandLocationId = 0,
                Description = "Gold coin, used as common currency.",             
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
                Value = 300,
                Rarity = Treasure.RarityLevel.Rare,
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
                Value = 200,
                Rarity = Treasure.RarityLevel.Rare,
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
                Value = 500,
                Rarity = Treasure.RarityLevel.Legendary,
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
                HealthPoints = 25,
                IsSpoiled = false,
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
                HealthPoints = 10,
                IsSpoiled = false,
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
                HealthPoints = -10,
                IsSpoiled = false,
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
                HealthPoints = 35,
                IsSpoiled = false,
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
                HealthPoints = 35,
                IsSpoiled = false,
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
                Damage = 10,
                Name = "Dagger",
                Type = GameObject.ObjectType.Weapon,
                IslandLocationId = 1,
                Description = "A rusty old dagger.",
                Value = 100,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new Weapon
            {
                Id = 35,
                Damage = 20,
                Name = "Broad Sword",
                Type = GameObject.ObjectType.Weapon,
                IslandLocationId = 1,
                Description = "Standard sword prefered by many on the battlefield.",
                Value = 100,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new Weapon
            {
                Id = 31,
                Damage = 100,
                Name = "Warhammer",
                Type = GameObject.ObjectType.Weapon,
                IslandLocationId = 3,
                Description = "A giant hammer capable of delivering devastating blows.",
                Value = 250,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new Weapon
            {
                Id = 32,
                Damage = 20,
                Name = "Bow and Arrow",
                Type = GameObject.ObjectType.Weapon,
                IslandLocationId = 4,
                Description = "A bow made of oak, equipped with steel tipped arrows.",
                Value = 500,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new Weapon
            {
                Id = 33,
                Damage = 30,
                Name = "Battle Axe",
                Type = GameObject.ObjectType.Weapon,
                IslandLocationId = 7,
                Description = "A razor sharp axe designed for deadly conflicts.",
                Value = 1000,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },


	        #endregion           
        };
    }
}
