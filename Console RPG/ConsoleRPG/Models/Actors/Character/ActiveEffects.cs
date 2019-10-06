using ConsoleRPG.Models.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleRPG.Models.Actors.Character
{
    public class ActiveEffects
    {
        public List<Effect> EffectList { get; private set; }
        public Dictionary<string,int> EffectInstanceCount
        {
            get
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();
                foreach(Effect effect in EffectList)
                {
                    if( !(dict.TryAdd(effect.EffectName,1)))
                    {
                        dict[effect.EffectName]++;
                    }
                }
                return dict;
            }
        }
        public Dictionary<string, int> EffectDurations
        {
            get
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();
                foreach (Effect effect in EffectList)
                {
                    if (!(dict.TryAdd(effect.EffectName, effect.Duration)))
                    {
                        dict[effect.EffectName]+= effect.Duration;
                    }
                }
                return dict;
            }
        }


        public void AddEffect(Effect newEffect) // TODO Effects: finish add effect duration refreshing
        {
            if(newEffect.EffectTags.Contains("Unique") // Duration stacks or refreshes rather than new instance
                && EffectInstanceCount.ContainsKey(newEffect.EffectName))
            {
                if(newEffect.EffectTags.Contains("Stacking Duration"))
                {
                    // Add duration to existing instance
                }
                else
                {
                    // Refresh duration to new instance's starting duration
                }
            }
            else // Effect starts
            {
                EffectList.Add(newEffect);
                if (newEffect.EffectTags.Contains("Trigger on Start"))
                {
                    newEffect.TriggerEffect();
                }
            }
        }
        public void RemoveEffect(int i)
        {
            if(EffectList[i].EffectTags.Contains("Trigger on Expiry"))
            {
                EffectList[i].Duration = 0;
                EffectList[i].TriggerEffect();
            }
            EffectList.RemoveAt(i);
        }
        public void RemoveKeywordEffects(int numToRemove, string keyword)
        {
            for(int i = EffectList.Count - 1; i >= 0; i--)
            {
                if(numToRemove == 0)
                {
                    break;
                }

                if(EffectList[i].EffectTags.Contains(keyword))
                {
                    RemoveEffect(i);
                }

                numToRemove--;
            }
        }

        public void TriggerAllEffects()
        {
            foreach(Effect effect in EffectList)
            {
                effect.TriggerEffect();
            }
        }
        public void TickAllEffects()
        {
            foreach(Effect effect in EffectList)
            {
                effect.TickEffect();
            }
        }
    }
}
