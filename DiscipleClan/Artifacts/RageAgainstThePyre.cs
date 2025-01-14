﻿using DiscipleClan.Cards;
using HarmonyLib;
using Trainworks.Builders;
using Trainworks.Managers;
using System.Collections.Generic;
using static CharacterState;
using static Trainworks.Constants.VanillaRelicPoolIDs;

namespace DiscipleClan.Artifacts
{
    class RageAgainstThePyre
    {
        public static string ID = "RageAgainstThePyre";

        public static void Make()
        {
            var relic = new CollectableRelicDataBuilder
            {
                IconPath = "Relic/FourtuneTellerB.png",
                RelicPoolIDs = new List<string> { MegaRelicPool },
                EffectBuilders = new List<RelicEffectDataBuilder>
                {
                    new RelicEffectDataBuilder
                    {
                        RelicEffectClassName = "RelicEffectAddStatusEffectOnSpawn",
                        ParamStatusEffects = new StatusEffectStackData[] { new StatusEffectStackData { statusId = "buff", count = 4 } },
                        ParamSourceTeam = Team.Type.Heroes,
                        ParamBool = false,
                        ParamTargetMode = TargetMode.FrontInRoom,
                        ParamCardType = CardType.Monster,
                        ParamCharacterSubtype = "SubtypesData_None",
                    },
                },
            };
            Utils.AddRelic(relic, ID);

            var r = relic.BuildAndRegister();
            r.GetNameEnglish();
        }
    }

    [HarmonyPatch(typeof(CharacterState), "ApplyDamage")]
    class PyreHeartRageImmune
    {
        static void Prefix(CharacterState __instance, ref int damage, ApplyDamageParams damageParams)
        {
            SaveManager saveManager;
            ProviderManager.TryGetProvider<SaveManager>(out saveManager);

            if (damageParams.attacker != null)
                if (__instance.IsPyreHeart())
                    if (damageParams.attacker.GetStatusEffectStacks("buff") > 0)
                        if (saveManager.GetRelicCount("RageAgainstThePyre") > 0)
                            damage = 0;
        }
    }
}
