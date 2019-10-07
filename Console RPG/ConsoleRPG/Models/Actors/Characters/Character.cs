using ConsoleRPG.Models.Actors.Characters.Stats;
using ConsoleRPG.Models.Combat;
using ConsoleRPG.Models.Items;
using ConsoleRPG.Models.Items.Equipment;
using ConsoleRPG.Models.Items.Equipment.Body;
using ConsoleRPG.Models.Items.Equipment.Charms;
using ConsoleRPG.Models.Items.Equipment.Hands;
using ConsoleRPG.Models.Professions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors.Characters
{
    public class Character : Actor, IStatModifiers, IAttack, IDefense
    {
        public Character(string name, Profession prof)
        {
            Name = name;
            Gender = prof.Gender;
            Profession = prof;
            Attributes = new Attributes(this, prof.StartingAttributesDict);
            Talents = new Talents(this, prof.StartingTalentsDict);
            Inventory = new Inventory(this, prof.StartingInventoryDict);
            Equipment = new Equipment(this, prof.StartingEquipmentDict);

            HP = new Health(Profession, Equipment, ActiveEffects);
            SP = new Stamina(Profession, Equipment, ActiveEffects);
            HP.AdjustHP(9999); // Start off at full health.
            SP.AdjustSP(999); // Start off at full stamina.
            XP = new Experience(this, 1);
        }

        #region Tags
        public string Name { get; } // TODO Tags: add handling for First and Last name
        public Profession Profession { get; }
        public List<string> CharacterTags { get; private set; } =
            new List<string>();
        #endregion

        #region Inventory
        /// <summary>
        /// The items currently held by the character.
        /// </summary>
        public Inventory Inventory { get; private set; }
        #endregion

        #region Equipment
        public Equipment Equipment { get; private set; }
        #endregion

        #region Attributes and Talents
        public Attributes Attributes { get; private set; }
        public Talents Talents { get; private set; }
        #endregion

        #region Health, Stamina, XP
        public bool IsAlive
        {
            get
            {
                return HP.Current > 0;
            }
        }
        public Health HP { get; private set; }
        public Stamina SP { get; private set; }
        public Experience XP { get; private set; }
        #endregion

        #region Stat Modifiers
        public double EquipmentMod(string stat, Equipment equipment)
        {
            double mod = 0;
            foreach (KeyValuePair<string, EquipmentItem> item in equipment.Slot)
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
        public double EffectMod(string stat, ActiveEffects activeEffects)
        {
            // TODO Effect Mod
            return 0;
        }
        #endregion

        #region Active Effects
        public ActiveEffects ActiveEffects { get; private set; }
            = new ActiveEffects();
        #endregion

        #region Offense
        public double EquipmentDmgMultiplier(string dmgType)
        {
            string dmgMult = dmgType + "Multiplier";
            return EquipmentMod(dmgMult,this.Equipment);
        }
        public double EffectDmgMultiplier(string dmgType)
        {
            string dmgMult = dmgType + "Multiplier";
            return EffectMod(dmgMult, this.ActiveEffects);
        }
        public Dictionary<string, double> DmgScaling
        {
            get
            {
                return new Dictionary<string, double>()
                {
                    // + EffectMultiplier("slash")
                    { "slash", 0.2 * (Attributes.ModdedValue["DEX"] - 5) },
                    { "pierce", 0.2 * (Attributes.ModdedValue["SKL"] - 5) },
                    { "crush", 0.2 * (Attributes.ModdedValue["STR"] - 5) },

                    { "poison", 0.1 * Talents.ModdedValue["Bestiary"] },
                    { "bleed", 0.1 * Talents.ModdedValue["Medicine"] },
                    { "fire", 0.1 * Talents.ModdedValue["Explosives"] },
                    { "acid", 0.1 * Talents.ModdedValue["Engineering"] },
                };
            }
        } // Attack scaling is additive
        public double Bonus2HScaling(string dmgType, bool is2H)
        {
            if (is2H && (
                   dmgType == "slash"
                || dmgType == "pierce"
                || dmgType == "crush"
                ))
            {
                return 0.2;
            }
            else
            {
                return 0.0;
            }
        }
        public double DmgMULT(string dmgType)
        {
            return EquipmentDmgMultiplier(dmgType)
                + EffectDmgMultiplier(dmgType)
                + DmgScaling[dmgType] 
                + Bonus2HScaling(dmgType, this.Equipment.Is2H);
        }
        #endregion

        #region Defense
        public double EquipmentPROT(string dmgType)
        {
            string dmgProt = dmgType + "PROT";
            return EquipmentMod(dmgProt,this.Equipment);
        }
        public double EffectPROT(string dmgType)
        {
            string dmgPROT = dmgType + "PROT";
            return EffectMod(dmgPROT, this.ActiveEffects);
        }
        public Dictionary<string, double> PROTScaling
        {
            get
            {
                return new Dictionary<string, double>()
                { // TODO Balance: balance sorely needed for defense
                    // Also the math needs adjusted, right now you can have negative PROT
                    { "slash", 0.05 * (Attributes.ModdedValue["FOR"] - 5) },
                    { "pierce", 0.05 * (Attributes.ModdedValue["FOR"] - 5)},
                    { "crush", 0.05 * (Attributes.ModdedValue["FOR"] - 5)},

                    { "poison", 0.25 * Talents.BaseValue["Bestiary"] },
                    { "bleed", 0.25 * Talents.BaseValue["Medicine"] },
                    { "fire", 0.25 * Talents.BaseValue["Explosives"] },
                    { "acid", 0.25 * Talents.BaseValue["Engineering"] },
                };
            }
        }
        public double PROT(string dmgType)
        {
            // Defense scaling is multiplicative with equipment PROT, 
            // otherwise becoming invincible would be too easy.
            return EquipmentPROT(dmgType)
                * EffectPROT(dmgType)
                * PROTScaling[dmgType];
        }
        public bool TryBlock(EquipmentItem equipment)
        {
            return true;
        }
        #endregion

        #region Combat Functions

        #endregion
    }
}
