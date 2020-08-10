using DiscipleClan.CardEffects;
using MonsterTrainModdingAPI.Builders;
using System.Collections.Generic;

namespace DiscipleClan.Cards.Pyrepact
{
    class EmberwaveDelta
    {
        public static string IDName = "EmberwaveDelta";

        public static void Make()
        {
            // Basic Card Stats 
            CardDataBuilder railyard = new CardDataBuilder
            {
                Cost = 0,
                Rarity = CollectableRarity.Common,
                TargetsRoom = true,

                EffectBuilders = new List<CardEffectDataBuilder>
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateName = typeof(CardEffectEmberwaveFibonacci).AssemblyQualifiedName,
                        ParamInt = 0,
                        TargetMode = TargetMode.DropTargetCharacter,
                        TargetTeamType = Team.Type.Heroes | Team.Type.Monsters,
                    },
                },
            };

            Utils.AddSpell(railyard, IDName);
            Utils.AddImg(railyard, "Emberwave.png");

            // Do this to complete
            railyard.BuildAndRegister();
        }
    }
}