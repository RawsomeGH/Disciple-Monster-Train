using Trainworks.Builders;
using System.Collections.Generic;
using DiscipleClan.CardEffects;

namespace DiscipleClan.Cards.Retain
{
    class Rewind
    {
        public static string IDName = "Rewind";

        public static void Make()
        {
            // Basic Card Stats 
            CardDataBuilder railyard = new CardDataBuilder
            {
                CostType = CardData.CostType.ConsumeRemainingEnergy,
                Rarity = CollectableRarity.Uncommon,
                Targetless = true,

                TraitBuilders = new List<CardTraitDataBuilder>
                {
                    new CardTraitDataBuilder
                    {
                         TraitStateName = typeof(CardTraitScalingReturnConsumedCardsFixed).AssemblyQualifiedName,
                         ParamTrackedValue = CardStatistics.TrackedValueType.PlayedCost,
                         ParamEntryDuration = CardStatistics.EntryDuration.ThisBattle,
                         ParamUseScalingParams = true,
                         ParamInt = 1,
                    },
                    new CardTraitDataBuilder
                    {
                         TraitStateName = "CardTraitExhaustState",
                    },
                }
            };

            Utils.AddSpell(railyard, IDName);
            Utils.AddCardPortrait(railyard, "Rewind");

            // Do this to complete
            railyard.BuildAndRegister();
        }
    }
}
