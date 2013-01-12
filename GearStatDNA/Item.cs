using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GearStatDNA
{
    public class Item
    {
        public int id { get; set; }
        public int disenchantingSkillRank { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int stackable { get; set; }
        public IEnumerable<BonusStat> bonusStats { get; set; }
        public IEnumerable<ItemSpell> itemSpells { get; set; }
        public int buyPrice { get; set; }
        public int itemClass { get; set; }
        public int containerSlots { get; set; }
        public int inventoryType { get; set; }
        public bool equippable { get; set; }
        public int itemLevel { get; set; }
        public int maxCount { get; set; }
        public int maxDurability { get; set; }
        public int minFactionId { get; set; }
        public int minReputation { get; set; }
        public int quality { get; set; }
        public int sellPrice { get; set; }
        public int requiredSkill { get; set; }
        public int requiredLevel { get; set; }
        public int requiredSkillRank { get; set; }
        public ItemSource itemSource { get; set; }
        public int baseArmor { get; set; }
        public bool hasSockets { get; set; }
        public bool isAuctionable { get; set; }
        public double armor { get; set; }
        public int displayInfoId { get; set; }
        public string nameDescription { get; set; }
        public string nameDescriptionColor { get; set; }

        public class ItemSource
        {
            public int sourceId { get; set; }
            public string sourceType { get; set; }
        }

        public class BonusStat
        {
            public int stat { get; set; }
            public double amount { get; set; }
            public bool reforged { get; set; }
        }

        public class ItemSpell
        {
            public int spellId { get; set; }
            public Spell spell { get; set; }
            public int nCharges { get; set; }
            public bool consumable { get; set; }
            public int categoryId { get; set; }
            public string trigger { get; set; }

            public class Spell
            {
                public int id { get; set; }
                public string name { get; set; }
                public string icon { get; set; }
                public string description { get; set; }
                public string castTime { get; set; }
            }
        }
    }
}
