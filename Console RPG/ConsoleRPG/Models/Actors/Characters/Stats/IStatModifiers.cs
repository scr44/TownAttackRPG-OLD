using ConsoleRPG.Models.Items.Equipment;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors.Characters.Stats
{
    interface IStatModifiers
    {
        ///// <summary>
        ///// Returns the total equipment modifier for the given stat.
        ///// </summary>
        ///// <param name="stat"></param>
        ///// <returns></returns>
        double EquipmentMod(string stat, Equipment equipment);
        //{
        //    double mod = 0;
        //    foreach (KeyValuePair<string, EquipmentItem> item in equipment.Slot)
        //    {
        //        foreach (KeyValuePair<string, double> itemStat in item.Value.WeaponStats)
        //        {
        //            if (itemStat.Key == stat)
        //            {
        //                mod += itemStat.Value;
        //            }
        //        }
        //        foreach (KeyValuePair<string, double> itemStat in item.Value.ArmorStats)
        //        {
        //            if (itemStat.Key == stat)
        //            {
        //                mod += itemStat.Value;
        //            }
        //        }
        //        foreach (KeyValuePair<string, double> itemStat in item.Value.CharmStats)
        //        {
        //            if (itemStat.Key == stat)
        //            {
        //                mod += itemStat.Value;
        //            }
        //        }
        //    }
        //    return mod;
        //}
        double EffectMod(string stat, ActiveEffects activeEffects);
    }
}
