﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Weapon : GameObject
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int IslandLocationId { get; set; }
        public override bool CanInventory { get; set; }
        public override bool IsConsumable { get; set; }
        public override bool IsVisible { get; set; }
        public override int Value { get; set; }
        public override bool HasBeenPickedUp { get; set; }
        public override ObjectType Type { get; set; }
        public override bool Consumed { get; set; }
        public int Damage { get; set; }
    }
}
