using ConsoleRPG.Models.Actors.Character.Stats;
using ConsoleRPG.Models.Items;
using ConsoleRPG.Models.Items.Equipment;
using ConsoleRPG.Models.Items.Equipment.Body;
using ConsoleRPG.Models.Items.Equipment.Charms;
using ConsoleRPG.Models.Items.Equipment.Hands;
using ConsoleRPG.Models.Professions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors.Character
{
    public class Character : Actor
    {
        public Character(string name, Profession prof)
        {
            Name = name;
            Gender = prof.Gender;
            Profession = prof;
            Attributes = new Attributes(this, prof.StartingAttributesDict);
            Talents = new Talents(this, prof.StartingTalentsDict);
            Inventory = new Inventory(prof.StartingInventoryDict);
            Equipment = new Equipment(this.Inventory, prof.StartingEquipmentDict);

            BaseHealth = prof.BaseHealth;
            BaseStamina = prof.BaseStamina;
        }

        #region Flavor Text Info
        public string Name { get; } // TODO add handling for First and Last name
        public Profession Profession { get; }
        #endregion

        #region Inventory
        /// <summary>
        /// The items currently held by the character.
        /// </summary>
        public Inventory Inventory { get; private set; }
        public double WeightCapacity
        {
            get
            {
                double moddedSTR = Attributes.BaseValue["STR"] + EquipmentMod("STR") + EffectMod("STR");
                if (moddedSTR <= 10)
                {
                    // 15 points of Weight Cap for every STR up to 10
                    return moddedSTR * 15;
                }
                else
                {
                    // Diminishing max Weight Capacity returns for STR > 10
                    return (moddedSTR - 10) * 5 + (10 * 15);
                }
                
            }
        }
        public double WeightLoad
        {
            get
            {
                double weight = 0;
                foreach(KeyValuePair<string, Item> item in Inventory.InventoryContents)
                {
                    // weight of all items in inventory
                    weight += Inventory.InventoryContents[item.Key].Weight
                        * Inventory.InventoryCounts[item.Key];
                }
                foreach(var item in Equipment.Slot)
                {
                    // weight of all equipped items
                    weight += Equipment.Slot[item.Key].Weight;
                }
                return weight;
            }
        }
        public bool IsOverburdened
        {
            get
            {
                return WeightLoad > WeightCapacity;
            }
        } // If held weight exceeds the weight capacity.
        #endregion

        #region Equipment
        public Equipment Equipment { get; private set; }
        #endregion

        #region Attributes and Talents
        public Attributes Attributes { get; private set; }
        public Talents Talents { get; private set; }
        #endregion

        #region Health, Stamina, XP
        public double BaseHealth { get; private set; }
        public double BaseStamina { get; private set; }
        public double HP { get; private set; }
        public double SP { get; private set; }
        public double MaxHP
        {
            get
            {
                return BaseHealth + EquipmentMod("healthBonus");
                // TODO add max health modifier from Effects
            }
        }
        public double MaxSP
        {
            get
            {
                return Profession.BaseStamina + EquipmentMod("staminaBonus");
            }
        }
        public double PercentHP
        {
            get
            {
                return Math.Round((HP / MaxHP * 100),2);
            }
        }
        public double PercentSP
        {
            get
            {
                return Math.Round((SP / MaxSP * 100), 2);
            }
        }
        public int XP { get; private set; } = 0;
        public int NextLevelXP { get; private set; } = 100; // TODO build level up module
        #endregion

        #region Stat Modifiers
        /// <summary>
        /// Returns the total equipment modifier for the given stat.
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
        public double EquipmentMod(string stat)
        {
            double mod = 0;
            foreach (KeyValuePair<string, EquipmentItem> item in this.Equipment.Slot)
            {
                foreach (KeyValuePair<string, double> itemStat in item.Value.WeaponStats)
                {
                    if (itemStat.Key == stat)
                    {
                        mod += itemStat.Value;
                    }
                }
                foreach (KeyValuePair<string, double> itemStat in item.Value.ArmorStats)
                {
                    if (itemStat.Key == stat)
                    {
                        mod += itemStat.Value;
                    }
                }
                foreach (KeyValuePair<string, double> itemStat in item.Value.CharmStats)
                {
                    if (itemStat.Key == stat)
                    {
                        mod += itemStat.Value;
                    }
                }
            }
            return mod;
        }
        /// <summary>
        /// Returns the total effect modifier for the given stat.
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
        public double EffectMod(string stat)
        {
            // TODO build Effects and get modified character stats from them
            return 0;
        }
        #endregion

        #region Active Effects
        public ActiveEffects ActiveEffects { get; private set; }
            = new ActiveEffects();
        #endregion

        #region Offense
        public Dictionary<string, double> DmgMultiplier // TODO add Effect mods to offense
        {
            get
            {
                return new Dictionary<string, double>()
                {
                    // + EffectMultiplier("slash")
                    { "slash", EquipmentDmgMultiplier("slash") + DmgScaling["slash"] + Bonus2HScaling }, 
                    { "pierce", EquipmentDmgMultiplier("pierce") + DmgScaling["pierce"] + Bonus2HScaling },
                    { "crush", EquipmentDmgMultiplier("crush") + DmgScaling["crush"] + Bonus2HScaling },

                    { "poison", EquipmentDmgMultiplier("poison") + DmgScaling["poison"] },
                    { "bleed", EquipmentDmgMultiplier("bleed") + DmgScaling["bleed"] },
                    { "fire", EquipmentDmgMultiplier("fire") + DmgScaling["fire"] },
                    { "acid", EquipmentDmgMultiplier("acid") + DmgScaling["acid"] },
                };
            }
        }
        public Dictionary<string, double> DmgScaling
        {
            get
            {
                return new Dictionary<string, double>()
                {
                    // + EffectMultiplier("slash")
                    { "slash", 0.2 * (Attributes.ModdedValue["DEX"] - 5) },
                    { "pierce", 0.2 * (Attributes.ModdedValue["SKL"] - 5)},
                    { "crush", 0.2 * (Attributes.ModdedValue["STR"] - 5)},

                    { "poison", 0.1 * Talents.ModdedValue["Herbalism"] },
                    { "bleed", 0.1 * Talents.ModdedValue["Medicine"] },
                    { "fire", 0.1 * Talents.ModdedValue["Explosives"] },
                    { "acid", 0.1 * Talents.ModdedValue["Engineering"] },
                };
            }
        } // Attack scaling is additive
        public double Bonus2HScaling
        {
            get
            {
                if(this.Equipment.Is2H)
                {
                    return 0.2;
                }
                else
                {
                    return 0.0;
                }
            }
        }
        public double EquipmentDmgMultiplier(string dmgType)
        {
            string dmgMult = dmgType + "Multiplier";
            return EquipmentMod(dmgMult);
        }
        #endregion

        #region Defense
        public Dictionary<string,double> PROTMultiplier // TODO add Effect mods to defense
        {
            get
            {
                return new Dictionary<string, double>()
                {
                    { "slash", EquipmentPROT("slash") * PROTScaling["slash"] }, // + EffectPROT("slash") },
                    { "pierce", EquipmentPROT("pierce") * PROTScaling["pierce"] },
                    { "crush", EquipmentPROT("crush") * PROTScaling["crush"] },

                    { "poison", EquipmentPROT("poison") * PROTScaling["poison"] },
                    { "bleed", EquipmentPROT("bleed") * PROTScaling["bleed"] },
                    { "fire", EquipmentPROT("fire") * PROTScaling["fire"] },
                    { "acid", EquipmentPROT("acid") * PROTScaling["acid"] },
                };
            }
        }
        // Defense scaling is multiplicative with equipment PROT, otherwise becoming invincible would be easy
        public Dictionary<string, double> PROTScaling 
        {
            get
            {
                return new Dictionary<string, double>()
                { // TODO Balance the hell out of these defense stats, they're broke AF
                    // + EffectMultiplier("slash")
                    { "slash", 0.05 * (Attributes.ModdedValue["FOR"] - 5) },
                    { "pierce", 0.05 * (Attributes.ModdedValue["FOR"] - 5)},
                    { "crush", 0.05 * (Attributes.ModdedValue["FOR"] - 5)},

                    { "poison", 0.25 * Talents.BaseValue["Herbalism"] },
                    { "bleed", 0.25 * Talents.BaseValue["Medicine"] },
                    { "fire", 0.25 * Talents.BaseValue["Explosives"] },
                    { "acid", 0.25 * Talents.BaseValue["Engineering"] },
                };
            }
        }
        public double EquipmentPROT(string dmgType)
        {
            string dmgProt = dmgType + "PROT";
            return EquipmentMod(dmgProt);
        }
        #endregion

        #region Combat Functions
        /// <summary>
        /// Reduces damage per armor, adds armor piercing damage, then deals remaining damage to Actor's HP.
        /// </summary>
        /// <param name="dmgType">The damage type.</param>
        /// <param name="dmg">The amount of damage.</param>
        /// <param name="ap">The armor-piercing multiplier of the attack.</param>
        override public void TakeHit(string dmgType, int dmg, double ap)
        {
            double reducedDmg = (1 - EquipmentPROT(dmgType)) * dmg + (EquipmentPROT(dmgType) * dmg * ap);
            TakeHpDmg((int)reducedDmg);
        }
        public override void TakeHpDmg(int dmg)
        {
            HP -= dmg;
            if(HP < 0)
            {
                HP = 0;
            }
        }
        public override void RestoreHp(int hp)
        {
            HP += hp;
            if(HP > MaxHP)
            {
                HP = MaxHP;
            }
        }
        public void ReduceSP(int sp)
        {
            SP -= sp;
            if(SP < 0)
            {
                SP = 0;
            }
        }
        public void RestoreSP(int sp)
        {
            SP += sp;
            if(SP > MaxSP)
            {
                SP = MaxSP;
            }
        }
        #endregion
    }
}
