using DiscipleClan.CardEffects;
using Trainworks.Builders;
using System.Collections.Generic;

// TODO - look into CardTraitRetain and CardTraitFreeze, no builder for CardTriggerEffectData

namespace DiscipleClan.Cards.Retain
{
    class DivineroftheInfinite
    {
        public static string IDName = "Diviner of the Infinite";
        public static string imgName = "Clockness";
        public static void Make()
        {

            // Basic Card Stats 
            CardDataBuilder railyard = new CardDataBuilder
            {
                Cost = 5,
                Rarity = CollectableRarity.Uncommon,

                TraitBuilders = new List<CardTraitDataBuilder>
                {
                    new CardTraitDataBuilder
                    {
                        TraitStateName = "CardTraitFreeze"
                    }
                },

                TriggerBuilders = new List<CardTriggerEffectDataBuilder>
                {
                    new CardTriggerEffectDataBuilder
                    {
                        trigger = CardTriggerType.OnUnplayed,
                        CardEffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateName = typeof(CardEffectAddTempUpgrade).AssemblyQualifiedName,
                                ParamCardUpgradeData = new CardUpgradeDataBuilder {
                                    CostReduction = 1,
                                }.Build(),
                                TargetMode = TargetMode.Self,
                            }
                        }
                    }
                }
            };

            Utils.AddUnit(railyard, IDName, BuildUnit());
            Utils.AddCardPortrait(railyard, "Diviner");

            // CardTriggerEffectData needs to add a trigger for OnUnplayed here, that activates the cost and stasis effects


            // Do this to complete
            railyard.BuildAndRegister();
        }

        // Builds the unit
        public static CharacterData BuildUnit()
        {
            // Monster card, so we build an attached unit
            CharacterDataBuilder characterDataBuilder = new CharacterDataBuilder
            {
                CharacterID = IDName,
                NameKey = IDName + "_Name",
                SubtypeKeys = new List<string> { "ChronoSubtype_Eternal" },

                Size = 3,
                Health = 50,
                AttackDamage = 35
            };

            Utils.AddUnitAnim(characterDataBuilder, "diviner");
            return characterDataBuilder.BuildAndRegister();
        }
    }
}
