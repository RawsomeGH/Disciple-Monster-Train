﻿using DiscipleClan.Cards;
using Trainworks.Builders;
using System.Collections.Generic;
using static Trainworks.Constants.VanillaRelicPoolIDs;

namespace DiscipleClan.Artifacts
{
    class GoldOverTime
    {
        public static string ID = "GoldOverTime";

        public static void Make()
        {
            var relic = new CollectableRelicDataBuilder
            {
                IconPath = "Relic/FortuneCookie.png",
                RelicPoolIDs = new List<string> { MegaRelicPool },
                EffectBuilders = new List<RelicEffectDataBuilder>
                {
                    new RelicEffectDataBuilder
                    {
                         RelicEffectClassName = "RelicEffectAddStatusEffectOnSpawn",
                         ParamStatusEffects = new StatusEffectStackData[] { new StatusEffectStackData { statusId = "loaded", count = 5 } },
                         ParamSourceTeam = Team.Type.Heroes,
                         ParamBool = false,
                         ParamTargetMode = TargetMode.FrontInRoom,
                         ParamCardType = CardType.Monster,
                         ParamCharacterSubtype = "SubtypesData_None",
                    }
                }
            };
            Utils.AddRelic(relic, ID);

            var r = relic.BuildAndRegister();
            r.GetNameEnglish();
        }
    }
}
