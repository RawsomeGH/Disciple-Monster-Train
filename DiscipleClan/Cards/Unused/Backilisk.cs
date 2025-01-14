using DiscipleClan.Triggers;
using Trainworks.Builders;
using System.Collections.Generic;


namespace DiscipleClan.Cards.Unused
{
    class Backilisk
    {
        public static string IDName = "Backilisk";
        public static string imgName = "AngryGecko";
        public static void Make()
        {

            // Basic Card Stats 
            CardDataBuilder railyard = new CardDataBuilder
            {
                Cost = 1,
                Rarity = CollectableRarity.Uncommon,
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

                Size = 2,
                Health = 20,
                AttackDamage = 12,

                // Relocate
                TriggerBuilders = new List<CharacterTriggerDataBuilder>
                {
                    new CharacterTriggerDataBuilder {
                        Trigger = OnRelocate.OnRelocateCharTrigger.GetEnum(),
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateName = "CardEffectDamage",
                                ParamInt = 12,
                                TargetMode = TargetMode.BackInRoom,
                                TargetTeamType = Team.Type.Heroes,
                            }
                        }
                    },
                }
            };

            Utils.AddUnitImg(characterDataBuilder, imgName + ".png");
            return characterDataBuilder.BuildAndRegister();
        }
    }
}
