using DiscipleClan.CardEffects;
using Trainworks.Builders;
using System.Collections.Generic;

// TODO - Icarian, Pyre attacks whole tower (we can fake it though)

namespace DiscipleClan.Cards.Pyrepact
{
    class Fireshaped
    {
        public static string IDName = "Fireshaped";
        public static string imgName = "Fireshaped";
        public static void Make()
        {

            // Basic Card Stats 
            CardDataBuilder railyard = new CardDataBuilder
            {
                Cost = 0,
                Rarity = CollectableRarity.Uncommon,
            };

            Utils.AddUnit(railyard, IDName, BuildUnit());
            Utils.AddCardPortrait(railyard, "Fireshaped");

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
                SubtypeKeys = new List<string> { "ChronoSubtype_Pythian" },

                Size = 2,
                Health = 20,
                AttackDamage = 0,

                TriggerBuilders = new List<CharacterTriggerDataBuilder>
                {
                    new CharacterTriggerDataBuilder
                    {
                        Trigger = CharacterTriggerData.Trigger.OnSpawn,
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateName = typeof(CardEffectEmpowerStatusOnSpawn).AssemblyQualifiedName,
                                TargetMode = TargetMode.Self,
                                ParamStatusEffects = new StatusEffectStackData[]
                                {
                                    new StatusEffectStackData { statusId="buff", count=3 },
                                    new StatusEffectStackData { statusId="regen", count=2 },
                                }
                            },
                        }
                    },
                }
            };
            Utils.AddUnitAnim(characterDataBuilder, "fireshaped");
            return characterDataBuilder.BuildAndRegister();
        }
    }
}
