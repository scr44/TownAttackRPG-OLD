using ConsoleRPG.Models.Actors.Characters;
using ConsoleRPG.Models.Effects;
using ConsoleRPG.Models.Effects.StatusConditions;
using ConsoleRPG.Models.Professions.DefaultProfessions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Effects
{
    [TestClass]
    public class EffectTests
    {
        [TestMethod]
        public void NewEffect()
        {
            // create a new character
            Character Guinevere = new Character("Guinevere", new Knight("F"));

            // new Knight has no starting poison PROT
            Assert.AreEqual(0, Guinevere.PROT("poison"));

            // poison the knight (they really don't pay her enough for this)
            Guinevere.ActiveEffects.AddEffect(new Poisoned(5, 5, Guinevere));
            bool isPoisoned = false;
            foreach (Effect effect in Guinevere.ActiveEffects.EffectList)
            {
                if (effect is Poisoned)
                {
                    isPoisoned = true;
                    break;
                }
            }
            Assert.IsTrue(isPoisoned);
        }

        [TestMethod]
        public void PoisonEffect()
        {
            // create a new character
            Character Guinevere = new Character("Guinevere", new Knight("F"));

            // poison the knight
            Guinevere.ActiveEffects.AddEffect(new Poisoned(5, 5, Guinevere));
            
            Assert.AreEqual(5, Guinevere.ActiveEffects.EffectDurations["Poisoned"]);

            // knight should have taken no damage yet
            Assert.AreEqual(Guinevere.HP.Max, Guinevere.HP.Current);

            // tick the damage effect of the poison
            Guinevere.ActiveEffects.TickAllEffects();

            // knight should take 5 damage
            Assert.AreEqual(Guinevere.HP.Max - 5, Guinevere.HP.Current);

            // poison duration should have dropped to 4 turns/ticks
            Assert.AreEqual(4, Guinevere.ActiveEffects.EffectDurations["Poisoned"]);
        }
        
        [TestMethod]
        public void EffectExpiration()
        {
            // create a new character
            Character Guinevere = new Character("Guinevere", new Knight("F"));

            // poison the knight
            Guinevere.ActiveEffects.AddEffect(new Poisoned(1, 5, Guinevere));

            // tick effect to get duration to 0
            Guinevere.ActiveEffects.TickAllEffects();

            // poison should have expired
            Assert.AreEqual(0, Guinevere.ActiveEffects.EffectList.Count);
        }
    }
}
