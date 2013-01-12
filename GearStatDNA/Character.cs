using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GearStatDNA
{
    public class Character
    {
        public string lastModified { get; set; }
        public string name { get; set; }
        public string realm { get; set; }
        public string battlegroup { get; set; }
        public int @class { get; set; }
        public int race { get; set; }
        public int gender { get; set; }
        public int level { get; set; }
        public int achievementPoints { get; set; }
        public string thumbnail { get; set; }
        public char calcClass { get; set; }
        public Guild guild { get; set; }
        public Items items { get; set; }
        public Stats stats { get; set; }
        public Professions professions { get; set; }


        public class Items
        {
            public int averageItemLevel { get; set; }
            public int averageItemLevelEquipped { get; set; }

            public Item head { get; set; }
            public Item neck { get; set; }
            public Item shoulder { get; set; }
            public Item back { get; set; }
            public Item chest { get; set; }
            public Item shirt { get; set; }
            public Item wrist { get; set; }
            public Item hands { get; set; }
            public Item waist { get; set; }
            public Item legs { get; set; }
            public Item feet { get; set; }
            public Item finger1 { get; set; }
            public Item finger2 { get; set; }
            public Item trinket1 { get; set; }
            public Item trinket2 { get; set; }
            public Item mainHand { get; set; }
            public Item offHand { get; set; }

            public class Item
            {
                public int id { get; set; }
                public string name { get; set; }
                public string icon { get; set; }
                public int quality { get; set; }
                public ToolTipParams tooltipParams { get; set; }
                public IEnumerable<Stat> Stats { get; set; }
                public class ToolTipParams
                {
                    public int gem0 { get; set; }
                    public int gem1 { get; set; }
                    public int enchant { get; set; }
                    public IEnumerable<int> set { get; set; }
                    public int reforge { get; set; }
                }

                public class Stat
                {
                    public int stat { get; set; }
                    public double amount { get; set; }
                }
            }

            private Dictionary<string, Item> BasicGear;

            public Dictionary<string, Item> GetBasicDetails()
            {
                if (BasicGear == null)
                {
                    BasicGear = new Dictionary<string, Item>();
                }
                else
                {
                    //Careful - force caching?
                    return BasicGear;
                }

                if (head != null) BasicGear.Add("head", head);
                if (neck != null) BasicGear.Add("neck", neck);
                if (shoulder != null) BasicGear.Add("shoulder", shoulder);
                if (back != null) BasicGear.Add("back", back);
                if (chest != null) BasicGear.Add("chest", chest);
                if (shirt != null) BasicGear.Add("shirt", shirt);
                if (wrist != null) BasicGear.Add("wrist", wrist);
                if (hands != null) BasicGear.Add("hands", hands);
                if (waist != null) BasicGear.Add("waist", waist);
                if (legs != null) BasicGear.Add("legs", legs);
                if (feet != null) BasicGear.Add("feet", feet);
                if (finger1 != null) BasicGear.Add("finger1", finger1);
                if (finger2 != null) BasicGear.Add("finger2", finger2);
                if (trinket1 != null) BasicGear.Add("trinket1", trinket1);
                if (trinket2 != null) BasicGear.Add("trinket2", trinket2);
                if (mainHand != null) BasicGear.Add("mainHand", mainHand);
                if (offHand != null) BasicGear.Add("offHand", offHand);

                return BasicGear;
            }
        }

        public class Guild
        {
            public string Name { get; set; }
            public string Realm { get; set; }
            public string Battlegroup { get; set; }
            public int Level { get; set; }
            public int Members { get; set; }
            public int AchievementPoints { get; set; }
            public Emblem emblem { get; set; }

            public class Emblem
            {
                public int Icon { get; set; }
                public string IconColor { get; set; }
                public int Border { get; set; }
                public string BorderColor { get; set; }
                public string BackgroundColor { get; set; }
            }
        }

        public class Professions
        {
            public IEnumerable<Profession> primary { get; set; }
            public IEnumerable<Profession> secondary { get; set; }

            public class Profession
            {
                public int id { get; set; }
                public string name { get; set; }
                public string icon { get; set; }
                public int rank { get; set; }
                public int max { get; set; }
                public IEnumerable<int> recipes { get; set; }
            }
        }
        public class Stats
        {
            public double health { get; set; }
            public string powerType { get; set; }
            public double power { get; set; }
            public double str { get; set; }
            public double agi { get; set; }
            public double sta { get; set; }
            public double @int { get; set; }
            public double spr { get; set; }
            public double attackPower { get; set; }
            public double rangedAttackPower { get; set; }
            public double mastery { get; set; }
            public double masteryRating { get; set; }
            public double crit { get; set; }
            public double critRating { get; set; }
            public double hitPercent { get; set; }
            public double hitRating { get; set; }
            public double hasteRating { get; set; }
            public double expertiseRating { get; set; }
            public double spellPower { get; set; }
            public double spellPen { get; set; }
            public double spellCrit { get; set; }
            public double spellCritRating { get; set; }
            public double spellHitPercent { get; set; }
            public double spellHitRating { get; set; }
            public double mana5 { get; set; }
            public double mana5combat { get; set; }
            public double armor { get; set; }
            public double dodge { get; set; }
            public double dodgeRating { get; set; }
            public double parry { get; set; }
            public double parryRating { get; set; }
            public double block { get; set; }
            public double blockRating { get; set; }
            public double pvpResilience { get; set; }
            public double pvpResilienceRating { get; set; }
            public double mainHandDmgMin { get; set; }
            public double mainHandDmgMax { get; set; }
            public double mainHandSpeed { get; set; }
            public double mainHandExpertise { get; set; }
            public double offHandDmgMin { get; set; }
            public double offHandDmgMax { get; set; }
            public double offHandSpeed { get; set; }
            public double offHandDps { get; set; }
            public double offHandExpertise { get; set; }
            public double rangedDmgMin { get; set; }
            public double rangedDmgMax { get; set; }
            public double rangedSpeed { get; set; }
            public double rangedDps { get; set; }
            public double rangedExpertise { get; set; }
            public double rangedCrit { get; set; }
            public double rangedCritRating { get; set; }
            public double rangedHitPercent { get; set; }
            public double rangedHitRating { get; set; }
            public double pvpPower { get; set; }
            public double pvpPowerRating { get; set; }
        }


    }
}

