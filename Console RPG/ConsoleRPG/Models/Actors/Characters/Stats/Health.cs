using ConsoleRPG.Models.Items.Equipment;
using ConsoleRPG.Models.Professions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors.Characters.Stats
{
    public class Health : IStatModifiers
    {
        /*
         Health or HP (health points) measures how close a character is to death. Character HP is determined
         by their profession, while Enemy and NPC HP is set at Actor intialization. Most armor increases 
         max health, and many skill effects can temporarily grant extra max HP or restore lost HP.
        */
        public Health(Profession prof, Equipment equipment, ActiveEffects activeEffects)
        {
            Prof = prof;
            Equipment = equipment;
            ActiveEffects = activeEffects;
            Base = Prof.BaseHealth;
            Current = Max;
            BaseRegen = 0; // Actors don't start with any implicit base health regen
        }

        #region Linked objects for stat modifier calculation
        private Profession Prof { get; }
        private Equipment Equipment { get; }
        private ActiveEffects ActiveEffects { get; }
        #endregion
        public double EquipmentMod(string stat, Equipment equipment)
        {
            if (equipment is null)
            {
                return 0;
            }

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
        public double EffectMod(string stat)
        {
            // TODO Effect: HP Mod
            return 0;
        }

        public int Current { get; private set; }
        public int Max
        {
            get
            {
                return Base
                    + (int)Math.Round(EquipmentMod("healthBonus", this.Equipment))
                    + (int)Math.Round(EffectMod("healthBonus"));
            }
        }
        public double Percent => Math.Round((((double)Current / Max * 100)));
        public int Base { get; private set; }
        public double BaseRegen { get; private set; }
        
        public void AdjustHP(double points)
        {
            if(0 < points && points < 1)
            {
                Current += 1; // since HP is an integer, any increase must be at least 1 HP.
            }
            else if (-1 < points && points < 0)
            {
                Current -= 1; // Likewise for losing HP.
            }

            Current += (int)Math.Round(points);

            if (Current > Max)
            {
                Current = Max; // Cannot have more HP than max. Max itself can be adjusted by buffs, however.
            }
            else if(Current < 0)
            {
                Current = 0; // Die if you hit 0 HP.
                // TODO HP: Dies() method needed
            }
        }
        public void AdjustBase(int points)
        {
            // Base health can be adjusted in events.
            Base += points;
            if(Base <= 0)
            {
                Base = 1; // ensures that you'll never die simply from taking your armor off
            }
        }
        public void AdjustBaseRegen(int points)
        {
            // Base regen can be adjusted in events.
            BaseRegen += points;
            if (BaseRegen < 0)
            {
                BaseRegen = 0; // can't have base negative regen, though effects can cause negatives.
            }
        }
        public void RegenTick()
        {
            AdjustHP(
                BaseRegen
                + EquipmentMod("healthRegen", Equipment)
                + EffectMod("healthRegen")
                - EffectMod("healthDegen")
                );
        }
    }
}
