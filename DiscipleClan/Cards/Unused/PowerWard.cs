using DiscipleClan.CardEffects;
using Trainworks.Builders;
using System.Collections.Generic;

namespace DiscipleClan.Cards.Unused
{
    class PowerWard
    {
        public static string IDName = "PowerWard";

        public static void Make()
        {
            // Basic Card Stats 
            CardDataBuilder railyard = new CardDataBuilder
            {
                Cost = 1,
                Rarity = CollectableRarity.Common,

                TraitBuilders = new List<CardTraitDataBuilder>
                {
                    new CardTraitDataBuilder
                    {
                        TraitStateName = "CardTraitExhaustState",
                    }
                }
            };

            Utils.AddWard(railyard, IDName, BuildUnit());
            Utils.AddImg(railyard, "Webcam.png");

            // Do this to complete
            railyard.BuildAndRegister();
        }

        // Builds the unit
        public static CharacterDataBuilder BuildUnit()
        {
            // Monster card, so we build an attached unit
            CharacterDataBuilder characterDataBuilder = new CharacterDataBuilder
            {
                CharacterID = IDName,
                NameKey = IDName + "_Name",

                Size = 0,
                Health = 1,
                AttackDamage = 0,
                CanAttack = false,
                PriorityDraw = false,
                RoomModifierBuilders = new List<RoomModifierDataBuilder>
                {
                    new RoomModifierDataBuilder
                    {
                        roomStateModifierClassName = typeof(RoomStateModifierRelocateBuff).AssemblyQualifiedName,
                        ParamInt = 5
                    }
                }
            };

            Utils.AddUnitImg(characterDataBuilder, IDName + ".png");
            characterDataBuilder.SubtypeKeys = new List<string> { "ChronoSubtype_Ward" };
            return characterDataBuilder;
        }
    }
}
