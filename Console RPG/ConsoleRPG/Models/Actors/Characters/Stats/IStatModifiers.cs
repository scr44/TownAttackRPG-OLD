using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors.Characters.Stats
{
    interface IStatModifiers
    {
        double EquipmentMod(string stat, Equipment equipment);
        double EffectMod(string stat);
    }
}
