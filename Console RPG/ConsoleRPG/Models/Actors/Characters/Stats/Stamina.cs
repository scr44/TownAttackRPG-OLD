using ConsoleRPG.Models.Items.Equipment;
using ConsoleRPG.Models.Professions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors.Characters.Stats
{
    public class Stamina : IStatModifiers
    {
        /*
         Stamina or SP (stamina points) measures how much energy your character has available to use skills.
         Stamina will regenerate on its own in combat, but can also be restored by certain skills or items.
        */
        public Stamina()
        {
            // TODO Dexterity: make dex mod affect stamina regen
        }
        public Stamina(Profession prof, Equipment equipment, ActiveEffects activeEffects)
        {
            Prof = prof;
            Equipment = equipment;
            ActiveEffects = activeEffects;
            Base = Prof.BaseStamina;
            BaseRegen = Prof.BaseStaminaRegen;
            Current = Max;
        }

        #region Attached objects
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
            // TODO Effect Mod
            return 0;
        }

        public int Current { get; private set; } = 0;
        public int Max
        {
            get
            {
                return Base
                    + (int)Math.Round(EquipmentMod("addMaxSP", this.Equipment))
                    + (int)Math.Round(EffectMod("addMaxSP"));
            }
        }
        public double Percent
        {
            get
            {
                return Math.Round((((double)Current / Max * 100)));
            }
        }
        public int Base { get; private set; }
        public double BaseRegen { get; private set; }

        public void AdjustSP(double points)
        {
            if (0 < points && points < 1)
            {
                Current += 1; // since SP is an integer, any increase must be at least 1 SP.
            }
            else if (-1 < points && points < 0)
            {
                Current -= 1; // Likewise for losing SP.
            }

            Current += (int)Math.Round(points);

            if (Current > Max)
            {
                Current = Max;
            }
            else if (Current < 0)
            {
                Current = 0; // TODO Stamina: Exhaustion/overcast
            }
        }
        public void AdjustBase(int points)
        {
            // Base stamina can be adjusted in events.
            Base += points;
            if (Base < 0)
            {
                Base = 0; // can't have less than 0 base energy.
            }
        }
        public void AdjustBaseRegen(int points)
        {
            // Base regen can be adjusted in events.
            Base += points;
            if (Base < 1)
            {
                Base = 1; // can't have less than 1 base regen.
            }
        }
        public void RegenTick()
        {
            AdjustSP(
                BaseRegen
                + EquipmentMod("staminaRegen", Equipment)
                + EffectMod("staminaRegen")
                );
        }
    }
}
