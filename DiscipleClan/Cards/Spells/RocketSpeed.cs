using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using MonsterTrainModdingAPI.Builders;
using MonsterTrainModdingAPI.Enums.MTCardPools;
using MonsterTrainModdingAPI.Enums.MTClans;
using MonsterTrainModdingAPI.Enums.MTStatusEffects;
using MonsterTrainModdingAPI.Managers;
using ShinyShoe;

namespace DiscipleClan.Cards.Spells
{
    class RocketSpeed
    {
        public static string IDName = "Rocket Speed";

        public static void Make()
        {
            // Basic Card Stats 
            CardDataBuilder railyard = new CardDataBuilder
            {
                Cost = 1,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,

                EffectBuilders = new List<CardEffectDataBuilder>
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateName = "CardEffectAddStatusEffect",
                        TargetMode = TargetMode.Pyre,
                        TargetTeamType = Team.Type.Heroes | Team.Type.Monsters,
                    },
                },

                TraitBuilders = new List<CardTraitDataBuilder>
                {
                    new CardTraitDataBuilder
                    {
                        TraitStateName = "CardTraitExhaustState"
                    }
                }
            };

            railyard.EffectBuilders[0].AddStatusEffect(typeof(MTStatusEffect_Quick), 1);


            Utils.AddSpell(railyard, IDName);
            Utils.AddImg(railyard, "sigmaligma.png");

            // Do this to complete
            railyard.BuildAndRegister();
        }
    }
}