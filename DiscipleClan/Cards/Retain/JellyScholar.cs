using Trainworks.Builders;
using System.Collections.Generic;


namespace DiscipleClan.Cards.Retain
{
    class JellyScholar
    {
        public static string IDName = "Jelly Scholar";
        public static string imgName = "JellyFish";
        public static void Make()
        {
            // Basic Card Stats 
            CardDataBuilder railyard = new CardDataBuilder
            {
                Cost = 2,
                Rarity = CollectableRarity.Uncommon,
            };

            Utils.AddUnit(railyard, IDName, BuildUnit());
            Utils.AddCardPortrait(railyard, "JellyScholar");

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

                Size = 1,
                Health = 4,
                AttackDamage = 10,

                TriggerBuilders = new List<CharacterTriggerDataBuilder>
                {
                    new CharacterTriggerDataBuilder
                    {
                        Trigger = CharacterTriggerData.Trigger.PostCombat,
                        AdditionalTextOnTrigger = "The Jelly Grows",
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateName = "CardEffectAddTempCardUpgradeToUnits",
                                TargetMode = TargetMode.Self,
                                ParamCardUpgradeData = new CardUpgradeDataBuilder
                                {
                                    BonusHP = 12,
                                    BonusSize = 1,
                                    HideUpgradeIconOnCard = true,
                                }.Build(),
                            },
                        }
                    }
                }
            };

            Utils.AddUnitAnim(characterDataBuilder, "jellyscholar");
            return characterDataBuilder.BuildAndRegister();
        }
    }
}
