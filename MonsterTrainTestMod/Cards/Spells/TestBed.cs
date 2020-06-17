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

namespace MonsterTrainTestMod.Cards.Spells
{
    class TestBed
    {
        private static string IDName = "For Testing";

        public static void Make()
        {
            // Basic Card Stats 
            CardDataBuilder railyard = new CardDataBuilder
            {
                CardID = IDName,
                Name = IDName,
                Cost = 0,
                Description = "",
                Rarity = CollectableRarity.Starter,
                ClanID = MTClanIDs.GetIDForType(typeof(MTClan_Hellhorned)),
                CardPoolIDs = new List<string> { MTCardPoolIDs.GetIDForType(typeof(MTCardPool_MegaPool)) },

                TargetsRoom = true,
                Targetless = false,

                AssetPath = "netstandard2.0/chrono/zyzzy.png",

                EffectBuilders = new List<CardEffectDataBuilder>
                {
                    //new CardEffectDataBuilder
                    //{
                    //    EffectStateName = "CardEffectBump",
                    //    ParamInt = -4,
                    //    TargetMode = TargetMode.DropTargetCharacter,
                    //    TargetTeamType = Team.Type.Monsters,
                    //}
                },

                TraitBuilders = new List<CardTraitDataBuilder>
                {
                    new CardTraitDataBuilder
                    {
                        TraitStateName = "CardTraitSpellAffinity"
                    },
                    new CardTraitDataBuilder
                    {
                        TraitStateName = "CardTraitTreasure"
                    },
                }
            };

            // Do this to complete
            railyard.BuildAndRegister();
        }
    }
}