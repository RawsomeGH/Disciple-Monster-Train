using DiscipleClan.CardEffects;
using Trainworks.Builders;
using System.Collections.Generic;

// TODO - OnUnplayed doesn't seem to trigger on Permafrosted cards.

namespace DiscipleClan.Cards.Unused
{
    class FriggaOwl
    {
        public static string IDName = "Frigga Owl";
        public static string imgName = "Cowl";
        public static void Make()
        {
            // Basic Card Stats 
            CardDataBuilder railyard = new CardDataBuilder
            {
                Cost = 1,
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
                                    BonusDamage = 5,
                                    BonusHP = 5,
                                }.Build(),
                                TargetMode = TargetMode.Self
                            },
                        }
                    }
                }
            };

            Utils.AddUnit(railyard, IDName, BuildUnit());
            Utils.AddImg(railyard, imgName + ".png");

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

                Size = 1,
                Health = 5,
                AttackDamage = 5,

            };

            Utils.AddUnitImg(characterDataBuilder, imgName + ".png");
            return characterDataBuilder.BuildAndRegister();
        }
    }
}
