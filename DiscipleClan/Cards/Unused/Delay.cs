using Trainworks.Builders;
using System.Collections.Generic;

namespace DiscipleClan.Cards.Unused
{
    class Delay
    {
        public static string IDName = "Delay";

        public static void Make()
        {
            // Basic Card Stats 
            CardDataBuilder railyard = new CardDataBuilder
            {
                Cost = 3,
                Rarity = CollectableRarity.Rare,

                EffectBuilders = new List<CardEffectDataBuilder>
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateName = "CardEffectAddStatusEffect",
                        TargetMode = TargetMode.DropTargetCharacter,
                        TargetTeamType = Team.Type.Heroes | Team.Type.Monsters,
                    },
                },
            };

            railyard.EffectBuilders[0].AddStatusEffect("slow", 1);

            Utils.AddSpell(railyard, IDName);
            Utils.AddImg(railyard, "sigmaligma.png");

            // Do this to complete
            railyard.BuildAndRegister();
        }
    }
}
