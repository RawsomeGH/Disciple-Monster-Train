using DiscipleClan.CardEffects;
using MonsterTrainModdingAPI.Builders;
using System.Collections.Generic;
using static MonsterTrainModdingAPI.Constants.VanillaStatusEffectIDs;

namespace DiscipleClan.Cards.Shifter
{
    class PowerWardBeta
    {
        public static string IDName = "PowerWardBeta";

        public static void Make()
        {
            // Basic Card Stats 
            CardDataBuilder railyard = new CardDataBuilder
            {
                Cost = 1,
                Rarity = CollectableRarity.Common,

                EffectBuilders = new List<CardEffectDataBuilder>
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectAddWard),
                        ParamStr = "WardStatePower",
                        TargetMode = TargetMode.Room,
                        TargetTeamType = Team.Type.Monsters,
                        ParamInt = 5,
                    }
                },
                
                TraitBuilders = new List<CardTraitDataBuilder>
                {
                    new CardTraitDataBuilder
                    {
                        TraitStateName = "CardTraitExhaustState",
                    },
                }
            };

            Utils.AddSpell(railyard, IDName);
            Utils.AddImg(railyard, "Webcam.png");

            // Do this to complete
            railyard.BuildAndRegister();
        }
    }
}